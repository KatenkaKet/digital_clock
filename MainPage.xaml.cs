
using System;
using Microsoft.Maui.Layouts;
using Color = Microsoft.Maui.Graphics.Color;
using Android.Util;
using AbsoluteLayout = Microsoft.Maui.Controls.AbsoluteLayout;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using System.Drawing;
using Android.Content.Res;
using Java.Security.Cert;

namespace LastWatch;



    public partial class MainPage : ContentPage
    {


        const int WidhtDots = 35;
        const int HeightDots = 7;
            private int[,,] numbers = new int[10, 7, 4]
            {
                //0
                {
                    {0, 1, 1, 0},
                    {1, 0, 0, 1},
                    {1, 0, 0, 1},
                    {0, 0, 0, 0},
                    {1, 0, 0, 1},
                    {1, 0, 0, 1},
                    {0, 1, 1, 0},
                },
                //1
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 1},
                    {0, 0, 0, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 1},
                    {0, 0, 0, 0},
                },
                //2
                {
                    {0, 1, 1, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 1},
                    {0, 1, 1, 0},
                    {1, 0, 0, 0},
                    {1, 0, 0, 0},
                    {0, 1, 1, 0},
                },
                //3
                {
                    {0, 1, 1, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 1},
                    {0, 1, 1, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 1},
                    {0, 1, 1, 0},
                },
                //4
                {
                    {0, 0, 0, 0},
                    {1, 0, 0, 1},
                    {1, 0, 0, 1},
                    {0, 1, 1, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 1},
                    {0, 0, 0, 0},
                },
                //5
                {
                    {0, 1, 1, 0},
                    {1, 0, 0, 0},
                    {1, 0, 0, 0},
                    {0, 1, 1, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 1},
                    {0, 1, 1, 0},
                },
                //6
                {
                    {0, 1, 1, 0},
                    {1, 0, 0, 0},
                    {1, 0, 0, 0},
                    {0, 1, 1, 0},
                    {1, 0, 0, 1},
                    {1, 0, 0, 1},
                    {0, 1, 1, 0},
                },
                //7
                {
                    {0, 1, 1, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 1},
                    {0, 0, 0, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 1},
                    {0, 0, 0, 0},
                },
                //8
                {
                    {0, 1, 1, 0},
                    {1, 0, 0, 1},
                    {1, 0, 0, 1},
                    {0, 1, 1, 0},
                    {1, 0, 0, 1},
                    {1, 0, 0, 1},
                    {0, 1, 1, 0},
                },
                //9
                {
                    {0, 1, 1, 0},
                    {1, 0, 0, 1},
                    {1, 0, 0, 1},
                    {0, 1, 1, 0},
                    {0, 0, 0, 1},
                    {0, 0, 0, 1},
                    {0, 1, 1, 0},
                },
            };
        
        
        static readonly int[] pause = new int[7]
        {
            0, 0, 1, 0, 1, 0, 0
        };

        BoxView[,,] BW = new BoxView[6, 7, 5];

        public MainPage()
        {
            
            InitializeComponent();

            // double h = 200.0 / hDots;
            // double w = 800.0 / wDots;
            // double posX = 860.0 / (wDots - 1);
            // double posY = 200.0 / (hDots - 1);
            
            double h = 50.0 / HeightDots;
            double w = 300.0 / WidhtDots;
            double posX = 350.0 / (WidhtDots - 1);
            double posY = 70.0 / (HeightDots - 1);
        
            double x = -15;
            int number = 0;
            int column = 0;
            int row = 0;

            x += posX;

            for (number = 0; number <= 5; number++)
            {
                for (column = 0; column <= 3; column++)
                {
                    double y = 0;

                    for (row = 0; row <= 6; row++)
                    {
                        BoxView boxView = new BoxView{Color = Colors.Gold, CornerRadius = 10};
                        BW[number, row, column] = boxView;
                        absoluteLayout.Children.Add(boxView);
                        absoluteLayout.SetLayoutBounds(boxView,
                                        new Rect(x, y, w, h));
                        y += posY;
                    }
                    x += posX;
                }
                x += posX;

                if (number != 1 && number != 3) continue;
                {
                    for (column = 0; column <= 0; column++)
                    {
                        double y = 0;

                        for (row = 0; row <= 6; row++)
                        {
                            bool isPause = pause[row] == 1;
                            bool IsVP = isPause ? IsVisible : !IsVisible;
                            BoxView boxView = new BoxView
                            {
                                IsVisible = IsVP,
                                Color = Colors.Gold,
                                CornerRadius = 10
                            };
                            absoluteLayout.Children.Add(boxView);
                            absoluteLayout.SetLayoutBounds(boxView,
                                new Rect(x, y, w, h));

                            y += posY;
                        }
                        x += posX;
                    }
                    x += posX;
                }


            }

        Device.StartTimer(TimeSpan.FromSeconds(1), Time);
        Time();

        }
    

        bool Time()
        {
            DateTime dateTime = DateTime.Now;

            SetNumber(0, dateTime.Hour / 10);
            SetNumber(1, dateTime.Hour % 10);
            SetNumber(2, dateTime.Minute / 10);
            SetNumber(3, dateTime.Minute % 10);
            SetNumber(4, dateTime.Second / 10);
            SetNumber(5, dateTime.Second % 10);

            return true;
        }

        void Size(object sender, EventArgs args)
        {
            absoluteLayout.HeightRequest = HeightDots * Width / WidhtDots;
        }

        void SetNumber(int item, int number)
        {
            int row, column;
            for (row = 0; row <= 6; row++)
            {
                for (column = 0; column <= 3; column++)
                {
                    bool isOn = numbers[number, row, column] == 1;
                    //Color color = isOn ? colorN : colorF;
                    //BW[item, row, column].Color = color;
                    bool isV = isOn ? IsVisible : !IsVisible;
                    BW[item, row, column].IsVisible = isV;
                }
            }
        }

    }


