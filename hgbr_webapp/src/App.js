// import logo from './logo.svg';
import './App.css';

import React from 'react';
import btn_urgencia from './media/urgencias.png';
// import add_paciente from './components/pacientes/agregar_paciente';

function BotonConImagen(props) {
  return (
    <button
      style={{
        backgroundImage: `url(${props.btn_urgencia})`,
        backgroundSize: 'cover',
        width: '200px',
        height: '200px',
        border: 'none',
        borderRadius: '50%',
        cursor: 'pointer',
      }}
      onClick={props.onClick}
    />
  );
}

// export default BotonConImagen;


function App() {
  return (
    <div className="App">
      <center>
        <img width='200px' src="./media/urgencias.png" className="opt1" />
        <img width='200px' src="./media/hospitalarios.png" className="opt2" />
      </center>
    </div>
  );
}

export default App;
