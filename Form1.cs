using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_Version_1
{

    public partial class Form1 : Form
    {
        bool moveUp;
        bool moveDown;
        bool moveLeft;
        bool moveRight;


        int score = 0;

        int ghostOne = 3;
        int ghostTwo = 3;
        
        

        public Form1()
        {
            new Pacman();
            InitializeComponent();
            label2.Visible = false;
            resetBtn.Visible = false;
            exitBtn.Visible = false;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //assesses keypresses
        private void pacmanDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }
        }

        private void pacmanUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
        }

    

        private void timer1_Tick(object sender, EventArgs e)
        {

          

                Pacman p = new Pacman();
             
                label1.Text = "Score: " + score;
                p.speed = 5;

                if (moveLeft)
                {
                    pacman.Left -= p.speed;
                }

                if (moveRight)
                {
                    pacman.Left += p.speed;
                }

                if (moveUp)
                {
                    pacman.Top -= p.speed;
                }

                if (moveDown)
                {
                    pacman.Top += p.speed;
                }

                //Ghosts g = new Ghosts();
                //g.ghostOne = ghostOne;
                //g.ghostTwo = ghostTwo;

                ghostRed.Left += ghostOne;
                ghostOrange.Left += ghostTwo;

                //Reversing speed if ghost collides with picture box
                if (ghostRed.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    ghostOne = -ghostOne;
                    //ghostRed.Left -= g.GhostOne;
                }
                if (ghostRed.Bounds.IntersectsWith(pictureBox2.Bounds))
                {
                    ghostOne = -ghostOne;
                    //ghostRed.Left -= 100;

                    Console.WriteLine("ghostone:" + ghostOne);
                }
                if (ghostOrange.Bounds.IntersectsWith(pictureBox3.Bounds))
                {
                    ghostTwo = -ghostTwo;
                }
                if (ghostOrange.Bounds.IntersectsWith(pictureBox4.Bounds))
                {
                    ghostTwo = -ghostTwo;
                }


                foreach (Control x in this.Controls)
                {

                    if (x is PictureBox && x.Tag == "ghost")
                    {
                        if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                        {
                            pacman.Left = 0;
                            pacman.Top = 25;
                            label2.Text = "Game Over!";
                            label2.Visible = true;
                            resetBtn.Visible = true;
                            this.label2.ForeColor = Color.Crimson;
                            timer1.Stop();
                        }
                        else if (p.score == 12)
                        {
                            label2.Text = "You Win!!";
                            label2.Visible = true;
                            resetBtn.Visible = true;
                            this.label2.ForeColor = Color.Aqua;
                            timer1.Stop();
                        }
                    }

                    if(x is PictureBox && x.Tag == "wall")
                    {
                        //wall bounds statement
                        if(((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                        {
                            pacman.Left = 2;
                        }
                    }

                    if (x is PictureBox && x.Tag == "coin")
                    {

                        if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                        {
                            this.Controls.Remove(x);
                            score++;

                        }

                    }
                }
            
            
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            pacman.Top = mazeBottom.Top - pacman.Height;
            label2.Visible = false;
            score = 0;
            resetBtn.Visible = false;
            timer1.Start();
        }

        
    }
}
