console.log("kurwa co jest")
let today=new Date();

var yearInCalendar=today.getFullYear();
var monthInCalendar=today.getMonth();
var events;


setCalendarByMonth(monthInCalendar,yearInCalendar);

$("#previousMonthButton").click(()=>{
    
    monthInCalendar --;
    if (monthInCalendar<0){
        monthInCalendar=11;
        yearInCalendar--;
    }
    
    setCalendarByMonth(monthInCalendar,yearInCalendar);
});

$("#nextMonthButton").click(()=>{
    monthInCalendar++;
    if (monthInCalendar>11) {
        monthInCalendar = 1;
        yearInCalendar++;
    }
    setCalendarByMonth(monthInCalendar,yearInCalendar);
})

function setCalendarByMonth(monthNr,yearNr){
    
    let monthStart=new Date(yearNr,monthNr,1);
     let monthName=monthStart.toLocaleString("en-US", { month: "long" });

    $("#monthName").html(monthName);
    $("#yearNr").html(yearNr)

    let currentDay=new Date(yearNr,monthNr,1);
    currentDay.setDate(currentDay.getDate()-currentDay.getDay());
    let staringDayNr= currentDay.getDay();
    for(let i=0; i<=42;i++){
        let firstDayBoxId="calRecord" + (staringDayNr+i);
        
        let currentDayDiv=$(`#${firstDayBoxId}`);

        currentDayDiv.html(currentDay.getDate());

        let classInactive="inactive-calendar-box";
        currentDayDiv.removeClass(classInactive);
        if(currentDay.getMonth()!==monthStart.getMonth()){
            currentDayDiv.addClass(classInactive);
        }

        let currentDateCss="current-day";


        currentDayDiv.removeClass(currentDateCss);
        currentDayDiv.removeClass("pointer")
        if(IsTheSameDate(currentDay,today)){
            currentDayDiv.addClass(currentDateCss);
            
            
        }
        ////////////////////////handle adding stars
        let nrEventInThisDay=0;
        for (let item  of events) {
            
            if(currentDay.getDate()==item.day
                &&currentDay.getMonth()==item.month
                &&currentDay.getFullYear()==item.year
            ){
                nrEventInThisDay++;
            }
        }
        if(nrEventInThisDay>0){
            let stars="<i class=\"bi bi-star-fill\"></i>\n" 
            if(nrEventInThisDay==2)
                stars=stars+stars;
            if(nrEventInThisDay>=3)
                stars=stars+stars+stars;
            
            currentDayDiv.append(
                "<div class='text-center text-dark'>\n" +
                stars +
                "</div>");
            currentDayDiv.addClass("pointer");
            console.log("====>",currentDay.getDate());
            let dayWithEvents={
                day:currentDay.getDate(),
                month: currentDay.getMonth(),
                year:currentDay.getFullYear(),
            }
            //todo add popup window with items on that day
            currentDayDiv.on("click",event => {
                
                
                showPopWindow();
                changeDateInPopupWindow(dayWithEvents);
            })
            
            // showPopWindow();
            
        }

        ////////////////////////handle adding stars

        currentDay.setDate(currentDay.getDate()+1);

    }
}





function IsTheSameDate(date1,date2) {
    return date1.getDate() === date2.getDate()
        && date1.getMonth() === date2.getMonth()
        && date1.getFullYear() === date2.getFullYear();
    
}
//////////////////////////handle popup window disappear

let bgDiv=$(".cal-popup-background");
let calWindow=document.getElementById("js-calWindow");
let isPopUpVisible=false;
if(!isPopUpVisible){
    bgDiv.hide();
    $(calWindow).hide();
}

document.addEventListener("click",event => {
    if(!isPopUpVisible)
       return;
    
    const isClickInside = calWindow.contains(event.target);
    //hide PopWindow
    if (!isClickInside) {
        
        $(calWindow).fadeOut();
        bgDiv.fadeOut("slow");
        isPopUpVisible=false;
    }
    
});
/////////////////////////////////////

function showPopWindow() {
        
    bgDiv.css("visibility","visible");
    $(calWindow).fadeIn("slow",()=>{
         isPopUpVisible=true;
    });
    bgDiv.fadeIn("fast");
}

function changeDateInPopupWindow(date) {
    let month=date.month+1;
    $("#js-head-popup").html(date.day+"-"+month+"-"+date.year+"zzz");

    let eventsInThatDay=events.filter(e=>
        e.day==date.day
        && e.month==date.month
        && e.year==date.year
    )

    console.log("ooooooooooo")
    console.log(eventsInThatDay)
    let eventItem=createEventItem(eventsInThatDay[0]);
    console.log(eventItem)
    $("#js-popup-content").html($("#js-popup-content").html()+eventItem);
}

function createEventItem(eventData) {
    console.log(typeof eventData.time)
    return `
    <div class="event-item">
            <img src="${eventData.img}"/>
      
        <div class="popup-name-time">
            <div class="popup-name">
                ${eventData.name}
            </div>
            <div class="popup-time">
                ${eventData.time}
            </div>      
        </div>
            <i style="color: black" class="bi bi-trash3 me-2 p-3 "></i>
    </div>
    
    `
}