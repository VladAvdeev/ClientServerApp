﻿using GymClient.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymClient.ViewModels
{
    public class ClientViewModel : NotifyPropertyChanged, IPageViewModel
    {
        public string Client { get; set; } = "Клиент";
    }
}
