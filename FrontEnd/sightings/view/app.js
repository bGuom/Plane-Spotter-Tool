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

