using AMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMAPI
{
    public interface IWordsService
    {
        public List<Words> GetWords(string conStr);

        public WordList GetWordsPaginated(Int64 pageIndex, Int64 pageSize, string constr);

        public Words GetWordById(Int64 id, string conStr);
        public List<Words> GetWordByPageNo(Int64 id, Int64 cno, string conStr);
        public Words TodaysRandomWord(Int64 PageNoNo, Int64 ColNo, string conStr);
        public Words AddWord(Words word, string conStr);
        public Words UpdateWord(Words words, string conStr);
        public Int64 DeleteWord(Int64 id, string conStr);

        public Int64 ResetSeen(string constr);

        public Int64 ToBeSeen(Int64 PageNoNo, Int64 ColNo, string conStr);

        public IEnumerable<PageNos> GetPageNos(string conStr);

        public IEnumerable<ColNos> GetColNos(string conStr);

    }
}
