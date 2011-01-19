using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using englishsnsVS10.datacontext;
using englishsnsVS10.SystemInterfaces;

namespace englishsnsVS10.DAOimpl
{
    public class EnglishDictRepo : IEnglishDictRepo 
    {   
        private englishdictDataContext db = new englishdictDataContext();


        public IQueryable<explanation> getExplanations(String queryWord) {
            var qresult = from exp in db.explanations
                          where exp.wordname == queryWord && exp.active == 1                  
                          select exp;
           return qresult;
        }

        public explanation GetExplanation(int id)
        {
            return db.explanations.SingleOrDefault(e => e.id == id);
        }


        public void AddExplanation(explanation ex)
        {
            db.explanations.InsertOnSubmit(ex);
        }

        public IQueryable<explanation> GetHistory(explanation ex)
        {
            IQueryable<explanation> history;
            if (ex.reference != -1)
            {
                history = from e in db.explanations
                          where (e.reference == ex.reference && ex.wordname == e.wordname && e.active != -1) || ( e.reference == -1 && e.id == ex.reference)
                          select e;
            }
            else
            {
                history = from e in db.explanations
                          where (e.reference == ex.id || e.id == ex.id) && e.active != -1
                          select e;
            }
            return history;
        }

        public void DeleteExplanation(explanation ex)
        {
            db.explanations.DeleteOnSubmit(ex);
        }

        public explanation GetRootExplanation(explanation ex)
        {
            if (ex.reference != -1)
                return db.explanations.SingleOrDefault(e => e.reference == -1 && e.id == ex.reference);
            else
                return ex;
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