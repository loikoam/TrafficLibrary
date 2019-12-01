using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testService.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookServices>().To<BookServices>();
        }
    }
}
