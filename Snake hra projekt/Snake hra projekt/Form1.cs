using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_hra_projekt
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle Food = new Circle();
        int maxWidth;
        int maxheight;
        int skore;
        int nejSkore;

        Random rand = new Random();
        bool goLeft, goRight, goUp, goDown;




        public Form1()
        {
            InitializeComponent();
            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private PictureBox GetPicCanvas()
        {
            return picCanvas;
        }

        private void GameTimerEvent(object sender, EventArgs e, PictureBox picCanvas)
        {
            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }
            for (int i = Snake.Count -1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {                                                           
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxheight;
                    }
                    if (Snake[i].Y > maxheight)
                    {
                        Snake[i].Y = 0;
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }

            picCanvas.Invalidate();


        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;
            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Green;
                }
                else
                {
                    snakeColour = Brushes.GreenYellow;
                }
                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    )
                    );
            }
            canvas.FillEllipse(Brushes.Pink, new Rectangle
                (
                Food.X * Settings.Width,
                Food.Y * Settings.Height,
                Settings.Width, Settings.Height
                )
                );
        }

        private void txtScore_Click_1(object sender, EventArgs e)
        {

        }

        private void RestartGame()
        {
            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxheight = picCanvas.Height / Settings.Height - 1;
            Snake.Clear();
            startButton .Enabled = false;
            skore = 0;
            txtScore.Text = "SKÓRE: " + skore;

            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            Food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxheight)};
            gameTimer.Start();
        }

        private void EatFood()
        {

        }

        private void GameOver()
        {

        }
    }
}
