using Foxentold.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxentold.Links
{
    public class Settings
    {
        private LanguageCode languageCode = LanguageCode.EN;

        public LanguageCode LanguageCode { get { return languageCode; } set { this.languageCode = value; } }

        public Settings(LanguageCode code)
        {
            languageCode = code;
        }
    }
}
