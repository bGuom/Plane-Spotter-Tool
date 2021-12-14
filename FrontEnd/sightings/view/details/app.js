//Sighting Model For View
function SightingData (data) {
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

//Spotter Model
function  Spotter(data) {
    this.UserId = data.userId;
    this.Name = data.name;
};


const SightingViewModel = {
    sightingId : ko.observable(),
    spotter : ko.observable(),
    registration : ko.observable(),
    make : ko.observable(),
    model : ko.observable(),
    location : ko.observable(),
    dateTime : ko.observable(),

    getCurrentRecord : function () {
        let page_url = window.location.href;
        let url = new URL(page_url);
        let id = url.searchParams.get("id");
        SightingViewModel.sightingId(id);
        console.log(id);
        if (id === undefined){
            window.location.href = '../view/index.html';
        }
        $.ajax({
            url:GET_AIRCRAFT_SIGHTINGS + "/" + id,
            type:"GET",
            success: function(data){
                let mappedRecord =  new SightingData(data);
                SightingViewModel.spotter(mappedRecord.Spotter.Name);
                SightingViewModel.registration(mappedRecord.Aircraft.RegistrationId);
                SightingViewModel.make(mappedRecord.Aircraft.AircraftType.Make);
                SightingViewModel.model(mappedRecord.Aircraft.AircraftType.Model);
                SightingViewModel.location(mappedRecord.Location);
                SightingViewModel.dateTime(mappedRecord.DateTime);
                console.log(mappedRecord);
            },
            fail: function(data){
                console.log(data);
            }
        })

    },
};
SightingViewModel.getCurrentRecord();
// Activates knockout.js
ko.applyBindings(SightingViewModel);

