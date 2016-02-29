/*

Here is a list of the keyboard shortcuts in KeyboardCode. You can access these shortcuts
by pressing the control key once (not holding it); you will be taken to a text box on the bottom of
the screen where you will type the command. When you hit enter, the command will be executed and you
will be taken back to the source code.

// TODO: instead of going to a different text box, make it work like Vim

line <number>		Go to line					Will go to the specified line number
v					Recall variable name		Will speak the names of the defined variables in the current scope
s					Speak line					Speak the text of the current line from the beginning
runth <number> <number>
					Run through					Go through the the lines of code from the first numberth line to the second
												numberth line and speak the first words
m <string>			Marker						Make a marker with the given name
g <string>			Go to marker				Go to the marker with the given name
pre	<construct>		Previous					Go to the most recent previous occurence of the construct
												(which will vary from language to language, but will usually be
												things like "if", "for", etc.)
nex <construct>		Next						Go to the next occurence of the construct

speed <number>		Set speech speed			Set the speaker's speed in words per minute
// TODO: add more ways to customize speech


There is a special command that reads the text in the action menu after the Ctrl key is pressed:

Caps Lock-,				Read action menu command	Reads the text entered in the action menu

Then there are these:

Escape				Exit the action manu		Exit the action menu and go back to the code

Caps Lock-n			Create new file				Create a new file in the file system

 */

$(document).ready(
 	// Get information about the languages's syntax
	// For now, there is only one option for the language
	// In the future, there will be more options
	function() {
        $.ajax(
			// The symbol map maps text like "{" or "|" to text ("open brace", "bar")
			// This is needed because meSpeak does not automatically speak some symbols
            "/programming/symbolmap",
            {
                method: "get",
                
                success: function (data, status, xhr) {
					// initEditor is a callback here that initializes
					// the text editor with the options received from
					// the web server
					// Note that the web server sends JSON data
                    // TODO: make sure data JSON is valid
                	initEditor(JSON.parse(data));
                }
            }
        );
        
    }
);

/* Initializes the editor with JSON data about the
 * programming language being used (and other factors
 * as well)
 *
 * @param {Object} symbol_map - A map where the keys are symbols (like ^, |, etc.) and the values
 * are the text that should be read to the user when the editor needs to speak them ("caret", "bar")
 */
function initEditor(symbol_map)
{
	// Right now, initEditor's job is to speak any characters that were typed
	// or say "delete" if a character was deleted
	
	// The text before the new character was typed
	var editorPreviousText = $("#editor").val();
	
	var actionPreviousText = $("#action-menu").val();
	
	var speechActionID;
	
	var controlKeyWasPressed = false;
	
	var command = "";
	
	// The text editor
	// TODO: find faster speech library
	// TODO: change this so that it fires whenever any key is pressed,
	// to handle a wider range of events
	// TODO: (HIGH PRIORITY) register copies, cuts, and pastes
	// When something changes inside of the editor
	document.getElementById("editor").addEventListener("keyup", function (event) {
 
		// Control was pressed
		if (event.keyCode == 17) {
			$("#action-menu").focus();
			speechActionID = meSpeak.speak("Control");
			
			return;
		}
		
		var currentText = $("#editor").val();

		// A single character was deleted - there is one less character than before
		if (currentText.length == editorPreviousText.length - 1) {
			meSpeak.stop(speechActionID);
			var charToSpeak = findDifferentCharacter(editorPreviousText, currentText);
			if (charToSpeak in symbol_map) {
				speechActionID = meSpeak.speak(symbol_map[charToSpeak]);
			}
			else {
				speechActionID = meSpeak.speak(findDifferentCharacter(editorPreviousText, currentText));
			}
		}
		// Multiple characters were deleted - there is less text than before
		else if (currentText.length < editorPreviousText.length) {
			meSpeak.stop(speechActionID);
			speechActionID = meSpeak.speak("delete");
		}
		// Something was added - there is more text now than before
		else if (currentText.length > editorPreviousText.length) {
			meSpeak.stop(speechActionID);

			var charToSpeak = findDifferentCharacter(editorPreviousText, currentText);

			if (charToSpeak in symbol_map) {
				speechActionID = meSpeak.speak(symbol_map[charToSpeak]);
			}
			else {
				speechActionID = meSpeak.speak(findDifferentCharacter(editorPreviousText, currentText));
			}
		}

		editorPreviousText = currentText;
	});
	
	// The action menu
	document.getElementById("action-menu").addEventListener("keyup", function (event) {
		// Enter was pressed
		if (event.keyCode == 13) {
			executeCommand(command);
			$("text-editor").focus();
			return;
		}
		else {
			command = $("action-menu").val();
		}
		
		var currentText = $("#action-menu").val();

		// A single character was deleted - there is one less character than before
		if (currentText.length == actionPreviousText.length - 1) {
			meSpeak.stop(speechActionID);
			var charToSpeak = findDifferentCharacter(actionPreviousText, currentText);
			if (charToSpeak in symbol_map) {
				speechActionID = meSpeak.speak(symbol_map[charToSpeak]);
			}
			else {
				speechActionID = meSpeak.speak(findDifferentCharacter(actionPreviousText, currentText));
			}
		}
		// Multiple characters were deleted - there is less text than before
		else if (currentText.length < actionPreviousText.length) {
			meSpeak.stop(speechActionID);
			speechActionID = meSpeak.speak("delete");
		}
		// Something was added - there is more text now than before
		else if (currentText.length > actionPreviousText.length) {
			meSpeak.stop(speechActionID);

			var charToSpeak = findDifferentCharacter(actionPreviousText, currentText);

			if (charToSpeak in symbol_map) {
				speechActionID = meSpeak.speak(symbol_map[charToSpeak]);
			}
			else {
				speechActionID = meSpeak.speak(findDifferentCharacter(actionPreviousText, currentText));
			}
		}

		actionPreviousText = currentText;
	});
}

function executeCommand(command)
{
	alert("Executing |" + command + "|");
}

/*
 * If a character was typed into previous to get current, find that character
 * If a character was deleted from previous to get current, find the character at the cursor
 *
 * @param {String} previous - the text before the text was typed/deleted
 * @param {String} current - the text after the text was typed/deleted
 *
 * @returns {String} The character that was typed (if a character was typed) OR the character at the cursor (if a character was deleted)
 */
function findDifferentCharacter(previous, current)
{	
	// If the user deleted something
	if (previous.length > current.length) {
		// Iterate over all of the current characters
		for (var i = 0; i < current.length; i++) {
			// If the text differs
			if (current[i] != previous[i]) {
				// Return the previous character (the character
				// at the cursor now that the user has deleted
				// something)
				
				// If there is no previous character
				// (the cursor is at the beginning of the text widget)
				if (previous[i - 1] === undefined) {
					return '';
				}
				else {
					return previous[i - 1]
				}
			}
		}	
		
		// Return the last character
		
		// If there is no previous character
		// (the cursor is at the beginning of the text widget)
		if (previous[previous.length - 2] === undefined) {
			return '';
		}
		else {
			return previous[previous.length - 2];
		}
	}
	// If the user typed something
	else if (current.length > previous.length) {
		// Do the inverse of if they deleted something
		for (var i = 0; i < previous.length; i++) {
			if (previous[i] != current[i]) {
				return current[i];
			}
		}	
		
		return current[current.length - 1];
	}
	else {
		return '';
	}
}