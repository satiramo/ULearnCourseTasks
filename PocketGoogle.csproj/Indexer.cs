using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PocketGoogle
{
    public class Indexer : IIndexer
    {
        public Indexer()
        {
            Indexes = new Dictionary<string, List<int>>();
            TextDictionary = new Dictionary<int, string>();
        }
        public Dictionary<string, List<int>> Indexes { get; set; }
        public Dictionary<int,string> TextDictionary { get; set; }
        public void Add(int id, string documentText)
        {

            if (!TextDictionary.ContainsKey(id))            
                TextDictionary.Add(id, documentText);
            var splittedTextArray = documentText.Split(' ', '.', ',', '!', '?', ':', '-','\r','\n');
            foreach (var word in splittedTextArray)
            {
                if(word!="")
                    if (!Indexes.ContainsKey(word))
                        Indexes.Add(word, new List<int>() { id });
                    else
                        if (!Indexes[word].Contains(id))
                            Indexes[word].Add(id);
            }
        }

        public List<int> GetIds(string word)
        {
            if (Indexes.ContainsKey(word))
                return Indexes[word];
            else
                return new List<int>(0);
        }
        private void FindPositions(List<int> positionsList, string text, string word, int start)
        {
            var wordPosition = text.IndexOf(word, start);
            if (wordPosition != -1)
            {
                positionsList.Add(wordPosition);
                if (wordPosition + word.Length + 1 <= text.Length)
                    FindPositions(positionsList, text, word, wordPosition + word.Length + 1);
                else
                    return;
            }
            else
                return;
        }

        public List<int> GetPositions(int id, string word)
        {
            var firstCheck = Indexes.ContainsKey(word) ? true : false;
            var secondCheck = (firstCheck) ? (Indexes[word].Contains(id) ? true : false) : false;
            var resultList = new List<int>(0);
            if (secondCheck)
            {
                var text = string.Copy(TextDictionary[id]);
                FindPositions(resultList, text, word, 0);                
            }
            return resultList;
        }

        public void Remove(int id)
        {
            for (var i = 0; i < Indexes.Count; i++)
            {
                var indexKey = Indexes.Keys.ElementAtOrDefault(i);
                if (!String.IsNullOrEmpty(indexKey))
                {
                    var indexValue = Indexes[indexKey];
                    if(indexValue.Contains(id))
                        indexValue.Remove(id);
                    if (Indexes[indexKey].Count == 0)
                    {
                        Indexes.Remove(indexKey);
                        i--;
                    }
                }
            }           
        }
    }
}
