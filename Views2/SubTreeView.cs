using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TreeLife.Enum;
using TreeLife.Interface;

namespace TreeLife.Views2
{
    public class SubTreeView: GraphicBase
    {
        // ***** Attributes
        private readonly List<GraphicBase> _children = new List<GraphicBase>();

        // ***** Methods
        // Constructor
        private SubTreeView(Panel canvas, int id, Point position, float angle, INodeInformation nodeInfo, bool isRoot = false) : base(canvas, id, position, angle)
        {
            if (!isRoot) DefineNodeChildren(nodeInfo);
        }

        static public SubTreeView BuildTree(Panel canvas, int id, Point position, INodeInformation nodeInfo)
        {
            bool isRoot = true;
            SubTreeView treeView = new SubTreeView(canvas, id, position, 0, nodeInfo, isRoot);
            treeView.DefineNodeChildren(nodeInfo, 360, isRoot);
            return treeView;
        }
        // Getters & Setters

        private void AddChild(GraphicBase child)
        {
            _children.Add(child);
        }

        private void RemoveChild(GraphicBase child)
        {
            _children.Remove(child);
        }

        private void DefineNodeChildren(INodeInformation nodeInfo, float totalAngleRange = 180.0f, bool isRoot = false)
        {
            List<int> childrenIds = nodeInfo.GetChildren(Id);
            int numberOfChildren = childrenIds.Count;

            if (numberOfChildren <= 0) return;

            int branchLength = 150; // TODO => The branch length must depend on the child of all the node
            float angleIncrement = totalAngleRange / numberOfChildren;

            for (int i = 0; i < numberOfChildren; i += 1)
            {
                float angleDegrees = CalculateDegreesAngle(isRoot, RelativeAngleToParent, i, angleIncrement, -90);
                Point childPosition1 = CalculateChildPosition(branchLength, angleDegrees);
                AddChild(DefineChild(nodeInfo, Canvas, childrenIds[i], childPosition1, angleDegrees));
            }
        }

        private float CalculateDegreesAngle(bool isRoot, float relativeAngleToParent, int childIndex, float angleIncrement, int delta)
        {
            float angle = (childIndex * angleIncrement + delta);
            if (!isRoot) angle += relativeAngleToParent;
            return angle;
        }

        private Point CalculateChildPosition(float d, float angleDegress)
        {
            float angleRadians = (float) (angleDegress * (Math.PI / 180.0f));

            int childX = (int)(Position.X + d * Math.Cos(angleRadians));
            int childY = (int)(Position.Y + d * Math.Sin(angleRadians));

            return new Point(childX, childY);
        }

        private GraphicBase DefineChild(INodeInformation nodeInfo, Panel canvas, int id, Point Position, float angle)
        {
            return nodeInfo.GetNodeType(id) == NodeType.Leaf
                ? (GraphicBase)new LeafView(canvas, id, Position, angle)
                : new SubTreeView(canvas, id, Position, angle, nodeInfo);
        }

        // ***** Interface implementation
        // Draw the current node and its children
        public override void Draw()
        {
            AddButtonView();

            foreach (var child in _children)
            {
                child.Draw();
            }
        }


        // Supprime le dessin du nœud et de ses enfants
        public override void DeleteDraw()
        {
            DeleteButton();

            foreach (var child in _children)
            {
                child.DeleteDraw();
            }
        }

        // ***** Other Methods
    }
}
