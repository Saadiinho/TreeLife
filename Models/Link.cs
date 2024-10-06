using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLife.Models
{
    internal class Link
    {
        public int ChildId { get; set; }
        public int ParentId { get; set; }

        public Link (int childId, int parentId)
        {
            // Les identifiants des noeuds parents et enfants
            this.ChildId = childId;
            this.ParentId = parentId;
        }

        public static List<Link> createListLink(string filePath)
        {
            var links = new List<Link>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Chaque ligne est censée être au format "ParentId,ChildId"
                    var values = line.Split(',');

                    if (values.Length == 2) // Vérifie que la ligne contient exactement 2 éléments
                    {
                        int parentId = int.Parse(values[0].Trim()); // Trim pour enlever les espaces éventuels
                        int childId = int.Parse(values[1].Trim());

                        // Crée un nouvel objet Link avec parentId et childId
                        var link = new Link(childId, parentId);

                        // Ajoute le lien à la liste
                        links.Add(link);
                    }
                }
            }
            return links;
        }
    }
}
