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

        bool goUp;
        bool goDown;
        int playerSpeed = 7;

        DispatcherTimer gameTimer = new DispatcherTimer();


        public MainWindow()

        {
            InitializeComponent();
            myCanvas.Focus();
        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (Canvas.GetTop(player1) > 0.0)
                {
                    Canvas.SetTop(player1, Canvas.GetTop(player1) - playerSpeed);
                }

            }
            if (e.Key == Key.W)
            {
                if (Canvas.GetTop(player2) > 0.0)
                {

                    Canvas.SetTop(player2, Canvas.GetTop(player2) - playerSpeed);
                }

            }

            if (e.Key == Key.Down)
            {
                if (Canvas.GetTop(player1) + player1.Height < myCanvas.ActualHeight)
                {
                    Canvas.SetTop(player1, Canvas.GetTop(player1) + playerSpeed);
                }
            }

            if (e.Key == Key.S)
            {
                if (Canvas.GetTop(player2) + player2.Height < myCanvas.ActualHeight)
                {
                    Canvas.SetTop(player2, Canvas.GetTop(player2) + playerSpeed);
                }
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.W:
                    {
                        goUp = true;
                        goDown = false;
                        break;
                    }

                case Key.S:
                    {
                        goUp = false;
                        goDown = true;
                        break;
                    }

                case Key.Up:
                    {
                        goUp = true;
                        goDown = false;
                        break;
                    }

                case Key.Down:
                    {
                        goUp = false;
                        goDown = true;
                        break;
                    }



            }


        }
    }

}