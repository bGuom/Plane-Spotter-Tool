//Sighting Model For View
function SightingData (data) {
    this.SightingId = data.sightingId;
    this.Aircraft = new Aircraft(data.aircraft);
    this.Spotter = new Spotter(data.spotter);
    this.DateTime = data.dateTime;
    this.Location = data.location;
    this.Image = data.image;
};

//Sighting Model for Save
function Sighting (id,spotter,aircraft, datetime,location,image) {
    this.SightingId = id;
    this.AircraftId = aircraft;
    this.SpotterId = spotter;
    this.DateTime = datetime;
    this.Location = location;
    this.Image = image;
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
    allSpotters: ko.observableArray([]),
    allAircraftList: ko.observableArray([]),
    selectedSpotter : ko.observable(),
    selectedAircraft : ko.observable(),
    location : ko.observable(),
    dateTime : ko.observable(),
    spotterError : ko.observable(),
    aircraftError : ko.observable(),
    locationError : ko.observable(),
    datetimeError : ko.observable(),
    newSpotterName : ko.observable(),
    newSpotterNameError : ko.observable(),
    photoUrl : ko.observable(),

    fileUpload : function(data, e)
    {
        var file    = e.target.files[0];
        //Upload Image
        if(file)
        {
            var formData = new FormData();
            // Attach file
            formData.append('File', file);
            $.ajax({
                url: POST_IMAGE,
                data: formData,
                type: 'POST',
                contentType: false,
                processData: false,
                success: function(data){
                    SightingViewModel.photoUrl(data);
                }
            });
        }
    },

    createNewSpotter : function() {
        if(this.newSpotterName() !== undefined){
            this.newSpotterNameError(undefined)
            $.ajax({
                url:POST_USER,
                type:"POST",
                data:JSON.stringify({name : this.newSpotterName()}),
                contentType:"application/json; charset=utf-8",
                dataType:"json",
                success: function(data){
                    if(data.status === 201){
                        alert("Successfully Saved!")
                        SightingViewModel.getAllSpotters()
                    }else {
                        alert("Failed to save! Try again!")
                    }
                },
                fail: function(data){
                    console.log(data);
                }
            })
        }else{
            this.newSpotterNameError("Required!")
        }
    },

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
		let spotter = SightingViewModel.allSpotters().find(x => x.UserId === mappedRecord.Spotter.UserId);
                SightingViewModel.selectedSpotter(spotter);
		let aircraft = SightingViewModel.allAircraftList().find(x => x.RegistrationId === mappedRecord.Aircraft.RegistrationId);
                SightingViewModel.selectedAircraft(aircraft);
                SightingViewModel.location(mappedRecord.Location);
                SightingViewModel.dateTime(mappedRecord.DateTime);
                SightingViewModel.photoUrl(mappedRecord.Image);
                console.log(mappedRecord);
            },
            fail: function(data){
                console.log(data);
            }
        })

    },

    getAllSpotters : function() {
        $.ajax({
            url:GET_USER,
            type:"GET",
            success: function(data){
                let mappedSpotters = $.map(data, function(item) { return new Spotter(item) });
                SightingViewModel.allSpotters(mappedSpotters);
                console.log(mappedSpotters);
            },
            fail: function(data){
                console.log(data);
            }
        })
    },
    getAllAircraft : function() {
        $.ajax({
            url:GET_AIRCRAFT_LIST,
            type:"GET",
            success: function(data){
                let mappedAircraftList = $.map(data, function(item) { return new Aircraft(item) });
                SightingViewModel.allAircraftList(mappedAircraftList);
                console.log(mappedAircraftList);
            },
            fail: function(data){
                console.log(data);
            }
        })
    },
    record : function() {
        //Remove validation messages
        this.spotterError(undefined)
        this.aircraftError(undefined)
        this.locationError(undefined)
        this.datetimeError(undefined)
        //Validate inputs
        let valid = true;
        if (this.selectedSpotter() === undefined) {
            this.spotterError("Required!")
            valid = false;
        }
        if (this.selectedAircraft() === undefined) {
            this.aircraftError("Required!")
            valid = false;
        }
        if (this.location() === undefined) {
            this.locationError("Required!")
            valid = false;
        }
        if (this.dateTime() === undefined) {
            this.datetimeError("Required!")
            valid = false;
        }
        var submittedDateTime = new Date(this.dateTime());
        var now = new Date();

        if(submittedDateTime > now) {
            this.datetimeError("Should be before curent date/time!")
            valid = false;
        }
        if (valid){
            console.log("create")
            //Send Ajax request to server
            this.save();
        }
    },
    save : function() {
        let page_url = window.location.href;
        let url = new URL(page_url);
        let id = url.searchParams.get("id");

        $.ajax({
            url:PUT_AIRCRAFT_SIGHTINGS,
            type:"PUT",
            data:JSON.stringify(new Sighting(id,this.selectedSpotter().UserId,this.selectedAircraft().RegistrationId,this.dateTime(),this.location(),this.photoUrl())),
            contentType:"application/json; charset=utf-8",
            dataType:"json",
            success: function(data){
                if(data.status === 200){
                    alert("Successfully Updated!")
                    window.location.href = '../view/index.html';
                }else {
                    alert("failed!")
                }
            },
            fail: function(data){
                console.log(data);
            }
        })
    },
};
SightingViewModel.getAllSpotters();
SightingViewModel.getAllAircraft();
SightingViewModel.getCurrentRecord();
// Activates knockout.js
ko.applyBindings(SightingViewModel);

