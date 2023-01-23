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
import ProtectedRoute from './Session/ProtectedRoute';

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

  const hasToken = () => localStorage.getItem("jwtToken")
  const changeToken = (value) => localStorage.setItem("jwtToken", value)
  // const revokeToken = () => localStorage.removeItem("jwtToken");
  const curUserName = () => localStorage.getItem('Dusername');
  const changeUsername = (value) => localStorage.setItem('Dusername', value);

  function revokeToken()
  {
    localStorage.removeItem("jwtToken")
  }

  const handleDrawer = () => {
    setIsOpen(!isOpen);
  }

  hasToken()

  const RoutingPaths = () => {
    return (
      <Routes>
        <Route path="/pacientes/detalles/:noExpediente/historia-clinica" element={<ProtectedRoute/>}>
          <Route path="/pacientes/detalles/:noExpediente/historia-clinica" element={<MainHistoriaClinica token={hasToken} changeToken={changeToken} />}/>
        </Route>
        <Route path="/pacientes/detalles/:noExpediente/encuesta" element={<ProtectedRoute/>}>
          <Route path="/pacientes/detalles/:noExpediente/encuesta" element={<Encuesta token={hasToken} />}/>
        </Route>
        <Route path="/pacientes/detalles/:noExpediente/nota-medica" element={<ProtectedRoute/>}>
          <Route path="/pacientes/detalles/:noExpediente/nota-medica" element={<NotaMedica token={hasToken} />}/>
        </Route>
        <Route path="/pacientes/detalles/:noExpediente/nota-medica/lista" element={<ProtectedRoute/>}>
          <Route path="/pacientes/detalles/:noExpediente/nota-medica/lista" element={<ListaNotas token={hasToken} />}/>
        </Route>
        <Route path="/pacientes/detalles/:noExpediente" element={<ProtectedRoute/>}>
          <Route path="/pacientes/detalles/:noExpediente" element={<DetallesPaciente token={hasToken} />}/>
        </Route>
        <Route path="/pacientes/registro" element={<ProtectedRoute/>}>
          <Route path="/pacientes/registro" element={<RegistroPaciente token={hasToken} />}/>
        </Route>
        <Route path="/pacientes" element={<ProtectedRoute/>}>
          <Route path="/pacientes" element={<ListaPacientes token={hasToken} revokeToken={revokeToken} />}/>
        </Route>
        <Route path="/doctores/registro" element={<ProtectedRoute/>}>
          <Route path="/doctores/registro" element={<RegistroDoctor revokeToken={revokeToken} token={hasToken} />}/>
        </Route>
        <Route path="/doctores/detalles/:noDoctor" element={<ProtectedRoute/>}>
          <Route path="/doctores/detalles/:noDoctor" element={<DetalleDoctor revokeToken={revokeToken} token={hasToken} />}/>
        </Route>
        <Route path="/doctores/eliminar/:noDoctor" element={<ProtectedRoute/>}>
          <Route path="/doctores/eliminar/:noDoctor" element={<EliminarDoctor revokeToken={revokeToken} token={hasToken} />}/>
        </Route>
        <Route path="/doctores" element={<ProtectedRoute/>}>
          <Route path="/doctores" element={<ListaDoctores token={hasToken} changeToken={changeToken} />}/>
        </Route>
        <Route path="/consejeria/registro" element={<ProtectedRoute/>}>
          <Route path="/consejeria/registro" element={<RegistroPersonal token={hasToken} />}/>
        </Route>
        <Route path="/consejeria" element={<ProtectedRoute/>}>
          <Route path="/consejeria" element={<ListaConsejeria token={hasToken} />}/>
        </Route>
        <Route path="/" element={<ProtectedRoute/>}>
          <Route path="/" element={<Home token={hasToken} />}/>
        </Route>
        <Route path="/cuenta" element={<ProtectedRoute/>}>
          <Route path="/cuenta" element={<DetalleCuenta token={hasToken} />}/>
        </Route>
        <Route path="/usuarios" element={<ProtectedRoute/>}>
          <Route path="/usuarios" element={<ListaUsuarios token={hasToken} />}/>
        </Route>
        <Route path="/usuarios/registrarusuario" element={<ProtectedRoute/>}>
          <Route path="/usuarios/registrarusuario" element={<RegistroUsuario token={hasToken} />}/>
        </Route>
        <Route path="/login" element={<Login/>}/>
        <Route path="/logout" element={<ProtectedRoute/>}>
          <Route path="/logout" element={<Logout token={hasToken} changeUser = {changeUsername}/>}/>
        </Route>
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
            <Drawer token={hasToken} open={isOpen} menuCallBack = {handleDrawer}/>
          </header>
          <main className={classes.main}>
          { RoutingPaths() }
          </main>
          <footer>
            <div className='footerRight'>
              <p>Realizado en acuerdo por FIEE-UV</p>
              <img alt="Logotipo de FIEE" src="media/fiee.jpg"></img>
            </div>
          </footer>
        </ThemeProvider>
      </div>
    </BrowserRouter>
  );
}
