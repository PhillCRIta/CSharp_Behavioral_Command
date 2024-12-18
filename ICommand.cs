using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beahavioral_Command
{
	internal interface ICommand
	{
		void Execute();
		void Undo();
	}
}
