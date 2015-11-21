if (typeof Parser === "undefined") {
	throw new ReferenceError("The base class Parser for DummyParser is not defined");
}

var DummyParser = function() {
	Parser.call(this);
	
	alert("Dummy parser created");
};

DummyParser.prototype = Object.create(Parser.prototype);

DummyParser.prototype.parse = function(text) {
	return text.split(" ");
};
