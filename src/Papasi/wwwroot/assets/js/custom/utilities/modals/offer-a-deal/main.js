"use strict";

// Class definition
var SwapModalOfferADeal = function () {
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
			stepper = document.querySelector('#swap_modal_offer_a_deal_stepper');
			form = document.querySelector('#swap_modal_offer_a_deal_form');

			initStepper();
		},

		getStepper: function () {
			return stepper;
		},

		getStepperObj: function () {
			return stepperObj;
		},
		
		getForm: function () {
			return form;
		}
	};
}();


// Webpack support
if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	window.SwapModalOfferADeal = window.SwapModalOfferADeal = module.exports = SwapModalOfferADeal;
}