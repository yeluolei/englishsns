﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using englishsnsVS10.DAO;
namespace englishsnsVS10.DAOimpl
{
    public class EnglishDictRepo : englishsnsVS10.DAO.IEnglishDictRepo 
    {   
        private englishdictDataContext db = new englishdictDataContext();
        public IQueryable<String> getExplanations(String queryWord) {
//             var qresult = from wd in db.words
//                     where wd.theWord == queryWord
//                     select wd.explanations.;
            var qresult = from exp in db.explanations
                          where exp.wordname == queryWord
                          select exp.expcontent;
           return qresult;
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