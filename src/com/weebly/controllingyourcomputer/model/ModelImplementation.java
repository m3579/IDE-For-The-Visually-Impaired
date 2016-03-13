/**
 * 
 */
package com.weebly.controllingyourcomputer.model;

import java.awt.event.KeyEvent;

import javax.swing.JComponent;
import javax.swing.JTextArea;

import com.weebly.controllingyourcomputer.view.View;

/**
 * The implementation of the model to be used in the final application (in other words,
 * not a test model implementation).
 * 
 * @author Mihir Kasmalkar
 *
 */
public class ModelImplementation implements Model
{
	/**
	 * The view object that the model will manipulate
	 */
	private View view;

	/**
	 * The object used to handle speech (currently, talking to the user; in the
	 * future, maybe listening to the user as well)
	 */
	private SpeechManager speechManager;
	
	private String actionString = "";
	
	/**
	 * Initialize the model with the given view to manipulate
	 * @param view the view that the model should control
	 */
	@Override
	public Model setView(View view)
	{
		this.view = view;

		speechManager = new FreeTTSSpeechManager();
		
		return this;
	}
	
	/**
	 * The method that the controller will invoke when the application starts up
	 */
	@Override
	public void Start()
	{
		speechManager.speak("Welcome to Keyboard Code", 120);
	}

	/**
	 * The method that the controller will invoke if a character must be spoken
	 * (i.e. when a new character is typed or when the user moves around the text
	 * with the arrow keys)
	 * @param keycode the key code of the character that needs to be spoken
	 * @param textArea the JTextArea where the event happened
	 */
	// TODO: change "backspace" to "delete"
	@Override
	public void SpeakCurrentChar(int keycode, JTextArea textArea)
	{
		// Escape pressed - go to action menu
		if (keycode == 27) {
			speechManager.speak("Command", 160);
			view.moveToActionTextArea();
			return;
		}
		// Arrow keys
		else if (keycode >= 37 && keycode <= 40) {
			String selectedText = textArea.getSelectedText();
			if (selectedText != null) {
				speechManager.speak(selectedText, 200);
				return;
			}
			else {
				// TODO: when moving left with left arrow key, make speaker
				// read character that the cursor is on the right of, not the one
				// that the cursor is on the left of
				int caretPosition = textArea.getCaretPosition();
				if (caretPosition > 0) {
					speechManager.speak(String.valueOf(textArea.getText().charAt(caretPosition - 1)));
				}
				else {
					speechManager.speak(String.valueOf(textArea.getText().charAt(0)));
				}
				return;
			}
		}
		
		speechManager.speak(KeyEvent.getKeyText(keycode));
	}
	
	public void RegisterActionCommandCharacter(char c, JComponent widget)
	{
		if (c == '\n') {
			JTextArea actionTextArea = (JTextArea)widget;
			executeAction(actionTextArea.getText());
			actionTextArea.setText("");
		
			view.moveToEditorTextArea();
			
			return;
		}
	}
	
	private void executeAction(String action)
	{
		System.out.println(action);
	}
}
