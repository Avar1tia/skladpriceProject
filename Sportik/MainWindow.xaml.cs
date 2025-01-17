﻿
using skladprice.Pages;
using SkladPrice.Pages;
using sportik.Classes;
using sportik.Pages;
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
using skladprice.Windows;

namespace sportik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int sessionTimeInMinutes = 3600;
        private int remainingTimeInSeconds;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Info());
            Manager.MainFrame = MainFrame;
            InitializeTimer();
            // Установка расположения окна по центру экрана
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // Установка состояния окна на обычное (не развернутое и не свернутое)
            WindowState = WindowState.Normal;
        }
        
        private void Calculator(object sender, RoutedEventArgs e)
        {
            CalculatorWindow calrulatorWindow = new CalculatorWindow();
            calrulatorWindow.Show();
        }
        private void root(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RootMerch());
        }
        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            /*timer.Tick += Timer_Tick;*/
            StartSessionTimer();
        }

        private void StartSessionTimer()
        {
            remainingTimeInSeconds = sessionTimeInMinutes * 60;
            timer.Start();
        }
        /*
        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingTimeInSeconds--;
            if (remainingTimeInSeconds <= 0)
            {
                timer.Stop();
                Application.Current.Shutdown();
            }
            else
            {
                TimerTextBlock.Text = TimeSpan.FromSeconds(remainingTimeInSeconds).ToString(@"mm\:ss");

                if (remainingTimeInSeconds == 2 * 60) // Оповещение за 2 минуты до конца
                {
                    MessageBox.Show("До конца сессии осталось 2 минуты!");
                }
                else if (remainingTimeInSeconds == 60) // Блокировка кнопки за 1 минуту до конца
                {
                    autobnt.Visibility = Visibility.Hidden;
                }
            }
        }
        */
        private void Othet(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ReportPage());
        }
        private void Info(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Info());
        }        
        private void Exit(object sender, RoutedEventArgs e)
        {
            // Закрываем приложение
            Application.Current.Shutdown();
        }
    }
}
