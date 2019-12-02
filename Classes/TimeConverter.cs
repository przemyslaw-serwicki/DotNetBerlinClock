using Autofac;
using BerlinClock.Classes.Common;
using BerlinClock.Classes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeValidator timeValidator;

        public TimeConverter()
        {
            IContainer container = AutoFacRegistration.RetrieveAutofacContainer();

            this.timeValidator = container.Resolve<ITimeValidator>();
        }

        public string convertTime(string aTime)
        {
            var a = this.timeValidator.ValidateEntry("s");
            return "ready";
        }
    }
}
