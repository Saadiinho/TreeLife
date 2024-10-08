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
        private INodeInformation _controller;
        private readonly int _id;       
        private readonly Panel _canvas;
        private Point _position;
        private float _relativeAngleToParent;

        private int _btnWidth = 80;
        private int _btnHeight = 30;
        private Button _btnView;

        // ***** Methods
        // Constructor

        protected GraphicBase(INodeInformation controller, Panel canvas, int id, Point position, float relativeAngleToParent)
        {
            this._controller = controller;
            this._id = id;
            this._canvas = canvas;
            this._position = position;
            this._relativeAngleToParent = relativeAngleToParent;
        }

        // Gets & Setters
        protected INodeInformation Controller
        {
            get { return _controller; }
        }
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
                Text = _controller.GetNode(Id).NodeName,
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

        private int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private void SetBtnSize(float zoomFactor)
        {
            int width = (int)(BtnWidth * zoomFactor);
            int height = (int)(BtnHeight * zoomFactor);

            int normalWidth = 80;
            int normalHeight = 30;

            int marge = 10;

            width = Clamp(width, normalWidth - marge, normalWidth + marge);
            height = Clamp(height, normalHeight - marge, normalHeight + marge);

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

        private void SetBtnPosition(int x, int y)
        {
            Position = new Point(x, y);
        }

        public virtual void Move(int x, int y)
        {
            SetBtnPosition(Position.X + x, Position.Y + y);

            if (BtnView != null)
            {
                BtnView.Location = Position;
            }
        }
    }
}
