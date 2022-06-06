﻿
///////////////////////////////////////////////// Gallery
$("#gallery-bg").hide();
/**
 * 
 * @param {HTMLDivElement} item
 */
function chooseImage(item) {
    let divId = item.id;
    let pictureId = item.getAttribute("data-pictureId");
    let pictureSrc = item.getAttribute("data-pictureSrc");
    let pictureName = item.getAttribute("data-pictureName");

    $('#chosenImageInput')[0].setAttribute("value", pictureId);
    $("#chosenImageIMG")[0].setAttribute("src", pictureSrc)
    $('#chosenImage')[0].innerHTML = pictureName;


    changeSelectedImageDiv(item)
    //TODO Change custom Input for pick item
}
/**
 *
 * @param {HTMLDivElement} selectedDiv
 */
function changeSelectedImageDiv(selectedDiv) {
    let pictures = $(".gallery-picture-container");
    pictures.removeClass("chosen-img");

    selectedDiv.classList.add("chosen-img");
}


function closeGalleryPicker() {
    $("#gallery-bg").hide();
}

function showGalleryPicker() {
    $("#gallery-bg").show();
}

///////////////////////////////////////////////// Gallery


///////////////////notify

function addEventToCalendar(iconSpan) {
    let isInCallendar = iconSpan.getAttribute("data-isInCallendar");


    if (isInCallendar == "yes") {

        iconSpan.classList.remove("bi-bell");
        iconSpan.classList.add("bi-bell-fill");
    } else {
        iconSpan.classList.remove("bi-bell-fill");
        iconSpan.classList.add("bi-bell");
    }
    isInCallendar = (isInCallendar == "yes") ? "no" : "yes";


    iconSpan.setAttribute("data-isInCallendar", isInCallendar);

}
///////////////////notify

$(document).ready(() => {




});
