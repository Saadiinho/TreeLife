using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeLife.Enum;
using TreeLife.Models;

namespace TreeLife.Interface
{
    public interface INodeInformation
    {
        // Méthode pour récupérer les enfants d'un parent donné
        List<int> GetChildren(int parentId);

        // Méthode pour récupérer le noeud à partir de l'id
        Node GetNode(int nodeId);

        // Méthode pour déterminer le type de nœud (parent, enfant)
        NodeType GetNodeType(int nodeId);

    }
}
