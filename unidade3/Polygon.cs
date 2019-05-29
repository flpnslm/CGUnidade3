using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Collections.Generic;

namespace unidade3
{
     class Polygon
    {
        List<Ponto4D> pontoList = new List<Ponto4D>();
        Primitive primitive = new Primitive();
        Colors color = new Colors();
        public Polygon (List<Ponto4D> pontoList, Primitive primitive, Colors color)
        {
            this.pontoList = pontoList;
            this.primitive = primitive;
            this.color = color;
        }        

        public void desenha()
        {
            GL.LineWidth(10);
            GL.PointSize(10);
            GL.Color3(this.color.CurrentColor);
            GL.Begin((PrimitiveType) Enum.Parse(typeof(PrimitiveType), this.primitive.CurrentPrimitive));
            foreach (Ponto4D ponto in pontoList)
            {
                GL.Vertex3(ponto.X, ponto.Y, ponto.Z);
            }
            GL.End();
        }
    }
}