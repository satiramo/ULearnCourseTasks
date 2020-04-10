using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PocketGoogle
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dictionary = new Dictionary<int, string>();
            var indexer = new Indexer();

            var directoryInfo = new DirectoryInfo("Texts");
            foreach (var file in directoryInfo.GetFiles("*.txt"))
            {
                var parts = file.Name.Split('.');
                var id = int.Parse(parts[0]);
                var text = File.ReadAllText(file.FullName).Replace("\r", "");
                dictionary[id] = text;
                indexer.Add(id, text);
            }
            /*var dictionary2 = new Dictionary<string, List<int>>();
            dictionary2.Add("aa", new List<int>(1));
            var bb = dictionary2["aa"];
            bb.Add(2);
            bb.Remove(1);
            bb.Remove(2);

            //var aa = bb
            Console.ReadKey();*/
            //var Indexer2 = new Indexer();
            


            Application.Run(new PocketGoogleWindow(indexer, dictionary));
        }
    }
}