/**
 * 
 */
package com.weebly.controllingyourcomputer.controller;

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
	public void RegisterEvent(ControllerEventArgs args)
	{
		ControllerEventType type = args.getEventType();
		
		switch (type)
		{
			case STARTED: {
				
				model.Start();
				
				break;
			}
			
			case KEYPRESSED: {
				
				model.SpeakCurrentChar(args.getKeyCode());
				
				break;
			}
			
			case NOEVENT: {
				break;
			}
		}
	}

}
