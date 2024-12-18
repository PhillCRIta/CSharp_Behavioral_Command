using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beahavioral_Command
{
	internal class JukeboxCommand : ICommand
	{
		private readonly JukeboxSongReciver _songReciver;
		private readonly JukeboxAction _songAction;
		private readonly string _songToPlay;

		public JukeboxCommand(JukeboxSongReciver songReciver, JukeboxAction songAction, string songToPlay)
		{
			_songReciver = songReciver;
			_songAction = songAction;
			_songToPlay = songToPlay;
		}

		public string GetSongCommand()
		{
			return _songToPlay;
		}
		public JukeboxAction GetSongAction()
		{
			return _songAction;
		}

		public void Execute()
		{
			if (_songAction == JukeboxAction.AddSong)
			{
				_songReciver.AddSong(_songToPlay);
			}
			else
			{
				_songReciver.RemoveSong(_songToPlay);
			}
		}

		public void Undo()
		{
			//the opposite actions of Execute
			if (_songAction == JukeboxAction.AddSong)
			{
				_songReciver.RemoveSong(_songToPlay);
			}
			else
			{
				_songReciver.AddSong(_songToPlay);
			}
		}
	}
}
