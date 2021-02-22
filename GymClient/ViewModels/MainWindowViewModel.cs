using GymClient.Core;
using GymClient.Entities;
using GymClient.Services;
using GymClient.ViewModels.Admin;
using GymClient.Views.Admin;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymClient.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private IPageViewModel currentPageViewModel;
        private IWindowService windowService;
        public ICommand ChangePageCommand { get; }
        public ICommand OpenAdminWindowCommand { get; }
        public List<IPageViewModel> PageViewModels { get; set; }

        public MainWindowViewModel()
        {

            windowService = NinjectDI.Instanse.Get<IWindowService>();

            InitPages();
            CurrentPageViewModel = PageViewModels[0];
            ChangePageCommand = new Command((x) => ChangeViewModel(Convert.ToInt32(x)));
            OpenAdminWindowCommand = new Command(OpenAdminWindow);
        }

        private void InitPages()
        {
            PageViewModels = new List<IPageViewModel>()
            {
              new HomeViewModel(),
              new ClubViewModel(),
              new Club2ViewModel(),
              new Club3ViewModel(),
              new ClientViewModel(),
              new ScheduleViewModel()
            };
        }


        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return currentPageViewModel;
            }
            set
            {
                if (currentPageViewModel != value)
                {
                    currentPageViewModel = value;
                    SetProperty(ref currentPageViewModel, value);
                }
            }
        }

        private void OpenAdminWindow()
        {
            windowService.Show(new AdminWindowView(), new AdminWindowViewModel());
        }

        private void ChangeViewModel(int viewModel)
        {
            CurrentPageViewModel = PageViewModels.ElementAt(viewModel);
        }
    }
}
