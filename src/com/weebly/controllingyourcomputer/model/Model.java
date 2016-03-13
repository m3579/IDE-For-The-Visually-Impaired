/**
 * 
 */
package com.weebly.controllingyourcomputer.model;

import com.weebly.controllingyourcomputer.view.View;

/**
 * The model of the Model-View-Controller architecture - contains the application
 * logic and manipulates the view when it receives a message from the controller
 * (which receives an event from the view)
 * 
 * @author Mihir Kasmalkar
 *
 */
public interface Model
{
	/**
	 * Initialize the model with the given view to control
	 * @param view the view that the model will manipulate
	 * @return the model object (to enable code such as <code>Model model = new ModelImplementation().setView(view);</code>
	 */
	Model setView(View view);

	/**
	 * The method that the controller will invoke when the application starts up
	 */
	void Start();
	
	/**
	 * The method that the controller will invoke if a character must be spoken
	 * (i.e. when a new character is typed or when the user moves around the text
	 * with the arrow keys)
	 * @param keycode the key code of the character that needs to be spoken
	 */
	void SpeakCurrentChar(int keycode);
}
