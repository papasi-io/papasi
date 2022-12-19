"use strict";

// Class definition
var SwapModalUserSearch = function () {
    // Private variables
    var element;
    var suggestionsElement;
    var resultsElement;
    var wrapperElement;
    var emptyElement;
    var searchObject;

    // Private functions
    var processs = function (search) {
        var timeout = setTimeout(function () {
            var number = SwapUtil.getRandomInt(1, 3);

            // Hide recently viewed
            suggestionsElement.classList.add('d-none');

            if (number === 3) {
                // Hide results
                resultsElement.classList.add('d-none');
                // Show empty message 
                emptyElement.classList.remove('d-none');
            } else {
                // Show results
                resultsElement.classList.remove('d-none');
                // Hide empty message 
                emptyElement.classList.add('d-none');
            }

            // Complete search
            search.complete();
        }, 1500);
    }

    var clear = function (search) {
        // Show recently viewed
        suggestionsElement.classList.remove('d-none');
        // Hide results
        resultsElement.classList.add('d-none');
        // Hide empty message 
        emptyElement.classList.add('d-none');
    }

    // Public methods
    return {
        init: function () {
            // Elements
            element = document.querySelector('#swap_modal_users_search_handler');

            if (!element) {
                return;
            }

            wrapperElement = element.querySelector('[data-swap-search-element="wrapper"]');
            suggestionsElement = element.querySelector('[data-swap-search-element="suggestions"]');
            resultsElement = element.querySelector('[data-swap-search-element="results"]');
            emptyElement = element.querySelector('[data-swap-search-element="empty"]');

            // Initialize search handler
            searchObject = new SwapSearch(element);

            // Search handler
            searchObject.on('kt.search.process', processs);

            // Clear handler
            searchObject.on('kt.search.clear', clear);
        }
    };
}();
