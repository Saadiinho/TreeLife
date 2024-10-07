using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        private bool _childrenVisible = false;
        private readonly List<GraphicBase> _children = new List<GraphicBase>();

        // ***** Methods
        // Constructor
        private SubTreeView(Panel canvas, int id, Point position, float angle, INodeInformation nodeInfo, bool isRoot = false) : base(canvas, id, position, angle)
        {
            _childrenVisible = isRoot;
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
        private bool ChildrenAreVisible() { return _childrenVisible; }

        private void SetChildrenVisibility(bool visible)
        {
            _childrenVisible = visible;
            Canvas.Invalidate();
        }

        private void AddChild(GraphicBase child)
        {
            _children.Add(child);
        }


        private void RemoveChild(GraphicBase child)
        {
            _children.Remove(child);
        }

        private List<GraphicBase> GetAllGraphicChildren()
        {
            return _children;
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
                float angleDegrees = CalculateDegreesAngle(isRoot, RelativeAngleToParent, i, angleIncrement);
                Point childPosition1 = CalculateChildPosition(branchLength, angleDegrees);
                AddChild(DefineChild(nodeInfo, Canvas, childrenIds[i], childPosition1, angleDegrees));
            }

            Canvas.Paint += (sender, e) => InteractWithImmediateChildren(e.Graphics);

        }


        private float CalculateDegreesAngle(bool isRoot, float relativeAngleToParent, int childIndex, float angleIncrement)
        {
            float angle = (childIndex * angleIncrement);
            if (!isRoot) angle += (relativeAngleToParent - 90);
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

        private bool AtLeastOneChildrenHasAChildrenDisplayed()
        {
            if (_children.Count == 0) return true;

            foreach (var child in _children)
            {
                if (child is LeafView leaf) continue;
                if (child is SubTreeView subtree)
                {
                   if (subtree.GetAllGraphicChildren().Any(c => c.isDisplayed())) return true;
                }
            }
            return false;
        }


        public override void Draw()
        {
            AddButtonView(() => SetChildrenVisibility(!_childrenVisible));
        }


        // Supprime le dessin du nœud et de ses enfants
        public override void DeleteDraw()
        {
            DeleteButton();
        }

        private void DrawImmediateChildren(Graphics g)
        {

            if (_childrenVisible)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    Point parentCenter = this.GetCenter();

                    foreach (var child in _children)
                    {
                        child.Draw();
                        g.DrawLine(pen, parentCenter, child.GetCenter());
                    }
                }
            }
        }


        private void DeleteImmediateChildren()
        {
            foreach (var child in _children)
            {
                child.DeleteDraw();
            }
        }


        private void InteractWithImmediateChildren(Graphics g)
        {
            if (_childrenVisible) {
                DrawImmediateChildren(g);
                return;
            }
            if (AtLeastOneChildrenHasAChildrenDisplayed())
            {
                // Then it is impossible to delete anything
                _childrenVisible = true;
                InteractWithImmediateChildren(g);
                return;
            };
            DeleteImmediateChildren();
        }


        public override void Zoom(float zoomFactor, float mouseX, float mouseY, float previousZoomFactor)
        {
            base.Zoom(zoomFactor, mouseX, mouseY, previousZoomFactor);

            foreach (var child in _children)
            {
                child.Zoom(zoomFactor, mouseX, mouseY, previousZoomFactor);
            }

            Canvas.Invalidate();
        }

        // ***** Other Methods

    }
}
