$(function () { $("#tabs").tabs(); });
$(function () { $("#search1").button().click(function (event) { event.preventDefault(); }); });
$(function () { $("#search2").button().click(function (event) { event.preventDefault(); }); });
$(function () { $("#reset1").button().click(function (event) { event.preventDefault(); }); });
$(function () { $("#reset2").button().click(function (event) { event.preventDefault(); }); });


$(function () { $("#accordion").accordion({
			active: false,
			collapsible: true
		});
});

$(function () {
    // run the currently selected effect    
    function runEffect() {
        // get effect type from      
        var selectedEffect = $("#effectTypes").val();
        // most effect types need no options passed by default      
        var options = {};
        // some effects have required parameters      
        if (selectedEffect === "scale") {
            options = { percent: 0 };
        }
        else if
(selectedEffect === "size") {
            options = { to: { width: 200, height: 60} };
        }
        // run the effect      
        $("#effect").toggle(selectedEffect, options, 500);
    };
    // set effect from select menu value    
    $("#button").click(function () {
        var element = $(this);
        
        runEffect();
        return false;
    });
});



$(document).ready(function () {
    $("#e1").select2(
        {
            placeholder: "Επιλέξτε σύλλογο",
            matcher: function (term, text) { return text.toUpperCase().indexOf(term.toUpperCase()) == 0; }
        });
});

$(document).ready(function () {
    $("#e2").select2({
        maximumSelectionSize: 5,
        placeholder: "Επιλέξτε τομέα",
        matcher: function (term, text) { return text.toUpperCase().indexOf(term.toUpperCase()) == 0; }
    });
});


$(document).ready(function () {
    $("#clearButton").click(function () {
        $("#e1").select2("val", "");
        $("#e2").select2("val", "");
    });
});
