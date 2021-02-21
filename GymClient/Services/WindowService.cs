using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;

namespace GymClient.Services
{
    public interface IWindowService
    {
        void Show(Window window, object dataContext);
        bool ShowDialog(Window window, object dataContext);
        bool ShowDialogEffect(Window window, object dataContext);

    }
    public class WindowService : IWindowService
    {
        private Window GetDefaultOwner()
        {
            return Application.Current.Windows.OfType<Window>().SingleOrDefault(window => window.IsActive);
        }
        public void Show(Window window, object dataContext)
        {
            window.DataContext = dataContext;
            window.Show();
        }

        public bool ShowDialog(Window window, object dataContext)
        {
            window.DataContext = dataContext;
            window.Owner = GetDefaultOwner();
            return window.ShowDialog() == true;
        }

        public bool ShowDialogEffect(Window window, object dataContext)
        {
            window.DataContext = dataContext;
            window.Owner = GetDefaultOwner();
            BlurEffect effect = new BlurEffect();
            effect.Radius = 6;
            window.Owner.Effect = effect;        
            bool ret = window.ShowDialog() == true;
            window.Owner.Effect = null;
            return ret;
        }
    }
}
