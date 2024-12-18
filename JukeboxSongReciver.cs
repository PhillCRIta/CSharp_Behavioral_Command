using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beahavioral_Command
{
	internal class JukeboxSongReciver
	{
		public string NewSong { get; set; }
		public List<string> ListSongs { get; set; }
		public JukeboxSongReciver(string newSong, List<string> listSongs)
		{
			NewSong = newSong;
			ListSongs = listSongs;
			if (string.IsNullOrEmpty(newSong) == false)
				listSongs.Add(NewSong);
		}
		public void AddSong(string song)
		{
			ListSongs.Add(song);
			Console.WriteLine("I add new song in my list: " + song + ". The songs in list are: " + ListSongs.Count);
		}
		public void RemoveSong(string song)
		{
			ListSongs.Remove(song);
			Console.WriteLine("I remove song from my list: " + song + ". The songs in list are: " + ListSongs.Count);
		}

		public override string ToString()
		{
			if (ListSongs.Count > 0)
			{
				//return "The songs in list are: " + string.Join(", ", ListSongs);
				string sOut = string.Empty;
				int k = 1;
				foreach (string song in ListSongs)
				{
					sOut += $"{k}-{song} ";
					k++;
				}
				return "The songs in list are: " + sOut;
			}
			else
				return "The songs list is empty";
		}
	}
}
