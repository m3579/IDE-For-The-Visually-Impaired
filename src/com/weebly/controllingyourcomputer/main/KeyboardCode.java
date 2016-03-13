/**
 * The entry point into the application. This class instantiates the GUI and
 * the rest of the code.
 */
package com.weebly.controllingyourcomputer.main;

import com.weebly.controllingyourcomputer.controller.Controller;
import com.weebly.controllingyourcomputer.controller.ControllerImplementation;
import com.weebly.controllingyourcomputer.model.Model;
import com.weebly.controllingyourcomputer.model.ModelImplementation;
import com.weebly.controllingyourcomputer.view.View;
import com.weebly.controllingyourcomputer.view.ViewImplementation;

/**
 * The entry point into the application
 * 
 * @author Mihir Kasmalkar
 *
 */
public class KeyboardCode
{
	public static void main(String[] args)
	{
		Model model = new ModelImplementation();
		View view = new ViewImplementation();
		Controller controller = new ControllerImplementation();
		
		view.setController(controller);
		controller.setModel(model);
		model.setView(view);
		
		view.start();
	}
	
}
