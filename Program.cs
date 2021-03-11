using System;
using System.Collections.Generic;
using System.Linq;

namespace TasksAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>() 
            { {"shards", 0}, 
              {"fragments", 0}, 
              {"motes", 0}

            };
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            bool isAchieved = false;

            while (true)
            {
                if (isAchieved == true)
                {
                    break;
                }

                string[] quantityRecourse = Console.ReadLine()
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < quantityRecourse.Length; i += 2)
                {
                    int quantity = int.Parse(quantityRecourse[i]);
                    string material = quantityRecourse[i + 1];

                    if (material == "shards" || material == "fragments" || material == "motes")
                    { //now we ernter in materialsDictionary to check
                        
                            materials[material] += quantity;                        

                        if (materials[material] >= 250)
                        {

                            if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }

                            materials[material] -= 250;  //this is the ramining balance at each material
                            isAchieved = true;
                            break;
                        }
                    }
                    else // if material is junk now we enter in JunkDictioanry to check
                    {
                        if (junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] += quantity;
                        }
                        else // if junk materialKey exists not, then add a key and value
                        {
                            junkMaterials.Add(material, quantity);
                        }
                    }
                }
            }

            Dictionary<string, int> sortedMaterials = materials
                 .OrderByDescending(x => x.Value)
                 .ThenBy(x => x.Key)
                 .ToDictionary(x => x.Key, x => x.Value);

            foreach (var material in sortedMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            Dictionary<string, int> sortedJunkMaterials = junkMaterials
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var material in sortedJunkMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
