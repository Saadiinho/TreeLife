using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLife.Enum
{
    public enum NodeType
    {
        ParentOfNodeAndLeaf,  // Un nœud parent d'au moins un autre nœud ET d'au moins une feuille
        ParentOfNodeOnly,     // Un nœud parent d'au moins un autre nœud mais pas d'une feuille
        ParentOfLeafOnly,     // Un nœud parent d'au moins une feuille mais pas d'un autre nœud
        Leaf                  // Un nœud qui est une feuille, donc parent de personne
    }

}
