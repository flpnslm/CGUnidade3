using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace unidade3
{
    class Primitive
    {
        public Primitive()
        {
            this.CurrentPrimitive = "2";
        }
        public string CurrentPrimitive { get; set; }

        public void changePrimitive()
        {
            this.CurrentPrimitive = this.CurrentPrimitive == "2" ? "3" : "2";
        }
    }
}