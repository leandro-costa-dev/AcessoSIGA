using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class Util
    {

		public static string limparString(string str)
		{
			string[] charsToRemove = new string[] { "\\"," ", "-", "/", "@", ",", ".", ";", ":", "'", "%", "&", "(", ")" };
			foreach (var c in charsToRemove)
			{
				str = str.Replace(c, string.Empty);
			}
			return str;
		}
	}
}
