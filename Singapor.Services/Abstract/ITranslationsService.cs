namespace Singapor.Services.Abstract
{
    public interface ITranslationsService
    {
        string GetTranslations();
        string GetTranslationByKey(string key);
    }
}