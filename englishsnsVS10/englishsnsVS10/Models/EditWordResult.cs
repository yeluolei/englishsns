using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace englishsnsVS10.Models
{
    public class EditWordResult
    {
        public EditWordResult(String _word, List<string> _sentence, List<string> _trans, List<int> _ids)
        {
            queryWord = _word;
            sentence = _sentence;
            translate = _trans;
            ids = _ids;
        }
        public List<string> sentence
        {
            get;
            private set;
        }
        public List<string> translate
        {
            get;
            private set;
        }
        public List<int> ids
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