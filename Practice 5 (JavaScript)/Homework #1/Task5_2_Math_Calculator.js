(function() {
	"use strict";

	function CalculateString(inputStr) {
		this._str = inputStr;
		console.log("Введена строка: " + this._str);
	}
	CalculateString.prototype.calc = function() {
		var result = 0,
			matchArr = [],
			searchPattern = /\-?\d+(\.\d+)?|[\+,\-,\*,\/,\=]{1}/ig;

		matchArr = this._str.match(searchPattern);

		if(matchArr[0]*1+"" !== "NaN") {
			result += matchArr[0]*1;
		}

		for(var i = 0; i < matchArr.length; i++) {
			switch(matchArr[i]) {
				case "+": result += matchArr[i+1] * 1; break;
				case "-": result -= matchArr[i+1] * 1; break;
				case "*": result *= matchArr[i+1] * 1; break;
				case "/": result /= matchArr[i+1] * 1; break;
				case "=": break;
				default: continue; break;
			}
		}

		return result;
	}

	var test = new CalculateString("3.5 землекопа +4 поросенка *10 рублей - 5.5 $ /5 человек =");
	console.log(test.calc());

	var test2 = new CalculateString("7+7*2=ёжик");
	console.log(test2.calc());

	var test3 = new CalculateString("2 яблока + апельсин -2 жука = ");
	console.log(test3.calc());

})();