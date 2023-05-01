// import logo from './logo.svg';
import './App.css';

//import {React, useState} from 'react';
// import NavBar from './Main/AppBar';
// import { createTheme, ThemeProvider} from '@material-ui/core/styles';
// import { BrowserRouter, Route, Routes } from 'react-router-dom';
// import useStyles from './Styles/Styles';
// import Drawer from './Main/Drawer';
// import Home from './Main/Home';
import img_urgencias from './media/urgencias.png';
import img_pacientes from "./media/pacientes.png";
// import add_paciente from './components/pacientes/agregar_paciente';

/* const theme = createTheme({
  palette: {
    primary: {
      light: '#A3DDCB',
      main: '#ffffff',
      dark: '#03506F',
      contrastText: '#FFFFFF',
    },
  }
}); */

function BotonConImagen(props) {
  return (
    <button
      style={{
        backgroundImage: `url(${props.img_urgencias})`,
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
  // return (
  //   <BrowserRouter>
  //     <div className="App">
  //       <ThemeProvider theme = {theme}>
  //         <header>
  //           <NavBar userName = {curUserName} menuCallBack = {handleDrawer}/>
  //           <Drawer token={hasToken} open={isOpen} menuCallBack = {handleDrawer}/>
  //         </header>
  //         <main className={classes.main}>
  //         { RoutingPaths() }
  //         </main>
  //         <footer>
  //           <div className='footerRight'>
  //             <p>Realizado en acuerdo por FIEE-UV</p>
  //             <img alt="Logotipo de FIEE" src="media/fiee.jpg"></img>
  //           </div>
  //         </footer>
  //       </ThemeProvider>
  //     </div>
  //   </BrowserRouter>
  // );
  return (
    <div className="App">
      <center>
        <img width='200px' src='./media/pacientes.png' className="opt1" />
        <img width='200px' src="/media/urgencias.png" className="opt2" />
      </center>
      <footer>
        <div className='footer'>
          <p>Powered by FIEE-UV</p>
          <img alt="Logo FIEE" src="/media/fiee.jpg"></img>
        </div>
      </footer>
    </div>
  );
}

export default App;
