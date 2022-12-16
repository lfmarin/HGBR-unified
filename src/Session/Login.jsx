import React, { useEffect, useState } from "react";
import axios from 'axios'
import { Navigate } from "react-router-dom";
import { TextField } from '@mui/material'
import './sesion.css'

/**
 * Pagina de inicio de sesión.
 * @param {*} props 
 */
export default function Login({token, changeToken, changeUser}) {
	// Declara estados para verificar la sesion.
	const [estado, setEstado] = useState(
		{
			errorMessages : {},
		}
	)
	// const [errorMessages, setErrorMessages] = useState({});
	const [isSubmitted, setIsSubmitted] = useState(token !== null);

	/**
	 * Esta función se encarga de reportar al usuario que los datos introducidos son incorrectos
	 * @param {*} name El elemento que será modificado.
	 * @returns {HTMLDivElement} El elemento generado.
	 */
	const renderErrorMessage = (name) => {
		return name === estado.errorMessages.name ? (
			<div className='error'>{estado.errorMessages.message}</div>
		) : <div></div>;
	}

	const handleSubmit = (event) => {
		// No permitas la pagina en recargar.
		event.preventDefault();

		var {uname, pass} = document.forms[0];

		// Pide el API la información con lo escrito del usuario.
		const opcionesPOST = {username: uname.value, password: pass.value}

		axios
		.post( process.env.REACT_APP_SERVIDOR + process.env.REACT_APP_USUARIOS + 'authenticate', opcionesPOST)
		.then(
			response => {
				if (response.status === 200) {
					// Verifica si recibimos un Token.
					if( response.data.token && uname.value === response.data.userName )
					{
						// Hora de guardar el token.
						changeToken(response.data.token)
						changeUser(response.data.userName)
						setIsSubmitted(true)
					}
				}
			}
		)
		.catch(
			err => {
				if(err.response)
					if(err.response.status === 401) {
						// Reporta el mensaje que los datos son incorrectos.
						setEstado({errorMessages: { name: "pass", message: "Los datos son incorrectos."}})
					}
			}
		)
	}

	if(isSubmitted)
		return <Navigate to="/" />

	// Hora de generar el formulario.
	const Formulario = (
		<div className='form'>
			<form onSubmit={handleSubmit}>
				<div className='input-container'>
					<TextField
						required
						id="box"
						label="Nombre de usuario"
						variant="outlined"
						name="uname"
						fullWidth
						inputProps={{ maxLength: 50 }}
					/>
					{renderErrorMessage("uname")}
				</div>
				<div className='input-container'>
				<TextField
						required
						id="box"
						label="Contraseña"
						variant="outlined"
						name="pass"
						type="password"
						fullWidth
						inputProps={{ maxLength: 50 }}
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
				<h2 className="title">Inicio de sesión</h2>
				{isSubmitted ? null: Formulario}
			</div>
		</div>
	)
}