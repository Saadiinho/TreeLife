using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeLife.Enum;

namespace TreeLife.Interface
{
    public interface INodeInformation
    {
        // Méthode pour récupérer les enfants d'un parent donné
        List<int> GetChildren(int parentId);

        // Méthode pour déterminer le type de nœud (parent, enfant)
        NodeType GetNodeType(int nodeId);
    }
}
