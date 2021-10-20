using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCloudWPF
{
    public class LanguageUtility
    {
        private IDictionary<string, IDictionary<string, string>> languageData;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageUtility"/> class.
        /// </summary>
        public LanguageUtility()
        {
            this.languageData = new Dictionary<string, IDictionary<string, string>>();
        }

        public void AddLanguageData(string languageKey, string key, string value)
        {
            var dict = new Dictionary<string, string>();
            dict.Add(key, value);
            this.languageData.Add(languageKey, dict);
        }

    }
}
