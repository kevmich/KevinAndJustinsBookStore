import React from 'react';
import logo from './logo.svg';
import Navbar from './components/Navbar.js';
import './App.css';
import About from './components/About';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

function App() {
  return (
    <div className="App">
      <Navbar/>
      <Route exact path="/About" component={About} />
    </div>
  );
}

export default App;
