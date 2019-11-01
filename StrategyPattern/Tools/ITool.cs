using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Tools
{
    public interface ITool
    {
        void HandleMouseMove(PointF position, Bitmap canvas);
        void HandleMouseDown(PointF position, Bitmap canvas);
        void HandleMouseUp(PointF position, Bitmap canvas);
        void RenderPreview(PointF position, Graphics window);
    }
}
