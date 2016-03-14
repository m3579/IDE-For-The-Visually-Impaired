package com.weebly.controllingyourcomputer.controller;

import java.awt.event.KeyEvent;

import javax.swing.JComponent;

/**
 * Arguments sent by the view in a message to the controller to do something
 * 
 * @author Mihir Kasmalkar
 *
 */
// TODO: add "modifiers" parameter for key press events (shift, alt, etc.)
public class ControllerEventArgs
{
	/**
	 * The type of event this is; in other words, what the event itself it
	 */
	private ControllerEventType type;
	
	private KeyEvent keyEvent;
	
	/**
	 * The widget on the user interface related to the event
	 */
	private JComponent widget;
	
	/**
	 * Creates a new ControllerEventArgs object setting every member to its
	 * default value: type = ControllerEventType.NOEVENT
	 */
	public ControllerEventArgs()
	{
		type = ControllerEventType.NOEVENT;
	}
	
	/**
	 * Set the event argument object's ControllerEventType (in essence, set the
	 * type of the event; or what the event itself is)
	 * @param type the type of the event
	 * @return the ControllerEventArgs object itself, enabling code such as <code>ControllerEventArgs args = new ControllerEventArgs().setEventType(type);</code>
	 */
	public ControllerEventArgs setEventType(ControllerEventType type)
	{
		this.type = type;
		
		return this;
	}
	
	public ControllerEventArgs setKeyEvent(KeyEvent keyEvent)
	{
		this.keyEvent = keyEvent;
		
		return this;
	}
	
	/**
	 * Set the widget in the user interface that is relevant to this event
	 */
	public ControllerEventArgs setWidget(JComponent widget)
	{
		this.widget = widget;
		
		return this;
	}
	
	/**
	 * Returns the type of the event (in essence, what the event itself is)
	 * @return the type of the event
	 */
	public ControllerEventType getEventType()
	{
		return type;
	}
	
	public KeyEvent getKeyEvent()
	{
		return keyEvent;
	}
	
	/**
	 * Returns the widget in the user interface related to this event
	 * @return
	 */
	public JComponent getWidget()
	{
		return widget;
	}
}
