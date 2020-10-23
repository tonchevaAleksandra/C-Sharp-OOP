using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Sneaking
{
   public class Enemy
    {
        public char Character { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public string Direction { get; set; }
        public Enemy(int row, int col, char character, string direction)
        {
            this.Row = row;
            this.Col = col;
            this.Character = character;
            this.Direction = direction;

        }

        public void Move()
        {
            if(this.Direction=="right")
            {
                this.Col++;
            }
            else
            {
                this.Col--;
            }
        }
        public void ChangeCharacter()
        {
            if (this.Character == 'b')
            {
                this.Character = 'd';
                this.Direction = "left";
               
            }
            if (this.Character == 'd')
            {
                this.Character = 'b';
                this.Direction = "right";
            }
        }
    }
}
