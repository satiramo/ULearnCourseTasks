using System.Collections.Generic;
using System.Linq;


namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static void GetBigramFrequencyDictionary(Dictionary<string, string> res, List<List<string>> text)
        {
            var beGramFrequentDictionary = new Dictionary<string, int>();
            foreach (var sentence in text)
            {
                for (var i = 0; i < sentence.Count - 1; i++)
                {
                    var firstWord = sentence.ElementAt(i).ToLower();
                    var secondWord = sentence.ElementAt(i + 1).ToLower();
                    if (!beGramFrequentDictionary.ContainsKey(string.Format("{0} {1}", firstWord, secondWord)))
                        beGramFrequentDictionary.Add(string.Format("{0} {1}", firstWord, secondWord), 1);
                    else
                        beGramFrequentDictionary[string.Format("{0} {1}", firstWord, secondWord)]++;
                }
            }
            GetMostFrequentBigramsDictionary(res, beGramFrequentDictionary);
        }

        public static void GetThreegramFrequencyDictionary(Dictionary<string, string> res, List<List<string>> text)
        {
            var threeGramFrequentDictionary = new Dictionary<string, int>();
            foreach (var sentence in text)
            {
                for (var i = 0; i < sentence.Count - 2; i++)
                {
                    var firstWord = sentence.ElementAt(i).ToLower();
                    var secondWord = sentence.ElementAt(i + 1).ToLower();
                    var thirdWord = sentence.ElementAt(i + 2).ToLower();
                    if (!threeGramFrequentDictionary.ContainsKey(string.Format("{0} {1} {2}", firstWord, secondWord, thirdWord)))
                        threeGramFrequentDictionary.Add(string.Format("{0} {1} {2}", firstWord, secondWord, thirdWord), 1);
                    else
                        threeGramFrequentDictionary[string.Format("{0} {1} {2}", firstWord, secondWord, thirdWord)]++;
                }
            }
            GetMostFrequentThreegramsDictionary(res, threeGramFrequentDictionary);
        }

        public static void GetMostFrequentBigramsDictionary(Dictionary<string, string> beGramResultDictionary, 
                                                            Dictionary<string, int> bigramFrequencyDictionary)
        {
            foreach (var Pair in bigramFrequencyDictionary)
            {
                var pairKey = Pair.Key;
                var pairValue = Pair.Value;
                var firstWord = pairKey.Split(new char[] { ' ' })[0];
                var secondWord = pairKey.Split(new char[] { ' ' })[1];
                if (!beGramResultDictionary.ContainsKey(firstWord))
                    beGramResultDictionary.Add(firstWord, string.Format("{0}:{1}", secondWord, pairValue));
                else
                {
                    var beGramValue = beGramResultDictionary[firstWord];
                    var existingValueWord = beGramValue.Split(new char[] { ':' })[0];
                    var existingValueDigit = int.Parse(beGramValue.Split(new char[] { ':' })[1]);

                    if (existingValueDigit < pairValue)
                        beGramResultDictionary[firstWord] = string.Format("{0}:{1}", secondWord, pairValue);
                    else if (existingValueDigit == pairValue && string.CompareOrdinal(secondWord, existingValueWord) < 0)
                        beGramResultDictionary[firstWord] = string.Format("{0}:{1}", secondWord, pairValue);
                }
            }
            foreach (var Key in beGramResultDictionary.Keys.ToList())
            {
                beGramResultDictionary[Key] = beGramResultDictionary[Key].Split(new char[] { ':' })[0];
            }
        }

        public static void GetMostFrequentThreegramsDictionary(Dictionary<string, string> threeGramResultDictionary,
                                                               Dictionary<string, int> threegramFrequencyDictionary)
        {
            foreach (var Pair in threegramFrequencyDictionary)
            {
                var pairKey = Pair.Key;
                var pairValue = Pair.Value;
                var firstWord = pairKey.Split(new char[] { ' ' })[0];
                var secondWord = pairKey.Split(new char[] { ' ' })[1];
                var thirdWord = pairKey.Split(new char[] { ' ' })[2];
                if (!threeGramResultDictionary.ContainsKey(string.Format("{0} {1}", firstWord, secondWord)))
                    threeGramResultDictionary.Add(string.Format("{0} {1}", firstWord, secondWord),
                                                    string.Format("{0}:{1}", thirdWord, pairValue));
                else
                {
                    var threeGramValue = threeGramResultDictionary[string.Format("{0} {1}", firstWord, secondWord)];
                    var existingValueWord = threeGramValue.Split(new char[] { ':' })[0];
                    var existingValueDigit = int.Parse(threeGramValue.Split(new char[] { ':' })[1]);

                    if (existingValueDigit < pairValue)
                        threeGramResultDictionary[string.Format("{0} {1}", firstWord, secondWord)] =
                                                                        string.Format("{0}:{1}", thirdWord, pairValue);
                    else if (existingValueDigit == pairValue && string.CompareOrdinal(thirdWord, existingValueWord) < 0)
                        threeGramResultDictionary[string.Format("{0} {1}", firstWord, secondWord)] =
                                                                        string.Format("{0}:{1}", thirdWord, pairValue);
                }
            }
            foreach (var Key in threeGramResultDictionary.Keys.ToList())
            {
                threeGramResultDictionary[Key] = threeGramResultDictionary[Key].Split(new char[] { ':' })[0];
            }
        }

        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            GetBigramFrequencyDictionary(result, text);
            GetThreegramFrequencyDictionary(result, text);
            return result;
        }
   }
}