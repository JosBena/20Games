import React from 'react';
// Remember react icons 
import {Tabs} from "./sections/tabSection"
import Game from "./sections/game"

function App() {
  let here = "20Games/Builds/Games/Build/";
  let remote = "Builds/Games/Build/"
  return (
    <div className="App">
      
      <Tabs />
      <Game path={here} />
      
    </div>
  );
}

export default App;
