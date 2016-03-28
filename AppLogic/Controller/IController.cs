using System;

namespace AppLogic
{
	/// <summary>
	/// An interface for the controller part of the Model-View-Controller pattern implemented in the source code.
	/// 
	/// When an event occurs on the View, the user interface, it sends that event to the Controller.
	/// The Controller decides what it wants the Model, the application logic, to do; and it invokes
	/// that action.
	/// The Model will do that action and change the View, the user interface, accordingly.
	/// FOR MORE INFORMATION ON MVC, SEE README.MD (ALL CAPS)
	/// </summary>
	public interface IController
	{
		/// <summary>
		/// A method to use to test if this IController is working or just to see if the architecture works
		/// </summary>
		void Test();

		/// <summary>
		/// Configures the controller to invoke actions in response to events it receives
		/// from the view upon the given model. The reason why the model is not configured
		/// in the controller's constructor is because there is a circular dependency with
		/// the view needing a controller, the controller needing a model, and the model needing
		/// a view; we need to create all of the objects first and then supply them with the 
		/// other component that they need.
		/// </summary>
		/// <param name="model">The model to invoke actions upon</param>
		void SetModel(IModel model);

		/*
		 * The following methods will be invoked by the View when an event on the user interface
		 * occurs. They will invoke an action on the Model in response to the event.
		 * 
		 * THESE METHODS ARE THE PART OF THE VIEW THAT WILL INVOKE ACTIONS ON THE MODEL.
 		 */

		/// <summary>
		/// The method called when the application is started that will send a message to
		/// the Model to react
		/// </summary>
		void RegisterApplicationStartedEvent();

		/// <summary>
		/// The method called by the view when a key is pressed in the code editor
		/// text box
		/// </summary>
		/// <param name="key">The string representation of the key that was pressed</param>
		void RegisterCodeEditorKeypress(Key key);
	}
}

