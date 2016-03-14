package com.weebly.controllingyourcomputer.model;

import com.sun.speech.freetts.Voice;
import com.sun.speech.freetts.VoiceManager;

/**
 * A speech manager implemented using FreeTTS
 * 
 * @author Mihir Kasmalkar
 *
 */
// TODO: make sure that when the user is typing fast, letters don't "overlap"
// each other
public class FreeTTSSpeechManager implements SpeechManager
{
//	/**
//	 * The voice to use to speak text
//	 */
//	private Voice voice;
	
	/**
	 * The VoiceManager to use to get voices
	 */
	private VoiceManager voiceManager;
	
	private Voice previousVoice;
	
	/**
	 * Initialize the speech manager with the FreeTTS voice "kevin"
	 */
	public FreeTTSSpeechManager()
	{		
		// TODO: make different voices customizable
		System.setProperty("mbrola.base", "C:\\Users\\Mihir Kasmalkar\\Documents\\Mbrola\\mbr302a");
	
		voiceManager = VoiceManager.getInstance();
	}
	
	/**
	 * Speak text to the user
	 * @param text the text to speak
	 */
	@Override
	public void speak(String text)
	{
		Thread thread = new Thread(new SpeakTextRunnable(text));
		thread.start();
	}
	
	/**
	 * Speak text to the user
	 * @param text the text to speak
	 * @param rate the rate to speak at in words per minute
	 */
	@Override
	public void speak(String text, int rate)
	{
		Thread thread = new Thread(new SpeakTextRunnable(text, rate));
		thread.start();
	}
	
	
	/**
	 * A class used to asynchronously speak text (otherwise, the user would
	 * have to wait for the app to speak a character before they could type
	 * the next one)
	 * @author Mihir Kasmalkar
	 *
	 */
	class SpeakTextRunnable implements Runnable
	{
		private String text;
		
		private int rate;
		
		public SpeakTextRunnable(String text)
		{
			this.text = text;
			this.rate = 250;
		}
		
		public SpeakTextRunnable(String text, int rate)
		{
			this.text = text;
			this.rate = rate;
		}
		
		// TODO: Sometimes this error occurs:
		// Exception in thread "Thread-38" java.lang.IndexOutOfBoundsException: Index: 12, Size: 54
		//	 at java.util.ArrayList.rangeCheck(ArrayList.java:653)
		//	 at java.util.ArrayList.get(ArrayList.java:429)
		//	 at com.sun.speech.freetts.lexicon.LetterToSoundImpl$FinalState.loadBinary(LetterToSoundImpl.java:851)
		//	 at com.sun.speech.freetts.lexicon.LetterToSoundImpl.loadBinary(LetterToSoundImpl.java:308)
		//	 at com.sun.speech.freetts.lexicon.LetterToSoundImpl.<init>(LetterToSoundImpl.java:221)
		//	 at com.sun.speech.freetts.lexicon.LexiconImpl.load(LexiconImpl.java:313)
		//	 at com.sun.speech.freetts.Voice.allocate(Voice.java:331)
		//	 at com.weebly.controllingyourcomputer.model.FreeTTSSpeechManager$SpeakTextRunnable.run(FreeTTSSpeechManager.java:78)
		//	 at java.lang.Thread.run(Thread.java:745)
		// when the user types a lot of keys fast. Although it does not crash the
		// application (thanks, God!), it should be resolved.
		// TODO: make the speech manager stop whatever it is saying before
		// saying something new
		@Override
		public void run()
		{
			if (previousVoice != null) {
				previousVoice.deallocate();
			}
			
			Voice voice = voiceManager.getVoice("kevin");
			voice.setRate(rate);
			voice.allocate();
			voice.speak(text);
			voice.deallocate();
			
			previousVoice = voice;
		}
		
	}
}
