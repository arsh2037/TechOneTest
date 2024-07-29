
using System;
using System.Globalization;
using System.Text;

namespace TechOneTest2.Services
{
    public class NumberToWordsService : INumberToWordsService
    {
        public string ConvertNumberToWords(string number)
        {
            if (decimal.TryParse(number, out decimal value))
            {
                return ConvertToWords(value);
            }

            throw new ArgumentException("Invalid number format");
        }

        private string ConvertToWords(decimal number)
        {
            var dollars = (int)Math.Floor(number);
            var cents = (int)((number - dollars) * 100);

            var dollarText = ConvertToWords(dollars) + " DOLLARS";
            var centText = cents > 0 ? " AND " + ConvertToWords(cents) + " CENTS" : string.Empty;

            return dollarText + centText;
        }

        private string ConvertToWords(int number)

            //I have taken the approach to map the number to words by dividing the number into its highest value eg: millions, thousands, hundreds, tens and units
            //the time complexity of this algorithm is O(1) and space is O(n) where n being 
        {
            if (number == 0) return "ZERO";

            if (number < 0) return "MINUS " + ConvertToWords(Math.Abs(number));

            string[] unitsMap = { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            string[] tensMap = { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
            //init a new sting 
            var words = new StringBuilder();

            //the below logic will map the number's highest value to the words eg: if its in millions or thousands or hundreds

            if ((number / 1000000) > 0)
            {
                words.Append(ConvertToWords(number / 1000000) + " MILLION ");
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words.Append(ConvertToWords(number / 1000) + " THOUSAND ");
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words.Append(ConvertToWords(number / 100) + " HUNDRED ");
                number %= 100;
            }

            if (number > 0)
            {
                if (words.Length > 0) words.Append("AND ");

                if (number < 20)
                    words.Append(unitsMap[number]);
                else
                {
                    words.Append(tensMap[number / 10]);
                    if ((number % 10) > 0)
                        words.Append("-" + unitsMap[number % 10]);
                }
            }

            return words.ToString().Trim();
        }
    }
}
