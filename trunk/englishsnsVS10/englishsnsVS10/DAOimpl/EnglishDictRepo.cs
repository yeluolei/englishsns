using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using englishsnsVS10.DAO;
using englishsnsVS10.datacontext;

namespace englishsnsVS10.DAOimpl
{
    public class EnglishDictRepo /* : englishsnsVS10.DAO.IEnglishDictRepo */
    {   
        private englishdictDataContext db = new englishdictDataContext();
        public IQueryable<explanation> getExplanations(String queryWord) {
            var qresult = from exp in db.explanations
                          where exp.wordname == queryWord
                          select exp;
           return qresult;
        }

        public explanation GetExplanation(int id)
        {
            return db.explanations.SingleOrDefault(e => e.id == id);
        }


        //public List<string> getSentence(string queryWord) {
        //    var qresult = from term in db.terms
        //                  where term.word.theWord == queryWord
        //                  orderby term.id
        //                  select term.sentence;
        //    return qresult.ToList();
        //}
        //public List<string> getTranslate(string queryWord)
        //{
        //    var qresult = from term in db.terms
        //                  where term.word.theWord == queryWord
        //                  orderby term.id
        //                  select term.translate;
        //    return qresult.ToList();
        //}
        //public List<int> getTermID(string queryWord)
        //{
        //    var qresult = from term in db.terms
        //                  where term.word.theWord == queryWord
        //                  orderby term.id
        //                  select term.id;
        //    return qresult.ToList();
        //}

        //public terms getTermbyId(int id)
        //{
        //    return db.terms.Single(d => d.id == id);
        //}

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}