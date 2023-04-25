using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projectPaint
{
    public partial class frmPaint : Form
    {
        public Point x = new Point();
        public Point y = new Point();
        public Pen penA = new Pen(Color.Red, 2);
        public Pen Eraser = new Pen(Color.White, 10);
        public Graphics graphics;
        public Graphics graphicsPanelB;

        frmResult result;

        public frmPaint()
        {
            InitializeComponent();
            result = new frmResult();
            result.Show();
            graphicsPanelB = result.graphics;
            graphics = panelDraw.CreateGraphics();
            panelDraw.MouseDown += panelDraw_MouseDown;
            panelDraw.MouseMove += panelDraw_MouseMove;
            panelDraw.MouseUp += panelDraw_MouseUp;

            (panelDraw as Control).KeyDown += panelDraw_KeyDown;
        }

        bool drawing = false; // Drawing Var

        Point xGlobal = new Point();
        Point yGlobal = new Point();

        int sizeDiff = 50; //Var pixels to difference square to line  

        //
        Point[] vertexs = new Point[0]; // Vertexs of active paint
        Point lastPoint; // last point active paint

        private void panelDraw_KeyDown(object sender, KeyEventArgs e) // Add vertex on Key Down
        {
            if (e.KeyCode == Keys.Space) // Using 'SPACE' key to Define create new vertex
            {
                addVertex(lastPoint); // Add new Vertex
            }   
        }

        private void addVertex(Point p) // Add point to list vertexs
        {
            Point[] p2 = new Point[vertexs.Length + 1];
            for (int i = 0; i < vertexs.Length; i++)
            {
                p2[i] = vertexs[i];
            }
            p2[vertexs.Length] = p;
            vertexs = p2;
        }

        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            xGlobal = e.Location; // X Point for draw in the MouseLeave
            addVertex(xGlobal); // Add Last Point

            int XDiff = (yGlobal.X - xGlobal.X); // Difference start point and end point int width
            int YDiff = (yGlobal.Y - xGlobal.Y); // Difference start point and end point int height

            // Convert difference to positive integer
            if (XDiff < 0)
            {
                XDiff = XDiff * -1;
            }
            if (YDiff < 0)
            {
                YDiff = YDiff * -1;
            }

            bool isLine = true; // isLine Var - Define by distance start point-end point
            bool isCircle = false; //isCircle Var - Define by number of vertex = 2 (start and end)
            bool isTriangle = false;//isTriangle Var - Define by number of vertex = 4 (start and end + 2 vertexs)
            bool isSquare = false; //isSquare Var - Define by number of vertex = 5 (start and end + 3 vertexs)
            bool isPolygon = false; ////isCircle Var - Define by number of vertex > 5 (start and end + vertexs)

            // Verify start point and end point 
            if (XDiff < sizeDiff)
            {
                if (YDiff < sizeDiff)
                {
                    isLine = false; // defines whether it is a line or not based on the start and end point
                }
            }

            if (isLine == false)
            {
                if (vertexs.Length == 2) // Define Circle
                {
                    isCircle = true; // Define Circle
                }
                if (vertexs.Length == 4) // Define Triangle
                {
                    isTriangle = true; // Define Triangle
                }
                if (vertexs.Length == 5) // Define Square
                {
                    isSquare = true; // Define Square
                }
                if (vertexs.Length > 5) // Define Polygon
                { 
                    isPolygon = true; // Define Polygon
                }
                vertexs[vertexs.Length - 1] = vertexs[0]; // if is not line set te last vertex = first vertex;
            }

            

            if (drawing == true)
            {
                if (isLine)
                {
                    //Draw Line in Panel B
                    graphicsPanelB.DrawLine(penA, xGlobal, yGlobal); //Graphics panel B
                    
                }
                else
                {
                    if (isCircle)
                    {
                        //Draw Circle in Panel B
                        graphicsPanelB.DrawEllipse(penA, new Rectangle(upPoint, new Size(downPoint.X - upPoint.X, downPoint.Y - upPoint.Y))); //Graphics panel B
                    }
                    if (isTriangle)
                    {
                        //Draw Triangle in Panel B
                        graphicsPanelB.DrawPolygon(penA, vertexs); //Graphics panel B
                    }
                    if (isSquare)
                    {
                        //Draw Square in Panel B
                        graphicsPanelB.DrawRectangle(penA, new Rectangle(upPoint, new Size(downPoint.X - upPoint.X, downPoint.Y - upPoint.Y))); //Graphics panel B
                    }
                    if (isPolygon)
                    {
                        //Draw Polygon in Panel B
                        graphicsPanelB.DrawPolygon(penA, vertexs); //Graphics panel B
                    }
                    
                }


                drawing = false;
            }

            vertexs = new Point[0]; //Clear Vertexs

        }

        Point upPoint = new Point(); //Point A for Square
        Point downPoint = new Point(); //Point B for Square


        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            panelDraw.Focus(); //Define focus to panelDraw
            if (e.Button == MouseButtons.Left)
            {
                drawing = true; //On drawing var to MouseLeave event
            }
            y = e.Location;
            yGlobal = y; // Y Point for draw in the MouseLeave
            upPoint = y; //Reference point for Square
            downPoint = y; //Reference point for Square
            addVertex(y); // Add first point

            if (rbLineWidth5.Checked)
                penA.Width = 5;
            if (rbLineWidth10.Checked)
                penA.Width = 10;
            if (rbLineWidth15.Checked)
                penA.Width = 15;
        }

        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.Location;
                lastPoint = x; // Actualize the last point
                graphics.DrawLine(penA, x, y);
                y = e.Location;

                //Verify to decrease upPoint
                if (x.X < upPoint.X)
                {
                    upPoint.X = x.X;
                }
                if (x.Y < upPoint.Y)
                {
                    upPoint.Y = x.Y;
                }

                //Verify to increment downPoint
                if (x.X > downPoint.X)
                {
                    downPoint.X = x.X;
                }
                if (x.Y > downPoint.Y)
                {
                    downPoint.Y = x.Y;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                x = e.Location;
                graphics.DrawLine(Eraser, x, y);
                y = e.Location;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                penA.Color = colorDialog.Color;
        }
    }
}
