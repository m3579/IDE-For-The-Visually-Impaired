/**
 * 
 */
package com.weebly.controllingyourcomputer.view;

import java.awt.Point;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.text.Caret;

import com.weebly.controllingyourcomputer.controller.Controller;
import com.weebly.controllingyourcomputer.controller.ControllerEventArgs;
import com.weebly.controllingyourcomputer.controller.ControllerEventType;

/**
 * The implementation of the view to be used in the final application (in other
 * words, not a test view implementation).
 * 
 * @author Mihir Kasmalkar
 *
 */
public class ViewImplementation implements View
{
	private Controller controller;

	private JTextArea editorTextArea;
	
	private JTextArea actionTextArea;
	
	@Override
	public View setController(Controller controller)
	{
		this.controller = controller;
		return this;
	}
	
	@Override
	public void start()
	{
		JFrame frame = new JFrame("Keyboard Code");
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setSize(700, 700);
		
		JPanel mainPanel = new JPanel();
		mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.X_AXIS));
		
		JPanel editorPanel = new JPanel();
		//editorPanel.setLayout(new BoxLayout(editorPanel, BoxLayout.Y_AXIS));
		
	    editorTextArea = new JTextArea(30, 30);
		editorTextArea.addKeyListener(new EditorKeyListener());
	
		editorPanel.add(editorTextArea);
		
		actionTextArea = new JTextArea(10, 20);
		actionTextArea.addKeyListener(new ActionKeyListener());
		editorPanel.add(actionTextArea);
		
		mainPanel.add(editorPanel);
		
		JPanel filesystemPanel = new JPanel();
		JButton testCaretPosition = new JButton("Caret");
		testCaretPosition.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e)
			{
				System.out.println(editorTextArea.getCaretPosition());
			}
			
		});
		filesystemPanel.add(testCaretPosition);
		// Will add content to the filesystemPanel later
		mainPanel.add(filesystemPanel);
		
		frame.getContentPane().add(mainPanel);
		frame.setVisible(true);
		
		ControllerEventArgs args = new ControllerEventArgs();
		args.setEventType(ControllerEventType.STARTED);
		controller.registerEvent(args);
	}
	
	public void moveToActionTextArea()
	{
		actionTextArea.requestFocus();
	}
	
	public void moveToEditorTextArea()
	{
		editorTextArea.requestFocus();
	}
	
	class EditorKeyListener implements KeyListener
	{

		@Override
		public void keyTyped(KeyEvent e)
		{

		}

		@Override
		public void keyPressed(KeyEvent e)
		{
			ControllerEventArgs args = new ControllerEventArgs();
			args.setEventType(ControllerEventType.EDITORKEYTYPED);
			args.setKeyEvent(e);
			args.setWidget(editorTextArea);
			controller.registerEvent(args);
		}

		@Override
		public void keyReleased(KeyEvent e)
		{
			ControllerEventArgs args = new ControllerEventArgs();
			args.setEventType(ControllerEventType.EDITORKEYRELEASED);
			args.setKeyEvent(e);
			args.setWidget(editorTextArea);
			controller.registerEvent(args);
		}
	}
	
	
	class ActionKeyListener implements KeyListener
	{

		@Override
		public void keyTyped(KeyEvent e)
		{
			
		}

		@Override
		public void keyPressed(KeyEvent e)
		{
			
		}

		@Override
		public void keyReleased(KeyEvent e)
		{
			ControllerEventArgs args = new ControllerEventArgs();
			args.setEventType(ControllerEventType.ACTIONKEYPRESSED);
			args.setKeyEvent(e);
			args.setWidget(actionTextArea);
			controller.registerEvent(args);
		}
		
	}

	// KEYBOARD SHORTCUTS =========================================================

	@Override
	public void goToLine(int line)
	{
		Caret caret = editorTextArea.getCaret();
		caret.setMagicCaretPosition(new Point(0, line));
		System.out.println("Went to position");
	}

	@Override
	public void recallVariableNames()
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void speakLine()
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void speakSelected()
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void runThrough(int beginning, int end)
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void makeMarker(String name)
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void goToMarker(String name)
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void goToPrevious(String construct)
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void goToNext(String construct)
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void setSpeechSpeed(int wpm)
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void createNewFile(String name)
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void readActionText()
	{
		// TODO Auto-generated method stub
		
	}

	@Override
	public void exitActionMenu()
	{
		// TODO Auto-generated method stub
		
	}
	
	// ============================================================================
}
