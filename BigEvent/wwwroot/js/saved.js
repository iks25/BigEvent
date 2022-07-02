function deleteEventInSaved(eventId) {
    let eventDiv=$("#js-event-eiv-"+eventId);
    eventDiv.fadeOut();
    console.log(eventDiv)

    $.ajax({
        type: "DELETE",
        url: "../api/Calendar/DeleteEvent/" + eventId ,
        success: () => {
            console.log("Delete OK");
        },
        error: (result) => {
            console.log("error", result);
        }
    });
}