using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Resources
{
    public static class AppResources
    {
        public static string CulturesPath = @"..\..\..\Singapor.Resources\cultures.json";

        /// <summary>
        /// Parameter requiers language code
        /// </summary>
        public static string TranslationsPath = @"..\..\..\Singapor.Resources\{0}\texts.json";
    }
}
