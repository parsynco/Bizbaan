
const $element = $('input[type="range"]');
//const $tooltip = $('#range-tooltip');
const sliderStates = [
    { name: "low", tooltip: "Great, we're confident we can complete your project within <strong>24 hours</strong> of launch.", range: _.range(5, 26) },
    { name: "med", tooltip: "Looks good! We can complete a project of this size within <strong>48 hours</strong> of launch.", range: _.range(26, 36) },
    { name: "high", tooltip: "With a project of this size we'd like to talk with you before setting a completion timeline.", range: _.range(36, 51) },
];
let currentState;
let $handle;

$element
    .rangeslider({
        polyfill: false,
        onInit: function () {

            $handle = $('.rangeslider__handle', this.$range);
            updateHandle($handle[0], this.value);
            updateState($handle[0], this.value);
        }
    })
    .on('input', function () {
        updateHandle($handle[0], this.value);
        checkState($handle[0], this.value);
    });

// Update the value inside the slider handle
function updateHandle(el, val) {
    el.textContent = val.toString();

}

// Check if the slider state has changed
function checkState(el, val) {
    // If the value does not fall in the range of the current state, update it
    if (!_.includes(currentState.range, parseInt(val))) {
        updateState(el, val);
    }
}

// Change the state of the slider
function updateState(el, val) {
    for (let j = 0; j < sliderStates.length; j++) {
        if (_.includes(sliderStates[j].range, parseInt(val))) {
            currentState = sliderStates[j];
            // updateSlider();
        }
    }
    // If the state is high, update the handle count to read 50+
    //if (currentState.name == "high") {
    //    updateHandle($handle[0], "50+");
    //}
    // Update handle color
    $handle
        .removeClass(function (index, css) {
            return (css.match(/(^|\s)js-\S+/g) || []).join(' ');
        })
        .addClass("js-" + currentState.name);

    $(".rangeslider__fill").removeClass("js-low");
    $(".rangeslider__fill").removeClass("js-med");
    $(".rangeslider__fill").removeClass("js-high");
    $(".rangeslider__fill").addClass("js-" + currentState.name);

    $(".rangeslider__handle").removeClass("js-low");
    $(".rangeslider__handle").removeClass("js-med");
    $(".rangeslider__handle").removeClass("js-high");
    $(".rangeslider__handle").addClass("js-" + currentState.name);
    // Update tooltip
    //$tooltip.html(currentState.tooltip);
}