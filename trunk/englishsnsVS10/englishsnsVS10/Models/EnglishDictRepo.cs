using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace englishsnsVS10.Models
{
    public class EnglishDictRepo
    {   
        private englishdictDataContext db = new englishdictDataContext();
        public List<String> getExplanations(String queryWord) {
//             var qresult = from wd in db.words
//                     where wd.theWord == queryWord
//                     select wd.explanations.;
           var qresult = from exp in db.explanations
                     where exp.word.theWord==queryWord
                     select exp.theExplanation;
           return qresult.ToList();
        }
    }
}