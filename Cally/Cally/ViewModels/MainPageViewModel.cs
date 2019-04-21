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

        Random rnd = new Random();

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Work Schedule";
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
                for(var i = 1; i <= 100; i++)
                {
                    lstEmployee.Add(new Employee()
                    {
                        ID = i,
                        Name = $"Employee {i}",
                        Schedule = GenerateRandomSchedule()
                    });
                }
                obsEmployee = new ObservableCollection<Employee>(lstEmployee);
            }
            catch(Exception ex)
            {

            }
        }
        
        private Schedule GenerateRandomSchedule()
        {
            var lstRandomSchedule = new List<Schedule>()
            {
                new Schedule()
                {
                    Monday = "Unavailable",
                    Tuesday = "Manager",
                    Wednesday = "Manager",
                    Thursday = "Manager",
                    Friday = "Manager",
                    Saturday = "Holiday",
                    Sunday = "Holiday"
                },
                new Schedule()
                {
                    Monday = "Manager",
                    Tuesday = "Front Desk",
                    Wednesday = "Holiday",
                    Thursday = "Supervisor",
                    Friday = "Floor",
                    Saturday = "Holiday",
                    Sunday = "Holiday"
                },
                new Schedule()
                {
                    Monday = "Floor",
                    Tuesday = "Floor",
                    Wednesday = "Supervisor",
                    Thursday = "Supervisor",
                    Friday = "Holiday",
                    Saturday = "Half Day",
                    Sunday = "Holiday"
                },
                new Schedule()
                {
                    Monday = "Team Lead",
                    Tuesday = "Manager",
                    Wednesday = "Team Lead",
                    Thursday = "Inventory",
                    Friday = "Unavailable",
                    Saturday = "Holiday",
                    Sunday = "Holiday"
                },
                new Schedule()
                {
                    Monday = "Floor",
                    Tuesday = "Floor",
                    Wednesday = "Inventory",
                    Thursday = "Manager",
                    Friday = "Holiday",
                    Saturday = "Holiday",
                    Sunday = "Manager"
                },
            };
            var iRandomNo = rnd.Next(0, 4);
            return lstRandomSchedule[iRandomNo];
        }
    }
}
