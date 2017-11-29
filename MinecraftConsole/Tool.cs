using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftConsole
{
    public class Tool
    {
        const int FIELDSIZE = 9;
        Material[] arr = new Material[FIELDSIZE];
        string name;
        public Tool(Material[] materials, string n)
        {
            arr = materials;
            name = n;
        }
        public string GetName()
        {
            return name;
        }
       
        public Material[] GetMaterials()
        {
            return arr;
        }

    }
}
