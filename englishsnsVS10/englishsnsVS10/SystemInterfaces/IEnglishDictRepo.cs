using System;
using englishsnsVS10.DAOimpl;
namespace englishsnsVS10.DAO
{
    interface IEnglishDictRepo
    {
        System.Linq.IQueryable<string> getExplanations(string queryWord);
        englishsnsVS10.datacontext.explanation GetExplanation(int id);
        void Save();
    }
    class EnglishDictRepoFactory {
        static EnglishDictRepo instance = null;
        public static EnglishDictRepo getInstance() {
            if (instance==null)
                instance = new EnglishDictRepo();
            return instance;
        }
    }
}
