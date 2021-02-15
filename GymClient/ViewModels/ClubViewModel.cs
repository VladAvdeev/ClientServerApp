using GymClient.Core;
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
    }
}
