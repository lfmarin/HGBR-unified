import {React, useState} from 'react'
import NavBar from './Main/AppBar';
import { createTheme, ThemeProvider} from '@material-ui/core/styles';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import useStyles from './Styles/Styles';
import Drawer from './Main/Drawer';
import ListaPacientes from './Pacientes/listaPacientes'
import RegistroPaciente from './Pacientes/agregaPaciente'
import ListaDoctores from './Doctores/ListaDoctores'
import RegistroDoctor from './Doctores/agregaDoctor'
import ListaConsejeria from './Consejeria/ListaPersonal'
import RegistroPersonal from './Consejeria/agregaPersonal'
import DetallesPaciente from './Pacientes/detallesPaciente'
import MainHistoriaClinica from './Pacientes/HistoriaClinica/MainHistoria'
import Encuesta from './Pacientes/Encuesta/Encuesta'
import NotaMedica from './Pacientes/NotasMedicas/notaMedica'
import ListaNotas from './Pacientes/NotasMedicas/listaNotasMedicas'
import DetalleDoctor from './Doctores/DetalleDoctor'
import EliminarDoctor from './Doctores/EliminarDoctor'
import Logout from './Session/Logout'
import DetalleCuenta from './Session/DetalleCuenta'
import ListaUsuarios from './Session/ListaUsers'
import RegistroUsuario from './Session/RegistroUsuario'
import Home from './Main/Home';
import Login from './Session/Login';

const theme = createTheme({
  palette: {
    primary: {
      light: '#A3DDCB',
      main: '#0A043C',
      dark: '#03506F',
      contrastText: '#FFFFFF',
    },
  }
});

export default function App() {
  const [isOpen, setIsOpen] = useState(false);
  const classes = useStyles();

  const hasToken = () => localStorage.getItem("jwtToken")
  const changeToken = (value) => localStorage.setItem("jwtToken", value)
  function isTokenValid() {
    const tkn = hasToken()
    console.log(tkn)
    return tkn !== null && tkn.length !== 0
  }
  // const revokeToken = () => localStorage.removeItem("jwtToken");
  const curUserName = () => localStorage.getItem('Dusername');
  const changeUsername = (value) => localStorage.setItem('Dusername', value);

  function revokeToken()
  {
    localStorage.removeItem("jwtToken")
  }

  hasToken()

  const handleDrawer = () => {
    setIsOpen(!isOpen);
  }

  const RoutingPaths = () => {
    if( !isTokenValid() )
      return <Login token={hasToken()} changeToken={changeToken} changeUser = {changeUsername} />

    return (
      <Routes>
        <Route path="/pacientes/detalles/:noExpediente/historia-clinica" element={<MainHistoriaClinica token={hasToken()} changeToken={changeToken} />}/>
        <Route path="/pacientes/detalles/:noExpediente/encuesta" element={<Encuesta token={hasToken()} />}/>
        <Route path="/pacientes/detalles/:noExpediente/nota-medica" element={<NotaMedica token={hasToken()} />}/>
        <Route path="/pacientes/detalles/:noExpediente/nota-medica/lista" element={<ListaNotas token={hasToken()} />}/>
        <Route path="/pacientes/detalles/:noExpediente" element={<DetallesPaciente token={hasToken()} />}/>
        <Route path="/pacientes/registro" element={<RegistroPaciente token={hasToken()} />}/>
        <Route path="/pacientes" element={<ListaPacientes token={hasToken()} />}/>
        <Route path="/doctores/registro" element={<RegistroDoctor revokeToken={revokeToken} token={hasToken()} />}/>
        <Route path="/doctores/detalles/:noDoctor" element={<DetalleDoctor revokeToken={revokeToken} token={hasToken()} />}/>
        <Route path="/doctores/eliminar/:noDoctor" element={<EliminarDoctor revokeToken={revokeToken} token={hasToken()} />}/>
        <Route path="/doctores" element={<ListaDoctores token={hasToken()} changeToken={changeToken} />}/>
        <Route path="/consejeria/registro" element={<RegistroPersonal token={hasToken()} />}/>
        <Route path="/consejeria" element={<ListaConsejeria token={hasToken()} />}/>
        <Route path="/" element={<Home token={hasToken()} />}/>
        <Route path="/cuenta" element={<DetalleCuenta token={hasToken()} />}/>
        <Route path="/usuarios" element={<ListaUsuarios token={hasToken()} />}/>
        <Route path="/usuarios/registrarusuario" element={<RegistroUsuario token={hasToken()} />}/>
        <Route path="/login" element={<Login token={hasToken()} changeToken={changeToken} changeUser = {changeUsername}/>}/>
        <Route path="/logout" element={<Logout token={hasToken()} changeUser = {changeUsername}/>}/>
        <Route path="*" element={
          <div>
            <h1>La página que buscas no existe.</h1>
            <a href="/">Volver a inicio</a>
          </div>
          } 
        />
      </Routes>
    )
  }

  return (
    <BrowserRouter>
      <div className="App">
        <ThemeProvider theme = {theme}>
          <header>
            <NavBar userName = {curUserName} menuCallBack = {handleDrawer}/>
            <Drawer token={hasToken()} open={isOpen} menuCallBack = {handleDrawer}/>
          </header>
          <main className={classes.main}>
          { RoutingPaths() }
          </main>
        </ThemeProvider>
      </div>
    </BrowserRouter>
  );
}
