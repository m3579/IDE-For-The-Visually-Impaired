"use strict";

$(document).ready(
	function() {
		startInitChainReaction();
	}
);

function startInitChainReaction() {
	initCompiler();
}

function initCompiler() {
	var TERMINATOR_CHARS = "";
	
	$.get("/editor/compiler", {"language-server": "127.0.0.1:7890"},
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