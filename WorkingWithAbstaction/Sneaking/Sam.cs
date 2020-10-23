using System;
using System.Collections.Generic;
using System.Text;

namespace Sneaking
{
   public class Sam
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public char Character => 'S';

        public Sam(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
