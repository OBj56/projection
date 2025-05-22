using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using projection;



namespace projection
{
    public partial class Form1 : Form
    {

        Vector3[] rawCloud = PointCloud.GenerateRandomCube(); 
        Vector3[] alignedCloud;



        public Form1()
        {
            InitializeComponent();
        }

        private void trackBarY_Scroll(object sender, EventArgs e)
        {
            drawPanel.Invalidate();
        }

        private void trackBarX_Scroll(object sender, EventArgs e)
        {
            drawPanel.Invalidate();
        }

        private void trackBarZ_Scroll(object sender, EventArgs e)
        {
            drawPanel.Invalidate();
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TranslateTransform(drawPanel.Width / 2, drawPanel.Height / 2);
            g.Clear(Color.White);


            if (alignedCloud != null)
            {
                foreach (var v in alignedCloud)
                {
                    var p = mathy.PerspectiveProject(v * 100); // scale to view
                    g.FillEllipse(Brushes.Black, p.X - 1, p.Y - 1, 3, 3);
                }
            }

            float ax = trackBarX.Value;
            float ay = trackBarY.Value;
            float az = trackBarZ.Value;

            PointF[] points = new PointF[CubeModel.Vertices.Length];

            for (int i = 0; i < CubeModel.Vertices.Length; i++)
            {
                var v = CubeModel.Vertices[i];
                v = mathy.RotateX(v, ax);
                v = mathy.RotateY(v, ay);
                v = mathy.RotateZ(v, az);
                points[i] = mathy.PerspectiveProject(v);
            }

            foreach (var edge in CubeModel.Edges)
            {
                var p1 = points[edge[0]];
                var p2 = points[edge[1]];
                g.DrawLine(Pens.Black, p1, p2);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            drawPanel.Paint += new PaintEventHandler(drawPanel_Paint);
            trackBarX.Scroll += new EventHandler(trackBarX_Scroll);
            trackBarY.Scroll += new EventHandler(trackBarY_Scroll);
            trackBarZ.Scroll += new EventHandler(trackBarZ_Scroll);


            var cov = PCAHelper.ComputeCovarianceMatrix(rawCloud);
            var eigen = PCAHelper.GetEigenvectors(cov);
            alignedCloud = PCAHelper.TransformPoints(rawCloud, eigen);
        }

       
    }
}
