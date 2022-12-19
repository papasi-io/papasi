"use strict";

// Class definition
var SwapModalOfferADealComplete = function () {
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
			form = SwapModalOfferADeal.getForm();
			stepper = SwapModalOfferADeal.getStepperObj();
			startButton = SwapModalOfferADeal.getStepper().querySelector('[data-swap-element="complete-start"]');

			handleForm();
		}
	};
}();

// Webpack support
if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
	window.SwapModalOfferADealComplete = window.SwapModalOfferADealComplete = module.exports = SwapModalOfferADealComplete;
}