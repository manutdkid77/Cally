using Cally.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Cally.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> _obsEmployee;
        public ObservableCollection<Employee> obsEmployee
        {
            get { return _obsEmployee; }
            set { SetProperty(ref _obsEmployee, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            BindData();
        }

        private void BindData()
        {
            try
            {
                var lstEmployee = new List<Employee>();
                for(var i = 1; i <= 40; i++)
                {
                    lstEmployee.Add(new Employee()
                    {
                        ID = i,
                        Name = $"Employee {i}",
                        Schedule = new Schedule()
                        {
                            Monday = "Work",
                            Tuesday = "Work",
                            Wednesday = "Work",
                            Thursday = "HalfDay",
                            Friday = "Holiday",
                            Saturday = "Holiday",
                            Sunday = "Easter"
                        }
                    });
                }
                obsEmployee = new ObservableCollection<Employee>(lstEmployee);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
