using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLife.Event;
using TreeLife.Interface;
using TreeLife.Models;

namespace TreeLife.Views2
{
    public class LeafView: GraphicBase
    {
        private static event EventHandler<LeafSelectedEvent> LeafSelected;
        private int _parentId;

        // ***** Methods
        // Constructor
        public LeafView(INodeInformation nodeInfo, Panel canvas, int parentId, int id, Point position, float angle) : base(nodeInfo, canvas, id, position, angle)
        {
            _parentId = parentId;
        }

        // ***** IGraphic Implementation
        public override void Draw()
        {
            AddButtonView(() => OnLeafSelected());
        }


        public override void DeleteDraw()
        {
            DeleteButton();
        }

        public static void SubscribeToLeafSelected(EventHandler<LeafSelectedEvent> handler)
        {
            LeafSelected += handler;
        }

        public static void UnsubscribeFromLeafSelected(EventHandler<LeafSelectedEvent> handler)
        {
            LeafSelected -= handler;
        }

        public void OnLeafSelected()
        {
            Console.WriteLine("NEW EVENT DECLENCHE POUR CHERCHER LES INFORMATIONS DU NOEUDS !!");
            LeafSelected?.Invoke(this, new LeafSelectedEvent(_parentId, Id));
        }

    }
}
