using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Collections.Generic;

namespace unidade3
{
    static class BBox
    {
        static List<Ponto4D> pontoList = new List<Ponto4D>();
        static Primitive primitive = new Primitive();
        static Colors color = new Colors();

        public static void desenha(List<Ponto4D> pointList)
        {
            
            List<Ponto4D> bBoxPoints = calculateBBox(pointList);
            GL.LineWidth(2);
            GL.PointSize(2);
            GL.Color3(Color.Yellow);
            GL.Begin(PrimitiveType.LineLoop);
            foreach (Ponto4D ponto in bBoxPoints)
            {
                GL.Vertex3(ponto.X, ponto.Y, ponto.Z);
            }
            GL.End();
        }

        public static List<Ponto4D> calculateBBox(List<Ponto4D> pontoList) {
            double menorX;
            double menorY;
            double maiorX;
            double maiorY;
            List<Ponto4D> bBoxPoints = new List<Ponto4D>();
            if (pontoList == null)
            {
                pontoList = new List<Ponto4D>();
            }
            if (pontoList.Count > 0)
            {
                menorX = pontoList[0].X;
                menorY = pontoList[0].Y;
                maiorX = pontoList[0].X;
                maiorY = pontoList[0].Y;
                foreach (Ponto4D ponto in pontoList)
                {
                    menorX = ponto.X < menorX ? ponto.X : menorX;
                    menorY = ponto.Y < menorY ? ponto.Y : menorY;
                    maiorX = ponto.X > maiorX ? ponto.X : maiorX;
                    maiorY = ponto.Y > maiorY ? ponto.Y : maiorY;
                }
                bBoxPoints.Add(new Ponto4D(menorX, maiorY, 1));
                bBoxPoints.Add(new Ponto4D(maiorX, maiorY, 1));
                bBoxPoints.Add(new Ponto4D(maiorX, menorY, 1));
                bBoxPoints.Add(new Ponto4D(menorX, menorY, 1));
            }
            return bBoxPoints;
        }
    }
}