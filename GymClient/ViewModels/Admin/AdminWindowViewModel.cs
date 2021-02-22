using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymClient.Core;

namespace GymClient.ViewModels.Admin
{
    public class AdminWindowViewModel : NotifyPropertyChanged
    {
        private AdminEmployeeViewModel adminEmployeeViewModel;
        public AdminEmployeeViewModel AdminEmployeeViewModel
        {
            get => adminEmployeeViewModel;
            set => SetProperty(ref adminEmployeeViewModel, value);
        }
        private AdminClientViewModel adminClientViewModel;
        public AdminClientViewModel AdminClientViewModel
        {
            get => adminClientViewModel;
            set => SetProperty(ref adminClientViewModel, value);
        }
        private AdminGymViewModel adminGymViewModel;
        public AdminGymViewModel AdminGymViewModel
        {
            get => adminGymViewModel;
            set => SetProperty(ref adminGymViewModel, value);
        }
        public AdminWindowViewModel()
        {
            AdminEmployeeViewModel = new AdminEmployeeViewModel();
            AdminClientViewModel = new AdminClientViewModel();
            AdminGymViewModel = new AdminGymViewModel();
        }
    }
}
