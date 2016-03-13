/**
 * 
 */
package com.weebly.controllingyourcomputer.model;

import java.awt.event.KeyEvent;

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
		speechManager.speak("Welcome to Keyboard Code");
	}

	/**
	 * The method that the controller will invoke if a character must be spoken
	 * (i.e. when a new character is typed or when the user moves around the text
	 * with the arrow keys)
	 * @param keycode the key code of the character that needs to be spoken
	 */
	@Override
	public void SpeakCurrentChar(int keycode)
	{
		speechManager.speak(KeyEvent.getKeyText(keycode));
	}
}
