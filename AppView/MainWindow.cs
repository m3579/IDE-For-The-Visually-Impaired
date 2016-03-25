using System;
using Gtk;

namespace AppView
{
	/// <summary>
	/// The class that represents the user interface that the user
	/// will interact with. The GUI code is contained here.
	/// </summary>
	public partial class MainWindow: Gtk.Window
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AppView.MainWindow"/> class.
		/// </summary>
		public MainWindow () : base (Gtk.WindowType.Toplevel)
		{
			InitGUI ();
		}

		/// <summary>
		/// Initialize the user interface of the KeyboardCode app; in other words,
		/// place all of the components/widgets that are part of the user interface
		/// to the user interface. This method does not show the user interface;
		/// it only places the components. Call the <see cref="Gtk.Window.ShowAll"/> method
		/// to show the user interface 
		/// </summary>
		private void InitGUI()
		{
			
		}

		/// <summary>
		/// Raises the delete event event.
		/// </summary>
		/// <param name="sender">The object that has invoked this event</param>
		/// <param name="a">Any arguments that the object invoking this event wants to send</param>
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
	}
}