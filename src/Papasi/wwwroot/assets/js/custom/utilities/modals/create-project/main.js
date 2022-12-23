"use strict";

// Class definition
var SwapModalCreateProject = function () {
	// Private variables
	var stepper;
	var stepperObj;
	var form;	

	// Private functions
	var initStepper = function () {
		// Initialize Stepper
		stepperObj = new SwapStepper(stepper);
	}

	return {
		// Public functions
		init: function () {
			stepper = document.querySelector('#swap_modal_create_project_stepper');
			form = document.querySelector('#swap_modal_create_project_form');

			initStepper();
		},

		getStepperObj: function () {
			return stepperObj;
		},

		getStepper: function () {
			return stepper;
		},
		
		getForm: function () {
			return form;
		}
	};
}();


// Webpack support
if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	window.SwapModalCreateProject = window.SwapModalCreateProject = module.exports = SwapModalCreateProject;
}
