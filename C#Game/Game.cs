// Manages the overall game state
// September 2024
// Ruth Tilahun

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class Game
{
    private Player _player;
    private List<Obstacle> _obstacles;
    private Random random = new Random();
    private float generateTimer;
    private bool _gameOver;

    public void Setup()
    {
        _player = new Player(Window.width / 2 - 20, Window.height - 50);
        _obstacles = new List<Obstacle>();
        _gameOver = false;
        generateTimer = 0f;
    }

    public void Update(float dt)
    {
        _player.Update(dt);

        //update obstacles
        foreach (Obstacle obstacle in _obstacles)
        {
            obstacle.Update(dt);

            if (CheckCollision(_player, obstacle))
            {
                _gameOver = true;
            }
            
        }

        //generate a new obstacle at a random horizontal position 
        generateTimer += dt;
        if (generateTimer >= 1f)  
        {
            int randomX = random.Next(0, Window.width - 40);  
            _obstacles.Add(new Obstacle(randomX, 0));
            generateTimer = 0f;
        }
    }

    public void Draw(Graphics g)
    {
        Image bgr = Image.FromFile("Background.jpg");
        g.DrawImage(bgr, 1, 1, Window.width, Window.height);

        if (_gameOver)
        {
            Font font = new Font("Arial", 46);
            Font font2 = new Font("Arial", 36);

            SolidBrush fontBrush = new SolidBrush(Color.White);

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            g.DrawString("GAME OVER!", font, fontBrush,
               (float)(Window.width * 0.5),
               (float)(Window.height * 0.4),
               format);
            g.DrawString("Press any key to restart", font2, fontBrush,
               (float)(Window.width * 0.5),
               (float)(Window.height * 0.5),
               format);
        }
        //Draw player and obstacles to screen 
        else
        {
            _player.Draw(g);

            foreach (Obstacle obstacle in _obstacles)
            {
                obstacle.Draw(g);
            }
        }
        
    }

    public void Reset()
    {
        Setup();
    }

    public void MouseClick(MouseEventArgs mouse)
    {
        if (mouse.Button == MouseButtons.Left)
        {
            System.Console.WriteLine(mouse.Location.X + ", " + mouse.Location.Y);
        }
    }

    public void KeyDown(KeyEventArgs key)
    {
        if(_gameOver)
        {
            Reset();
        }
       
        _player.KeyDown(key);
    }

    private bool CheckCollision(Player player, Obstacle obstacle)
    {
        return player.X < obstacle.X + obstacle.Width &&
               player.X + player.Width > obstacle.X &&
               player.Y < obstacle.Y + obstacle.Height &&
               player.Y + player.Height > obstacle.Y;
    }
}
