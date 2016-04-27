using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Resources.Providers
{
    public class TranslationsProvider : ITranslationsProvider
    {
        public string GetTranslations(string lang)
        {
            var pathToTranslation = string.Format(AppResources.TranslationsPath, lang);
            if (File.Exists(pathToTranslation))
                return File.ReadAllText(pathToTranslation);

            return String.Empty;
        }
    }
}
