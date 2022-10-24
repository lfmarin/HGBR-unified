import React, { useState } from 'react'
import { Route, Switch } from 'react-router-dom'
import Home from './Home'
import { SetStateAction } from 'react'
import ListaPacientes from '../Pacientes/listaPacientes'
import RegistroPaciente from '../Pacientes/agregaPaciente'
import ListaDoctores from '../Doctores/ListaDoctores'
import RegistroDoctor from '../Doctores/agregaDoctor'
import ListaConsejeria from '../Consejeria/ListaPersonal'
import RegistroPersonal from '../Consejeria/agregaPersonal'
import DetallesPaciente from '../Pacientes/detallesPaciente'
import MainHistoriaClinica from '../Pacientes/HistoriaClinica/MainHistoria'
import Encuesta from '../Pacientes/Encuesta/Encuesta'
import NotaMedica from '../Pacientes/NotasMedicas/notaMedica'
import ListaNotas from '../Pacientes/NotasMedicas/listaNotasMedicas'
import Login from '../Session/Login'
import Logout from '../Session/Logout'
import { Redirect } from 'react-router-dom'

export default function MainRoutes() {
  const [isSubmitted, setIsSubmitted] = useState(() => sessionStorage.getItem('jwtToken') !== "");
  
  return (
    <Switch>
      <Route exact path="/pacientes/detalles/:noExpediente/historia-clinica">
        <MainHistoriaClinica />
      </Route>
      <Route exact path="/pacientes/detalles/:noExpediente/encuesta">
        <Encuesta />
      </Route>
      <Route exact path="/pacientes/detalles/:noExpediente/nota-medica">
        <NotaMedica />
      </Route>
      <Route exact path="/pacientes/detalles/:noExpediente/nota-medica/lista">
        <ListaNotas />
      </Route>
      <Route exact path="/pacientes/detalles/:noExpediente">
        <DetallesPaciente />
      </Route>
      <Route exact path="/pacientes/registro">
        <RegistroPaciente />
      </Route>
      <Route exact path="/pacientes">
        <ListaPacientes />
      </Route>
      <Route exact path="/doctores/registro">
        <RegistroDoctor />
      </Route>
      <Route exact path="/doctores">
        <ListaDoctores />
      </Route>
      <Route exact path="/consejeria/registro">
        <RegistroPersonal />
      </Route>
      <Route exact path="/consejeria">
        <ListaConsejeria />
      </Route>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/login">
        <Login />
      </Route>
      <Route exact path="/logout">
        <Logout />
      </Route>
      <Route path="*">
        <div>
          <h1>La página que buscas no existe.</h1>
          <a href="/">Volver a inicio</a>
        </div>
      </Route>
    </Switch>
  )
}
