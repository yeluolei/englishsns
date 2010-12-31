using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using englishsnsVS10.datacontext;
namespace englishsnsVS10.Models
{
    public class LookUpWordResult
    {
        public LookUpWordResult(string _word, IQueryable<explanation> exps)
        {
            this.explanations = exps;
            this.queryWord = _word;
        }
        public IQueryable<explanation> explanations
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
