// @ts-check

/**
 * @typedef User
 * @property {String=} Id
 * @property {String} FirstName
 * @property {String} LastName
 * @property {Boolean} IsStudent
 * 
 * @typedef Pie
 * @property {String} Id
 * @property {String} Name
 * @property {String} Flavor
 * @property {Boolean} IsGlutenFree
 * @property {Boolean} IsVegan
 * @property {String[]} MadeByUserIds
 * @property {String=} SoldToUserId
 * @property {String} ImageAddress
 * @property {String} StartDateTime
 * @property {String} EndDateTime
 */
// @ts-ignore
let apiHostBase = `http://localhost:15665/api`;

$(function () {
    // Add click event to "Add New Student"
    $("#new-user-btn").click(function () {
        /**@type {User} user */
        let user = {
            FirstName: $("#new-user-first-name").val().toString(),
            LastName: $("#new-user-last-name").val().toString(),
            IsStudent: $("#new-user-is-student").is(":checked")
        }

        $.ajax({
            url: `${apiHostBase}/auctionUsers`,
            method: "POST",
            data: user
        }).done(refresh);
    });

    // Add click event to "Search" button
    $("#search-btn").click(runPieSearch);


    // Refresh the UI (for the first time)
    refresh();
});

function refresh() {
    // Get users for the Made By filter
    $.ajax(`${apiHostBase}/auctionUsers?isStudent=true`)
        .done(populateMadeByUi)

    runPieSearch();
}

// Get the search filters from the page and call api with the search
function runPieSearch() {
    let searchParams = {};
    if ($("#is-vegan-select :selected").val() !== "null") {
        searchParams.isVegan = $("#is-vegan-select :selected").val();
    }
    if ($("#is-gluten-free-select :selected").val() !== "null") {
        searchParams.isGlutenFree = $("#is-gluten-free-select :selected").val();
    }
    if ($("#made-by-select :selected").val() !== "null") {
        searchParams.madeByUserId = $("#made-by-select :selected").val();
    }

    if($("#search-input").val() !== ""){
        searchParams.flavor = $("#search-input").val();
    }

    let searchParamsString = "";
    for (let searchParam in searchParams) {
        if(searchParamsString !== ""){
            searchParamsString += "&";
        }
        searchParamsString += searchParam + "=" + searchParams[searchParam];
    }

    clearSearchResultsAndSayLoading();
    $.ajax({
        url: `${apiHostBase}/pies?${searchParamsString}`,
        method: "GET"
    }).done(populateSearchResults)
}

/**
 * @param {Pie} pie
 * @description Adds a single Pie object to the search results table
 */
function addPieToSearchResults(pie) {
    let pieTableBody = $("#pie-list-table tbody");
    let pieRow = $("<tr>");
    pieRow.click(function() {
        window.location.href = "./pie_page/pie_page.html?pieId=" + pie.Id;
    })
    pieRow.append($(`<td>${pie.Name}</td>
        <td>${pie.Flavor}</td>
        <td class="text-center">${pie.IsVegan ? "Yes" : "No"}</td>
        <td class="text-center">${pie.IsGlutenFree ? "Yes" : "No"}</td>
        <td class="userIds"></td>`));
    // For every user, get that user from that API because we need their name
    for (let userId of pie.MadeByUserIds) {
        $.ajax(`${apiHostBase}/auctionUsers/${userId}`)
            .done(function (user) {
                if (pieRow.find(".userIds").text() !== "") {
                    pieRow.find(".userIds").append("<br>");
                }
                pieRow.find(".userIds").append(user.FirstName + " " + user.LastName);
            })
    }
    pieRow.addClass("mt-1");

    pieTableBody.append(pieRow);
}

// Clears the search results and says loading. Should be used right before the
// ajax request to populate with a search
function clearSearchResultsAndSayLoading(){
    let pieTable = $("#pie-list-table");
    pieTable.find("tbody").children().remove();
    $("#pie-list-div").append($(`<div id="loadingDiv">Loading....</div>`));
}

/**
 * @param {Pie[]} pies
 * @description Removes the loading bar, and loads in all of the pies
 */
function populateSearchResults(pies) {
    $("#loadingDiv").remove();
    for (let pie of pies) {
        addPieToSearchResults(pie);
    }
}

/**
 * @param {User[]} users
 * @description Loads the "Made By" select in the search filter list. 
 */
function populateMadeByUi(users) {
    let madeBySelect = $("#made-by-select");
    madeBySelect.children(`:not([value="null"])`).remove();

    for (let user of users) {
        let newUserOption = $(`<option>`);
        newUserOption.val(user.Id);
        newUserOption.text(`${user.FirstName} ${user.LastName}`);
        madeBySelect.append(newUserOption);
    }
}

