import React from 'react';
import ReactDOM from 'reactdom';
import { render } from 'reactdom';
import App from './App';

//
// <div id="container"></div>
render(<App todo="" />, document.getElementById('container'));

/////////
// App.js
import React from "ract";

class App extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            foo: "...",
            bar: "..."
        }
    }

    updateState(e){
        this.setState({bar: e.target.value});
    }

    clearInput(){
        this.setState({bar:''});
        ReactDOM.findDOMNode(this.refs.myInput).focus();
    }

    render(){
        return(<>
            <Header />
            <div>{this.state.foo}</div>
            <div>{this.props.todo}</div>
            <input type = "text"
                value = {this.state.bar}
                onChange = {this.updateState}
                ref = "myInput" />
            <button onClick= {this.clearInput}>CLR</button>
        </>)
    };
}

class Header extends React.Component{
    render(){
        return(<>
            <h1>...</h1>
        </>)
    }
}

export default App;