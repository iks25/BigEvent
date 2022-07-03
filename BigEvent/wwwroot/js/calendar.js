
    
let today=new Date();

var yearInCalendar=today.getFullYear();
var monthInCalendar=today.getMonth();
var events;

console.log("changes");
// setCalendar(today.getMonth())
//
// var eventsInCalendar=$.ajax({
//     method:"GET",
//     url:"~/../api/calendar/EventInCalendar",
//     success:(result)=>{
//         events=result;
//         console.log("ok----->",result);
//     },
//     error:(error)=>{
//         console.log("error----->",error);
//     }
// })

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

    console.log("events -> ",events)
    
    let monthStart=new Date(yearNr,monthNr,1);
     let monthName=monthStart.toLocaleString("en-US", { month: "long" });

    $("#monthName").html(monthName);
    $("#yearNr").html(yearNr)

    let currentDay=new Date(yearNr,monthNr,1);
    currentDay.setDate(currentDay.getDate()-currentDay.getDay());
    let staringDayNr= currentDay.getDay();
    for(let i=0; i<=42;i++){
        let firstDayBoxId="calRecord" + (staringDayNr+i);

        $("#"+firstDayBoxId).html(currentDay.getDate());

        let classInactive="inactive-calendar-box";
        $("#"+firstDayBoxId).removeClass(classInactive);
        if(currentDay.getMonth()!==monthStart.getMonth()){
            $("#"+firstDayBoxId).addClass(classInactive);
        }

        let currentDateCss="current-day";


        $("#"+firstDayBoxId).removeClass(currentDateCss);
        if(IsTheSameDate(currentDay,today)){
            $("#"+firstDayBoxId).addClass(currentDateCss);
            $("#"+firstDayBoxId).append(
                "<div class='text-center text-dark'>\n" +
                    "<i class=\"bi bi-star-fill\"></i>\n" +
                    "<i class=\"bi bi-star-fill\"></i>\n" +
                "</div>");
            
        }

        currentDay.setDate(currentDay.getDate()+1);

    }
}


function setCalendar(){
    
    let year=today.getFullYear();
    // let monthName=today.toLocaleString("en-US", { month: "long" });
    let monthName=today.toLocaleString("en-US", { month: "long" });
    
    $("#monthName").html(monthName);
    $("#yearNr").html(year)
    let monthStartText="01-"+monthName+"-"+year;
    let monthStart=new Date(monthStartText);

    let currentDay=new Date(monthStartText);
    currentDay.setDate(currentDay.getDate()-currentDay.getDay());
    let staringDayNr= currentDay.getDay();
    for(let i=0; i<=42;i++){
        let firstDayBoxId="calRecord" + (staringDayNr+i);

        $("#"+firstDayBoxId).html(currentDay.getDate());

        let classInactive="inactive-calendar-box";
        $("#"+firstDayBoxId).removeClass(classInactive);
        if(currentDay.getMonth()!==monthStart.getMonth()){
            $("#"+firstDayBoxId).addClass(classInactive);
        }

        let currentDateCss="current-day";
     

        $("#"+firstDayBoxId).removeClass(currentDateCss);
        if(IsTheSameDate(currentDay,today)){
            $("#"+firstDayBoxId).addClass(currentDateCss);
        }

        currentDay.setDate(currentDay.getDate()+1);

    }
}


function IsTheSameDate(date1,date2) {
    return date1.getDate() === date2.getDate()
        && date1.getMonth() === date2.getMonth()
        && date1.getFullYear() === date2.getFullYear();
    
}


