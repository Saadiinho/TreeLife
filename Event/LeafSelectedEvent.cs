using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLife.Event
{
    public class LeafSelectedEvent
    {
        public int ParentId { get; }
        public int NodeId { get; }

        public LeafSelectedEvent(int parentId, int nodeId)
        {
            ParentId = parentId;
            NodeId = nodeId;
        }
    }
}
