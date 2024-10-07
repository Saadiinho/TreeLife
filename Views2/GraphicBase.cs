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
    public abstract class GraphicBase : IGraphic
    {
        // ***** Attributes
        private readonly int _id;       
        private readonly Panel _canvas;
        private Point _position;
        private float _relativeAngleToParent;

        private int _btnWidth = 40;
        private int _btnHeight = 40;
        private Button _btnView;

        // ***** Methods
        // Constructor

        protected GraphicBase(Panel canvas, int id, Point position, float relativeAngleToParent)
        {
            this._id = id;
            this._canvas = canvas;
            this._position = position;
            this._relativeAngleToParent = relativeAngleToParent;
        }

        // Gets & Setters
        public int Id
        {
            get { return _id; }
        }

        protected Panel Canvas
        {
            get { return _canvas; }
        }

        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public float RelativeAngleToParent
        {
            get { return _relativeAngleToParent; }
            set { _relativeAngleToParent = value; }
        }

        public int BtnWidth
        {
            get { return _btnWidth; }
            set { _btnWidth = value; }
        }

        public int BtnHeight
        {
            get { return _btnHeight; }
            set { _btnHeight = value; }
        }

        public Button BtnView
        {
            get { return _btnView; }
            set { _btnView = value; }
        }

        protected void AddButtonView(Action action = null)
        {
            if (BtnView == null)
            {
                BtnView = CreateButton(action);
                Canvas.Controls.Add(BtnView);
            }
        }

        public Point GetCenter()
        {
            return new Point(Position.X + BtnView.Width / 2, Position.Y + BtnView.Height / 2);
        }

        // ***** Interface implementation: IGraphic
        public abstract void Draw();
        public abstract void DeleteDraw();


        // ***** Create and Delete Methods for all form of drawings. Here there are two forms: TODO => Define which form we will deal with ...
        private Button CreateButton(Action action = null)
        {
            if (action == null) action = () => { };

            Button nodeButton = new Button
            {
                Text = Id.ToString(),
                Location = new Point(Position.X, Position.Y),
                Size = new Size(BtnWidth, BtnHeight),
                BackColor = Color.LightGray
            };

            nodeButton.Click += (sender, e) => action();
            nodeButton.MouseEnter += (sender, e) => action();

            return nodeButton;
        }

        public bool isDisplayed() { return BtnView != null; }

        public void DeleteButton()
        {
            if (BtnView != null && BtnView.Parent != null)
            {
                BtnView.Parent.Controls.Remove(BtnView);
                BtnView.Dispose();
                BtnView = null;
            }
        }

        private void SetBtnSize(float zoomFactor)
        {
            // Define both with and height depending on the zoomFactor
            int width = (int)(BtnWidth * zoomFactor);
            int height = (int)(BtnHeight * zoomFactor);

            if (width < 30) width = 30;
            if (width > 40) width = 40;
            if (height < 30) height = 30;
            if (height > 40) height = 40;

            BtnWidth = width;
            BtnHeight = height;
        }

        private void SetBtnPosition(float zoomFactor, float mouseX, float mouseY, float previousZoomFactor)
        {
            float zoomRatio = zoomFactor / previousZoomFactor;
            Position = new Point((int)(Position.X * zoomRatio + mouseX * (1 - zoomRatio)), (int)(Position.Y * zoomRatio + mouseY * (1 - zoomRatio)));
        }

        public virtual void Zoom(float zoomFactor, float mouseX, float mouseY, float previousZoomFactor)
        {
            SetBtnSize(zoomFactor);
            SetBtnPosition(zoomFactor, mouseX, mouseY, previousZoomFactor);

            if (BtnView != null)
            {
                BtnView.Size = new Size(BtnWidth, BtnHeight);
                BtnView.Location = Position;
            }
        }

        // TODO => see what we need to with this one ...
        public void LineTowardParent(GraphicBase parent)
        {
            if (parent == null)
                return;

            using (Graphics g = Canvas.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 2);
                Point parentCenter = new Point(parent.Position.X, parent.Position.Y);
                Point childCenter = new Point(this.Position.X, this.Position.Y);
                g.DrawLine(pen, parentCenter, childCenter);
            }
        }
    }
}
