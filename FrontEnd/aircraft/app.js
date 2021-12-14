//Aircraft Model
function Aircraft (type, registration) {
    this.AircraftTypeId = type;
    this.RegistrationId = registration;
};

//Aircraft Type
function  AircraftType(data) {
    this.AircraftTypeId = data.aircraftTypeId;
    this.Make = data.make;
    this.Model = data.model;

    this.FormattedAircraftType = ko.computed(function() {
        return data.make + " " + data.model;
    });
};

const AircraftViewModel = {
    availableAircraftTypes: ko.observableArray([]),
    selectedType: ko.observable(),
    registration: ko.observable(),
    typeError: ko.observable(),
    registrationError: ko.observable(),

    createAircraft : function() {
        //Remove validation messages
        this.typeError(undefined)
        this.registrationError(undefined)
        //Validate inputs
        let valid = true;
        if (this.selectedType() === undefined) {
            this.typeError("Required!")
            valid = false;
        }
        if (this.registration() === undefined) {
            this.registrationError("Required!")
            valid = false;
        } else if (!(/^[A-Z]{1,2}[-][A-Z]{1,5}$/.test(this.registration()))) {
            this.registrationError("Invalid Format!")
            valid = false;
        }
        if (valid){
            console.log("create")
            //Send Ajax request to server
            this.save();
        }
    },
    save : function() {
        $.ajax({
            url:POST_AIRCRAFT,
            type:"POST",
            data:JSON.stringify(new Aircraft(this.selectedType().AircraftTypeId,this.registration())),
            contentType:"application/json; charset=utf-8",
            dataType:"json",
            success: function(data){
                if(data.status === 201){
                    alert("Successfully Saved!")
                    window.location.href = '../sightings/create/index.html';
                }else {
                    alert("Failed! Please check your inputs and retry")
                }
            },
            fail: function(data){
                console.log(data);
            }
        })
    },
    getTypes : function() {
        $.ajax({
            url:GET_AIRCRAFT_TYPES,
            type:"GET",
            success: function(data){
                let mappedAircraftTypes = $.map(data, function(item) { return new AircraftType(item) });
                AircraftViewModel.availableAircraftTypes(mappedAircraftTypes);
            },
            fail: function(data){
                console.log(data);
            }
        })
    }
};
AircraftViewModel.getTypes();
// Activates knockout.js
ko.applyBindings(AircraftViewModel);

