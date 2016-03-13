/**
 * 
 */
package com.weebly.controllingyourcomputer.view;

import com.weebly.controllingyourcomputer.controller.Controller;

/**
 * @author Mihir Kasmalkar
 *
 */
public interface View
{
	View setController(Controller controller);

	void start();
}
