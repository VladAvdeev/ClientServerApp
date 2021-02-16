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
    public class ClubViewModel : NotifyPropertyChanged, IPageViewModel
    {
        public string ClubName { get; set; } = "Первый";
        private Gym selectedGym;
        public Gym SelectedGym
        {
            get => selectedGym;
            set
            {
                SetProperty(ref selectedGym, value);
                Id = SelectedGym?.Id;
                Adress = SelectedGym?.Adress;
            }
        }
        //GymServer gymClient;
        //private List<Gym> gyms;
        //public List<Gym> Gyms
        //{
        //    get => gyms;
        //    set => SetProperty(ref gyms, value);
        //}
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
    }
}
