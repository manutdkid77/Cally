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
        bool bscrCalScrolled = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ScrCal_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (bscrCalScrolled || e.ScrollY <= -1)
                return;
            bscrCalScrolled = true;

            //animation false allows for instant scroll instead of waiting for animation to complete
            await scrNames.ScrollToAsync(0, e.ScrollY, false);
            bscrCalScrolled = false;
        }
    }
}