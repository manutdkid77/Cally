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
            scrNames.Scrolled += ScrNames_Scrolled;
            scrCal.Scrolled += ScrCal_Scrolled;
            BindEmployeeNames();
            BindCalendar();
        }

        private async void ScrNames_Scrolled(object sender, ScrolledEventArgs e)
        {
            try
            {
                if (bscrCalScrolled || e.ScrollY <= -1)
                    return;

                bscrNamesScrolled = true;

                await scrCal.ScrollToAsync(0, e.ScrollY, true);
            }
            finally
            {
                bscrNamesScrolled = false;
            }
        }

        private async void ScrCal_Scrolled(object sender, ScrolledEventArgs e)
        {
            try
            {
                if (bscrNamesScrolled || e.ScrollY <= -1)
                    return;
                bscrCalScrolled = true;

                await scrNames.ScrollToAsync(0, e.ScrollY, true);
            }
            finally
            {
                bscrCalScrolled = false;
            }
        }

        private void BindEmployeeNames()
        {
            try
            {
                for (var i = 1; i <= 40; i++)
                {
                    stkEmpNames.Children.Add(new Label()
                    {
                        Text = $"Employee {i}",
                        TextColor = Color.Black,
                        LineBreakMode = LineBreakMode.TailTruncation,
                        WidthRequest = 50,
                        HeightRequest = 16
                    });
                    stkEmpNames.Children.Add(new BoxView()
                    {
                        Color = Color.Black,
                        HeightRequest = 0.5,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BindCalendar()
        {
            try
            {
                for (var i = 1; i <= 280; i++)
                {
                    var lbl = new Label()
                    {
                        Text = $"Item{i}",
                        TextColor = Color.Black,
                        HeightRequest = 16
                    };
                    flxCal.Children.Add(lbl);
                    FlexLayout.SetGrow(lbl, 1);
                    FlexLayout.SetShrink(lbl, 0);
                    FlexLayout.SetBasis(lbl, new FlexBasis(50f));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnHorScrl_Clicked(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void btnVerScrl_Clicked(object sender, EventArgs e)
        {
            try
            {
                //scrlVwParent.InputTransparent = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}