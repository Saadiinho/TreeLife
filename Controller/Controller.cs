using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeLife.Enum;
using TreeLife.Interface;
using TreeLife.Models;

namespace TreeLife
{
    public class Controller : INodeInformation
    {
        private readonly Model _model;

        public Controller(Model model)
        {
            _model = model;
        }

        public List<int> GetChildren(int parentId)
        {
            return _model.childNodeIds(parentId);
        }

        public NodeType GetNodeType(int nodeId)
        {
            return GetChildren(nodeId).Count > 0 ? NodeType.Parent : NodeType.Leaf;
        }
    }
}
