package com.weebly.controllingyourcomputer.model;

import com.sun.speech.freetts.Voice;
import com.sun.speech.freetts.VoiceManager;

/**
 * A speech manager implemented using FreeTTS
 * 
 * @author Mihir Kasmalkar
 *
 */
public class FreeTTSSpeechManager implements SpeechManager
{
	/**
	 * The voice to use to speak text
	 */
	private Voice voice;
	
	/**
	 * The VoiceManager to use to get voices
	 */
	private VoiceManager voiceManager;
	
	/**
	 * Initialize the speech manager with the FreeTTS voice "kevin"
	 */
	public FreeTTSSpeechManager()
	{		
		// TODO: make different voices customizable
		System.setProperty("mbrola.base", "C:\\Users\\Mihir Kasmalkar\\Documents\\Mbrola\\mbr302a");
	
		voiceManager = VoiceManager.getInstance();
		voice = voiceManager.getVoice("kevin");
		voice.allocate();
	}
	
	/**
	 * Speak text to the user
	 * @param text the text to speak
	 */
	@Override
	public void speak(String text)
	{
		voice.speak(text);
	}
}
