using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long currAmount = long.Parse(safe[i + 1]);

                if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + currAmount)
                {
                    continue;
                }
                string typeOfTreasure = FindTypeOfTreasure(name);

                bool isValidTreasure = IsValidTreasure(typeOfTreasure, bag, currAmount);
                if (isValidTreasure)
                {
                    AddTreasuresToBag(bag, ref gold, ref gems, ref cash, name, currAmount, typeOfTreasure);
                }
            }

            PrintResult(bag);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var treasure in bag)
            {
                Console.WriteLine($"<{treasure.Key}> ${treasure.Value.Values.Sum()}");
                foreach (var item in treasure.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static void AddTreasuresToBag(Dictionary<string, Dictionary<string, long>> bag, ref long gold, ref long gems, ref long cash, string name, long currAmount, string typeOfTreasure)
        {
            if (!bag.ContainsKey(typeOfTreasure))
            {
                bag[typeOfTreasure] = new Dictionary<string, long>();
            }

            if (!bag[typeOfTreasure].ContainsKey(name))
            {
                bag[typeOfTreasure][name] = 0;
            }

            bag[typeOfTreasure][name] += currAmount;
            if (typeOfTreasure == "Gold")
            {
                gold += currAmount;
            }
            else if (typeOfTreasure == "Gem")
            {
                gems += currAmount;
            }
            else if (typeOfTreasure == "Cash")
            {
                cash += currAmount;
            }
        }

        private static bool IsValidTreasure(string typeOfTreasure, Dictionary<string,Dictionary<string, long>> bag, long currAmount)
        {
            switch (typeOfTreasure)
            {
                case "Gem":
                    if (!bag.ContainsKey(typeOfTreasure))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (currAmount > bag["Gold"].Values.Sum())
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (bag[typeOfTreasure].Values.Sum() + currAmount > bag["Gold"].Values.Sum())
                    {
                        return false;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(typeOfTreasure))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (currAmount > bag["Gem"].Values.Sum())
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (bag[typeOfTreasure].Values.Sum() + currAmount > bag["Gem"].Values.Sum())
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }
        private static string FindTypeOfTreasure(string name)
        {
            string typeOfTreasure = string.Empty;

            if (name.Length == 3)
            {
                typeOfTreasure = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                typeOfTreasure = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                typeOfTreasure = "Gold";
            }
            return typeOfTreasure;
        }
    }
}