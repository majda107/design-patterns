using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Tools
{
    public class PaintBrush : ITool
    {
        private bool draw;
        private PointF lastPosition;
        public PaintBrush()
        {
            this.draw = false;
        }
        public void HandleMouseDown(PointF position, Bitmap canvas)
        {
            this.draw = true;
            this.lastPosition = position;
        }
        public void HandleMouseUp(PointF position, Bitmap canvas) => this.draw = false;

        public void HandleMouseMove(PointF position, Bitmap canvas)
        {
            if(this.draw)
            {
                var g = Graphics.FromImage(canvas);
                g.DrawLine(Pens.Black, this.lastPosition, position);

                this.lastPosition = position;
            }
        }

        public void RenderPreview(PointF position, Graphics window)
        {
            window.DrawEllipse(Pens.Black, position.X - 3, position.Y - 3, 6, 6);
        }
    }
}

