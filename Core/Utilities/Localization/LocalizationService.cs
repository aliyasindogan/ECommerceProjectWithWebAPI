using System;
using Core.Localize;
using Core.Utilities.Messages;
using Microsoft.Extensions.Localization;

namespace Core.Utilities.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private IStringLocalizer<Resource> _stringLocalizer;

        public LocalizationService(IStringLocalizer<Resource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public string this[string key]
        {
            get
            {
                return _stringLocalizer[key];
            }
        }


        public string this[ResultCodes nkey]
        {
            get
            {
                return this[nkey.ToString()];
            }
        }
        public int IsLanguage(string languageCode)
        {
            if (languageCode == "tr-TR")
                return 1;//tr-TR
            else
                return 2;//en-US
        }
    }
}