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
    public class TreeLifeView
    {
        private SubTreeView _treeView;
        // zoom
        private float _zoomFactor = 1.0f;     // Intial zoom factor
        private const float ZoomStep = 0.5f;  // zoom (0.1 = 10% per scrolling)
        private const float MaxZoom = 300.0f;   // maximum zoom (30000%)
        private const float MinZoom = 0.3f;   // minimum zoom (0.30%)
        // drag & drop
        private bool _isDragging = false;
        private Point _lastMousePosition;


        public TreeLifeView(INodeInformation nodeInfo, Form userForm, int x, int y)
        {
            Panel canvas = new Panel
            {
                Size = new System.Drawing.Size(userForm.Width - 100, userForm.Height - 100)
            };

            _treeView = SubTreeView.BuildTree(nodeInfo, canvas, 1, new Point(x, y));
            _treeView.Draw();

            // zoom
            canvas.MouseWheel += OnMouseWheel;

            // drag & drop
            canvas.MouseDown += OnMouseDown;
            canvas.MouseMove += OnMouseMove;
            canvas.MouseUp += OnMouseUp;

            userForm.Controls.Add(canvas);
        }

        public Point GetPosition() { return _treeView.Position; }

        public void SetPosition(Point newPosition) { _treeView.Position = newPosition; }


        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            // Current mouse position
            float mouseX = e.X;
            float mouseY = e.Y;

            if (e.Delta > 0)
            {
                ZoomIn(mouseX, mouseY);
            }
            else if (e.Delta < 0)
            {
                ZoomOut(mouseX, mouseY);
            }
        }

        // Zoom in and Zoom Out
        private void ZoomIn(float mouseX, float mouseY)
        {
            if (_zoomFactor < MaxZoom)
            {
                float previousZoomFactor = _zoomFactor;
                _zoomFactor += ZoomStep;
                _treeView.Zoom(_zoomFactor, mouseX, mouseY, previousZoomFactor);
            }
        }

        private void ZoomOut(float mouseX, float mouseY)
        {
            if (_zoomFactor > MinZoom)
            {
                float previousZoomFactor = _zoomFactor;
                _zoomFactor -= ZoomStep;
                _treeView.Zoom(_zoomFactor, mouseX, mouseY, previousZoomFactor);
            }
        }

        // Drag and drop
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _lastMousePosition = e.Location;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                int deltaX = e.X - _lastMousePosition.X;
                int deltaY = e.Y - _lastMousePosition.Y;

                _treeView.Move(deltaX, deltaY);

                _lastMousePosition = e.Location;
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
            }
        }
    }

}
