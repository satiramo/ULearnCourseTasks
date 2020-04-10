namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
            int countLength = count.ToString().Length;
            string num = count.ToString();
            int lastDigit = int.Parse(num.Substring(num.Length - 1, 1));
            int preLastDigit = 0;            
            if (countLength > 1)
            {
               preLastDigit = int.Parse(num.Substring(num.Length - 2, 1));
            }
            int twoLastDigits = preLastDigit * 10 + lastDigit;           
            
            
            switch (lastDigit)
            {
                case 1:                     
                    return (twoLastDigits == 11)?"рублей": "рубль";  
                case 2:
                case 3:
                case 4:
                    return (twoLastDigits > 10 && twoLastDigits < 15 )?"рублей":"рубля";                    
                default:
                    return "рублей";

            }			
		}
	}
}