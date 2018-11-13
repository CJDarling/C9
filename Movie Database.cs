using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecting_to_OMDbAPI
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 0;
			while (count > -1)
				{
				System.Net.WebClient webClient = new System.Net.WebClient();
				Console.WriteLine("Do you have the name of the movie you want to look for?");
				string movieName = Console.ReadLine();
				Console.WriteLine("Do you have the year of release?");
				string movieYear = Console.ReadLine();
				string webData = webClient.DownloadString("http://www.omdbapi.com/?apikey=c1f46d38&s=" + movieName + "&y=" + movieYear);
				var replacement = webData.Replace("{", string.Empty);
				replacement = replacement.Replace("[", string.Empty);
				replacement = replacement.Replace("]", string.Empty);
				replacement = replacement.Replace("}", string.Empty);
				replacement = replacement.Replace("'", string.Empty);
				replacement = replacement.Replace('"', ' ');
				replacement = replacement.Remove(19 + movieName.Length, replacement.Length - (19 + movieName.Length));
				replacement = replacement.Remove(0, 10);
				Console.WriteLine(replacement);
				Console.WriteLine("Do you wish to save this to your wishlist? y/n");
				string wishlistCheck = Console.ReadLine();
				if (wishlistCheck == "y")
				{
					string wishlist = movieName;
					Console.WriteLine(wishlist);
				}
			}
			//System.Diagnostics.Process.Start("http://www.omdbapi.com/?apikey=c1f46d38&s="+movieName+"&y="+movieYear);
		}
	}
}
