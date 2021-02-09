using System.Collections.Generic;

namespace IdentityStore.Core.Mailing.Implementation.Templates.Shared
{
    public static class RazorHelperExtensions
    {
        private static readonly Dictionary<string, string> TranslateAnd = new Dictionary<string, string> { { "en", " and " }, { "nl", " en " }, { "fr", " et " }, { "de", " und " } };

        public static string WriteOutApplicationListCustomText(IList<string> applications, string language)
        {
            var appCounter = 1;
            var appTotal = applications.Count;
            string applicationInfo = default;
            foreach (var application in applications)
            {
                if (appCounter.Equals(appTotal))
                {
                    applicationInfo += TranslateAnd[language.ToLower()];
                }
                if (!appCounter.Equals(appTotal) && !appCounter.Equals(1))
                {
                    applicationInfo += ", ";
                }
                applicationInfo += application;
                appCounter++;
            }
            return applicationInfo;
        }

        public static string WriteOutApplicationListHtml(IList<string> applications, string language)
        {
            var appCounter = 1;
            var appTotal = applications.Count;
            string applicationInfo = default;
            foreach (var application in applications)
            {
                if (appCounter.Equals(appTotal))
                {
                    applicationInfo += TranslateAnd[language.ToLower()];
                }
                if (!appCounter.Equals(appTotal) && !appCounter.Equals(1))
                {
                    applicationInfo += ", ";
                }
                applicationInfo += "<span class=\"blurrable bold\">" + application + "</span>";
                appCounter++;
            }
            return applicationInfo;
        }
    }
}
