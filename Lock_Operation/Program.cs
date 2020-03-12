using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lock_Operation
{
	class Program
	{
		static double _val1 = 1, _val2 = 2;
		static object padlock = new object();
		static void Go()
		{
			lock (padlock)
			{
				if (_val2 != 0)
				{
					Console.WriteLine(_val1 / _val2);
					_val2 = 0;
				}
				else
					Console.WriteLine("NO");
			}
		}

		static void Go2()
		{
			Monitor.Enter(padlock);
			try
			{
				Console.WriteLine(_val1 / _val2);
				_val2 = 0;
			}
			catch
			{
				Console.WriteLine("operazione non eseguibile");
			}
			finally
			{
				Monitor.Exit(padlock);
			}
		}


		static void Main(string[] args)
		{
			//Task.Factory.StartNew(Go);
			//Task.Factory.StartNew(Go);
			//Task.Factory.StartNew(Go);

			Task.Factory.StartNew(Go2);
			Task.Factory.StartNew(Go2);
			Task.Factory.StartNew(Go2);



			Console.ReadLine(); 
		}
	}
}
