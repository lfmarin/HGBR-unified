// import logo from './logo.svg';
import './App.css';

import {React, useState} from 'react';
import NavBar from './Main/AppBar';
import { createTheme, ThemeProvider} from '@mui/material/styles';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import useStyles from './Styles/Styles';
import Drawer from './Main/Drawer';
import Home from './Main/Home';
import AllPacientes from './Pacientes/listadoPacientes';
import ArchivePaciente from './Pacientes/archivoPaciente';
import AddPaciente from './Pacientes/registrarPaciente';
import DetailsPaciente from './Pacientes/infoPaciente';
import AllAdmisiones from './Admisiones/listadoAdmisiones';
import ArchiveAdmision from './Admisiones/archivoAdmision';
import AddAdmision from './Admisiones/registrarAdmision';
import DetailsAdmision from './Admisiones/infoAdmision';

const theme = createTheme({
  palette: {
    primary: {
      light: '#A3DDCB',
      main: '#ffffff',
      dark: '#03506F',
      contrastText: '#FFFFFF',
    },
  }
});

// function BotonConImagen(props) {
//   return (
//     <button
//       style={{
//         backgroundImage: `url(${props.img_urgencias})`,
//         backgroundSize: 'cover',
//         width: '200px',
//         height: '200px',
//         border: 'none',
//         borderRadius: '50%',
//         cursor: 'pointer',
//       }}
//       onClick={props.onClick}
//     />
//   );
// }

// export default BotonConImagen;


export default function App() {

  const [isOpen, setIsOpen] = useState(false);
  const classes = useStyles();

  const handleDrawer = () => {
    setIsOpen(!isOpen);
  }

  const RoutingPaths = () => {
    return (
      <Routes>
        <Route path="/" element={<Home/>} />
        <Route path="/pacientes" element={<AllPacientes/>} />
        <Route path='/pacientes/add' element={<AddPaciente/>} />
        <Route path='/pacientes/archive/:folio' element={<ArchivePaciente/>}/>
        <Route path='/pacientes/details/:folio' element={<DetailsPaciente/>} />
        <Route path='/admisiones' element={<AllAdmisiones/>} />
        <Route path='/admisiones/add' element={<AddAdmision/>}/>
        <Route path='/admisiones/archive/:folio' element={<ArchiveAdmision/>} />
        <Route path='/admisiones/details/:folio' element={<DetailsAdmision/>} />
        <Route path="*" element={
          <div>
            <h1>Oh no!</h1>
            <h2>Se ha produciodo un error</h2>
            <a href="/">Home</a>
          </div>
          } 
        />
      </Routes>
    );
  }

  return (
    <BrowserRouter>
      <div className="App">
        <ThemeProvider theme = {theme}>
          <header>
            <NavBar menuCallBack = {handleDrawer}/>
            <Drawer open={isOpen} menuCallBack = {handleDrawer}/>
          </header>
          <main className={classes.main}>
          { RoutingPaths() }
          </main>
          <footer>
            <div className='footerRight'>
              <p>Powered by FIEE-UV</p>
              <img alt="Logotipo de FIEE" src="/media/fiee.jpg"></img>
            </div>
          </footer>
        </ThemeProvider>
      </div>
    </BrowserRouter>
  );

  // return (
  //   <div className="App">
  //     <center>
  //       <img width='200px' src='./media/pacientes.png' className="opt1" />
  //       <img width='200px' src="/media/urgencias.png" className="opt2" />
  //     </center>
  //     <footer>
  //       <div className='footer'>
  //         <p>Powered by FIEE-UV</p>
  //         <img alt="Logo FIEE" src="/media/fiee.jpg"></img>
  //       </div>
  //     </footer>
  //   </div>
  // );
}

