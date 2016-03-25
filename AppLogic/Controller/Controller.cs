using System;
using System.Diagnostics;

namespace AppLogic
{
	/// <summary>
	/// The Controller part of the Model-View-Controller pattern implemented in the source code.
	/// 
	/// When an event occurs on the View, the user interface, it sends that event to the Controller.
	/// The Controller decides what it wants the Model, the application logic, to do; and it invokes
	/// that action.
	/// The Model will do that action and change the View, the user interface, accordingly.
	/// FOR MORE INFORMATION ON MVC, SEE README.MD (ALL CAPS)
	/// 
	public class Controller : IController
	{
		/// <summary>
		/// The model object that the controller will invoke actions upon in response
		/// to events from the view
		/// </summary>
		private IModel model;
	
		/// <summary>
		/// A method to use when testing if the Model is working properly or just to
		/// see if the architecture works. It invokes its view's Test method.
		/// </summary>
		public void Test()
		{
			Debug.WriteLine ("Testing");
			model.Test ();
		}

		/// <summary>
		/// Configures the controller to invoke actions in response to events it receives
		/// from the view upon the given model. The reason why the model is not configured
		/// in the controller's constructor is because there is a circular dependency with
		/// the view needing a controller, the controller needing a model, and the model needing
		/// a view; we need to create all of the objects first and then supply them with the 
		/// other component that they need.
		/// </summary>
		/// <param name="model">The model to invoke actions upon</param>
		public void SetModel(IModel model)
		{
			this.model = model;
		}

		/*
		 * The following methods will be invoked by the View when an event on the user interface
		 * occurs. They will invoke an action on the Model in response to the event.
 		 */

		/// <summary>
		/// The method called when the application is started that will send a message to
		/// the Model to react
		/// </summary>
		public void RegisterApplicationStartedEvent()
		{
			Debug.WriteLine ("Application started event");
		}

		/// <summary>
		/// A method called when text is typed in the code editor that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="typedText">The text that was typed into the code editor</param>
		public void RegisterTextTypedEvent(string typedText)
		{
			Debug.WriteLine ("Text typed event: " + typedText);
		}

		/// <summary>
		/// A method called when text is deleted from the code editor that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="deletedText">The text that was deleted from the code editor</param>
		public void RegisterTextDeletedEvent(string deletedText)
		{
			Debug.WriteLine("Text deleted event: " + deletedText);
		}

		/// <summary>
		/// A method called when text is copied from the code editor that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="copiedText">The text that was copied from the code editor</param>
		public void RegisterTextCopiedEvent(string copiedText)
		{
			Debug.WriteLine ("Text copied event: " + copiedText);
		}

		/// <summary>
		/// A method called when text is pasted into the code editor that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="pastedText">The text that was pasted into the code editor</param>
		public void RegisterTextPastedEvent(string pastedText)
		{
			Debug.WriteLine ("Text pasted event: " + pastedText);
		}

		/// <summary>
		/// A method called when text is cut from the code editor that will send a message
		/// to the Model to react
		/// </summary>
		/// <param name="cutText">The text that was cut from the code editor</param>
		public void RegisterTextCutEvent(string cutText)
		{
			Debug.WriteLine ("Text cut event: " + cutText);
		}
	}
}

