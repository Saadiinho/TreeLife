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
    public class Model
    {
        public string linkFile;
        public string nodeFile;
        public Dictionary<int, Node> nodesMap;
        public LinkMap linksMap;
        

        public Model(string linkFile, string nodeFile)
        {
            this.linkFile = linkFile;
            this.nodeFile = nodeFile;
            this.nodesMap = Node.createListNode(nodeFile);
            this.linksMap = LinkMap.createMapLink(linkFile);
        }

        public List<int> childNodeIds(int nodeId) 
        {
            //Console.WriteLine($"[{nodeId}] a {linksMap.GetChildren(nodeId).Count} enfants");
            return linksMap.GetChildren(nodeId);
        }

        public Node GetChildNode(int nodeId)
        {
            return nodesMap[nodeId];
        }

    }
}
