//COMMAND PATTERN
//This is the Client Class
//Use an COMMAND object to encapsulate all informationneeded to perform an action, or trigger an event
//at a later time.
//Optinally you can add Undo/Redo functions.
//Can be used with another patterns, like Factory method or Template method.
//every song on jukebox is management by jukeboxmanager, every son is played with Execute function.
//for return back on previous song you can use Undo functionality,
//for restore the previus song undoed you use redo
//encapsulate all information needed to perform some actions

JukeboxInvoker jukeboxManager = new JukeboxInvoker();
//Crate the physical jukebox for playing song
JukeboxSongReciver physicalJukebox = new JukeboxSongReciver("", new List<string>());
//insert different songs to play
Execute(jukeboxManager, new JukeboxCommand(physicalJukebox, JukeboxAction.AddSong, "Another way"));
Execute(jukeboxManager, new JukeboxCommand(physicalJukebox, JukeboxAction.AddSong, "Tell my why"));
//remove one song
Execute(jukeboxManager, new JukeboxCommand(physicalJukebox, JukeboxAction.RemoveSong, "Another way"));
Execute(jukeboxManager, new JukeboxCommand(physicalJukebox, JukeboxAction.AddSong, "Mimmo amerelli"));
Execute(jukeboxManager, new JukeboxCommand(physicalJukebox, JukeboxAction.AddSong, "BlaBlaBla"));
Execute(jukeboxManager, new JukeboxCommand(physicalJukebox, JukeboxAction.AddSong, "Passion"));
//remove one song
Execute(jukeboxManager, new JukeboxCommand(physicalJukebox, JukeboxAction.RemoveSong, "BlaBlaBla"));

//PRINT > The songs in list are: 1-Tell my why 2-Mimmo amerelli 3-Passion
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);

Undo(1);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
Redo(1);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > The songs in list are: 1-Tell my why 2-Mimmo amerelli 3-Passion
//bla bla bla is readded with undo end re-removed with redo

Undo(1);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
Redo(1);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > The songs in list are: 1-Tell my why 2-Mimmo amerelli 3-Passion

Undo(1);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
Redo(1);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > The songs in list are: 1-Tell my why 2-Mimmo amerelli 3-Passion

Redo(1);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > Nothing to redo
Redo(1);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > Nothing to redo
Redo(1);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > Nothing to redo

Undo(2);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > The songs in list are: 1 - Tell my why 2-Mimmo amerelli 3-BlaBlaBla

Execute(jukeboxManager, new JukeboxCommand(physicalJukebox, JukeboxAction.AddSong, "SkyPlus"));
Execute(jukeboxManager, new JukeboxCommand(physicalJukebox, JukeboxAction.AddSong, "Heritage"));
//In this case redo function doesn't function because whenever you use execute method, the Redo list is cleaned.
Redo(3);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > Nothing to redo
//PRINT > The songs in list are: 1 - Tell my why 2-Mimmo amerelli 3-BlaBlaBla 4-SkyPlus 5-Heritage

Undo(3);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > The songs in list are: 1-Tell my why 2-Mimmo amerelli
Redo(3);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > The songs in list are: 1-Tell my why 2-Mimmo amerelli 3-BlaBlaBla 4-SkyPlus 5-Heritage
Redo(3);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > Nothing to redo
Undo(0);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > The songs list is empty
Redo(0);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > The songs in list are: 1-Tell my why 2-Mimmo amerelli 3-BlaBlaBla 4-SkyPlus 5-Heritage

Undo(0);
Console.WriteLine(physicalJukebox.ToString() + System.Environment.NewLine);
//PRINT > Nothing to redo

void Undo(int numberOfUndo = 0)
{
	jukeboxManager.UndoCommand(numberOfUndo);
}
void Redo(int numberOfRedo = 0)
{
	jukeboxManager.RedoCommand(numberOfRedo);
}
void Execute(JukeboxInvoker manageSong, ICommand songCommand)
{
	manageSong.SetCommand(songCommand);
	manageSong.Invoke();
}