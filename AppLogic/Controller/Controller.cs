﻿using System;
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
	}
}
