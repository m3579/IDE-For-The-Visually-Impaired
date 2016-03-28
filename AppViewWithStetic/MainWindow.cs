using System;
using Gtk;

using AppLogic;

public partial class MainWindow: Gtk.Window
{
	/// <summary>
	/// The controller that this project, the View of the Model-View-Controller architecture, will send
	/// messages to in response to events at the user interface.
	/// </summary>
	private IController controller;

	/// <summary>
	/// The text view into which the user will type code. This member simply makes the actual GUI widget
	/// accessible to the rest of the namespace since it is private by default.
	/// </summary>
	/// <value>Gets (doesn't set) the actual code editor object, which is private by default</value>
	internal TextView CodeEditor
	{
		get
		{
			return codeEditor;
		}
	}

	/// <summary>
	/// The text view into which the user types actions. This member simply makes the actual GUI widget
	/// accessible to the rest of the namespace since it is private by default.
	/// </summary>
	/// <value>Gets (doesn't set) the actual action text view object, which is private by default</value>
	internal TextView ActionTextBox
	{
		get
		{
			return actionTextBox;
		}
	}

	/// <summary>
	/// The class that represents the user interface that the user
	/// will interact with. The GUI code is contained here.
	/// </summary>
	/// <param name="controller">The controller of the Model-View-Controller architecture that this object, which
	/// is part of the view, should send messages to in response to events on the user interface</param> 
	public MainWindow (IController controller) : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		InitGUI ();
	
		this.controller = controller;
	}

	/// <summary>
	/// Initializes the user interface with anything that was not set using the drag-and-drop Stetic
	/// designer
	/// </summary>
	private void InitGUI()
	{
		Console.WriteLine ("InitGUI called");

		codeEditor.KeyPressEvent += CodeEditor_KeyPressEvent;
	}

	/// <summary>
	/// Start the user interface code; in other words, start showing the KeyboardCode screen
	/// to the user; in other words (again), start the app. Note that this is not the entry
	/// point into the application; that is the Main method in <see cref="AppView.EntryPoint"/>. 
	/// </summary>
	public void Start()
	{
		controller.RegisterApplicationStartedEvent ();

		ShowAll ();
	}

	/// <summary>
	/// The event raised (or rather, method called) when this component is "deleted"; because this component is the Window,
	/// the user interface, this means that the application has been closed.
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="a">Any arguments that the sender, the object invoking this event, wants to supply</param>
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	/*
	 * The following methods contain the code that will be invoked in response to events on the
	 * code editor, such as text being typed or deleted.
	 * 
	 * THESE METHODS ARE THE PART OF THE VIEW THAT WILL SEND MESSAGES TO THE CONTROLLER.
	 */

	/// <summary>
	/// An event invoked when a key such as Control, Shift, Escape, etc. is pressed
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender wants to provide this event</param>
	void CodeEditor_KeyPressEvent (object sender, KeyPressEventArgs args)
	{
		Console.WriteLine ("Key press event");

		// TODO: add events for the rest of the special keys as well
		// That is not required right now because the only special key we
		// use is the escape key, but all of the special keys really should
		// have events
		if (args.Event.Key == Gdk.Key.Escape) {
			Console.WriteLine ("Escape key pressed");
			controller.RegisterCodeEditorKeypress(AppLogic.Key.Escape);
		}
	}
}