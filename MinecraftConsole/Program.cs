using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const int FIELDCOUNT = 9;
            const int MATERIALSCOUNT = 5;
            const int TOOLSCOUNT = 4;
            Material[] materials = new Material[MATERIALSCOUNT];
            materials[0] = new Material(0, "Дерево");
            materials[1] = new Material(1, "Метал");
            materials[2] = new Material(2, "Золото");
            materials[3] = new Material(3, "Мифрил");
            materials[4] = new Material(4, "Камень");
            Workbench workbench = new Workbench();
            Material chosenMaterial = new Material();

            ////Кирка
            //workbench.addMaterial(materials[4], 1, 1);
            //workbench.addMaterial(materials[4], 1, 2);
            //workbench.addMaterial(materials[4], 1, 3);
            //workbench.addMaterial(materials[0], 2, 2);
            //workbench.addMaterial(materials[0], 3, 2);

            ////Топор
            //workbench.addMaterial(materials[4], 1, 1);
            //workbench.addMaterial(materials[4], 1, 2);
            //workbench.addMaterial(materials[4], 2, 1);
            //workbench.addMaterial(materials[4], 2, 2);
            //workbench.addMaterial(materials[0], 3, 2);

            ////Мотыга
            //workbench.addMaterial(materials[0], 1, 1);
            //workbench.addMaterial(materials[0], 1, 2);
            //workbench.addMaterial(materials[0], 2, 2);
            //workbench.addMaterial(materials[0], 3, 2);

            //Лопата
            workbench.addMaterial(materials[0], 1, 2);
            workbench.addMaterial(materials[0], 2, 2);
            workbench.addMaterial(materials[0], 3, 2);


            Tool[] tools = new Tool[TOOLSCOUNT]{
                new Tool(new Material[FIELDCOUNT] { materials[4], materials[4], materials[4], null, materials[0], null, null, materials[0], null }, "Кирка"),
                new Tool(new Material[FIELDCOUNT] { materials[4], materials[4], null, materials[4], materials[4], null, null, materials[0], null }, "Топор"),
                new Tool(new Material[FIELDCOUNT] { materials[0], materials[0], null, null, materials[0], null, null, materials[0], null }, "Мотыга"),
                new Tool(new Material[FIELDCOUNT] { null, materials[0], null, null, materials[0], null, null, materials[0], null }, "Лопата")
            };
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("       x   ");
                Console.WriteLine("     1 2 3");
                Console.WriteLine("    -------");
                Console.WriteLine("  1 |{0}|{1}|{2}|", workbench.GetMaterialTypeByIndex(0), workbench.GetMaterialTypeByIndex(1), workbench.GetMaterialTypeByIndex(2));
                Console.WriteLine("    -------");
                Console.WriteLine("y 2 |{0}|{1}|{2}|", workbench.GetMaterialTypeByIndex(3), workbench.GetMaterialTypeByIndex(4), workbench.GetMaterialTypeByIndex(5));
                Console.WriteLine("    -------");
                Console.WriteLine("  3 |{0}|{1}|{2}|", workbench.GetMaterialTypeByIndex(6), workbench.GetMaterialTypeByIndex(7), workbench.GetMaterialTypeByIndex(8));
                Console.WriteLine("    -------");
                Console.Write("Выберите действие: \n1. Выбрать материал и поместить в ячейку\n2. Проверить рецепт\n3. Очистить верстак\n");
                Console.Write(">");
                int menu;
                bool result = int.TryParse(Console.ReadLine(), out menu);
                if (result)
                    switch (menu)
                    {
                        case 3:
                            workbench = new Workbench();
                            break;
                        case 1:
                            bool isOk;
                            do
                            {
                                isOk = true;

                                Console.Write("Выберите материал из списка \n0. Дерево\n1. Метал\n2. Золото\n3. Мифрил\n4. Камень\n>");
                                int materialId;

                                result = int.TryParse(Console.ReadLine(), out materialId);
                                if (result)
                                {
                                    isOk = !(materialId >= 0 && materialId <= MATERIALSCOUNT - 1);
                                    if (!isOk)
                                        chosenMaterial = materials[materialId];
                                    else
                                        Console.WriteLine("Неверный материал");
                                }
                                else
                                {
                                    Console.WriteLine("Неверный ввод");
                                }

                            } while (isOk);
                            do
                            {
                                isOk = true;
                                int x, y;
                                Console.WriteLine("Введите позицию x(1-3): ");
                                result = int.TryParse(Console.ReadLine(), out x);
                                if (result)
                                {
                                    isOk = !(x >= 1 && x <= 3);
                                    if (!isOk)
                                    {
                                        Console.WriteLine("Введите позицию y(1-3): ");
                                        result = int.TryParse(Console.ReadLine(), out y);
                                        if (result)
                                        {
                                            isOk = !(y >= 1 && y <= 3);
                                            if (!isOk)
                                            {
                                                workbench.addMaterial(chosenMaterial, x, y);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Неверный индекс Y, начнем сначала");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Неверный ввод");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный индекс X");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Неверный ввод");
                                }

                            } while (isOk);
                            break;
                        case 2:
                            if (workbench.sizeOfAddedMaterials == 0)
                            {
                                Console.WriteLine("Отсутствуют материалы на верстаке!");
                                Console.ReadLine();
                                break;
                            }
                            isOk = false;
                            for (int i = 0; i < TOOLSCOUNT; i++)
                            {
                                if (workbench == tools[i])
                                {
                                    Console.WriteLine("Вы скрафтили " + tools[i].GetName());
                                    isOk = true;
                                    break;
                                }
                            }
                            if (!isOk)
                                Console.WriteLine("Неизвестный рецепт");
                            Console.ReadLine();

                            break;
                        default:
                            break;
                    }
                else
                {
                    Console.WriteLine("Неверный ввод");
                }
            }
        }
    }
}
