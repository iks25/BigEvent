
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

$(document).ready(() => {




});
