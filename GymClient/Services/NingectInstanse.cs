using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace GymClient.Services
{
    public class NinjectDI
    {
        static public IKernel Instanse { get; private set; } = new StandardKernel(new DiConfigModule());
        public NinjectDI()
        {

        }
        
    }
}
