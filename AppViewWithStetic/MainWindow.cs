using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	/// <summary>
	/// The class that represents the user interface that the user
	/// will interact with. The GUI code is contained here.
	/// </summary>
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		InitGUI ();
	}

	/// <summary>
	/// Initializes the user interface with anything that was not set using the drag-and-drop Stetic
	/// designer
	/// </summary>
	private void InitGUI()
	{
		Maximize ();

		CodeEditor.InsertAtCursor += CodeEditor_InsertAtCursor;
		CodeEditor.DeleteFromCursor += CodeEditor_DeleteFromCursor;
		CodeEditor.CopyClipboard += CodeEditor_CopyClipboard;
		CodeEditor.PasteClipboard += CodeEditor_PasteClipboard;
		CodeEditor.CutClipboard += CodeEditor_CutClipboard;
	}

	/*
	 * The following methods contain the code that will be invoked in response to events on the
	 * code editor, such as text being typed or deleted.
	 * 
	 * THESE METHODS ARE THE PART OF THE VIEW THAT WILL SEND MESSAGES TO THE CONTROLLER.
	 */

	/// <summary>
	/// The event raised whenever text is inserted into the code editor at the cursor, i.e. not by copy or
	/// pasting, but by actually typing characters
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	void CodeEditor_InsertAtCursor (object sender, InsertAtCursorArgs args)
	{

	}

	/// <summary>
	/// The event raised whenever text is deleted from the code editor by "hitting Backspace or Delete"
	/// (http://docs.go-mono.com/?link=E%3aGtk.TextView.DeleteFromCursor)
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	void CodeEditor_DeleteFromCursor (object sender, DeleteFromCursorArgs args)
	{
		
	}

	/// <summary>
	/// The event raised when text is copied from the code editor
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	void CodeEditor_CopyClipboard (object sender, EventArgs e)
	{

	}

	/// <summary>
	/// The event raised when text is pasted into the code editor
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	void CodeEditor_PasteClipboard (object sender, EventArgs e)
	{

	}

	/// <summary>
	/// The event raised when text is cut from the code editor
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	void CodeEditor_CutClipboard (object sender, EventArgs e)
	{

	}

	/// <summary>
	/// Start the user interface code; in other words, start showing the KeyboardCode screen
	/// to the user; in other words (again), start the app. Note that this is not the entry
	/// point into the application; that is the Main method in <see cref="AppView.EntryPoint"/>. 
	/// </summary>
	public void Start()
	{
		ShowAll ();
	}

	/// <summary>
	/// An event raised when the text in the code editor is changed; i.e., a character is
	/// typed, the user deleted some text, text was pasted, etc.
	/// </summary>
	/// <param name="sender">The object invoking this event</param>
	/// <param name="args">Any arguments that the sender, the object invoking this event, wants to supply</param>
	private void CodeEditor_Changed(object sender, EventArgs args)
	{
		Console.WriteLine ("Text changed");
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
}
