using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Singapor.Common.Contexts;
using Singapor.Resources.Providers;
using Singapor.Services.Abstract;

namespace Singapor.Services.Services
{
    public class TranslationsService : ITranslationsService
    {
        private readonly IUserSettingsContext _userSettingsContext;
        private readonly string _translationsJson;

        public TranslationsService(IUserSettingsContext userSettingsContext, ITranslationsProvider translationsProvider)
        {
            _userSettingsContext = userSettingsContext;
            _translationsJson = translationsProvider.GetTranslations(_userSettingsContext.LanguageCode);
        }

        public string GetTranslations()
        {
            return _translationsJson;
        }

        public string GetTranslationByKey(string key)
        {
            var data = (JObject)JsonConvert.DeserializeObject(_translationsJson);

            var translation = data.SelectToken(key, false);
            if (translation == null)
                return $"#no translation - key: {key}";

            return translation.Value<string>();
        }
    }
}
