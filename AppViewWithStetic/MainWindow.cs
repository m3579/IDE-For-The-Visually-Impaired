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

		Maximize ();

		CodeEditor.Buffer.InsertText += (object o, InsertTextArgs args) => {
			Console.WriteLine("InsertText event invoked: " + args.Text);
		};

		CodeEditor.Buffer.DeleteRange += (object o, DeleteRangeArgs args) => {
			Console.WriteLine("DeleteRange event invoked: " + args.Start + " to " + args.End);
		};
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
	/// The event raised when text is pasted into the code editor
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	protected void OnCodeEditorPasteClipboard (object sender, EventArgs e)
	{
		Console.WriteLine ("PasteClipboard event invoked");
		controller.RegisterTextPastedEvent ("<some pasted text>");
	}

	/// <summary>
	/// The event raised whenever text is inserted into the code editor at the cursor, i.e. not by copy or
	/// pasting, but by actually typing characters
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	protected void OnCodeEditorInsertAtCursor (object sender, InsertAtCursorArgs args)
	{
		Console.WriteLine ("InsertAtCursor event invoked");
		controller.RegisterTextTypedEvent (args.Str);
	}

	/// <summary>
	/// The event raised when text is cut from the code editor
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	protected void OnCodeEditorCutClipboard (object sender, EventArgs e)
	{
		Console.WriteLine ("CutClipboard event invoked");
		controller.RegisterTextCutEvent ("<some cut text>");
	}

	/// <summary>
	/// The event raised when text is copied from the code editor
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	protected void OnCodeEditorCopyClipboard (object sender, EventArgs e)
	{
		Console.WriteLine ("CopyClipboard event invoked");
		controller.RegisterTextCopiedEvent ("<some copied text>");
	}

	/// <summary>
	/// The event raised whenever text is deleted from the code editor by "hitting Backspace or Delete"
	/// (http://docs.go-mono.com/?link=E%3aGtk.TextView.DeleteFromCursor)
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	protected void OnCodeEditorDeleteFromCursor (object sender, DeleteFromCursorArgs args)
	{
		Console.WriteLine ("DeleteFromCursor event invoked");
		controller.RegisterTextDeletedEvent ("<some deleted text>");
	}

	/// <summary>
	/// The event raised whenever the cursor is moved in the code editor
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	protected void OnCodeEditorMoveCursor (object sender, MoveCursorArgs args)
	{
		Console.WriteLine ("MoveCursor event invoked");
		// controller.RegisterTextDeletedEvent(cursorPosition);
	}

	// TODO: change this method to the non-obsolete version
	/// <summary>
	/// The event raised when the focus leaves from the code editor to another widget on the user interface
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	protected void OnCodeEditorMoveFocus (object sender, MoveFocusArgs args)
	{
		Console.WriteLine ("MoveFocus event invoked");
		// controller.RegisterMoveFocusEvent(newlyFocusedWidget);
	}
}