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
        protected int Id
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

        protected Button BtnView
        {
            get { return _btnView; }
            set { _btnView = value; }
        }

        protected void AddButtonView()
        {
            _btnView = CreateButton();
            Canvas.Controls.Add(_btnView);
        }

        // ***** Interface implementation: IGraphic
        public abstract void Draw();
        public abstract void DeleteDraw();


        // ***** Create and Delete Methods for all form of drawings. Here there are two forms: TODO => Define which form we will deal with ...
        private Button CreateButton()
        {
            Button nodeButton = new Button
            {
                Text = Id.ToString(),
                Location = new Point(Position.X, Position.Y),
                Size = new Size(40, 40),
                BackColor = Color.LightGray
            };

            nodeButton.Click += (sender, e) => DeleteDraw();
            return nodeButton;
        }

        public void DeleteButton()
        {
            if (BtnView != null && BtnView.Parent != null)
            {
                BtnView.Parent.Controls.Remove(BtnView);
                BtnView.Dispose();
                BtnView = null;
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
