using System;

namespace AppView
{
	/// <summary>
	/// The interface for classes that implement the GUI code to display the
	/// user interface of KeyboardCode
	/// </summary>
	public interface IGUI
	{
		/// <summary>
		/// Start the user interface code; in other words, start showing the KeyboardCode screen
		/// to the user; in other words (again), start the app. Note that this is not the entry
		/// point into the application; that is the Main method in <see cref="AppView.EntryPoint"/>. 
		/// </summary>
		void Start();
	}
}