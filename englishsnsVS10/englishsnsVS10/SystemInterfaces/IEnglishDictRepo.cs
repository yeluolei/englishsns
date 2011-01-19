using System;
namespace englishsnsVS10.SystemInterfaces
{
    public interface IEnglishDictRepo
    {
        void AddExplanation(englishsnsVS10.datacontext.explanation ex);
        void DeleteExplanation(englishsnsVS10.datacontext.explanation ex);
        englishsnsVS10.datacontext.explanation GetExplanation(int id);
        System.Linq.IQueryable<englishsnsVS10.datacontext.explanation> getExplanations(string queryWord);
        System.Linq.IQueryable<englishsnsVS10.datacontext.explanation> GetHistory(englishsnsVS10.datacontext.explanation ex);
        englishsnsVS10.datacontext.explanation GetRootExplanation(englishsnsVS10.datacontext.explanation ex);
        void Save();
    }
}
