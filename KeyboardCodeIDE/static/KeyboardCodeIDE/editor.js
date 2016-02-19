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
	var previousText = $("#editor").val();
	
	var speechActionID;
	
	// TODO: change this so that it fires whenever any key is pressed,
	// to handle a wider range of events
	// TODO: (HIGH PRIORITY) register copies, cuts, and pastes
	// When something changes inside of the editor
	$("#editor").on("input", function (event) {
        var currentText = $("#editor").val();
		
		// A single character was deleted - there is one less character than before
        if (currentText.length == previousText.length - 1) {
            meSpeak.stop(speechActionID);
			var charToSpeak = findDifferentCharacter(previousText, currentText);
			if (charToSpeak in symbol_map) {
				speechActionID = meSpeak.speak(symbol_map[charToSpeak]);
			}
			else {
				speechActionID = meSpeak.speak(findDifferentCharacter(previousText, currentText));
        	}
		}
		// Multiple characters were deleted - there is less text than before
		else if (currentText.length < previousText.length) {
			meSpeak.stop(speechActionID);
			meSpeak.speak("delete");
		}
		// Something was added - there is more text now than before
        else if (currentText.length > previousText.length) {
			meSpeak.stop(speechActionID);
            
			var charToSpeak = findDifferentCharacter(previousText, currentText);
			if (charToSpeak in symbol_map) {
				speechActionID = meSpeak.speak(symbol_map[charToSpeak]);
			}
			else {
				speechActionID = meSpeak.speak(findDifferentCharacter(previousText, currentText));
        	}
		}
		// Nothing we care about happened (the event fired for some other reason)
		else {
            return;
        }

        previousText = currentText;
    });
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