using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeAttributes
{
    [Author("Aleksandra")]

    // [Obsolete("Cat will be deleted in the next version." ,true)]- [Obsolete] is an attribute that the compiler complies with
    //Marks the program elements that are no longer in use. This class cannot be inherited.
    //[Obsolete]
    public class Cat
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        
    }
}
