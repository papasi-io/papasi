"use strict";

// Class definition
var SwapAppChat = function () {
	// Private functions
	var handeSend = function (element) {
		if (!element) {
			return;
		}

		// Handle send
		SwapUtil.on(element, '[data-swap-element="input"]', 'keydown', function(e) {
			if (e.keyCode == 13) {
				handeMessaging(element);
				e.preventDefault();

				return false;
			}
		});

		SwapUtil.on(element, '[data-swap-element="send"]', 'click', function(e) {
			handeMessaging(element);
		});
	}

	var handeMessaging = function(element) {
		var messages = element.querySelector('[data-swap-element="messages"]');
		var input = element.querySelector('[data-swap-element="input"]');

        if (input.value.length === 0 ) {
            return;
        }

		var messageOutTemplate = messages.querySelector('[data-swap-element="template-out"]');
		var messageInTemplate = messages.querySelector('[data-swap-element="template-in"]');
		var message;
		
		// Show example outgoing message
		message = messageOutTemplate.cloneNode(true);
		message.classList.remove('d-none');
		message.querySelector('[data-swap-element="message-text"]').innerText = input.value;		
		input.value = '';
		messages.appendChild(message);
		messages.scrollTop = messages.scrollHeight;
		
		
		setTimeout(function() {			
			// Show example incoming message
			message = messageInTemplate.cloneNode(true);			
			message.classList.remove('d-none');
			message.querySelector('[data-swap-element="message-text"]').innerText = 'Thank you for your awesome support!';
			messages.appendChild(message);
			messages.scrollTop = messages.scrollHeight;
		}, 2000);
	}

	// Public methods
	return {
		init: function(element) {
			handeSend(element);
        }
	};
}();

