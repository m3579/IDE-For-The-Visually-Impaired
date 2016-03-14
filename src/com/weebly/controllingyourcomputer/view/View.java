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
	
	void moveToActionTextArea();
	void moveToEditorTextArea();
	
	// Implementations of keyboard shortcuts
	void goToLine(int line);
	void recallVariableNames();
	void speakLine();
	void speakSelected();
	void runThrough(int beginning, int end);
	void makeMarker(String name);
	void goToMarker(String name);
	void goToPrevious(String construct);
	void goToNext(String construct);
	void setSpeechSpeed(int wpm);
	void createNewFile(String name);
	void readActionText();
	void exitActionMenu();
}
