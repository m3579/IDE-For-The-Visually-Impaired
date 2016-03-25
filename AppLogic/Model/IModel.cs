using System;

namespace AppLogic
{
	/// <summary>
	/// An interface for the model part of the Model-View-Controller architecture implemented in KeyboardCode.
	/// 
	/// When an event occurs on the View, the user interface, it sends that event to the Controller.
	/// The Controller decides what it wants the Model, the application logic, to do; and it invokes
	/// that action.
	/// The Model will do that action and change the View, the user interface, accordingly.
	/// FOR MORE INFORMATION ON MVC, SEE README.MD (ALL CAPS)
	/// </summary>
	public interface IModel
	{
		/// <summary>
		/// A method to use to test if this IModel is working or just to see if the architecture works
		/// </summary>
		void Test();

		/// <summary>
		/// Configures the model to change the given view when it receives an instruction from
		/// the controller. The reason why the view is not configured
		/// in the model's constructor is because there is a circular dependency with
		/// the view needing a controller, the controller needing a model, and the model needing
		/// a view; we need to create all of the objects first and then supply them with the 
		/// other component that they need.
		/// </summary>
		/// <param name="view">The view to manipulate</param>
		void SetView(IView view);
	}
}

