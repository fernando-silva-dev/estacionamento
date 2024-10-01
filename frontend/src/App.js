import './App.css';
import React from "react";
import GridPrecos from './GridPrecos';
import GridEstacionamentos from './GridEstacionamentos';

export default function App() {
  return (
    <div style={{ width: '80%', margin: 50 }}>
      <div style={{ margin: 50, }}>
        <GridEstacionamentos />
      </div>
      <div style={{ margin: 50, }}>
        <GridPrecos />
      </div>
    </div>);
}
