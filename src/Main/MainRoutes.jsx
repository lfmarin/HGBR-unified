import React, { useState } from 'react'
import { Route, Switch } from 'react-router-dom'
import Home from './Home'
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
import DetalleDoctor from '../Doctores/DetalleDoctor'
import Login from '../Session/Login'
import Logout from '../Session/Logout'

export default function MainRoutes(props) {
  const [isSubmitted] = useState(sessionStorage.getItem('jwtToken'));

  if( !isSubmitted )
    return <Login changeUser = {props.changeUsr} />
  
  return (
    <Switch>
      <Route exact path="/pacientes/detalles/:noExpediente/historia-clinica"><MainHistoriaClinica /> </Route>
      <Route exact path="/pacientes/detalles/:noExpediente/encuesta"><Encuesta /> </Route>
      <Route exact path="/pacientes/detalles/:noExpediente/nota-medica"><NotaMedica /> </Route>
      <Route exact path="/pacientes/detalles/:noExpediente/nota-medica/lista"><ListaNotas /> </Route>
      <Route exact path="/pacientes/detalles/:noExpediente"> <DetallesPaciente /> </Route>
      <Route exact path="/pacientes/registro"> <RegistroPaciente /> </Route>
      <Route exact path="/pacientes"> <ListaPacientes /> </Route>
      <Route exact path="/doctores/registro"> <RegistroDoctor /> </Route>
      <Route exact path="/doctores/detalles/:noDoctor"> <DetalleDoctor /> </Route>
      <Route exact path="/doctores"> <ListaDoctores /> </Route>
      <Route exact path="/consejeria/registro"> <RegistroPersonal /> </Route>
      <Route exact path="/consejeria"> <ListaConsejeria /> </Route>
      <Route exact path="/"> <Home /> </Route>
      <Route exact path="/login"> <Login changeUser = {props.changeUsr} /> </Route>
      <Route exact path="/logout"> <Logout changeUser = {props.changeUsr} /> </Route>
      <Route path="*">
        <div>
          <h1>La página que buscas no existe.</h1>
          <a href="/">Volver a inicio</a>
        </div>
      </Route>
    </Switch>
  )
}
