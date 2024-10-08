using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLife.Interface;

namespace TreeLife.Views2
{
    public class LeafView: GraphicBase
    {

        // ***** Methods
        // Constructor
        public LeafView(INodeInformation nodeInfo, Panel canvas, int id, Point position, float angle) : base(nodeInfo, canvas, id, position, angle)
        {
        }

        // ***** IGraphic Implementation
        public override void Draw()
        {
            AddButtonView();
        }


        public override void DeleteDraw()
        {
            DeleteButton();
        }
    }
}
