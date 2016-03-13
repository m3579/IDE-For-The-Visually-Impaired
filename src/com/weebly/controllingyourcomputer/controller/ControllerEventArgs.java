package com.weebly.controllingyourcomputer.controller;

/**
 * Arguments sent by the view in a message to the controller to do something
 * 
 * @author Mihir Kasmalkar
 *
 */
public class ControllerEventArgs
{
	/**
	 * The type of event this is; in other words, what the event itself it
	 */
	private ControllerEventType type;
	
	/**
	 * Creates a new ControllerEventArgs object setting every member to its
	 * default value: type = ControllerEventType.NOEVENT
	 */
	public ControllerEventArgs()
	{
		type = ControllerEventType.NOEVENT;
	}
	
	/**
	 * Creates a new ControllerEventArgs object with the given parameters
	 * @param type the type of event that has occurred
	 */
	public ControllerEventArgs(ControllerEventType type)
	{
		this.type = type;
	}
	
	/**
	 * Returns the type of the event (in essence, what the event itself is)
	 * @return
	 */
	public ControllerEventType getEventType()
	{
		return type;
	}
}
