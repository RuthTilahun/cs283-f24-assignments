// Represents the user-controlled character
// September 2024
// Ruth Tilahun

using System;
using System.Drawing;
using System.Windows.Forms;

public class Player
{
	private float _x; 
	private float _y;
    private int _height = 40;
    private int _width = 40;
    private bool _movingLeft = false;
    private bool _movingRight = false;
    private float _speed = 20f;

    public Player(int startX, int startY)
    {
        _x = startX;
        _y = startY;
    }

    public int X
    {
        get { return (int) _x; }
        set { _x = value; }
    }

    public int Y
    {
        get { return (int) _y; }
        set { _y = value; }
    }

    public int Height
    { get { return _height; } }

    public int Width
    { get { return _width; } }

    public void Update(float dt)
    {
        float movement = _speed * dt;
        if (_movingLeft && _x > 0)
        {
            _x -= movement;
            _movingLeft = false;
            if (_x < 0)
                _x = 0; // to prevent from going off screen 
        }
        if (_movingRight && _x < Window.width - _width)
        {
            _x += movement;
            _movingRight = false;
            if (_x > Window.width - _width)
                _x = Window.width - _width;
        }
    }

    public void KeyDown(KeyEventArgs key)
    {
        if (key.KeyCode == Keys.D || key.KeyCode == Keys.Right)
        {
            _movingRight = true;
            _movingLeft = false;
        }
        else if (key.KeyCode == Keys.A || key.KeyCode == Keys.Left)
        {
            _movingLeft = true;
            _movingRight= false;
        }
    }

    public void Draw (Graphics g)
    {
        Color c = Color.FromArgb(200, 0, 0, 0);
        Brush brush = new SolidBrush(c);
        g.FillEllipse(brush, _x, _y, _width, _height); 
    }

    public bool Collided(Obstacle obstacle)
    {
        return X < obstacle.X + obstacle.Width && Y < obstacle.Y + obstacle.Height;

    }
}
