using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeLife.Models;
using CsvHelper;
using System.IO;

namespace TreeLife.Models
{
    internal class Model
    {
        public string linkFile;
        public string nodeFile;
        public List<Node> nodes;
        public List<Link> links;
        

        public Model(string linkFile, string nodeFile)
        {
            this.linkFile = linkFile;
            this.nodeFile = nodeFile;
            this.nodes = Node.createListNode(nodeFile);
            this.links = Link.createListLink(linkFile);
        }

        public List<Node> childNode(int nodeId) 
        {
            List<Node> childNode = new List<Node>();

            
            //Boucle qui permet de rentrer dans la liste tous les enfants du noeud entré en paramètre
            for (int i = 0; i < links.Count; i++)
            {
                if (links[i].ParentId == nodeId)
                {
                    int childId = links[i].ChildId;
                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (nodes[j].NodeId == childId)
                        {
                            childNode.Add(nodes[j]);
                        }
                    }
                }
            }
            Console.WriteLine("Nombre d'enfant : " + childNode.Count);
            for (int i = 0; i < childNode.Count; i++)
            {
                Console.WriteLine("Enfant : " + childNode[i].NodeName);
            }
            //Retourne la liste des id des enfants du noeuds entré en paramètre
            return childNode;
        }
        

        

    }
}
