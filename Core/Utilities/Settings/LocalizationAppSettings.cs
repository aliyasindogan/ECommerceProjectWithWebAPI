using Core.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;

namespace Core.Utilities.Settings
{
    public class LocalizationAppSettings
    {
        private Dictionary<string, string> _cultures;
        private string _localizations;
        public string BaseUrl { get; set; }
        public LocalizationAppSettings()
        {
            _cultures = new Dictionary<string, string>();
        }

        public string Localizations
        { get { return _localizations; } set { _localizations = value; ParseLocalizations(); } }

        public Dictionary<string, string> Cultures
        { get { return _cultures; } }

        private void ParseLocalizations()
        {
            //en=en-US;en-US=en-US;tr=tr-TR;tr-TR=tr-TR
            string[] languages = _localizations.Split(';');
            if (languages == null || languages.Count() == 0)
            {
                _cultures.Add(Constants.LangEN.ToLower(), Constants.LangEN);
                _cultures.Add(Constants.LangTR.ToLower(), Constants.LangTR);
            }
            foreach (var item in languages)
            {
                string[] keyval = item.Split('=');
                if (keyval.Count() == 2)
                    _cultures.Add(keyval[0].ToLower(), keyval[1]);
            }
        }
    }
}