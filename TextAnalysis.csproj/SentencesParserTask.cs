using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentencesSeparator = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            var sentenceLength = 0;
            var digitCount = 0;
            var currentWord = new StringBuilder();
            char currentDigit;

            foreach (var sentence in text.Split(sentencesSeparator))
            {
                var WordList = new List<string>();
                sentenceLength = sentence.Length;
                digitCount = 0;
                currentWord.Clear();
                while (digitCount < sentenceLength)
                {
                    currentDigit = sentence[digitCount];
                    if (char.IsLetter(currentDigit) || currentDigit == '\'')
                    {
                        currentWord.Append(char.ToLower(currentDigit));
                        if (digitCount + 1 == sentenceLength)
                        {
                            WordList.Add(currentWord.ToString());
                            currentWord.Clear();
                        }
                    }
                    else
                    {
                        if (currentWord.Length > 0)
                        {
                            WordList.Add(currentWord.ToString());
                            currentWord.Clear();
                        }
                    }
                    digitCount++;
                }
                if(WordList.Count > 0)
                    sentencesList.Add(WordList);
            }            
            return sentencesList;
        }
    }
}