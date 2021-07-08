using AMAPI;
using AMDataAccess;
using AMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMBAPI
{
    public class WordsService : IWordsService
    {
        private List<Words> _wordsList;

        private WordList _wordsListP;

        public WordsService()
        {
            _wordsList = new List<Words>();
        }

        public Words AddWord(Words word, string conStr)
        {
            WordsDB obj = new WordsDB();
            obj.AddWord(word, conStr);

            return word;
        }

        public Int64 DeleteWord(long id, string conStr)
        {
            WordsDB obj = new WordsDB();
            obj.DeleteWord(id, conStr);

            return id;
        }

        public Words GetWordById(long id, string conStr)
        {
            WordsDB obj = new WordsDB();

            return _wordsList.FirstOrDefault(w => w.ID == id);
        }

        public List<Words> GetWordByPageNo(long id, long cno, string conStr)
        {
            WordsDB obj = new WordsDB();
            _wordsList = (List<Words>)obj.AllwordsByPageNo(id, cno, conStr);

            return _wordsList;
        }

        public List<Words> GetWords(string conStr)
        {
            WordsDB obj = new WordsDB();
            _wordsList = (List<Words>)obj.Allwords(conStr);

            return _wordsList;
        }

        public WordList GetWordsPaginated(long pageIndex, long pageSize, string conStr)
        {
            WordsDB obj = new WordsDB();

            _wordsListP = obj.AllwordsPaginated(pageIndex, pageSize, conStr);

            return _wordsListP;
        }

        public Words TodaysRandomWord(Int64 PageNoNo, Int64 ColNo, string conStr)
        {
            WordsDB obj = new WordsDB();

            return obj.TodaysRandomNum(PageNoNo, ColNo, conStr);
        }

        public Words UpdateWord(Words word, string conStr)
        {
            WordsDB obj = new WordsDB();
            obj.EditWord(word, conStr);

            return word;
        }

        public IEnumerable<PageNos> GetPageNos(string conStr)
        {
            return WordsDB.GetAllPageNos();
        }

        public IEnumerable<ColNos> GetColNos(string conStr)
        {
            return WordsDB.GetAllColNos();
        }

        public Int64 ResetSeen(string constr)
        {
            WordsDB obj = new WordsDB();
            return obj.ResetWordSeen(constr);
        }

        public Int64 ToBeSeen(Int64 PageNoNo, Int64 ColNo, string conStr)
        {
            WordsDB obj = new WordsDB();

            return obj.ToBeSeen(PageNoNo, ColNo, conStr);
        }


    }
}
