
    
let today=new Date();

let year=today.getFullYear();
let month=today.toLocaleString("en-US", { month: "long" });

$("#monthName").append(month);
$("#yearNr").append(year)
let monthStartText="01-"+month+"-"+year;
let monthStart=new Date(monthStartText);

let currentDay=new Date(monthStartText);
currentDay.setDate(currentDay.getDate()-currentDay.getDay());
let staringDayNr= currentDay.getDay();
for(let i=0; i<=42;i++){
let firstDayBoxId="calRecord" + (staringDayNr+i);

$("#"+firstDayBoxId).append(currentDay.getDate());

let classInactive="inactive-calendar-box";
$("#"+firstDayBoxId).removeClass(classInactive);
if(currentDay.getMonth()!==monthStart.getMonth()){
    $("#"+firstDayBoxId).addClass(classInactive);
}
   
let currentDateCss="current-day";
    console.log(today);
    
    $("#"+firstDayBoxId).removeClass(currentDateCss);
if(IsTheSameDate(currentDay,today)){
    $("#"+firstDayBoxId).addClass(currentDateCss);
}

currentDay.setDate(currentDay.getDate()+1);
   
}

function IsTheSameDate(date1,date2) {
    return date1.getDate() === date2.getDate()
        && date1.getMonth() === date2.getMonth()
        && date1.getFullYear() === date2.getFullYear();
    
}