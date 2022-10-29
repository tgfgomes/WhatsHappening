
if (window.jQuery) {

    $('.input-group input#EventDate').datepicker({
        format: "dd/MM/yyyy",
        //startDate: new Date().getDate().toString(),
        autoclose: true,
        todayHighlight: true
    });

    $('#SelectedCategoryId').select2({ allowClear: true, width: 'resolve', theme: "bootstrap" });

    if ($('#EventLocation').length) {
        google.maps.event.addDomListener(window, 'load', initializeGoogleMapsSearch);
    }
}


function initializeGoogleMapsSearch() {
    var options = {
        types: ['(regions)']
    };
    var input = document.getElementById('EventLocation');
    var autocomplete = new google.maps.places.Autocomplete(input, options);
}


//if (window.jQuery) {

//    $('.input-group input#EventSearchModel_EventDate').datepicker({
//		format: "dd/MM/yyyy",
//		//startDate: new Date().getDate().toString(),
//		autoclose: true,
//		todayHighlight: true
//	});

//    $('#EventSearchModel_SelectedCategoryId').select2({ allowClear: true, width: 'resolve' });

//    if ($('#EventSearchModel_EventLocation')) {
//		google.maps.event.addDomListener(window, 'load', initializeGoogleMapsSearch);
//	}
//}


//function initializeGoogleMapsSearch() {
//	var options = {
//		types: ['(regions)']
//	};
//	var input = document.getElementById('EventSearchModel_EventLocation');
//	var autocomplete = new google.maps.places.Autocomplete(input, options);
//}
