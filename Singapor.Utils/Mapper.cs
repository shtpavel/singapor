using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Utils
{
    public class Mapper
    {
        public static TTo Map<TFrom, TTo>(TFrom from, TTo to)
        {
            var fromProperties = from.GetType().GetProperties();
            var toProperties = to.GetType().GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                var toProperty = toProperties.FirstOrDefault(x => x.Name == fromProperty.Name);
                if (toProperty == null)
                    continue;
                
                toProperty.SetValue(to, fromProperty.GetValue(from));
            }

            return to;
        }
    }
}
