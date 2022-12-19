"use strict";
 
// Class definition
var SwapSearchHorizontal = function () {
    // Private functions
    var initAdvancedSearchForm = function () {
       var form = document.querySelector('#swap_advanced_search_form');

       // Init tags
       var tags = form.querySelector('[name="tags"]');
       new Tagify(tags);
    }

    var handleAdvancedSearchToggle = function () {
        var link = document.querySelector('#swap_horizontal_search_advanced_link');

        link.addEventListener('click', function (e) {
            e.preventDefault();
            
            if (link.innerHTML === "Advanced Search") {
                link.innerHTML = "Hide Advanced Search";
            } else {
                link.innerHTML = "Advanced Search";
            }
        })
    }

    // Public methods
    return {
        init: function () {
            initAdvancedSearchForm();
            handleAdvancedSearchToggle();
        }
    }     
}();

