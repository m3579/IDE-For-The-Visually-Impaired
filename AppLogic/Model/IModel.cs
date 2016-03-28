using System;

using AppLogic.Utilities;

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

		/*
		 * The following methods will be invoked by the Controller as part of the Model-View-Controller
		 * architecture.
		 * 
		 * THESE METHODS ARE THE PART OF THE MODEL THAT WILL UPDATE THE VIEW.
 		 */

		/// <summary>
		/// A method invoked by the controller when the user wants to execute a certain action, such as by
		/// a keyboard shortcut or a typed command
		/// </summary>
		/// <param name="action">The action the user wants to execute</param>
		void ExecuteAction(UserAction action);

		/// <summary>
		/// A method invoked by the controller when it wants the focus of the window to be the text box
		/// where the user types actions; this is invoked when the user presses the action-key
		/// (for lack of a better name), which is currently escape, so that they can type a command and hit enter
		/// to run it.
		/// </summary>
		void FocusOnActionTextBox();
	}
}