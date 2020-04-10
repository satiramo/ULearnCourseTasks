using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareBooks
{
    public class Book : IComparable
    {
        public string Title;
        public int Theme;        

        int IComparable.CompareTo(object obj)
        {
            var otherBook = (Book)obj;
            if (this.Theme == otherBook.Theme)
            {
                return this.Title.CompareTo(otherBook.Title);
            }
            else
                return this.Theme.CompareTo(otherBook.Theme);            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
