using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beahavioral_Command
{
	internal class JukeboxInvoker
	{
		private readonly Stack<ICommand> _commands;
		private readonly Stack<ICommand> _redoStack;
		private ICommand _command;
		public JukeboxInvoker()
		{
			_commands = new Stack<ICommand>();
			_redoStack = new Stack<ICommand>();
		}
		public void SetCommand(ICommand command) => _command = command;

		public void Invoke()
		{
			Console.WriteLine("Clean the redo stack.");
			_redoStack.Clear();
			_commands.Push(_command);
			_command.Execute();
		}

		internal void UndoCommand(int numberOfUndo = 0)
		{
			int k = 0;
			if (numberOfUndo >= 0)
			{
				if (numberOfUndo == 0)
				{
					numberOfUndo = _commands.Count;
				}
				if (numberOfUndo > _commands.Count)
				{
					numberOfUndo = _commands.Count;
				}
				if (_commands.Count > 0)
				{
					do
					{
						//ICommand command = Enumerable.Reverse(_commands).First();				
						ICommand command = _commands.Pop();
						_redoStack.Push(command);
						if (command.GetType().Name == "JukeboxCommand")
						{
							Console.WriteLine($"Undo command, popped song: {((JukeboxCommand)command).GetSongCommand()} - Action TO RESTORE: {((JukeboxCommand)command).GetSongAction()}");
						}
						else
						{
							Console.WriteLine("Unknow command type");
						}
						command.Undo();
						k++;
					}
					while (k < numberOfUndo);
				}
				else
				{
					Console.WriteLine("Nothing to undo");
				}
			}
		}

		internal void RedoCommand(int numberOfRedo = 0)
		{
			int k = 0;
			if (numberOfRedo >= 0)
			{
				if (numberOfRedo == 0)
				{
					numberOfRedo = _redoStack.Count;
				}
				if (numberOfRedo > _redoStack.Count)
				{
					numberOfRedo = _redoStack.Count;
				}
				if (_redoStack.Count > 0)
				{
					do
					{
						//ICommand command = Enumerable.Reverse(_commands).First();				
						ICommand command = _redoStack.Pop();
						_commands.Push(command);
						if (command.GetType().Name == "JukeboxCommand")
						{
							Console.WriteLine($"Redo command, popped song: {((JukeboxCommand)command).GetSongCommand()} - Action TO UNRestore: {((JukeboxCommand)command).GetSongAction()}");
						}
						else
						{
							Console.WriteLine("Unknow command type");
						}
						command.Execute();
						k++;
					}
					while (k < numberOfRedo);
				}
				else
				{
					Console.WriteLine("Nothing to redo");
				}
			}
		}
	}
}
