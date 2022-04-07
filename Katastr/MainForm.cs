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
        public int Ratio = 1000;
        public string FilePath = "";
        public bool IsMeasuring = false;
        public float WholeArea = 0f;

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

        private void image_pBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (Points.Count > 1)
            {
                g.DrawPolygon(Pens.Black, Points.ToArray());
                foreach (var p in Points)
                {
                    g.DrawString($"X: {p.X}; Y: {p.Y}", DefaultFont, Brushes.Black, p);
                }
            }
            else if(Points.Count == 1)
            {
                g.FillEllipse(Brushes.Black, Points[0].X, Points[0].Y,2,2);
                foreach (var p in Points)
                {
                    g.DrawString($"X: {p.X}; Y: {p.Y}", DefaultFont, Brushes.Black, p);
                }
            }

            var mouseLoc = image_pBox.PointToClient(Cursor.Position);
            g.FillEllipse(Brushes.Black, mouseLoc.X, mouseLoc.Y, 2, 2);
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
            if (IsMeasuring && MeasureCounter == 2) return;
            else if (IsMeasuring) MeasureCounter++;

            Points.Add(e.Location);
            Retext();
            image_pBox.Invalidate();
        }
        private float GaussArea(List<Point> points, int ratio)
        {
            points.Add(points[0]);
            float area = MathF.Abs(points.Take(points.Count - 1)
            .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
            .Sum() / 2);
            return area / ratio;
        }
        private float Circumference(List<Point> points, int ratio)
        {
            points.Add(points[0]);
            float result = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                var xLen = points[i + 1].X - points[i].X;
                var yLen = points[i + 1].Y - points[i].Y;
                result += MathF.Sqrt(MathF.Pow(xLen,2) + MathF.Pow(yLen,2));
            }
            return result / ratio;

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

            if(int.TryParse(meritko_txt.Text, out int value))
            {
                if(value > 0)
                {
                    Ratio = value;
                    MeasureCounter = 0;
                    float pxToM = Ratio / PointLen(Points[0], Points[1]);
                    Points.Clear();
                    IsMeasuring = false;
                    ratio_label.Text = $"1px = {pxToM}m";
                    Retext();
                }

            }

        }

        // TODO polygon export
        private void export_btn_Click(object sender, EventArgs e)
        {

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
    }
}
