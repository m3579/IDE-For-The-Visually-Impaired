using System;

using AppLogic;

namespace AppLogicUnitTests
{
	/// <summary>
	/// A view implementation used to test the model and controller
	/// </summary>
	public class TestView : IView
	{
		/// <summary>
		/// Starts the app; in other words, displays the user interfaces and sends an
		/// event to the controller to initialize the application
		/// </summary>
		public void Start()
		{
			
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
			
		}

		/// <summary>
		/// A method to use when testing if the view is working properly or just to
		/// see if the architecture works. It outputs text to the console
		/// </summary>
		public void Test()
		{
			Console.WriteLine ("Testing");		
		}
	}
}

