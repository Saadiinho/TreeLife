using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeLife.Interface;

namespace TreeLife.Enum
{
    public class NodeInformation: INodeInformation
    {
        // Dictionnaire qui mappe un parentId à une liste d'enfants (childIds)
        private Dictionary<int, List<int>> _nodeRelations;

        // Constructeur qui initialise le dictionnaire avec des relations parent-enfant
        public NodeInformation(Dictionary<int, List<int>> nodeRelations)
        {
            _nodeRelations = nodeRelations;
        }

        // Méthode pour récupérer les enfants d'un parent donné
        public List<int> GetChildren(int parentId)
        {
            if (_nodeRelations.ContainsKey(parentId))
            {
                return _nodeRelations[parentId];
            }
            return new List<int>();  // Retourne une liste vide si le parent n'a pas d'enfants
        }

        public (List<int> leafChildren, List<int> nodeChildren) GetLeafAndNodeChildren(int parentId)
        {
            // Obtenir tous les enfants du parent
            List<int> children = GetChildren(parentId);

            // Initialiser deux listes : une pour les feuilles, une pour les noeuds
            List<int> leafChildren = new List<int>();
            List<int> nodeChildren = new List<int>();

            // Parcourir chaque enfant et les classer en fonction de leur type
            foreach (int childId in children)
            {
                if (_nodeRelations.ContainsKey(childId))
                {
                    // Si cet enfant est un parent d'autres noeuds, c'est un "node"
                    nodeChildren.Add(childId);
                }
                else
                {
                    // Sinon, c'est une feuille (pas de clés associées dans _nodeRelations)
                    leafChildren.Add(childId);
                }
            }

            // Retourne un tuple avec deux listes : les feuilles et les noeuds
            return (leafChildren, nodeChildren);
        }


        // Méthode pour déterminer le type de nœud (parent, enfant, ou les deux)
        public NodeType GetNodeType(int nodeId)
        {
            bool isParentOfNodes = _nodeRelations.ContainsKey(nodeId) && _nodeRelations[nodeId].Any(id => _nodeRelations.ContainsKey(id));
            bool isParentOfLeaves = _nodeRelations.ContainsKey(nodeId) && _nodeRelations[nodeId].Any(id => !_nodeRelations.ContainsKey(id));

            if (isParentOfNodes && isParentOfLeaves)
            {
                return NodeType.ParentOfNodeAndLeaf;  // Le nœud est parent d'au moins un autre nœud ET d'au moins une feuille
            }
            else if (isParentOfNodes)
            {
                return NodeType.ParentOfNodeOnly;  // Le nœud est parent uniquement d'autres nœuds
            }
            else if (isParentOfLeaves)
            {
                return NodeType.ParentOfLeafOnly;  // Le nœud est parent uniquement de feuilles
            }
            else
            {
                return NodeType.Leaf;  // Le nœud est une feuille (parent de personne)
            }
        }


        // Méthode pour vérifier si un nœud est une feuille (nœud sans enfants)
        public bool IsLeaf(int nodeId)
        {
            return !_nodeRelations.ContainsKey(nodeId);  // Si le nœud n'est pas un parent dans le dictionnaire
        }

        // Méthode pour vérifier si un nœud est présent dans la structure, soit comme parent soit comme enfant
        public bool IsNode(int nodeId)
        {
            return _nodeRelations.ContainsKey(nodeId) || _nodeRelations.Values.Any(children => children.Contains(nodeId));
        }
    }
}
