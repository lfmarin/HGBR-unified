/*
	Detalle usuario:
	Esta página define los ajustes para el usuario actual en particular.
*/
import React, { useState } from "react";
import axios from 'axios'
import { Redirect } from "react-router-dom";
import { TextField } from '@mui/material'
import './sesion.css'
import Alert from '@mui/material/Alert'
import Snackbar from '@mui/material/Snackbar'

/**
 * Pagina de inicio de sesión.
 * @param {*} props 
 */
export default function DetalleCuenta(props) {
	// Declara estados para verificar la sesion.
	const [errorMessages, setErrorMessages] = useState({});
	const token = useState(sessionStorage.getItem('jwtToken'));
	const [finish, setFinished] = useState(false);
	const [delay, setDelay] = useState(false);

	/**
	 * Esta función se encarga de reportar al usuario que los datos introducidos son incorrectos
	 * @param {*} name El elemento que será modificado.
	 * @returns {HTMLDivElement} El elemento generado.
	 */
	const renderErrorMessage = (name) => {
		return name === errorMessages.name ? (
			<div className='error'>{errorMessages.message}</div>
		) : <div></div>;
	}

	const verificarCambio = (event) => {
		// No permitas la pagina en recargar.
		event.preventDefault();

		// Agarra los formularios.
		var {curPass, newPass1, newPass2} = document.forms[0];

		// Checa si la nueva contraseña es la misma.
		if( newPass1.value !== newPass2.value )
		{
			setErrorMessages({ name: "pass", message: "Las contraseñas no coinciden."});
			return;
		}

		// Pide el API la información con lo escrito del usuario.
		const opcionesPOST = {givenPassword: curPass.value, newPassword: newPass1.value}

		console.log(opcionesPOST)

		axios
		.post(process.env.REACT_APP_SERVIDOR + '/api/Users/cambiarpass', opcionesPOST,
		{
			headers: {
			  'Content-type': 'application/json',
			  'Authorization': `Bearer ${token}`
			},
		})
		.then(
			response => {
				if (response.status === 200) {
					// Verifica si recibimos un Token.
					setFinished(true);
				}
			}
		)
		.catch(
			err => {
				if(err.response.status === 401) {
					// Reporta el mensaje que los datos son incorrectos.
					setErrorMessages({ name: "uname", message: "La contraseña original no coincide."});
				}
			}
		)
	}

	if (finish) {
		setTimeout(() => setDelay(true), 2000)
		if (delay) return <Redirect to="/" />
	}

	// Hora de generar el formulario.
	const Formulario = (
		<div className='form'>
			<form onSubmit={verificarCambio}>
				<div className='input-container'>
					<TextField
						required id="box" label="Contraseña actual"
						variant="outlined" name="curPass" type="password" fullWidth inputProps={{ maxLength: 50 }}
					/>
					{renderErrorMessage("uname")}
				</div>
				<div className='input-container'>
				<TextField
						required id="box" label="Nueva contraseña"
						variant="outlined" name="newPass1" type="password" fullWidth inputProps={{ maxLength: 50 }}
					/>
					{renderErrorMessage("pass")}
				</div>
				<div className='input-container'>
				<TextField
						required id="box" label="Repite nueva contraseña"
						variant="outlined" name="newPass2" type="password" fullWidth inputProps={{ maxLength: 50 }}
					/>
					{renderErrorMessage("pass")}
				</div>
				<div className='button-container'>
					<input type="submit" value="Iniciar" />
				</div>
			</form>
		</div>
	)

	return (
		<div className="login">
			<div className="login-form">
				<h2 className="title">Detalles de cuenta</h2>
				{Formulario}
			</div>
			<Snackbar open={finish}>
				<Alert variant="filled" severity="success" sx={{ width: '100%' }}>
				Contraseña cambiada con éxito, redirigiendo...
				</Alert>
			</Snackbar>
		</div>
	)
}