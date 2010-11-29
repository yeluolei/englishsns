using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace englishsnsVS10.Models
{
    public class LookUpWordResult
    {
        public LookUpWordResult(String _word,List<String> _exps) {
            queryWord = _word;
            explanations = _exps;
        }
        public List<String> explanations
        {
            get;
            private set;
        }
        public String queryWord
        {
            get;
            private set;
        }

    }
}
