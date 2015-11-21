"use strict";

$(document).ready(
	function() {
		// Many of these will have to change according to the parser
		
		var previousText = "";
		var currentWord = "";

		var symbols = "!@#$%^&*()-=_+[]\{};':\",./<>?`~";

		var wordTerminators = " \t\n";
		
		var parserType = DummyParser;
		
		if (typeof parserType === "undefined") {
			throw new ReferenceError("The parser " + parserType + " does not exist");
		}
		
		var parser = new DummyParser();

		$("#editor").on("input", function(event) {
			var currentText = $("#editor").val();
	
			var tokens = parser.parse(text);
			
			if (previousText.length < currentText.length) {
				var newLetter = parser.getNewLetter();
				speak(newLetter);
			}
			else if (previousText.length > currentText.length) {
				speak("Delete");
			}
			else {
				speak("An event was unnecessarily fired");
			}
			
			previousText = currentText;
		});
	}
);
