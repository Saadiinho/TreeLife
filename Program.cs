using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLife.Models;
using TreeLife.Enum;
using TreeLife.Interface;
using TreeLife.Views2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;

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
            // *************************************************************************** BACKEND PART

            //Récupération des paths pour les fichiers CSV
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string linkFile = Path.Combine(projectDirectory, "TreeLife/treeoflife_links.csv");
            string nodeFile = Path.Combine(projectDirectory, "TreeLife/treeoflife_nodes.csv");

            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ******* Model
            Model treeLifeModel = new Model(linkFile:linkFile, nodeFile:nodeFile);

            // ******* Controller
            Controller treeLifeController = new Controller(treeLifeModel);

            // *************************************************************************** FRONTEND PART

            const int appWidth = 800;
            const int appHeight = 800;

            // mainFrom
            Form mainForm = new Form
            {
                Text = "Tree of Life",
                Size = new System.Drawing.Size(appWidth, appHeight)
            };

            // ******* View
            TreeLifeView treeLifeView = new TreeLifeView(treeLifeController, mainForm, appWidth / 2, appHeight / 2);

            Application.Run(mainForm);
        }
    }
}
