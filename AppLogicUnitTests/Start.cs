using System;

using AppLogic;

namespace AppLogicUnitTests
{
	public class Start
	{
		public static void Main()
		{
			IModel model = new Model (new TestView());
			model.Test ();

			Console.ReadKey ();
		}
	}
}

