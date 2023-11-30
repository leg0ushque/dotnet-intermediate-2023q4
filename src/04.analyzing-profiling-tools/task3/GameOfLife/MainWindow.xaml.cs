﻿using System;
using System.Windows;
using System.Windows.Threading;

namespace GameOfLife
{
    public partial class MainWindow : Window
    {
        private Grid mainGrid;
        DispatcherTimer timer;   //  Generation timer
        private int genCounter;
        private AdWindow[] adWindow;

        public MainWindow()
        {
            InitializeComponent();
            mainGrid = new Grid(MainCanvas);
            adWindow = new AdWindow[Constants.Ads.AdContents.Count];

            timer = new DispatcherTimer();
            timer.Tick += OnTimer;
            timer.Interval = TimeSpan.FromMilliseconds(
                Constants.GameOfLifeOptions.MillisecondsTickInterval);
        }

        private void StartAd()
        {
            for (int i = 0; i < Constants.Ads.AdContents.Count; i++)
            {
                if (adWindow[i] != null)
                {
                    continue;
                }

                adWindow[i] = new AdWindow(this);
                adWindow[i].Top = this.Top + (330 * i) + 70;
                adWindow[i].Left = this.Left + 240;

                adWindow[i].Closed += AdWindowOnClosed;

                adWindow[i].Show();
            }
        }

        private void AdWindowOnClosed(object sender, EventArgs eventArgs)
        {
            var closedWindow = sender as AdWindow;

            closedWindow.Closed -= AdWindowOnClosed;
            adWindow[Array.IndexOf(adWindow, closedWindow)] = null;
        }

        private void Button_OnClick(object sender, EventArgs e)
        {
            if (!timer.IsEnabled)
            {
                timer.Start();
                ButtonStart.Content = "Stop";
                StartAd();
            }
            else
            {
                timer.Stop();
                ButtonStart.Content = "Start";
            }
        }

        private void OnTimer(object sender, EventArgs e)
        {
            mainGrid.Update();
            genCounter++;
            lblGenCount.Content = $"Generations: {genCounter}";
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Clear();
        }

        protected override void OnClosed(EventArgs e)
        {
            timer.Tick -= OnTimer;
            mainGrid.UnsubscribeCellsVisuals();

            base.OnClosed(e);
        }
    }
}
