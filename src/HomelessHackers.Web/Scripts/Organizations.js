
        function OrganizationViewModel()
        {
            var self = this;
            self.Organizations = ko.observableArray([]);
            self.NewOrganization = ko.observable();
            self.GetOrganizations = function () {
                $.getJSON("/api/organizations/", null, function (data){
                    self.Organizations(data);
                });
            };
            self.SaveOrganization = function () {
                $.ajax({
                    type: "POST",
                    url: "/api/organizations/",
                    data: self.NewOrganization(),
                    dataType: "Organization",
                    success: function (msg) {
                        alert("I did it: " + msg);
                    }
                });
            };
        }
$(document).ready(function () {

    var viewmodel = new OrganizationViewModel();

    viewmodel.GetOrganizations();

    ko.applyBindings(viewmodel);
                
});

