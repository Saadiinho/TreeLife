using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class DetailedLeafView : UserControl
    {
        private INodeInformation _nodeInfo;

        public DetailedLeafView(INodeInformation nodeInfo)
        {
            _nodeInfo = nodeInfo;
            InitializeComponent();
            LeafView.SubscribeToLeafSelected(OnLeafSelected);
        }

        private void OnLeafSelected(object sender, LeafSelectedEvent e)
        {
            UpdateDetails(e.ParentId, e.NodeId);
        }

        private void UpdateDetails(int parentId, int nodeId)
        {
            Node nodeSelectedByUser = _nodeInfo.GetNode(nodeId);
            lblNameToGet.Text = nodeSelectedByUser.NodeName;
            lblParentToGet.Text = _nodeInfo.GetNode(parentId).NodeName;
            lblPhylesisToGet.Text = nodeSelectedByUser.Phylesis.ToString();
            lblConfidenceToGet.Text = nodeSelectedByUser.Confidence.ToString();
            lblExtinctToGet.Text = nodeSelectedByUser.IsExtinct ? "Oui" : "Non";
            lblLinkToGet.Text = nodeSelectedByUser.HasTolOrgLink ? $"http://tolweb.org/{nodeSelectedByUser.NodeName}/{nodeSelectedByUser.NodeId}": "lien indisponible";
        }


        private void DetailedNodeView_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
