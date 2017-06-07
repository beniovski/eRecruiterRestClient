using Autofac;
using eRecruiterRestClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruiterRestClient.IoC
{
    class AutoFacConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthToken>().As<IAuthToken>().SingleInstance();
            builder.RegisterType<ErecruiterAction>().As<IErecruiterAction>();
            builder.Build();
        }


             

    


    }
}
