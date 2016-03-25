using System;

// I use this import for Debug.WriteLine(); I use this to output rather than Console.WriteLine() because
// code in the AppLogic project cannot use Console.WriteLine() and I want all (or at least most) of my code to
// use the same method to debug (just in case the IDE treats the output differently between the
// two methods)
using System.Diagnostics;

using Gtk;

using AppLogic;

namespace AppView
{
	/// <summary>
	/// The view part of the Model-View-Controller architecture implemented in KeyboardCode.
	/// 
	/// When an event occurs on the View, the user interface, it sends that event to the Controller.
	/// The Controller decides what it wants the Model, the application logic, to do; and it invokes
	/// that action.
	/// The Model will do that action and change the View, the user interface, accordingly.
	/// FOR MORE INFORMATION ON MVC, SEE README.MD (ALL CAPS)
	/// </summary>
	public class View : IView
	{
		/// <summary>
		/// The controller that this view will send messages to in response to events on the
		/// user interface
		/// </summary>
		private IController controller;

		/// <summary>
		/// Starts the app; in other words, displays the user interfaces and sends an
		/// event to the controller to initialize the application
		/// </summary>
		public void Start()
		{
			Application.Init ();

			// The MainWindow class contains the actual user interface code
			MainWindow window = new MainWindow (controller);
			window.Start ();

			Application.Run ();
		}

		/// <summary>
		/// Configures the view to send events that happen on the user interface to the given
		/// controller. The reason why the controller is not configured
		/// in the view's constructor is because there is a circular dependency with
		/// the view needing a controller, the controller needing a model, and the model needing
		/// a view; we need to create all of the objects first and then supply them with the 
		/// other component that they need.
		/// </summary>
		/// <param name="controller">The controller to manipulate</param>
		public void SetController(IController controller)
		{
			this.controller = controller;
		}

		/// <summary>
		/// A method to use when testing if the IView is working properly or just to
		/// see if the architecture works. As of right now, it just outputs text to the console
		/// </summary>
		public void Test()
		{
			Console.WriteLine ("Testing view");
			controller.Test ();
		}
	}
}


