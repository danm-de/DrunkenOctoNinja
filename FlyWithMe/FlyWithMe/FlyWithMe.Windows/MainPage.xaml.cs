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
        private Device drone;

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

        private void MyPage_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case Windows.System.VirtualKey.W:
                    {
                        drone.Forward();
                        break;
                    }
                case Windows.System.VirtualKey.S:
                    {
                        drone.Backward();
                        break;
                    }
                case Windows.System.VirtualKey.A:
                    {
                        drone.Left();
                        break;
                    }
                case Windows.System.VirtualKey.D:
                    {
                        drone.Right();
                        break;
                    }
                case Windows.System.VirtualKey.Space:
                    {
                        drone.Up();
                        break;
                    }
                case Windows.System.VirtualKey.X:
                    {
                        drone.Down();
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
            drone = new Device();
            await drone.Initialize();
        }

        private async void TakeOffButton_OnClick(object sender, RoutedEventArgs e)
        {
            network.SendData(ParrotUuids.Service_A00, ParrotUuids.Characteristic_TakeOffAndLand, Commands.TakeOff);
        }

        private async void LandingButton_OnClick(object sender, RoutedEventArgs e)
        {
            network.SendData(ParrotUuids.Service_A00, ParrotUuids.Characteristic_TakeOffAndLand, Commands.Landing);
        }

        private async void Emergency_OnClick(object sender, RoutedEventArgs e)
        {
            network.SendData(ParrotUuids.Service_A00, ParrotUuids.Characteristic_EmergencyStop, Commands.EmergencyShutdown);
        }

        private async void Connect_OnClick(object sender, RoutedEventArgs e)
        {
            //Task.WaitAll(new Task(async () =>
            //{
                await network.Connect();
                await network.Start();
            //}));
            
        }
    }
}
