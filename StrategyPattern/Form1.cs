using StrategyPattern.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrategyPattern
{
    public partial class Form1 : Form
    {
        public ITool CurrentTool { get; private set; }
        public Bitmap Canvas { get; private set; }

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.CurrentTool = new PaintBrush();
            this.Canvas = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.CurrentTool.HandleMouseMove(e.Location, this.Canvas);
            this.Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.CurrentTool.HandleMouseDown(e.Location, this.Canvas);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.CurrentTool.HandleMouseUp(e.Location, this.Canvas);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(this.Canvas, Point.Empty);

            this.CurrentTool.RenderPreview(e.Graphics);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case '1':
                    this.CurrentTool = new PaintBrush();
                    break;
                case '2':
                    this.CurrentTool = new RectangleTool();
                    break;
            }
        }
    }
}
