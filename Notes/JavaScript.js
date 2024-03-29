////////////////
// JAVASCRIPT //
////////////////
let arr,str,num,str2,start,end,i,o,obj,x,foo,bar;
///////////
// ARRAY
arr.toString(); // "a,b,c"
arr.map((val, idx, arr) => { x => x*x }); //new arr
arr.indexOf("foo");
arr.reduce((accumulator, val, idx, arr) => {accumulator + val});
arr.reduceRight(); // same as above
arr.fill(0);
arr.filter(x => x > 10);
arr.slice(3, 5); //new arr[2...4]
arr.join(","); //to string
arr.push("foo");
arr.pop();
arr.shift(); //remove arr[0]
arr.unshift(); //insert arr[0]
arr.reverse();
arr.sort( (a, b) => {
    if(a>b) return 1; if(a<b) return -1; return 0;
}) //[0, 1, 2, 10, 20]

///////////
// STRING
str.indexOf();
str.lastIndexOf();
str.slice(start, end); //negtive is from the end
str.substr(start, length); //negtive is from the end
str.toUpperCase();
str.toLowerCase();
str.concat(",", str2);
str.split("|");
str.trim();
str.charAt(i);
str.charCodeAt(i);

//////////
// NUMBER
num.toString();
parseInt(str);
parseFloat(str);
isNaN(o);

//////////
// LOOPS
for(x in obj){ obj[x] };
for(i of arr){ arr[i] };
arr.forEach((val, idx, arr) => {console.log("${val}:${idx}")})

///////////
// CLASS
class Bar{};
class Foo extends Bar {
    constructor(a, b) {super(); this.a=a; this.b=b; };
    method1() {/* */};
};
let f = new Foo(1, 2); Foo.method1();

///////////
// DESTRUCT
let {
        name: {
            firstName,
            lastName
        },
        age = '18'
    } = foo || {}; //destruct with default

/////////////
// TRY CATCH
try{}
catch(err){ err.message; throw new Error("..."); }

////////////
// PROMISE
let p = new Promise(function func(){ });
async function p1(){ }; //p1 is a Promise as well
p.then(
    function(value){ },
    function(error){ }
)

///////////
// THIS
/*
  Alone: global object.
  Method: the owner object.
  function: global object.
  Event: element that received the event.
*/
///////////
// DOM
let el = document.getElementById('')
el.style.color = 'red'
el.addEventListener("click", foo)
/* <button onclick="foo(this)" /> */
window.innerHeight
window.innerWidth
window.location.href
window.location.hostname
window.location.pathname
window.history
window.open()
close()
alert()
confirm()
setTimeout(foo, 3)
clearTimeout()
setInterval(foo, 5)
clearInterval()
document.cookie
navigator.geolocation.getCurrentPosition(pos => pos.coords.latitude)

///////////
// JQUERY
$("#id");
$("p");
$(".class");
el.text("..."); // [JS] .textContent="foo"
el = el.text();
el.html("<p>...</p>") // [JS] .innerHTML
foo = el.html
el.hide() // [JS] .style.display = 'none'
el.show() // [JS] .style.display = ''
el.css("font-size", "35px") // [JS] .style.fontsize = "35px"


//////////////
// HTTP
let req = new XMLHttpRequest();
req.open('GET', 'http://foo.com/', true);
req.onreadystatechange = function(){
    if (this.readyState == 4 && this.status == 200){/* */}
}
req.send();

////////////////
// Long Polling
async function subscribe() {
    let response = await fetch("/subscribe");
  
    if (response.status == 502) {
        // retry
    } else if (response.status != 200) {
      // reconnect in 1s
      await new Promise(resolve => setTimeout(resolve, 1000));
      await subscribe();
    } else {
      let message = await response.text();
      showMessage(message);
      // Call subscribe() again to get the next message
      await subscribe();
    }
};
  
subscribe();
//////////////////////
// JQUERY LONG POLLING
function showMessage(type, msg){
    $("#msg").append(
        "<div class='msg "+ type +"'>"+ msg +"</div>"
    );
};

function subscribe(){
    $.ajax({
        type: "GET",
        url: "/subscribe",
        async: true,
        cache: false,
        timeout:30000,

        success: function(data){
            addmsg("new", data);
            setTimeout(
                subscribe,
                1000
            );
        },
        error: function(XMLHttpRequest, textStatus, err){
            showMessage("error", textStatus + " (" + err + ")");
            setTimeout(
                subscribe,
                30000);
        }
    });
};

$(document).ready(function(){
    subscribe();
});
// SAME AS
$(document).ready(subscribe);
// OR - $(...) is $(document).ready(...)
$(function(){
    subscribe();
});

