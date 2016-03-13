/**
 * 
 */
package com.weebly.controllingyourcomputer.view;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.BoxLayout;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextArea;

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

		frame.getContentPane().add(mainPanel);
		frame.setVisible(true);
		
		ControllerEventArgs args = new ControllerEventArgs();
		args.setEventType(ControllerEventType.STARTED);
		controller.RegisterEvent(args);
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
			System.out.println("Pressed");
			ControllerEventArgs args = new ControllerEventArgs();
			args.setEventType(ControllerEventType.EDITORKEYPRESSED);
			args.setPressedKey(e.getKeyCode());
			args.setWidget(editorTextArea);
			controller.RegisterEvent(args);
		}

		@Override
		public void keyReleased(KeyEvent e)
		{
			
		}
	}
	
	
	class ActionKeyListener implements KeyListener
	{

		@Override
		public void keyTyped(KeyEvent e)
		{
			ControllerEventArgs args = new ControllerEventArgs();
			args.setEventType(ControllerEventType.ACTIONKEYTYPED);
			args.setTypedCharacter(e.getKeyChar());
			args.setWidget(actionTextArea);
			controller.RegisterEvent(args);
		}

		@Override
		public void keyPressed(KeyEvent e)
		{

		}

		@Override
		public void keyReleased(KeyEvent e)
		{
			
		}
		
	}
	
}
