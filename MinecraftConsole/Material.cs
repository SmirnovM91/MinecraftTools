using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftConsole
{
    public class Material
    {
        int type;
        string name;
        public Material(int val = -1, string nameval = "")
        {
            type = val;
            name = nameval;
        }
        public override string ToString()
        {
          
            return type == null ? " " : type.ToString();
        }
        
        public int GetMaterialType()
        {
            return type;
        }
        public void SetType(int val)
        {
            type = val;
        }
    }
}
