using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PracticeAttributes
{
    [Author("Aleksandra")]// this works with constructor for your custom attribute Author


    //[Author] - this works only when AllowMultiple=true and without constructor to exige a name or other porpety!!!
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cat = new Cat();
            Console.WriteLine(cat.Name);
            typeof(Cat)
                   .GetProperties()
                   .SelectMany(pr => pr.GetCustomAttributes())
                   .Select(a => a.GetType().Name)
                   .ToList()
                   .ForEach(Console.WriteLine);

            Console.WriteLine();

            var types = Assembly
                 .GetExecutingAssembly()
                 .GetTypes();

            var attributes = types
                .Select(t => t.GetCustomAttribute<AuthorAttribute>());

            var typesAndAttributes = types.Select(t => new
            {
                Type = t,
                Attributes = t.GetCustomAttributes<AuthorAttribute>()
            })
                .Where(a=>a.Attributes.Any());

            var result = new Dictionary<string, List<string>>();

            foreach (var typesAndAttribute in typesAndAttributes)
            {
                var type = typesAndAttribute.Type.Name;
                var authors = typesAndAttribute.Attributes.Select(a => a.Name);

                foreach (var author in authors)
                {
                    if (!result.ContainsKey(author))
                    {
                        result[author] = new List<string>();
                    }
                    result[author].Add(type);
                }
            }

            foreach (var author in result)
            {
                var classes = string.Join(", ", author.Value);
                Console.WriteLine($"The author {author.Key} worked on classes below - {classes}");
            }

        }
    }
}
