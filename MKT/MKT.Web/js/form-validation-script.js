var Script = function () {

    //Comentamos este c�digo para poder hacer submit y llevarlo al controller, de lo contrario si se deshabilita el c�digo en lugar de ir a controller llega a esta parte del codigo.
    //$.validator.setDefaults({
    //    submitHandler: function ()
    //    {
    //        alert("submitted!");
    //    }
    //});

    $().ready(function() {
        // validate the comment form when it is submitted
        $("#feedback_form").validate();

        // validate signup form on keyup and submit
        $("#register_form").validate({
            rules: {
                CodigoNomina: {
                    required: true,
                    minlength: 5
                },
                Nombre: {
                    required: true,
                    minlength: 5
                },
                Entidad: {
                    required: true
                },
                FechaInicio: {
                    required: true
                },
                Cargo: {
                    required: true
                }
            },
            messages: { 
                CodigoNomina: {
                    required: "Por favor ingresa el c\u00F3digo de nomina.",
                    minlength: "El c\u00F3digo de nomina debe ser igual a 5 d\u00EDgitos."
                },
                Nombre: {
                    required: "Por favor ingresa el nombre completo",
                    minlength: "El nombre completo no debe ser menor a 5 d\u00EDgitos."
                },
                Entidad: {
                    required: "Por favor ingrese la entidad."
                },

                FechaInicio: {
                    required: "Por favor ingresa la fecha de inicio."
                },
                Cargo: {
                    required: "Por favor ingrese el cargo de la persona."
                }
            }
        });

        // propose username by combining first- and lastname
        $("#username").focus(function() {
            var firstname = $("#firstname").val();
            var lastname = $("#lastname").val();
            if(firstname && lastname && !this.value) {
                this.value = firstname + "." + lastname;
            }
        });

        //code to hide topic selection, disable for demo
        var newsletter = $("#newsletter");
        // newsletter topics are optional, hide at first
        var inital = newsletter.is(":checked");
        var topics = $("#newsletter_topics")[inital ? "removeClass" : "addClass"]("gray");
        var topicInputs = topics.find("input").attr("disabled", !inital);
        // show when newsletter is checked
        newsletter.click(function() {
            topics[this.checked ? "removeClass" : "addClass"]("gray");
            topicInputs.attr("disabled", !this.checked);
        });
    });


}();