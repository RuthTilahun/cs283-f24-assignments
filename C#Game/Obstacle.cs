// Defines objects that the player must avoid
// September 2024
// Ruth Tilahun

using System;
using System.Drawing;
using System.Windows.Forms;

public class Obstacle
{
    private int _x;
    private int _y;
    private int _height = 40;
    private int _width = 40;
    private float speed = 1f;
   
    public Obstacle(int startX, int startY)
    {
        _x = startX;
        _y = startY;
    }

    public int X
    {
        get { return _x; }
        set { _x = value; }
    }

    public int Y
    {
        get { return _y; }
        set { _y = value; }
    }

    public int Height
    { get { return _height; } }

    public int Width
    { get { return _width; } }

    public void Update(float dt)
    {
        _y += (int)(speed * dt * 50);
    }

    public void Draw(Graphics g)
    {
        Color c = Color.FromArgb(200, 0, 0, 0); 
        Brush brush = new SolidBrush(c);
        g.FillRectangle(brush, _x, _y, _width, _height);
    }
}

