//Aircraft Type Model
const AircraftType = function (make, model) {
    this.Make = make;
    this.Model = model;
};

const AircraftTypeViewModel = {
    make: ko.observable(),
    model: ko.observable(),
    makeError: ko.observable(),
    modelError: ko.observable(),
    createAircraftType : function() {
        //Remove validation messages
        this.makeError(undefined)
        this.modelError(undefined)
        //Validate inputs
        let valid = true;
        if (this.make() === undefined) {
            this.makeError("Required!")
            valid = false;
        }
        if (this.model() === undefined) {
            this.modelError("Required!")
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
            url:POST_AIRCRAFT_TYPE,
            type:"POST",
            data:JSON.stringify(new AircraftType(this.make(),this.model())),
            contentType:"application/json; charset=utf-8",
            dataType:"json",
            success: function(data){
                if(data.status === 201){
                    alert("Successfully Saved!")
                    window.location.href = '../index.html';
                }else {
                    alert("Failed to save! Try again!")
                }
            },
            fail: function(data){
            console.log(data);
            }
        })
    }
};

// Activates knockout.js
ko.applyBindings(AircraftTypeViewModel);

