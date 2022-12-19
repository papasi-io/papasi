"use strict";

// Class definition
var SwapModalUpgradePlan = function () {
    // Private variables
    var modal;
	var planPeriodMonthButton;
	var planPeriodAnnualButton;
    var planUpgradeButton;

    // Private functions
	var changePlanPrices = function(type) {
		var items = [].slice.call(modal.querySelectorAll('[data-swap-plan-price-month]'));

		items.map(function (item) {
			var monthPrice = item.getAttribute('data-swap-plan-price-month');
			var annualPrice = item.getAttribute('data-swap-plan-price-annual');

			if ( type === 'month' ) {
				item.innerHTML = monthPrice;
			} else if ( type === 'annual' ) {
				item.innerHTML = annualPrice;
			}
		});
	}

    var handlePlanPeriodSelection = function() {
        // Handle period change
        planPeriodMonthButton.addEventListener('click', function (e) {
            e.preventDefault();

            planPeriodMonthButton.classList.add('active');
            planPeriodAnnualButton.classList.remove('active');

            changePlanPrices('month');
        });

		planPeriodAnnualButton.addEventListener('click', function (e) {
            e.preventDefault();

            planPeriodMonthButton.classList.remove('active');
            planPeriodAnnualButton.classList.add('active');
            
            changePlanPrices('annual');
        });
    }
    
    var handlePlanUpgrade = function () {
        if ( !planUpgradeButton ) {
            return;
        }

        planUpgradeButton.addEventListener('click', function (e) {
            e.preventDefault();

            var el = this;

            swal.fire({
                text: "Are you sure you would like to upgrade to selected plan ?",
                icon: "warning",
                buttonsStyling: false,
                showDenyButton: true,
                confirmButtonText: "Yes",
                denyButtonText: 'No',
                customClass: {
                    confirmButton: "btn btn-primary",
                    denyButton: "btn btn-light-danger"
                }
            }).then((result) => {
                if (result.isConfirmed) {
                    el.setAttribute('data-swap-indicator', 'on');            
                    el.disabled = true;

                    setTimeout(function() {
                        Swal.fire({
                            text: 'Your subscription plan has been successfully upgraded', 
                            icon: 'success',
                            confirmButtonText: "Ok",
                            buttonsStyling: false,
                            customClass: {
                                confirmButton: "btn btn-light-primary"
                            }
                        }).then((result) => {
                            bootstrap.Modal.getInstance(modal).hide();
                        })

                    }, 2000);
                } 
            });            
        });
    }

    // Public methods
    return {
        init: function () {
            // Elements
            modal = document.querySelector('#swap_modal_upgrade_plan');

            if (!modal) {
				return;
			}

			planPeriodMonthButton = modal.querySelector('[data-swap-plan="month"]');
			planPeriodAnnualButton = modal.querySelector('[data-swap-plan="annual"]');
            planUpgradeButton = document.querySelector('#swap_modal_upgrade_plan_btn');

            // Handlers
            handlePlanPeriodSelection();
            handlePlanUpgrade();
            changePlanPrices();
        }
    }
}();

