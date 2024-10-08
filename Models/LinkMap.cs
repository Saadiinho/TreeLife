using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLife.Models
{
    public class LinkMap
    {
        private Dictionary<int, List<int>> _link;

        private LinkMap ()
        {
            _link = new Dictionary<int, List<int>>();
        }

        public static LinkMap createMapLink(string filePath)
        {
            var LinkMap = new LinkMap();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        // Chaque ligne est censée être au format "ParentId,ChildId"
                        var values = line.Split(',');

                        if (values.Length == 2) // Vérifie que la ligne contient exactement 2 éléments
                        {
                            int parentId = int.Parse(values[0].Trim()); // Trim pour enlever les espaces éventuels
                            int childId = int.Parse(values[1].Trim());

                            LinkMap.AddLink(parentId, childId);
                        }
                    }
                    catch (Exception ex) {
                        //Console.WriteLine($"[LinkMap] Error processing line: '{line}'. Exception: {ex.Message}");
                    }
                }
            }

            return LinkMap;
        }


        private void AddLink(int parentId, int childId)
        {
            if (!_link.ContainsKey(parentId))
            {
                _link[parentId] = new List<int>();
            }
            _link[parentId].Add(childId);
        }
        

        public List<int> GetChildren(int parentId)
        {
            return _link.ContainsKey(parentId) ? _link[parentId] : new List<int>();
        }
    }
}
