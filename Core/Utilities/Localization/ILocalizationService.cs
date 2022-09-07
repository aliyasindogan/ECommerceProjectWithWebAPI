using Core.Utilities.Messages;

namespace Core.Utilities.Localization
{
    public interface ILocalizationService
    {
        string this[string Resourcekey] { get; }
        string this[ResultCodes nResourcekey] { get; }
        int IsLanguage(string languageCode);
    }
}