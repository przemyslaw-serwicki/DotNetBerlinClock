using Autofac;
using BerlinClock.Classes.Parser;
using BerlinClock.Classes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Common
{
    public static class AutoFacRegistration
    {
        public static IContainer RetrieveAutofacContainer()
        {
            var builder = new ContainerBuilder();
            AutoFacRegistration.RegisterTypes(builder);

            return builder.Build();
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<TimeValidator>().As<ITimeValidator>();
            builder.RegisterType<TimeParser>().As<ITimeParser>();
        }
    }
}
