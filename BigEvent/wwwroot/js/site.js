

$("#gallery-bg").hide();
/**
 * 
 * @param {HTMLDivElement} item
 */
function chooseImage(item) {
    let divId = item.id;
    let pictureId = item.getAttribute("data-pictureId");

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
    console.log("close");
    $("#gallery-bg").hide();
}

function showGalleryPicker() {
    console.log("close");
    $("#gallery-bg").show();
}



$(document).ready(() => {




});
