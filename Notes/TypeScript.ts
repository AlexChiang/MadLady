const my: number = 10;
let b: boolean = true;
let c: string | undefined = undefined;

let a1: number[];
let a2 = [1, 2, 3];
let a3: Array<number> = [1, 2, 3];

/////////////
// ENUM
enum Sex {
    Male = "M",
    Female = "F"
}
enum Dollar {
    Zero,
    One,
    Two
}
console.log(Sex.Male + Dollar.One); // M1

/////////////
// TYPE
type Direction = "N" |"S" | "W" | "E";
let dir:Direction = "N";


/////////////
// INTERFACE
// - interface has auto merging (type: use '&')
// - interface is extensible (type: no)

interface Server{
    ipv4: string;
    port: number;
    https: boolean;
}

interface Options{
    maxUser: number;
}

let var1: Server = {ipv4:"...", port: 80, https: true};

function config(obj: Server, opt: Options): Server{
    /* ... */
    return obj;
}

///////////
// CLASS

class Car{
    printCar = () =>{/* */}
}

interface NewCar extends Car{
    name: string;
}

class NewestCar implements NewCar{
    name: string;
    constructor(name: string){this.name = name};
    printCar = () => {console.log("{name}")};
}

//////////
// NEVER
function doNothing(x: never): never{
    throw new Error("foo");
}

/////////
// Props

// render(<Hello who="bob" />, el)
type Props = {who: string};
const Hello = ({who}: Props) => (
    <p>Hello {who}</p>
)
//OR
function HelloFunc({who}: Props){
    return <p>Hello, {who}<p>);
}
