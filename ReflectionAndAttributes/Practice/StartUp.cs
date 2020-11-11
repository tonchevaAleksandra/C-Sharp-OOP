using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Practice
{
    public class StartUp
    {
        static void Main()
        {
            string baseNamespace = "Practice";

            PropertyInfo[] properties = typeof(Cat).GetProperties();

            foreach (var property in properties)
            {
                Console.WriteLine((property.Name));
            }
            Console.WriteLine();
            var cat = new Cat("Roshko", 1);
            var type = cat.GetType();
            //var type = typeof(Cat);

            Type baseType = type.BaseType;
            if (baseType != null && baseType.IsAbstract)
            {
                Console.WriteLine(baseType.IsGenericType);
                Console.WriteLine(baseType.IsInstanceOfType(cat));
                Console.WriteLine($"The basetype of {type} is {baseType}");
            }
            Console.WriteLine();
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);//left and right
            foreach (var field in fields)
            {
                var value = field.GetValue(cat);
                Console.WriteLine(field.Name); ;
                Console.WriteLine(value);
            }
            Console.WriteLine();
            ///
            
           var anotherCat= (Cat)Activator.CreateInstance(type, "Pesho", 2 );
            Console.WriteLine(anotherCat.Name);
            Console.WriteLine("///");
            Console.Write("Animal type: ");
            var animalType = Console.ReadLine();
            var typeA = Type.GetType($"{baseNamespace}.{animalType}");

            if(typeA==null)
            {
                Console.WriteLine("Invalid animal!");
                return;
            }
            Console.Write("animal name: ");
            var animalName = Console.ReadLine();
            Console.Write("Animal age: ");
            var animalAge = int.Parse(Console.ReadLine());
            var animalCreated = (Animal)Activator.CreateInstance(typeA,new object[] { animalName, animalAge });
            Console.WriteLine(animalCreated.GetType());

            Console.WriteLine("////////////////////////////");

            Console.Write("Animal type: ");
            var animalTypeB = Console.ReadLine();
            var typeB = Type.GetType($"{baseNamespace}.{animalTypeB}");

            if (typeB == null)
            {
                Console.WriteLine("Invalid animal!");
                return;
            }

            var constructors = type.GetConstructors().First();
            var parameters = constructors.GetParameters();
            var values = new List<object>();

            foreach (var parameterInfo in parameters)
            {
                Console.Write($"Animal {parameterInfo.Name}: ");
                var value = Console.ReadLine();

                values.Add(value);
            }

            var animal = (Animal)Activator.CreateInstance(typeB, values.ToArray());
            Console.WriteLine(animal.Name);
        }
    }
}
