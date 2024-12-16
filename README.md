### Please note before start reading
Those code examples about design pattern have the purpose of personal use, to easily remember the patters; it's like a notepad. I took the following examples from Youtube and some web articles.

The major source of the examples is a Youtube channel of [DoableDanny](https://www.youtube.com/@doabledanny/videos), he's a very good developer. I suggest to all to buy 📒his book about design pattern 📒 , it's very clear.

# Command pattern
You can use the COMMAND object to encapsulate all information needed to perform an action, or trigger an event at a later time. \
Optionally you can add Undo/Redo functions. \
Can be used with another patterns, like Factory method or Template method. \
In our case every song on jukebox is management by jukeboxmanager, every son is played with Execute function. \
For return back on previous song you can use Undo functionality, for restore the previus song undoed you use redo. \
The command object encapsulate all information needed to perform some actions.