import React, { useState } from "react";
import axios from 'axios'
import { Redirect } from "react-router-dom";
import { TextField } from '@mui/material'
import './sesion.css'

/**
 * Pagina de inicio de sesión.
 * @param {*} props 
 */
export default function Login({changeUser}) {
	// Declara estados para verificar la sesion.
	const [estado, setEstado] = useState(
		{
			errorMessages : {},
			isSubmitted : sessionStorage.getItem('jwtToken')
		}
	)
	// const [errorMessages, setErrorMessages] = useState({});
	// const [isSubmitted, setIsSubmitted] = useState(sessionStorage.getItem('jwtToken'));

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
						sessionStorage.setItem('jwtToken',response.data.token);
						changeUser(response.data.userName)
						sessionStorage.setItem('Dusername',response.data.userName)
						setEstado( prev => ({
							...prev,
							isSubmitted : true
						}))
					}
				}
			}
		)
		.catch(
			err => {
				if(err.response.status === 401) {
					// Reporta el mensaje que los datos son incorrectos.
					setEstado({errorMessages: { name: "pass", message: "Los datos son incorrectos."}})
				}
			}
		)
	}

	if(estado.isSubmitted)
		return <Redirect to="/" />

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
				{estado.isSubmitted ? null: Formulario}
			</div>
		</div>
	)
}