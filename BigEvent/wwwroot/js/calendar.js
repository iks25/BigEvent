
    
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
            //todo add popup window with items on that day
            
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
let calWindow=document.getElementById("js-calWindow")

document.addEventListener("click",event => {
    const isClickInside = calWindow.contains(event.target);

    //hide PopWindow
    if (!isClickInside) {
        $(calWindow).fadeOut();
        bgDiv.fadeOut("slow")
    }
});


