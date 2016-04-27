using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Common.Contexts
{
    public class UserSettingsContext : IUserSettingsContext, IUserSettingsContextSettable
    {
        private string _languageCode;

        public string LanguageCode
        {
            get { return _languageCode ?? "en-US"; }
            set { _languageCode = value; }
        }
    }

    public interface IUserSettingsContextSettable
    {
        string LanguageCode { get; set; }
    }

    public interface IUserSettingsContext
    {
        string LanguageCode { get; }
    }
}
