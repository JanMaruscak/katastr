using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Katastr
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            measure_cBox.Items.Clear();
            measure_cBox.Items.Add("m");
            measure_cBox.Items.Add("km");
            measure_cBox.SelectedIndex = 0;
            measure_cBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public float Ratio = 1000;
        public string FilePath = "";
        public bool IsMeasuring = false;
        public float WholeArea = 0f;
        public List<List<Point>> OldPoints = new List<List<Point>>();

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void loadImg_btn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\Users\\marus\\Downloads";
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    FilePath = filePath;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        image_pBox.Image = Image.FromFile(filePath);
                        WholeArea = GaussArea(new List<Point>()
                        {
                            new Point(0,0),
                            new Point(image_pBox.Width,0),
                            new Point(image_pBox.Width,image_pBox.Height),
                            new Point(0, image_pBox.Height)
                        },Ratio);
                        wholeArea_label.Text = Convert.ToString(WholeArea);
                    }
                }
            }
        }

        private void image_pBox_Click(object sender, EventArgs e)
        {
        }

        List<Point> Points = new List<Point>();
        private Point HalfBetweenPoints(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X)/2, (p1.Y + p2.Y) / 2);
        }

        private void image_pBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Point mouseLoc = image_pBox.PointToClient(Cursor.Position);
            foreach (var list in OldPoints)
            {
                if (list.Count > 1)
                {
                    g.DrawPolygon(Pens.Red, list.ToArray());
                    for (int i = 0; i < list.Count; i++)
                    {
                        Point p = list[i];
                        g.DrawString($"X: {p.X}; Y: {p.Y}", DefaultFont, Brushes.Black, p);

                        if (i % 2 == 1)
                        {
                            var half = HalfBetweenPoints(p, list[i - 1]);
                            g.DrawString($"{PointLen(p, list[i - 1]) * Ratio}m", DefaultFont, Brushes.Black, half);
                        }
                    }

                }
                else if (list.Count == 1)
                {
                    g.FillEllipse(Brushes.Red, list[0].X - 2, list[0].Y - 2, 5, 5);
                    foreach (var p in list)
                    {
                        g.DrawString($"X: {p.X}; Y: {p.Y}", DefaultFont, Brushes.Black, p);
                    }
                }
            }
            if (Points.Count > 1)
            {
                g.DrawPolygon(Pens.Black, Points.ToArray());
                for (int i = 0; i < Points.Count; i++)
                {
                    Point p = Points[i];
                    g.DrawString($"X: {p.X}; Y: {p.Y}", DefaultFont, Brushes.Black, p);
                    g.FillEllipse(Brushes.Red, p.X - 2, p.Y - 2, 5, 5);

                    if (i % 2 == 1)
                    {
                        var half = HalfBetweenPoints(p, Points[i - 1]);
                        g.DrawString($"{PointLen(p,Points[i-1])*Ratio}m", DefaultFont, Brushes.Black, half);
                    }
                }

            }
            else if(Points.Count == 1)
            {
                g.FillEllipse(Brushes.Red, Points[0].X, Points[0].Y,5,5);
                foreach (var p in Points)
                {
                    g.DrawString($"X: {p.X}; Y: {p.Y}", DefaultFont, Brushes.Black, p);
                }
            }


            g.FillEllipse(Brushes.Red, mouseLoc.X - 2, mouseLoc.Y - 2, 5, 5);
            g.DrawString($"X: {mouseLoc.X}; Y: {mouseLoc.Y}", DefaultFont, Brushes.Black, mouseLoc);
        }




        private void Retext()
        {
            if (Points.Count == 0) return;
            textBox1.Text = GaussArea(new List<Point>(Points), Ratio).ToString();
            textBox2.Text = Circumference(new List<Point>(Points), Ratio).ToString();
        }
        int MeasureCounter = 0;
        private void image_pBox_MouseDown(object sender, MouseEventArgs e)
        {
            FindNearestPoint(e.Location);
        }
        private float GaussArea(List<Point> points, float ratio)
        {
            points.Add(points[0]);
            float area = MathF.Abs(points.Take(points.Count - 1)
            .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
            .Sum() / 2);
            return area * ratio;
        }
        private float Circumference(List<Point> points, float ratio)
        {
            points.Add(points[0]);
            float result = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                var xLen = points[i + 1].X - points[i].X;
                var yLen = points[i + 1].Y - points[i].Y;
                result += MathF.Sqrt(MathF.Pow(xLen,2) + MathF.Pow(yLen,2));
            }
            return result * ratio;

        }
        bool ColorsAreClose(Color a, Color z, int threshold = 50)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }
        private Point SnapIntoPlace(Point loc)
        {
            Bitmap bmp = (Bitmap)image_pBox.Image;
            if(WholeArea == 0) return loc;
            for (int x = -5; x < 5; x++)
            {
                for (int y = -5; y < 5; y++)
                {
                    var newLoc = new Point(loc.X + x, loc.Y + y);
                    var color = bmp.GetPixel(newLoc.X, newLoc.Y); 
                    if (newLoc.X > 0 && newLoc.Y > 0 && ColorsAreClose(color,Color.Black))
                    {
                        return new Point(loc.X + x, loc.Y + y);
                    }
                }
            }
            return loc;
        }

        private void measure_cBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public float PointLen(Point p1, Point p2)
        {
            var xLen = p2.X - p1.X;
            var yLen = p2.Y - p1.Y;
            return MathF.Sqrt(MathF.Pow(xLen, 2) + MathF.Pow(yLen, 2));
        }

        private void meritko_btn_Click(object sender, EventArgs e)
        {

            if(float.TryParse(meritko_txt.Text, out float value))
            {
                if(value > 0)
                {
                    MeasureCounter = 0;
                    Ratio = value / PointLen(Points[0], Points[1]);
                    Points.Clear();
                    IsMeasuring = false;
                    ratio_label.Text = $"1px = {Ratio}m";
                    Retext();
                }

            }

        }

        // TODO polygon export
        private void export_btn_Click(object sender, EventArgs e)
        {
            string output = "";
            foreach (var item in Points)
            {
                output += $"{item.X},{item.Y};";
            }
            Clipboard.SetText(output);
        }
        

        private void measureMeritko_btn_Click(object sender, EventArgs e)
        {
            Points.Clear();
            IsMeasuring = true;
            image_pBox.Invalidate();
        }


        private void image_pBox_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            image_pBox.Invalidate();
        }
        private bool FindNearestPoint(Point mouse)
        {
            Point change = new Point();
            foreach (var item in Points)
            {
                if(PointLen(mouse, item) < 20)
                {
                    change = item;
                    break;
                }
            }
            if (change == new Point()) return false;
            Points.Remove(change);
            return true;
        }

        private void image_pBox_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.X < 0 || e.Y < 0) return;
            if (e.X > image_pBox.Width || e.Y > image_pBox.Width) return;

            if (IsMeasuring && MeasureCounter == 2) return;
            else if (IsMeasuring) MeasureCounter++;


            var snappedLoc = SnapIntoPlace(e.Location);
            Points.Add(snappedLoc);
            Retext();
            image_pBox.Invalidate();
        }

        private void import_btn_Click(object sender, EventArgs e)
        {
        }

        private void newPolygon_btn_Click(object sender, EventArgs e)
        {
            OldPoints.Add(new List<Point>(Points));
            Points.Clear();
        }
    }
}
