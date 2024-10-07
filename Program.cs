using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLife.Enum;
using TreeLife.Interface;
using TreeLife.Views2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TreeLife
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Créer un formulaire directement dans le programme principal
            Form mainForm = new Form
            {
                Text = "Tree of Life",  // Titre de la fenêtre
                Size = new System.Drawing.Size(900, 800)  // Taille par défaut de la fenêtre
            };

            // ******************* MAP DECLARATION *******************

            Dictionary<int, List<int>> nodeRelations = new Dictionary<int, List<int>>()
            {
                { 1, new List<int> { 2, 3, 4 } }, 
                { 2, Enumerable.Range(5, 4).ToList() },  
                { 3, Enumerable.Range(15, 4).ToList() },
                { 4, Enumerable.Range(25, 4).ToList() },
                { 5, Enumerable.Range(35, 4).ToList() },
                { 15, Enumerable.Range(45, 4).ToList() },
                { 25, Enumerable.Range(55, 4).ToList() },
            };

            // Créer une instance de NodeInformation
            NodeInformation nodeInfo = new NodeInformation(nodeRelations);

            Panel panel = new Panel()
            {
                //Dock = DockStyle.Fill,
                Size = new Size(mainForm.Width, mainForm.Height),
            };

            int xMid = (int)(panel.Width / 2);
            int yMid = (int)(panel.Height / 2);

            new TreeLifeView(nodeInfo, panel, xMid, yMid);

            mainForm.Controls.Add(panel);
            // Lancer l'application avec ce formulaire
            Application.Run(mainForm);
        }
    }
}
