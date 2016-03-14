/**
 * 
 */
package com.weebly.controllingyourcomputer.model;

import java.awt.event.KeyEvent;
import java.util.ArrayList;
import java.util.HashMap;

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
		
	private ArrayList<Integer> arrowKeyCodes;
	
	private boolean charWasTyped = false;
	
	private int charIndex = -1;
			
	private boolean stopMovingLeft = false;
	private boolean stopMovingRight = false;
	
	/**
	 * A mapping between symbols that FreeTTS cannot pronounce or pronounces
	 * improperly (for example, it calls both { and [ "open bracket") and the
	 * text that should be spoken when they need to be spoken
	 */
	private HashMap<String, String> symbolsToText;
	
	public ModelImplementation()
	{
		arrowKeyCodes = new ArrayList<Integer>();
		arrowKeyCodes.add(KeyEvent.VK_UP);
		arrowKeyCodes.add(KeyEvent.VK_DOWN);
		arrowKeyCodes.add(KeyEvent.VK_LEFT);
		arrowKeyCodes.add(KeyEvent.VK_RIGHT);
	
		// These are the characters the FreeTTS does not speak:
		symbolsToText = new HashMap<String, String>();
		symbolsToText.put("!", "exclamation");
		symbolsToText.put("(", "left parenthesis");
		symbolsToText.put(")", "right parenthesis");
		symbolsToText.put("-", "minus");
		symbolsToText.put("{", "left brace");
		symbolsToText.put("}", "right brace");
		symbolsToText.put("[", "left bracket");
		symbolsToText.put("]", "right bracket");
		symbolsToText.put("\"", "quote");
		symbolsToText.put("'", "single quote");
		symbolsToText.put(":", "colon");
		symbolsToText.put(";", "semicolon");
		symbolsToText.put("<", "less than");
		symbolsToText.put(">", "greater than");
		symbolsToText.put(",", "comma");
		symbolsToText.put(".", "period");
		symbolsToText.put("?", "question mark");
		symbolsToText.put("`", "backtick");
		symbolsToText.put("\t", "tab");
		symbolsToText.put(" ", "space");
		// TODO: Add another entry for enter/newline?
	}
		
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
	public void registerEditorKeyRelease(KeyEvent keyEvent, JTextArea textArea)
	{
		// If the key press is actually a character (and not a key like Control
		// or Shift)
		// OR if the key is an arrow key...
		if (!charWasTyped) {
//			if (keyEvent.getKeyChar() != KeyEvent.CHAR_UNDEFINED
//				|| arrowKeyCodes.contains(keyEvent.getKeyCode())) {
//				// Speak the character that the cursor is currently on
//				speakCurrentChar(keyEvent, textArea);
//			}
			System.out.println("Char was not typed");
		}
		
		charWasTyped = false;
	}
	
	@Override
	public void registerActionKeyRelease(KeyEvent keyEvent, JTextArea textArea)
	{
		int keycode = keyEvent.getKeyCode();
		
		// Enter was pressed - execute the action and go back to the code editor
		if (keycode == 10) {
			executeAction(textArea.getText());
			textArea.setText("");
			
			// Make sure that the newline is not appended to the text area
			// (I set the text to "" in this method, BEFORE the newline will be
			// registered, so I need to disable it)
			keyEvent.consume();
		
			view.moveToEditorTextArea();
		}
		else {
			speakCurrentChar(keyEvent, textArea);
		}
	}

	@Override
	public void registerEditorKeyType(KeyEvent keyEvent, JTextArea textArea)
	{
		System.out.println("Typed");
		
		int keycode = keyEvent.getKeyCode();
		
		// Escape pressed - go to action menu
		if (keycode == KeyEvent.VK_ESCAPE) {
			speechManager.speak("Command", 120);
			view.moveToActionTextArea();
			return;
		}

		if (arrowKeyCodes.contains(keycode)) {
			speakCurrentChar(keyEvent, textArea);
			return;
		}
		
		if (keycode == KeyEvent.CHAR_UNDEFINED) {
			charWasTyped = false;
			return;
		}
		else {
			speakCurrentChar(keyEvent, textArea);
			charWasTyped = true;
		}
	}

	// TODO: change "backspace" to "delete"
	public void speakCurrentChar(KeyEvent keyEvent, JTextArea textArea)
	{
		int keycode = keyEvent.getKeyCode();
		
		// TODO: sometimes this exception occurs when typing fast:
//		Exception in thread "Thread-131" java.lang.IndexOutOfBoundsException: Index: 24, Size: 6
//		at java.util.ArrayList.rangeCheck(ArrayList.java:653)
//		at java.util.ArrayList.get(ArrayList.java:429)
//		at com.sun.speech.freetts.lexicon.LetterToSoundImpl$FinalState.loadBinary(LetterToSoundImpl.java:851)
//		at com.sun.speech.freetts.lexicon.LetterToSoundImpl.loadBinary(LetterToSoundImpl.java:308)
//		at com.sun.speech.freetts.lexicon.LetterToSoundImpl.<init>(LetterToSoundImpl.java:221)
//		at com.sun.speech.freetts.lexicon.LexiconImpl.load(LexiconImpl.java:313)
//		at com.sun.speech.freetts.Voice.allocate(Voice.java:331)
//		at com.weebly.controllingyourcomputer.model.FreeTTSSpeechManager$SpeakTextRunnable.run(FreeTTSSpeechManager.java:112)
//		at java.lang.Thread.run(Thread.java:745)
		// Although it does not crash the application, it must be taken care of
		
		// Arrow keys
		if (arrowKeyCodes.contains(keycode)) {
			System.out.println("An arrow key was pressed");
			String selectedText = textArea.getSelectedText();
			
			// Text is highlighted
			if (selectedText != null) {
				speechManager.speak(selectedText, 200);
			}
			// User is just moving around with arrow keys
			else {
				String text = textArea.getText();
				
				// TODO: when moving left with left arrow key, make speaker
				// read character that the cursor is on the right of, not the one
				// that the cursor is on the left

				if (keycode == KeyEvent.VK_RIGHT) {
					if (charIndex < text.length() - 1) {
						if (!stopMovingRight) {
							charIndex++;
							stopMovingRight = true;
						}
					}
					else {
						charIndex++;
					}
				}
				else if (keycode == KeyEvent.VK_LEFT) {
					if (charIndex < 0) {
						if (!stopMovingLeft) {
							charIndex--;
							stopMovingLeft = true;
						}
					}
					else {
						charIndex--;
					}
				}
				else if (keycode == KeyEvent.VK_DOWN) {
					// TODO: implement going down
				}
				else if (keycode == KeyEvent.VK_UP) {
					// TODO: implement going up
				}
				
				System.out.println("The index is " + charIndex);
				
				// User is at very beginning of the text area
				if (charIndex <= 0) {
					speechManager.speak(getPronounceableString(text.charAt(0)));
					java.awt.Toolkit.getDefaultToolkit().beep();			
					return;
				}
				// User is at the end of the text
				else if (charIndex == text.length() - 1) {
					speechManager.speak(getPronounceableString(text.charAt(text.length() - 1)));
					java.awt.Toolkit.getDefaultToolkit().beep();
					return;
				}
				// User is somewhere in the text area
				// Speak the character in front of the caret (the cursor)
				else {
					speechManager.speak(getPronounceableString(text.charAt(charIndex)));
				}
		
			}
		}
		// Normal character
		else {
			
			if (keycode == KeyEvent.VK_BACK_SPACE) {
				charIndex--;
			}
			else {
				charIndex++;
				System.out.println("Incremented: " + charIndex);
			}
			
			speechManager.speak(getPronounceableString(keyEvent.getKeyChar()));
		}
	}
	
	private String getPronounceableString(char c)
	{
		String s = String.valueOf(c);
		
		if (symbolsToText.containsKey(s)) {
			return symbolsToText.get(s);
		}
		
		return s;
	}
	
	private String getPronounceableString(int keycode)
	{
		return KeyEvent.getKeyText(keycode);
	}
	
	private void executeAction(String action)
	{
		action = action.trim();
		
		// Split the string by the whitespace
		String[] actionParts = action.split("\\s+");
		
		if (actionParts.length > 0) {
			if (actionParts[0].equals("line")) {
				if (actionParts.length > 1) {
					try {
						int line = Integer.parseInt(actionParts[1]);
						view.goToLine(line);
					}
					catch (NumberFormatException nfe) {
						speechManager.speak("Invalid line", 120);
					}
				}
			}
		}
	}
}
