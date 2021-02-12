using CommonLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GymClient.Helpers
{
    public class NotificationHelper
    {
        public static NotificationHelper Instance { get; set; } = new NotificationHelper();

        public void ShowResponse(ResponseServer response)
        {
            if (response == null || response.IsSuccess == null)
            {
                return;
            }
            if (response.IsSuccess.Value == false)
            {
                MessageBox.Show(response.Message, response.Action, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(response.Message, response.Action, MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
