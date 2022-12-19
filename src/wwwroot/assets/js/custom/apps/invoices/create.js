"use strict";

// Class definition
var SwapAppInvoicesCreate = function () {
    var form;

	// Private functions
	var updateTotal = function() {
		var items = [].slice.call(form.querySelectorAll('[data-swap-element="items"] [data-swap-element="item"]'));
		var grandTotal = 0;

		var format = wNumb({
			//prefix: '$ ',
			decimals: 2,
			thousand: ','
		});

		items.map(function (item) {
            var quantity = item.querySelector('[data-swap-element="quantity"]');
			var price = item.querySelector('[data-swap-element="price"]');

			var priceValue = format.from(price.value);
			priceValue = (!priceValue || priceValue < 0) ? 0 : priceValue;

			var quantityValue = parseInt(quantity.value);
			quantityValue = (!quantityValue || quantityValue < 0) ?  1 : quantityValue;

			price.value = format.to(priceValue);
			quantity.value = quantityValue;

			item.querySelector('[data-swap-element="total"]').innerText = format.to(priceValue * quantityValue);			

			grandTotal += priceValue * quantityValue;
		});

		form.querySelector('[data-swap-element="sub-total"]').innerText = format.to(grandTotal);
		form.querySelector('[data-swap-element="grand-total"]').innerText = format.to(grandTotal);
	}

	var handleEmptyState = function() {
		if (form.querySelectorAll('[data-swap-element="items"] [data-swap-element="item"]').length === 0) {
			var item = form.querySelector('[data-swap-element="empty-template"] tr').cloneNode(true);
			form.querySelector('[data-swap-element="items"] tbody').appendChild(item);
		} else {
			SwapUtil.remove(form.querySelector('[data-swap-element="items"] [data-swap-element="empty"]'));
		}
	}

	var handeForm = function (element) {
		// Add item
		form.querySelector('[data-swap-element="items"] [data-swap-element="add-item"]').addEventListener('click', function(e) {
			e.preventDefault();

			var item = form.querySelector('[data-swap-element="item-template"] tr').cloneNode(true);

			form.querySelector('[data-swap-element="items"] tbody').appendChild(item);

			handleEmptyState();
			updateTotal();			
		});

		// Remove item
		SwapUtil.on(form, '[data-swap-element="items"] [data-swap-element="remove-item"]', 'click', function(e) {
			e.preventDefault();

			SwapUtil.remove(this.closest('[data-swap-element="item"]'));

			handleEmptyState();
			updateTotal();			
		});		

		// Handle price and quantity changes
		SwapUtil.on(form, '[data-swap-element="items"] [data-swap-element="quantity"], [data-swap-element="items"] [data-swap-element="price"]', 'change', function(e) {
			e.preventDefault();

			updateTotal();			
		});
	}

	var initForm = function(element) {
		// Due date. For more info, please visit the official plugin site: https://flatpickr.js.org/
		var invoiceDate = $(form.querySelector('[name="invoice_date"]'));
		invoiceDate.flatpickr({
			enableTime: false,
			dateFormat: "d, M Y",
		});

        // Due date. For more info, please visit the official plugin site: https://flatpickr.js.org/
		var dueDate = $(form.querySelector('[name="invoice_due_date"]'));
		dueDate.flatpickr({
			enableTime: false,
			dateFormat: "d, M Y",
		});
	}

	// Public methods
	return {
		init: function(element) {
            form = document.querySelector('#swap_invoice_form');

			handeForm();
            initForm();
			updateTotal();
        }
	};
}();

