using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Citizen : IInhabitable
    {
        private string name;
        private int age;
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }
        public int Age { get; private set; }
        public string Name { get; private set; }
        public string ID { get; private set; }

    }
}
