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
        // Tell whether the point is within the user's current point of view
        //bool IsInUserView(Panel panel, int x, int y);

        //bool IsVisible();

        // Draw the view
        void Draw();

        // Delete all the things drew earlier by the draw function
        void DeleteDraw();
    }
}
