using System;

namespace AppLogic
{
	/// <summary>
	/// An interface for the view part of the Model-View-Controller architecture implemented in KeyboardCode.
	/// 
	/// When an event occurs on the View, the user interface, it sends that event to the Controller.
	/// The Controller decides what it wants the Model, the application logic, to do; and it invokes
	/// that action.
	/// The Model will do that action and change the View, the user interface, accordingly.
	/// For more information on MVC, see README.md.
	/// </summary>
	public interface IView
	{
		/// <summary>
		/// Starts the app; in other words, displays the user interfaces and sends an
		/// event to the controller to initialize the application
		/// </summary>
		void Start();

		/// <summary>
		/// Configures the view to send events that happen on the user interface to the given
		/// controller. The reason why the controller is not configured
		/// in the view's constructor is because there is a circular dependency with
		/// the view needing a controller, the controller needing a model, and the model needing
		/// a view; we need to create all of the objects first and then supply them with the 
		/// other component that they need.
		/// </summary>
		/// <param name="controller">The controller to manipulate</param>
		void SetController(IController controller);

		/// <summary>
		/// A method to use when testing if the IView is working properly or just to
		/// see if the architecture works. As of right now, it just outputs text to the console
		/// </summary>
		void Test();
	}
}

