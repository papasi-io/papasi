"use strict";

// Class definition
var SwapModalCreateProjectComplete = function () {
	// Variables
	var startButton;
	var form;
	var stepper;

	// Private functions
	var handleForm = function() {
		startButton.addEventListener('click', function () {
			stepper.goTo(1);
		});
	}

	return {
		// Public functions
		init: function () {
			form = SwapModalCreateProject.getForm();
			stepper = SwapModalCreateProject.getStepperObj();
			startButton = SwapModalCreateProject.getStepper().querySelector('[data-swap-element="complete-start"]');

			handleForm();
		}
	};
}();

// Webpack support
if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	window.SwapModalCreateProjectComplete = window.SwapModalCreateProjectComplete = module.exports = SwapModalCreateProjectComplete;
}
