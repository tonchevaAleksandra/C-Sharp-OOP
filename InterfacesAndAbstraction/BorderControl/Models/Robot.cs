using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Robot : IInhabitable
    {
        public Robot(string model, string id)         
        {
            this.Model = model;
            this.ID = id;
        }
        public string Model { get; set; }
        public string ID { get; private set; }
    }
}
