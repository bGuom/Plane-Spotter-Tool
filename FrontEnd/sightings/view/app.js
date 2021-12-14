//Sighting Model
function Sighting (data) {
    this.SightingId = data.sightingId;
    this.Aircraft = new Aircraft(data.aircraft);
    this.Spotter = new Spotter(data.spotter);
    this.DateTime = data.dateTime;
    this.Location = data.location;
    this.Image = data.image;
};

//Aircraft Model
function  Aircraft(data) {
    this.RegistrationId = data.registrationId;
    this.AircraftType = new AircraftType(data.aircraftType);
};

//Aircraft Type Model
function  AircraftType(data) {
    this.AircraftTypeId = data.aircraftTypeId;
    this.Make = data.make;
    this.Model = data.model;

    this.FormattedAircraftType = ko.computed(function() {
        return data.make + " " + data.model;
    });
};

//Aircraft Model
function  Spotter(data) {
    this.UserId = data.userId;
    this.Name = data.name;
};


const SightingViewModel = {
    allSightings: ko.observableArray([]),
    makeFilter : ko.observable(),
    modelFilter : ko.observable(),
    registrationFilter : ko.observable(),
    pageFilter : ko.observable(),
    perPageFilter : ko.observable(),

    getFilteredRecords : function() {
		console.log(SightingViewModel.makeFilter());
		console.log(SightingViewModel.modelFilter());
		var URL_PATH = FILTER_AIRCRAFT_SIGHTINGS + "?";
		if(SightingViewModel.makeFilter() != undefined) {
			URL_PATH = URL_PATH + "make=" + SightingViewModel.makeFilter() + "&";
		}
		if(SightingViewModel.modelFilter() != undefined) {
			URL_PATH= URL_PATH + "model=" + SightingViewModel.modelFilter() + "&";
			console.log(URL_PATH);
		}
		if(SightingViewModel.registrationFilter() != undefined) {
			URL_PATH = URL_PATH + "registration=" + SightingViewModel.registrationFilter() + "&";
		}
		if(SightingViewModel.pageFilter() != undefined) {
			URL_PATH = URL_PATH + "page=" + SightingViewModel.pageFilter() + "&";
		}
		if(SightingViewModel.perPageFilter() != undefined) {
			URL_PATH = URL_PATH + "per_page=" + SightingViewModel.perPageFilter();
		}
        $.ajax({
            url:URL_PATH,
            type:"GET",
            success: function(data){
                let mappedRecords = $.map(data, function(item) { return new Sighting(item) });
                SightingViewModel.allSightings(mappedRecords);
                console.log(mappedRecords)
            },
            fail: function(data){
                console.log(data);
            }
        })
    },

    getAllRecords : function() {
        $.ajax({
            url:GET_AIRCRAFT_SIGHTINGS,
            type:"GET",
            success: function(data){
                let mappedRecords = $.map(data, function(item) { return new Sighting(item) });
                SightingViewModel.allSightings(mappedRecords);
                console.log(mappedRecords);
            },
            fail: function(data){
                console.log(data);
            }
        })
    },
    deleteRecord : function(sighting) {
        $.ajax({
            url:DELETE_AIRCRAFT_SIGHTINGS + "/" + sighting.SightingId,
            type:"DELETE",
            success: function(data){

            },
            fail: function(data){
                alert("Failed to delete! Try again")
                this.getAllRecords();
            }
        })
    },
    view : function(sighting) { window.location.href = 'details/index.html?id='+sighting.SightingId; },
    edit : function(sighting) { window.location.href = '../edit/index.html?id='+sighting.SightingId; },
    delete : function(sighting) {
        SightingViewModel.allSightings.remove(sighting);
        SightingViewModel.deleteRecord(sighting);
    }
};
SightingViewModel.getAllRecords();
// Activates knockout.js
ko.applyBindings(SightingViewModel);

