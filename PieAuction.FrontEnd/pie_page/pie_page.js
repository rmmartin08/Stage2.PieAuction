let apiHostBase = `http://localhost:15665/api`;
let pieId

$(function () {
    var urlParams = new URLSearchParams(window.location.search);
    pieId = urlParams.get("pieId");
    $.ajax(`${apiHostBase}/pies/${pieId}`)
        .done(renderPiePage);
});

/**
 * @param {Pie} pie
 */
function renderPiePage(pie) {

    // Render the name of the Pie
    $("#pie-name-header").text(pie.Name);

    // Render the Made By header
    let makerString = "Made by";
    for (let userId of pie.MadeByUserIds) {
        $.ajax(`${apiHostBase}/auctionUsers/${userId}`)
            .done(function (user) {
                if (makerString !== "Made by") {
                    makerString += " and";
                }
                makerString += " " + user.FirstName + " " + user.LastName;
                $("#pie-maker-header").text(makerString);
            });
    }

    // Render the properties    
    $("#pie-prop-div").append($(`<p>${pie.Flavor}</p>`))

    if (pie.IsGlutenFree) {
        $("#pie-prop-div").append($(`<p>Gluten Free</p>`))
    }
    if (pie.IsVegan) {
        $("#pie-prop-div").append($(`<p>Vegan</p>`))
    }

    $("#pie-prop-div").find("p").addClass("border border-black p-2")

    // Render the image
    $("#pie-image").prop("src", pie.ImageAddress);

    // Render the user list
    $.ajax(`${apiHostBase}/auctionUsers`)
        .done(function(users) {
            $("#user-select").children().remove();
            for(let user of users){
                $("#user-select").append(`<option value=${user.Id}>${user.FirstName} ${user.LastName}</option>`);
            }
        })

    // Render the Time Left and Start Time
    let timeEndMoment = moment.duration(moment(pie.EndDateTime).diff(moment()))
    $("#time-left").text(timeEndMoment.hours() + " hours, " + timeEndMoment.minutes() + " minutes, and " + timeEndMoment.seconds() + " seconds");
    $("#start-time").text(moment(pie.StartDateTime).format("MMMM Do, YYYY h:mm A"));

    // Render Recommended Pies
    let searchParams = {};
    searchParams.isGlutenFree = pie.IsGlutenFree;
    searchParams.isVegan = pie.IsVegan;
    searchParams.flavor = pie.Flavor;
    searchParams.limit = 3;
    searchParams.randomOrder = true;

    let searchParamsString = "";
    for (let searchParam in searchParams) {
        if (searchParamsString !== "") {
            searchParamsString += "&";
        }
        searchParamsString += searchParam + "=" + searchParams[searchParam];
    }
    $.ajax(`${apiHostBase}/pies?${searchParamsString}`)
        .done(function (pies) {
            for (let newPie of pies) {
                $("#recommended-pie-div").append($(`<a href="pie_page.html?pieId=${newPie.Id}" class="ml-1 mr-1">${newPie.Name}</a>`))
            }
        })
}