using System;

using AppLogic;

namespace AppLogicUnitTests
{
	/// <summary>
	/// The entry point into the unit tests; starts the "dummy" view
	/// </summary>
	public class Start
	{
		/// <summary>
		/// The start of the application; the code starts its execution from here
		/// </summary>
		public static void Main()
		{
			IModel model = new Model ();
			IView view = new TestView ();
			IController controller = new Controller ();

			model.SetView (view);
			view.SetController (controller);
			controller.SetModel (model);

			// Start the app
			view.Start ();

			// Keep the console open till a key is pressed
			Console.ReadKey ();
		}
	}
}

