using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Tools
{
    class RectangleTool : ITool
    {
        private PointF firstLocation;
        private bool preview;
        public void HandleMouseDown(PointF position, Bitmap canvas)
        {
            this.firstLocation = position;
            this.preview = true;
        }

        public void HandleMouseMove(PointF position, Bitmap canvas)
        {
            
        }

        public void HandleMouseUp(PointF position, Bitmap canvas)
        {
            if (!this.preview) return;

            var g = Graphics.FromImage(canvas);
            g.FillRectangle(Brushes.Black, this.RectangleFromPoints(this.firstLocation, position));

            this.preview = false;
        }
        
        private RectangleF RectangleFromPoints(PointF first, PointF second)
        {
            float left = (first.X < second.X) ? first.X : second.X;
            float top = (first.Y < second.Y) ? first.Y : second.Y;
            float right = (first.X > second.X) ? first.X : second.X;
            float bottom = (first.Y > second.Y) ? first.Y : second.Y;

            return RectangleF.FromLTRB(left, top, right, bottom);
        }

        public void RenderPreview(PointF position, Graphics window)
        {
            window.DrawEllipse(Pens.Black, position.X - 3, position.Y - 3, 6, 6);

            if (!this.preview) return;

            window.DrawRectangle(Pens.Black, Rectangle.Round(this.RectangleFromPoints(this.firstLocation, position)));
        }
    }
}
