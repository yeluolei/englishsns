using System;
namespace englishsnsVS10.DAO
{
    interface IEnglishDictRepo
    {
        System.Linq.IQueryable<string> getExplanations(string queryWord);
        void Save();
    }
}
