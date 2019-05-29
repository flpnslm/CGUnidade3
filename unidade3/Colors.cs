using System;
using System.Drawing;

namespace unidade3
{
    
    public class Colors
    {
        public Colors()
        {
            this.CurrentColor = Color.Blue;
        }
        public Color CurrentColor { get; set; }
        public void ChangeColor(String color)
        {
            switch (color)
            {
                case "R":
                    this.CurrentColor = Color.Red;
                    break;
                case "G":
                    this.CurrentColor = Color.Green;
                    break;
                case "B":
                    this.CurrentColor = Color.Blue;
                    break;
            }
        }


    }
}