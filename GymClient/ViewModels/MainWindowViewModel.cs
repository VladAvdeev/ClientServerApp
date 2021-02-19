using GymClient.Core;
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
        public ICommand ChangePageCommand { get; }
        public List<IPageViewModel> PageViewModels { get; set; }

        public MainWindowViewModel()
        {
            InitPages();
            CurrentPageViewModel = PageViewModels[0];
            ChangePageCommand = new Command((x) => ChangeViewModel(Convert.ToInt32(x)));
        }

        private void InitPages()
        {
            PageViewModels = new List<IPageViewModel>()
            {
              new HomeViewModel(),
              new ClubViewModel(),
              new Club2ViewModel(),
              new Club3ViewModel(),
              new AdminViewModel(),
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

        private void ChangeViewModel(int viewModel)
        {
            CurrentPageViewModel = PageViewModels.ElementAt(viewModel);
        }
    }
}
