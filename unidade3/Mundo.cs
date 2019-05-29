using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Collections.Generic;

namespace unidade3
{
  class Mundo
  {
    private Ponto4D currentPoint;
    private Ponto4D ptoOrigem = new Ponto4D(0,0);
    private Matematica mat = new Matematica();
    private List<Ponto4D> pontoList = new List<Ponto4D>();
    private Primitive primitive = new Primitive();
    private Colors color = new Colors();
    private List<Polygon> polygonList = new List<Polygon>();
    public Polygon currentFocusedObject;
    public bool IsInserting = false;
    public void Desenha()
    {
      foreach (Polygon polygon in this.polygonList)
      {
          polygon.desenha();
      }

      Ponto4D pto = new Ponto4D(0,0);
      
      GL.LineWidth(10);
      GL.PointSize(10);

      GL.Begin((PrimitiveType) Enum.Parse(typeof(PrimitiveType), this.primitive.CurrentPrimitive));
        GL.Color3(this.color.CurrentColor);
        foreach (Ponto4D ponto in this.pontoList)
        {
          GL.Vertex3(ponto.X, ponto.Y, ponto.Z);
        }
      GL.End();

      BBox.desenha(this.pontoList);
    }
    public void SRU3D()
    {

    }

    public void newPolygon()
    {
      this.IsInserting = false;
      Polygon polygon = new Polygon(this.pontoList, this.primitive, this.color);
      this.polygonList.Add(polygon);
      this.pontoList = new List<Ponto4D>();
      this.currentPoint = null;
      this.primitive = new Primitive();
      this.color = new Colors();
    }

    public void AddVertex(double X, double Y, double Z)
    {
      this.IsInserting = true;
      if (this.currentPoint == null)
      {
        this.pontoList.Add(new Ponto4D(X, Y, Z));
        this.currentPoint = new Ponto4D(X, Y, Z);
        this.pontoList.Add(this.currentPoint);
      }
      else
      {
        this.currentPoint = new Ponto4D(X, Y, Z);
        this.pontoList.Add(currentPoint);
      }
    }

    public void drawTail(double x, double y, double z)
    {
      if (this.currentPoint != null)
      {
        this.currentPoint.X = x;
        this.currentPoint.Y = y;
        this.currentPoint.Z = z;
      }
    }

    public void changePrimitive()
    {
      this.primitive.changePrimitive();
    }
    public void changeColor()
    {
      if (this.color.CurrentColor == Color.Red)
      {
        this.color.ChangeColor("G");
      }
      else if (this.color.CurrentColor == Color.Green)
      {
          this.color.ChangeColor("B");
      }
      else
      {
          this.color.ChangeColor("R");
      }
    }
  }

}