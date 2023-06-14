// import logo from './logo.svg';
import './App.css';

import {React, useState} from 'react';
import Bar from './Main/Bar';
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

export default function App() {

  const [isOpen, setIsOpen] = useState(false);
  const classes = useStyles();

  //AÑO ACTUAL

  var fecha = new Date(Date.now());
  var year = fecha.getFullYear();

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
            <h2>Se ha producido un error</h2>
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
            <Bar menuCallBack = {handleDrawer}/>
            <Drawer open={isOpen} menuCallBack = {handleDrawer}/>
          </header>
          <main className={classes.main}>
          { RoutingPaths() }
          </main>
          <footer>
            <div>
              <p>&copy; {year} - Powered by FIEE-UV</p>
              <img alt="Logo_FIEE" src="/media/fiee.jpg" className={classes.imgFooter}></img>
            </div>
          </footer>
        </ThemeProvider>
      </div>
    </BrowserRouter>
  );

}

