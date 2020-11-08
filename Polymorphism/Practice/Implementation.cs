using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    public class Implementation<T> : IGenericInterface<int>
    {
        public int SomeMethod(int input)
        {
            throw new NotImplementedException();
        }
    }
}
