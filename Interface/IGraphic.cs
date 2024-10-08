using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeLife.Interface
{
    public interface IGraphic
    {

        // Draw the view
        void Draw();

        // Delete all the things drew earlier by the draw function
        void DeleteDraw();

        void Zoom(float zoomFactor, float mouseX, float mouseY, float previousZoomFactor);

        void Move(int x, int y);
    }
}
