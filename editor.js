"use strict";

$(document).ready(
	function() {
<<<<<<< HEAD
		startInitChainReaction();
	}
);

function startInitChainReaction() {
	initCompiler();
}

function initCompiler() {
	var TERMINATOR_CHARS = "";
	
	$.get("/editor/compiler", {"language": "keyboardcode"},
		function (data) {
			var grammar = JSON.parse(data);
			
			TERMINATOR_CHARS = grammar["terminator-chars"];
			
			initEditor();
		}
	);
}

function initEditor() {
	var previousText = $("#editor").val();
		
	$("#editor").on("input", function(event) {
		var currentText = $("#editor").val();
	
		if (previousText.length < currentText.length) {
			var newLetter = currentText[currentText.length - 1];
			speak(newLetter);
		}
		else if (previousText.length > currentText.length) {
			speak("Delete");
		}
		else {
			speak("An event was unnecessarily fired");
		}
		
		previousText = currentText;
		
		endInitChainReaction();
	});

}

function endInitChainReaction() {
	speak("Ready");
}
=======
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
>>>>>>> cf78e7b7b29586e8c13cec1d09b92b5166df8ee5
