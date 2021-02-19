using CommonLibrary1.Models;
using GymClient.Core;
using GymClient.RestClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymClient.ViewModels
{
    public class Club2ViewModel : NotifyPropertyChanged, IPageViewModel
    {
        GymServer gymServer;
        private Gym gym;
        public Gym Gym
        {
            get => gym;
            set => SetProperty(ref gym, value);
        }
        private string clubName;
        public string ClubName
        {
            get => clubName;
            set => SetProperty(ref clubName, value);
        }
        public Club2ViewModel()
        {
            gymServer = new GymServer();
        }
       
    }
}
