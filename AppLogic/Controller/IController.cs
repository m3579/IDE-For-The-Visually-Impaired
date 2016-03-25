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
 		 */

		/// <summary>
		/// The method called when the application is started that will send a message to
		/// the Model to react
		/// </summary>
		void RegisterApplicationStartedEvent();

		/// <summary>
		/// A method called when text is typed in the code editor that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="typedText">The text that was typed into the code editor</param>
		void RegisterTextTypedEvent(string typedText);

		/// <summary>
		/// A method called when text is deleted from the code editor that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="deletedText">The text that was deleted from the code editor</param>
		void RegisterTextDeletedEvent(string deletedText);

		/// <summary>
		/// A method called when text is copied from the code editor that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="copiedText">The text that was copied from the code editor</param>
		void RegisterTextCopiedEvent(string copiedText);

		/// <summary>
		/// A method called when text is pasted into the code editor that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="pastedText">The text that was pasted into the code editor</param>
		void RegisterTextPastedEvent(string pastedText);

		/// <summary>
		/// A method called when text is cut from the code editor that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="cutText">The text that was cut from the code editor</param>
		void RegisterTextCutEvent(string cutText);

		/// <summary>
		/// A method called when the cursor in the code editor is moved that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="cursorPosition">The position that the cursor is at now</param>
		void RegisterMoveCursorEvent(int cursorPosition);

		/// <summary>
		/// A method called when the cursor in the code editor is moved that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="selectedText">The text that is selected in the code editor</param>
		void RegisterTextSelectedEvent(string selectedText);
	}
}

