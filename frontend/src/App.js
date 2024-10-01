import './App.css';
import React from "react";
import GridPrecos from './GridPrecos';
import GridEstacionamentos from './GridEstacionamentos';

export default function App() {
  return (
    <div style={{ height: 400, width: '80%', margin: 50 }}>
      <GridEstacionamentos />
      <GridPrecos />
    </div>);
}
