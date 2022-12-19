"use strict";

// Class definition
var SwapLandingPage = function () {
    // Private methods
    var initTyped = function() {
        var typed = new Typed("#swap_landing_hero_text", {
            strings: ["The Best Theme Ever", "The Most Trusted Theme", "#1 Selling Theme"],
            typeSpeed: 50
        });
    }

    // Public methods
    return {
        init: function () {
            //initTyped();
        }   
    }
}();

// Webpack support
if (typeof module !== 'undefined') {
    module.exports = SwapLandingPage;
}

