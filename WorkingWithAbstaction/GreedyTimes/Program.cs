using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long stones = 0;
            long money = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long count = long.Parse(safe[i + 1]);

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

                if (typeOfTreasure == "")
                {
                    continue;
                }
                else if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (typeOfTreasure)
                {
                    case "Gem":
                        if (!bag.ContainsKey(typeOfTreasure))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (count > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[typeOfTreasure].Values.Sum() + count > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(typeOfTreasure))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[typeOfTreasure].Values.Sum() + count > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(typeOfTreasure))
                {
                    bag[typeOfTreasure] = new Dictionary<string, long>();
                }

                if (!bag[typeOfTreasure].ContainsKey(name))
                {
                    bag[typeOfTreasure][name] = 0;
                }

                bag[typeOfTreasure][name] += count;
                if (typeOfTreasure == "Gold")
                {
                    gold += count;
                }
                else if (typeOfTreasure == "Gem")
                {
                    stones += count;
                }
                else if (typeOfTreasure == "Cash")
                {
                    money += count;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}