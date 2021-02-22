using CommonLibrary.Models;
using GymClient.ClientsREST;
using GymClient.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymClient.ViewModels.Admin
{
    public class AdminClientViewModel : NotifyPropertyChanged, IPageViewModel
    {
        ClientsServer adminClient;
        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set => SetProperty(ref clients, value);
        }
        private Client selectedClient;
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                SetProperty(ref selectedClient, value);
                Id = SelectedClient?.Id;
                FirstName = SelectedClient?.FirstName;
                LastName = SelectedClient?.LastName;
                Birthday = SelectedClient.Birthday;
                Phone = selectedClient?.Phone;
                Email = SelectedClient?.Email;
                ClientId = SelectedClient.ClientId;
                GymTicketId = SelectedClient.GymTickettId;
                ClubClientId = SelectedClient.ClubClientId;
            }
            
        }
        private int? id;
        public int? Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }
        private string lastName;
        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }
        private DateTime birthday;
        public DateTime Birthday
        {
            get => birthday;
            set => SetProperty(ref birthday, value);
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
        private int clientId;
        public int ClientId 
        { 
            get => clientId;
            set => SetProperty(ref clientId, value);
        }
        private int gymTicketId;
        public int GymTicketId
        {
            get => gymTicketId;
            set => SetProperty(ref gymTicketId, value);
        }
        private int clubClientId;
        public int ClubClientId
        {
            get => clubClientId;
            set => SetProperty(ref clubClientId, value);
        }
        public ICommand RefreshCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand ChangeCommand { get; }
        public ICommand OpenWinCommand { get; }
        public AdminClientViewModel()
        {
            adminClient = new ClientsServer();
            RefreshCommand = new Command(Refresh);
        }
        private void Refresh()
        {
            Clients = new ObservableCollection<Client>(adminClient.GetClients());
        }
    }
}
