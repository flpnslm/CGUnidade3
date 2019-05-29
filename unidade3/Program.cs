using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace unidade3
{
  class Render : GameWindow
  {
    Mundo mundo = new Mundo();
    Camera camera = new Camera(0, 1000, 1000, 0, -1, 1);
    
    public Render(int width, int height) : base(width, height) { }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
    }
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);

      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(this.camera.X1, this.camera.X2, this.camera.Y1, this.camera.Y2, this.camera.Z1, this.camera.Z2);
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);

      GL.Clear(ClearBufferMask.ColorBufferBit);
      GL.ClearColor(Color.White);
      GL.MatrixMode(MatrixMode.Modelview);
      mundo.SRU3D();
      mundo.Desenha();
      this.SwapBuffers();
    }

    protected override void OnMouseMove(OpenTK.Input.MouseMoveEventArgs e)
    {
      mundo.drawTail(e.X, e.Y, 1);
    }
    protected override void OnMouseDown(OpenTK.Input.MouseButtonEventArgs e)
    {
      if (!this.mundo.clickedPolygon(e.X, e.Y))
      {
        this.mundo.AddVertex(e.X, e.Y, 1);
      }
    }
    protected override void OnKeyPress(KeyPressEventArgs e)
    {
      switch (e.KeyChar.ToString().ToLower())
      {
        case "c":
          this.mundo.changeColor();
          break;
        case "p":
            this.mundo.changePrimitive();
          break;
        case " ":
          this.mundo.newPolygon();
          break;
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Render window = new Render(800, 800);
      window.Run();
      window.Run(1.0/60.0);
    }
  }
}
