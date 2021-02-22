using CommonLibrary1.Models;
using GymClient.Core;
using GymClient.RestClients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymClient.ViewModels.Admin
{
    public class AdminGymViewModel : NotifyPropertyChanged
    {
        GymServer gymServer;
        private ObservableCollection<Gym> gyms;
        public ObservableCollection<Gym> Gyms
        {
            get => gyms;
            set => SetProperty(ref gyms, value);
          
        }
        private Gym selectedGym;
        public Gym SelectedGym
        {
            get => selectedGym;
            set
            {
                SetProperty(ref selectedGym, value);
                Id = SelectedGym?.Id;
                Adress = SelectedGym.Adress;
                Phone = SelectedGym.Phone;
                Email = SelectedGym.Email;
            }
        }
        private int? id;
        public int? Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        private string adress;
        public string Adress
        {
            get => adress;
            set => SetProperty(ref adress, value);
        }
        private string phone;
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }
        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public ICommand RefreshCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand ChangeCommand { get; }
        public ICommand OpenWinCommand { get; }
        public AdminGymViewModel()
        {
            gymServer = new GymServer();
            RefreshCommand = new Command(Refresh);
        } 
        private void Refresh()
        {
            Gyms = new ObservableCollection<Gym>(gymServer.GetGyms());
        }
    }
}
