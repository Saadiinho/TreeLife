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

        // Méthode pour déterminer le type de nœud (parent, enfant, ou les deux)
        NodeType GetNodeType(int nodeId);

        (List<int> leafChildren, List<int> nodeChildren) GetLeafAndNodeChildren(int parentId);

        // Méthode pour vérifier si un nœud est une feuille (nœud sans enfants)
        bool IsLeaf(int nodeId);

        // Méthode pour vérifier si un nœud existe dans la structure
        bool IsNode(int nodeId);
    }
}
