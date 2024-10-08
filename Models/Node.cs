using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TreeLife.Interface;

namespace TreeLife.Models
{
    public class Node
    {
        public int NodeId { get; set; }
        public string NodeName { get; set; }
        public int ChildNodes { get; set; }
        public bool IsLeafNode { get; set; }
        public bool HasTolOrgLink { get; set; }
        public bool IsExtinct { get; set; }
        public int Confidence { get; set; }
        public int Phylesis { get; set; }
        private Node(int nodeId, string nodeName, int childNodes, bool isLeafNode, bool hasToLorgLink, bool isExtinct, int confidence, int phylesis) 
        {
            this.NodeId = nodeId;
            this.NodeName = nodeName;
            this.ChildNodes = childNodes; // Nombre d'enfant que le noeud possède
            this.IsLeafNode = isLeafNode; // Est-ce que le noeud est une feuille ?
            this.HasTolOrgLink = hasToLorgLink; // Est-ce qu'il possède un lien ?
            this.Confidence = confidence;
            this.Phylesis = phylesis;
        }

        public static Dictionary<int, Node> createListNode(string filePath)
        {
            var nodesMap = new Dictionary<int, Node>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                bool firstLine = true;

                while ((line = reader.ReadLine()) != null)
                {
                    // Ignore la première ligne (header) du fichier CSV
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    try
                    {
                        var values = ParseCsvLine(line);

                        int nodeId = int.Parse(values[0].Trim());
                        string nodeName = values[1].Trim();
                        int childNodes = int.Parse(values[2].Trim());
                        bool isLeafNode = int.Parse(values[3].Trim()) == 1; // Convertit 1/0 en booléen
                        bool hasTolOrgLink = int.Parse(values[4].Trim()) == 1; // Convertit 1/0 en booléen pour tolorg_link
                        bool isExtinct = int.Parse(values[5].Trim()) == 1; // Convertit 1/0 en booléen pour extinct
                        int confidence = int.Parse(values[6].Trim());
                        int phylesis = int.Parse(values[7].Trim());

                        // Crée un nouvel objet Node avec les données du fichier
                        var node = new Node(nodeId, nodeName, childNodes, isLeafNode, hasTolOrgLink, isExtinct, confidence, phylesis);

                        // Ajoute le Node à la liste
                        nodesMap[nodeId] = node;
                    }
                    catch(Exception ex) {
                        Console.WriteLine($"[NodeMap] Error processing line: '{line}'. Exception: {ex.Message}");
                    }

                }
            }
            return nodesMap;
        }

        public static List<string> ParseCsvLine(string line)
        {
            // Utilisation d'une expression régulière pour gérer les champs contenant des virgules
            var regex = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            var values = regex.Split(line.Trim());

            // Enlever les guillemets autour des valeurs si nécessaire
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim().Trim('"');
            }

            return new List<string>(values);
        }
    }
}
