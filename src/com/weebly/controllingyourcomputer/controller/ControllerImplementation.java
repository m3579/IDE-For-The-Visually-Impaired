/**
 * 
 */
package com.weebly.controllingyourcomputer.controller;

import java.awt.event.KeyEvent;

import javax.swing.JTextArea;

import com.weebly.controllingyourcomputer.model.Model;

/**
 * The implementation of the controller to be used in the final application
 * (in other words, not a test controller implementation).
 * 
 * @author Mihir Kasmalkar
 *
 */
public class ControllerImplementation implements Controller
{
	/**
	 * The model object that the controller should invoke when it receives a
	 * message from the view
	 */
	private Model model;
	
	/**
	 * Initialize the controller with a model object that it should invoke
	 * when it receives a message from the view
	 * @param model the model object that the controller should send messages to
	 * @return the controller object (to enable code such as <code>Controller controller = new ControllerImplementation().setModel(model);</code>
	 */
	@Override
	public Controller setModel(Model model)
	{
		this.model = model;
		return this;
	}

	/**
	 * The method that the view should invoke when an event occurs on the user
	 * interface
	 * @param args any arguments that the view needs to supply the controller with
	 */
	@Override
	// TODO: handle if an argument in ControllerEventArgs is not present for
	// a specific scenario
	public void RegisterEvent(ControllerEventArgs args)
	{
		ControllerEventType type = args.getEventType();
		
		switch (type)
		{
			case STARTED: {
				
				model.Start();
				
				break;
			}
			
			// TODO: make speaking more robust (i.e. stops speaking from previous speak() call
			// if speak() is called again, resolve when it cannot figure out or will mispronounce
			// a phrase or "Can't find diphone y-w/w-p/w-l", etc.)
			case EDITORKEYPRESSED: {
				// TODO: make sure that args.getWidget() actually is a JTextArea
				model.SpeakCurrentChar(args.getKeyCode(), (JTextArea)args.getWidget());
				
				break;
			}
			
			case ACTIONKEYTYPED: {
				model.RegisterActionCommandCharacter(args.getTypedCharacter(), args.getWidget());
				
				break;
			}
			
			case NOEVENT: {
				break;
			}
		}
	}

}
