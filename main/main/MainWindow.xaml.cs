using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace main
{

    public partial class MainWindow : Window
    {

        bool goUp1;
        bool goDown1;
        bool goUp2;
        bool goDown2;

        int playerSpeed = 7;

        int scorePlayer1 = 0;
        int scorePlayer2 = 0;

        int ballSpeedY = -200;
        int ballSpeedX = 150;


        private DispatcherTimer PlayerMovementTimer = new DispatcherTimer();

        private DispatcherTimer ballMovementTimer = new DispatcherTimer();


        public MainWindow()

        {
            InitializeComponent();
            myCanvas.Focus();

            //Spelarnas rörelser sätts igång

            PlayerMovementTimer.Interval = TimeSpan.FromMilliseconds(30);
            PlayerMovementTimer.Tick += playerMovement;
            PlayerMovementTimer.Start();


            //Bollens rörelse sätts igång
            ballMovementTimer.Interval = TimeSpan.FromSeconds(0.005);
            ballMovementTimer.Tick += ballMovement;
            ballMovementTimer.Start();
        }

        private void ballMovement(object sender, EventArgs e)
        {
            var x = Canvas.GetLeft(gameBall);
            var y = Canvas.GetTop(gameBall);


            //Krockar med toppen och botten av spelet

            if (y <= 0 || y>= myCanvas.ActualHeight - gameBall.Height)
            {
                ballSpeedY = -ballSpeedY;
            }

             
           
            x += ballSpeedX * ballMovementTimer.Interval.TotalSeconds;
            y += ballSpeedY * ballMovementTimer.Interval.TotalSeconds;

            Canvas.SetLeft(gameBall, x);
            Canvas.SetTop(gameBall, y);


        }

        //Vad som ska göras när en knapp blir tryckt, hur spelaren får röra sig med gränser och hastighet

        private void playerMovement(object sender, EventArgs e)
        {
            if (goUp1)
            {
                if (Canvas.GetTop(player1) > 0.0)
                {
                    Canvas.SetTop(player1, Canvas.GetTop(player1) - playerSpeed);
                }

            }
            if (goUp2)
            {
                if (Canvas.GetTop(player2) > 0.0)
                {

                    Canvas.SetTop(player2, Canvas.GetTop(player2) - playerSpeed);
                }

            }

            if (goDown1)
            {
                if (Canvas.GetTop(player1) + player1.Height < myCanvas.ActualHeight)
                {
                    Canvas.SetTop(player1, Canvas.GetTop(player1) + playerSpeed);
                }
            }

            if (goDown2)
            {
                if (Canvas.GetTop(player2) + player2.Height < myCanvas.ActualHeight)
                {
                    Canvas.SetTop(player2, Canvas.GetTop(player2) + playerSpeed);
                }
            }

        }
        //Känner av när man släpper en knapp 

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.W:
                    {
                        goUp2 = false;
                        goDown2 = false;
                        break;
                    }

                case Key.S:
                    {
                        goUp2 = false;
                        goDown2 = false;
                        break;
                    }

                case Key.Up:
                    {
                        goUp1 = false;
                        goDown1 = false;
                        break;
                    }

                case Key.Down:
                    {
                        goUp1 = false;
                        goDown1 = false;
                        break;
                    }

            }


        }

        //Känner av när man trycker in en knapp
        private void KeyIsDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.W:
                    {
                        goUp2 = true;
                        goDown2 = false;
                        break;
                    }

                case Key.S:
                    {
                        goUp2 = false;
                        goDown2 = true;
                        break;
                    }

                case Key.Up:
                    {
                        goUp1 = true;
                        goDown1 = false;
                        break;
                    }

                case Key.Down:
                    {
                        goUp1 = false;
                        goDown1 = true;
                        break;
                    }
            }
        }
    }

}