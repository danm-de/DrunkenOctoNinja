﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FlyWithMe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NetworkAl network;
        private Drone drone;
        
        public MainPage()
        {
            InitializeComponent();
            //Task.WaitAll(Stuff());
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CoreWindow.GetForCurrentThread().KeyDown += MyPage_KeyDown;
            this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Stuff());

        }

        private async void MyPage_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case Windows.System.VirtualKey.W:
                    {
                        await drone.Forward();
                        break;
                    }
                case Windows.System.VirtualKey.S:
                    {
                        await drone.Backward();
                        break;
                    }
                case Windows.System.VirtualKey.A:
                    {
                        await drone.Left();
                        break;
                    }
                case Windows.System.VirtualKey.D:
                    {
                        await drone.Right();
                        break;
                    }
                case Windows.System.VirtualKey.Space:
                    {
                        await drone.Up();
                        break;
                    }
                case Windows.System.VirtualKey.X:
                    {
                        await drone.Down();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            
        }

        private async void Stuff()
        {
            drone = new Drone();
            await drone.Initialize();
            drone.SomethingChanged += OnHandle_SomethingChanged;
            Console.Text += string.Format("Drone initialized. \n");
        }

        private void OnHandle_SomethingChanged(object sender, CustomEventArgs e)
        {
            this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Console.Text += string.Format(e.Message + "\n"));
            
        }

        private async void TakeOffButton_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.TakeOff();
            Console.Text += string.Format("Drone takeoff send. \n");
        }

        private async void LandingButton_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.Land();
            Console.Text += string.Format("Drone landing send. \n");
        }

        private async void Emergency_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.EmergencyStop();
            Console.Text += string.Format("Drone emergency stop send. \n");
        }

        private async void Connect_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.Connect();
            Console.Text += string.Format("Drone connected. \n");
        }

        private async void Forwards_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.Forward();
            Console.Text += string.Format("Drone move forwards. \n");
        }

        private async void Backwards_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.Backward();
            Console.Text += string.Format("Drone move backwards. \n");
        }

        private async void Left_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.Left();
            Console.Text += string.Format("Drone move left. \n");
        }

        private async void FlipLeft_OnCLick(object sender, RoutedEventArgs e)
        {
            await drone.FlipLeft();
            Console.Text += string.Format("Drone flip left. \n");
        }

        private async void FlipForward_OnCLick(object sender, RoutedEventArgs e)
        {
            await drone.FlipForward();
            Console.Text += string.Format("Drone flip forward. \n");
        }

        private async void Right_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.Right();
            Console.Text += string.Format("Drone move right. \n");
        }

        private async void Up_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.Up();
            Console.Text += string.Format("Drone move up. \n");
        }

        private async void Down_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.Down();
            Console.Text += string.Format("Drone move down. \n");
        }

        private async void Stabilise_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.Stabilise();
            Console.Text += string.Format("Drone stabilise. \n");
        }

        private async void Hover_OnClick(object sender, RoutedEventArgs e)
        {
            await drone.Hover();
            Console.Text += string.Format("Drone hover. \n");
        }
    }
}
