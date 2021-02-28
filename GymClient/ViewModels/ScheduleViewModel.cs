using CommonLibrary.Models;
using CommonLibrary1;
using GymClient.ClientsREST;
using GymClient.Core;
using GymClient.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymClient.ViewModels
{
    
    public class ScheduleViewModel : NotifyPropertyChanged, IPageViewModel
    {
        ScheduleServer scheduleServer;
        private ObservableCollection<TimeSport> timeSports;
        public ObservableCollection<TimeSport> TimeSports
        {
            get => timeSports;
            set => SetProperty(ref timeSports, value);
        }
        private TimeSport selectedTimeSport;
        public TimeSport SelectedTimeSport
        {
            get => selectedTimeSport;
            set
            {
                SetProperty(ref selectedTimeSport, value);
                Id = SelectedTimeSport?.Id;
                FromTo = SelectedTimeSport?.FromTo;
                TimeForClub = SelectedTimeSport?.TimeForClub;
            }
        }
        private int? id;
        public int? Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        private string fromTo;
        public string FromTo
        {
            get => fromTo;
            set => SetProperty(ref fromTo, value);
        }
        private int? timeForClub;
        public int? TimeForClub
        {
            get => timeForClub;
            set => SetProperty(ref timeForClub, value);
        }
        public ICommand RefreshCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand ChangeCommand { get; }
        public ICommand OpenWinCommand { get; }
        public ScheduleViewModel()
        {
            scheduleServer = new ScheduleServer();
            RefreshCommand = new Command(Refresh);
            AddCommand = new Command(Add, () => SendCondition());
            DeleteCommand = new Command(Delete, () => SelectedTimeSport != null);
            ChangeCommand = new Command(Update, () => SendCondition());

        }
        private void Refresh()
        {
            TimeSports = new ObservableCollection<TimeSport>(scheduleServer.GetTimes());
        }
        private void Add()
        {
            TimeSport time = new TimeSport() { Id = Id.Value, FromTo = FromTo, TimeForClub = TimeForClub.Value };
            ResponseServer response = scheduleServer.AddTime(time);
            NotificationHelper.Instance.ShowResponse(response);
            Refresh();
        }
        private void Delete()
        {
            ResponseServer response = scheduleServer.DeleteTime(SelectedTimeSport.Id);
            SelectedTimeSport = null;
            NotificationHelper.Instance.ShowResponse(response);
            Refresh();
        }
        private void Update()
        {
            TimeSport time = new TimeSport()
            {
                Id = Id.Value,
                FromTo = FromTo,
                TimeForClub = TimeForClub.Value
            };
            ResponseServer response = scheduleServer.UpdateTime(time);
            NotificationHelper.Instance.ShowResponse(response);
            Refresh();
        }
        private bool SendCondition()
        {
            return SelectedTimeSport != null;
        }
        
    }
}
