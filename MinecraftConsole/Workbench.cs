using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftConsole
{

    public class Workbench
    {
        public int sizeOfAddedMaterials = 0;
        const int FIELDSIZE = 9;
        Material[] arr = new Material[FIELDSIZE];
        public Workbench()
        {
            sizeOfAddedMaterials = 0;
            for (int i = 0; i < FIELDSIZE; i++)
            {
                arr[i] = null;
            }
        }
        public void addMaterial(Material material, int x, int y)
        {
            int pos = (x - 1) * 3 + y - 1;
            arr[pos] = material;
            sizeOfAddedMaterials++;
        }
        public static bool operator !=(Workbench workbench, Tool tool)
        {

            for (int i = 0; i < FIELDSIZE; i++)
            {
                if (workbench.arr[i] != tool.GetMaterials()[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator ==(Workbench workbench, Tool tool)
        {
            for (int i = 0; i < FIELDSIZE; i++)
            {

                if (workbench.arr[i]!= tool.GetMaterials()[i])
                {
                    return false;
                }
            }
            return true;
        }

        public string GetMaterialTypeByIndex(int index)
        {

            return arr[index] == null? " ": arr[index].GetMaterialType().ToString();
        }
    }
}
