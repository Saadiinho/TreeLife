using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLife.Models;

namespace TreeLife
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole(); // Permet d'ouvrir la console
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Récupération des paths pour les fichiers CSV
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string linkFile = Path.Combine(projectDirectory, "TreeLife/treeoflife_links_simplified.csv");
            string nodeFile = Path.Combine(projectDirectory, "TreeLife/treeoflife_nodes_simplified.csv");

            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Appel du model
            Model model = new Model(linkFile:linkFile, nodeFile:nodeFile);
            List<Node> test = model.childNode(2285);

            Application.Run(new Form1());
        }
    }
}
