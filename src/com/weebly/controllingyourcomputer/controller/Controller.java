/**
 * 
 */
package com.weebly.controllingyourcomputer.controller;

import com.weebly.controllingyourcomputer.model.Model;

/**
 * The controller between the model and the view in the Model-View-Controller
 * architecture
 * 
 * @author Mihir Kasmalkar
 *
 */
public interface Controller
{
	/**
	 * Initializes the controller object to send messages to the given model
	 * @param model the model object that the controller should send messages to
	 * @return the controller object (to enable code such as <code>Controller controller = new ControllerImplementation().setModel(model);</code>
	 */
	Controller setModel(Model model);
	
	/**
	 * A method that the view will use to send messages to the controller. This
	 * will be invoked whenever something happens on the user interface that
	 * the model should respond to
	 * 
	 * @param args arguments containing information about the event that had happened
	 */
	void registerEvent(ControllerEventArgs args);
}
