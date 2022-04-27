import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Home from './Home';
import ListaPacientes from '../Pacientes/listaPacientes';
import RegistroPaciente from '../Pacientes/agregaPaciente';
import ListaDoctores from '../Doctores/ListaDoctores';
import RegistroDoctor from '../Doctores/agregaDoctor';
import ListaConsejeria from '../Consejeria/ListaPersonal';
import RegistroPersonal from '../Consejeria/agregaPersonal';
import DetallesPaciente from '../Pacientes/detallesPaciente';
import MainHistoriaClinica from '../Pacientes/HistoriaClinica/MainHistoria';

export default function MainRoutes() {
    return(
        <Switch>
            <Route exact path="/pacientes/detalles/:noExpediente/historia-clinica">
                <MainHistoriaClinica/>
            </Route>
            <Route exact path="/pacientes/detalles/:noExpediente">
                <DetallesPaciente/>
            </Route>
            <Route exact path="/pacientes/registro">
                <RegistroPaciente/>
            </Route>
            <Route exact path="/pacientes">
                <ListaPacientes/>
            </Route>
            <Route exact path="/doctores/registro">
                <RegistroDoctor/>
            </Route>
            <Route exact path="/doctores">
                <ListaDoctores/>
            </Route>
            <Route exact path="/consejeria/registro">
                <RegistroPersonal/>
            </Route>
            <Route exact path="/consejeria">
                <ListaConsejeria/>
            </Route>
            <Route exact path="/">
                <Home/>
            </Route>
            <Route path="*">
                <h1> Oops! La página que buscas no existe :(</h1>
            </Route>
        </Switch>
    );
    
}