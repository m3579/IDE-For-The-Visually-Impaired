using System;
using Gtk;
using AppLogic;

namespace AppView
{
	/// <summary>
	/// The entry point into the application; in other words, CODE STARTS EXECUTING
	/// FROM THE MAIN METHOD IN THIS CLASS
	/// </summary>
	class EntryPoint
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The arguments, if any, that are given to this program from the command line</param>
		public static void Main (string[] args)
		{
			Console.WriteLine ("Started");

			Console.WriteLine ("Initialized Application");

			// Create the model, view, and controller of the Model-View-Controller architecture
			// implemented in KeyboardCode
			// FOR MORE INFORMATION ON MVC, SEE README.MD (ALL CAPS)
			IView view = new View ();
			IModel model = new Model ();
			IController controller = new Controller ();

			model.SetView (view);
			view.SetController (controller);
			controller.SetModel (model);

			Console.WriteLine ("Initialized Model, View, and Controller");

			// Start the application
			view.Start ();

			Console.WriteLine ("Started View");
		}
	}
}

