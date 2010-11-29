using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace englishsnsVS10.Models
{
    public class EnglishDictRepo
    {   
        private englishdictDataContext db = new englishdictDataContext();
        public List<String> getExplanation(String queryWord) {
           var  qresult = from ex in db.explanations
                          from wd in db.words
                          where ex.word_id==wd.id && wd.theWord==queryWord
                          select ex.theExplanation;
           return qresult.ToList();
        }
    }
}