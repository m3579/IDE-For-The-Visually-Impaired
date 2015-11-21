
// Abstract
var Parser = function() {
	if (this.constructor === Parser) {
		throw new Error("You cannot instantiate abstract class Parser");
	}
};

// Abstract
Parser.prototype.parse = function (text) {
	if (this.constructor === Parser) {
		throw new Error("You must override the Parser.prototype.parse method in the class " + this.constructor.name);		
	}
};