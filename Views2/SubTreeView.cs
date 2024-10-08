using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TreeLife.Enum;
using TreeLife.Interface;
using TreeLife.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TreeLife.Views2
{
    public class SubTreeView: GraphicBase
    {
        // ***** Attributes
        private bool _childrenVisible = false;
        private bool _paintEventAttached = false;

        private readonly List<GraphicBase> _children = new List<GraphicBase>();

        // ***** Methods
        // Constructor
        private SubTreeView(INodeInformation nodeInfo, Panel canvas, int id, Point position, float angle) : base(nodeInfo, canvas, id, position, angle)
        {
            //if (!isRoot) LoadNodeChildren(nodeInfo);
            //ConnectEventToUserView();
        }


        static public SubTreeView BuildTree(INodeInformation nodeInfo, Panel canvas, int id, Point position)
        {
            SubTreeView treeView = new SubTreeView(nodeInfo, canvas, id, position, 0);
            //treeView.ConnectEventToUserView();
            return treeView;
        }


        // Getters & Setters
        private bool ChildrenAreVisible() { return _childrenVisible; }

        private void SetChildrenVisibility(bool visible)
        {
            _childrenVisible = visible;

            if (!_paintEventAttached)
            {
                Canvas.Paint += (sender, e) => InteractWithImmediateChildren(e.Graphics);
                _paintEventAttached = true;  // Marque comme attaché pour éviter plusieurs attachements
            }


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

        private bool childrenAlreadyLoaded()
        {
            return _children.Count == Controller.GetChildren(Id).Count();
        }

        private void LoadNodeChildren(float totalAngleRange = 180.0f)
        {
            if (childrenAlreadyLoaded()) return;

            print($"    [{Id}] =========> DEBUT CHARGEMENT");

            List<int> childrenIds = Controller.GetChildren(Id);
            int numberOfChildren = childrenIds.Count;

            if (numberOfChildren <= 0) return;

            int branchLength = 150; // TODO => The branch length must depend on the child of all the node
            float angleIncrement = ((IsRoot())? 360: totalAngleRange) / numberOfChildren;

            for (int i = 0; i < numberOfChildren; i += 1)
            {
                float angleDegrees = CalculateDegreesAngle(RelativeAngleToParent, i, angleIncrement);
                Point childPosition1 = CalculateChildPosition(branchLength, angleDegrees);
                AddChild(DefineChild(Controller, Canvas, childrenIds[i], childPosition1, angleDegrees));
            }

            print(($"   [{Id}] xxxxxxxxxxx CHARGEMENT"));
        }

        private bool IsRoot() { return Id == 1; }

        private float CalculateDegreesAngle(float relativeAngleToParent, int childIndex, float angleIncrement)
        {
            float angle = (childIndex * angleIncrement);
            if (!IsRoot()) angle += (relativeAngleToParent - 90);
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
                ? (GraphicBase)new LeafView(nodeInfo,canvas, id, Position, angle)
                : new SubTreeView(nodeInfo,canvas, id, Position, angle);
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
            LoadNodeChildren();

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

        private void ConnectEventToUserView()
        {
            Canvas.Paint += (sender, e) => InteractWithImmediateChildren(e.Graphics);
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

        public override void Move(int x, int y)
        {
            base.Move(x, y);

            foreach (var child in _children)
            {
                child.Move(x, y);
            }

            Canvas.Invalidate();
        }
        // ***** Other Methods

    }
}
