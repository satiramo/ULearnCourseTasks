using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            if (nextWords.Count > 0 && wordsCount > 0)
            {
                for (var i = 0; i < wordsCount; i++)
                {
                    var wordsInPhraseBeginingArray = phraseBeginning.Split(' ');
                    var arrayLength = wordsInPhraseBeginingArray.Length;                    
                    var lastWord = wordsInPhraseBeginingArray[arrayLength - 1];
                    if (arrayLength > 1 && nextWords.ContainsKey(string.Format("{0} {1}", wordsInPhraseBeginingArray[arrayLength - 2], lastWord)))
                        phraseBeginning += " " + nextWords[string.Format("{0} {1}", wordsInPhraseBeginingArray[arrayLength - 2], lastWord)];
                    else if (nextWords.ContainsKey(lastWord))
                        phraseBeginning += " " + nextWords[lastWord];
                    else
                        return phraseBeginning;
                }
            }
            return phraseBeginning;
        }
    }
}