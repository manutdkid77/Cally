using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cally.Views
{
    public partial class MainPage : ContentPage
    {
        bool bscrNamesScrolled = false;
        bool bscrCalScrolled = false;

        public MainPage()
        {
            InitializeComponent();
            scrCal.Scrolled += ScrCal_Scrolled;
            BindCal();
            BindNames();
        }

        private void BindCal()
        {
            for (var i = 0; i < 70; i++)
            {
                var stk = new StackLayout();
                stk.Orientation = StackOrientation.Horizontal;
                for (var j = 0; j < 10; j++)
                {
                    var lbl = new Label()
                    {
                        Text = $"Row{i}, Day {j}",
                        TextColor = Color.Black,
                        BackgroundColor = Color.Yellow
                    };
                    stk.Children.Add(lbl);
                }
                stkCal.Children.Add(stk);
            }
        }

        private void BindNames()
        {
            for (var i = 0; i < 70; i++)
            {
                var lbl = new Label()
                {
                    Text = $"Employee {i}",
                    TextColor = Color.Black,
                    BackgroundColor = Color.Yellow
                };
                stkNames.Children.Add(lbl);
            }
        }

        private async void ScrNames_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (bscrCalScrolled || e.ScrollY <= -1)
                return;

            bscrNamesScrolled = true;

            await scrCal.ScrollToAsync(0, e.ScrollY, true);
            bscrNamesScrolled = false;
        }

        private async void ScrCal_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (bscrNamesScrolled || e.ScrollY <= -1)
                return;
            bscrCalScrolled = true;

            //animation false allows for instant scroll instead of waiting for animation to complete
            await scrNames.ScrollToAsync(0, e.ScrollY, false);
            bscrCalScrolled = false;
        }
    }
}