using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace GameOfLife
{
    class AdWindow : Window
    {
        private Dictionary<string, BitmapImage> imageCache = new Dictionary<string, BitmapImage>();

        private readonly DispatcherTimer adTimer;

        private int currentAdNumber;     // the number of the image currently shown
        private string link;    // the URL where the currently shown ad leads to


        public AdWindow(Window owner)
        {
            Random rnd = new Random();

            Owner = owner;
            Width = Constants.Ads.AdWindowDefaultWidth;
            Height = Constants.Ads.AdWindowDefaultHeight;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.ToolWindow;
            Title = "Support us by clicking the ads";
            Cursor = Cursors.Hand;
            ShowActivated = false;

            MouseDown += OnClick;

            currentAdNumber = rnd.Next(
                Constants.Ads.DefaultAdIndex,
                Constants.Ads.AdContents.Count);
            ChangeAds(this, new EventArgs());

            // Run the timer that changes the ad's image
            adTimer = new DispatcherTimer();
            adTimer.Interval = TimeSpan.FromSeconds(Constants.Ads.DefaultAdSecondsInterval);
            adTimer.Tick += ChangeAds;
            adTimer.Start();
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(link);
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            Unsubscribe();
            base.OnClosed(e);
        }

        public void Unsubscribe()
        {
            MouseDown -= OnClick;
            adTimer.Tick -= ChangeAds;
        }

        private void ChangeAds(object sender, EventArgs eventArgs)
        {
            ImageBrush myBrush = new ImageBrush();
            SwitchAdImage(myBrush);
        }

        private void SwitchAdImage(ImageBrush brush)
        {
            brush.ImageSource = TryGetImageFromCache(currentAdNumber);
            Background = brush;
            link = Constants.Ads.AdContents[currentAdNumber].Url;

            currentAdNumber++;

            if(currentAdNumber == Constants.Ads.AdContents.Count)
            {
                currentAdNumber = Constants.Ads.DefaultAdIndex;
            }
        }

        private BitmapImage TryGetImageFromCache(int adNumber)
        {
            BitmapImage image;

            var fileName = Constants.Ads.AdContents[adNumber].FileName;

            if (!imageCache.TryGetValue(fileName, out image))
            {
                image = new BitmapImage(new Uri(fileName, UriKind.Relative));
                imageCache.Add(fileName, image);
            }

            return image;
        }
    }
}