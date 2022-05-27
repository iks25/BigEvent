// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/**
 * 
 * @param {HTMLDivElement} item
 */
function chooseImage(item) {
    let divId = item.id;
    let pictureId = item.getAttribute("data-pictureId");

    changeSelectedImageDiv(item)
    //TODO Change custom Input
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

$(document).ready(() => {




});
