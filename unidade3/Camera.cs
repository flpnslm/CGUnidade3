namespace unidade3
{
  internal class Camera
  {
    private float x1;
    private float x2;
    private float y1;
    private float y2;
    private float z1;
    private float z2;
    public Camera(float x1 = 0, float x2 = 0, float y1 = 0, float y2 = 0, float z1 = 0, float z2 = 0)
    {
      this.x1 = x1;
      this.x2 = x2;
      this.y1 = y1;
      this.y2 = y2;
      this.z1 = z1;
      this.z2 = z2;
    }

    public float X1 { get => x1; set => x1 = value; }
    public float X2 { get => x2; set => x2 = value; }
    public float Y1 { get => y1; set => y1 = value; }
    public float Y2 { get => y2; set => y2 = value; }
    public float Z1 { get => z1; set => z1 = value; }
    public float Z2 { get => z2; set => z2 = value; }

  }
}