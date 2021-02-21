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
        public AdminWindowViewModel()
        {
            AdminEmployeeViewModel = new AdminEmployeeViewModel();
        }
    }
}
