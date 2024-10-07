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
        private IGraphic _treeView;
        private float _zoomFactor = 1.0f;     // Intial zoom factor
        private const float ZoomStep = 0.1f;  // zoom (0.1 = 10% per scrolling)
        private const float MaxZoom = 3.0f;   // maximum zoom (300%)
        private const float MinZoom = 0.3f;   // minimum zoom (30%)

        public TreeLifeView(INodeInformation nodeInfo, Panel canvas, int x, int y)
        {
            _treeView = SubTreeView.BuildTree(canvas, 1, new Point(x, y - 200), nodeInfo);
            _treeView.Draw();
            canvas.MouseWheel += OnMouseWheel;
        }

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
    }

}
