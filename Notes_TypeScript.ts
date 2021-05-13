arr.toString(); // "a,b,c"
arr.forEach((val, idx, arr) => {console.log("${val}:${idx}")});
arr.map((val, idx, arr) => { x => x*x }); //new arr
arr.indexOf("foo");
arr.reduce((total, val, idx, arr) => {total - val});
arr.reduceRight(...);
arr.fill(0);
arr.filter(x => x>10);
arr.slice(3, 5); //new arr[2...4]
arr.join(","); //to string
arr.push("foo");
arr.pop();
arr.shift(); //remove arr[0]
arr.unshift(); //insert arr[0]
arr.reverse();
arr.sort( (a, b) => { //[0, 1, 2, 10, 20]
    if(a>b) return 1;
    if(a<b) return -1;
    return 0;
})

//////////////////////////////////////////
let {
        name: {
            firstName,
            lastName
        },
        age = '18'
    } = foo || {}; //destruct with default

