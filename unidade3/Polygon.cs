using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Collections.Generic;

namespace unidade3
{
     class Polygon
    {
        public List<Ponto4D> pontoList = new List<Ponto4D>();
        Primitive primitive = new Primitive();

        private List<Ponto4D> boundaryBox;
        Colors color = new Colors();
        public Polygon (List<Ponto4D> pontoList, Primitive primitive, Colors color)
        {
            this.pontoList = pontoList;
            this.primitive = primitive;
            this.color = color;
            this.boundaryBox = BBox.calculateBBox(pontoList);
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

        public List<Ponto4D> getPontoList()
        {
            return this.pontoList;
        }

        public bool clickedInside(double x, double y)
        {

            double menorX;
            double menorY;
            double maiorX;
            double maiorY;

            if (this.boundaryBox == null)
            {
                this.boundaryBox = new List<Ponto4D>();
            }
            if (this.boundaryBox.Count > 0)
            {
                menorX = this.boundaryBox[0].X;
                menorY = this.boundaryBox[0].Y;
                maiorX = this.boundaryBox[0].X;
                maiorY = this.boundaryBox[0].Y;
                foreach (Ponto4D ponto in this.boundaryBox)
                {
                    menorX = ponto.X < menorX ? ponto.X : menorX;
                    menorY = ponto.Y < menorY ? ponto.Y : menorY;
                    maiorX = ponto.X > maiorX ? ponto.X : maiorX;
                    maiorY = ponto.Y > maiorY ? ponto.Y : maiorY;
                }
                if (menorX < x && x < maiorX)
                {
                    if (menorY < y && y < maiorY)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}