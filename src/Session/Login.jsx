import React, { useState } from "react";
import axios from 'axios'
import { Redirect } from "react-router-dom";

/**
 * Pagina de inicio de sesión.
 * @param {*} props 
 */
export default function Login(props) {
	// Declara estados para verificar la sesion.
	const [errorMessages, setErrorMessages] = useState({});
	const [isSubmitted, setIsSubmitted] = useState(sessionStorage.getItem('jwtToken'));

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

	const handleSubmit = (event) => {
		// No permitas la pagina en recargar.
		event.preventDefault();

		var {uname, pass} = document.forms[0];

		// Pide el API la información con lo escrito del usuario.
		const opcionesPOST = {username: uname.value, password: pass.value}

		axios
		.post('https://localhost:5001/api/Users/authenticate', opcionesPOST)
		.then(
			response => {
				if (response.status === 200) {
					// Verifica si recibimos un Token.
					if( response.data.token && uname.value === response.data.userName )
					{
						// Hora de guardar el token.
						sessionStorage.setItem('jwtToken',response.data.token);
						setIsSubmitted(true)
					}
				}
			}
		)
		.catch(
			err => {
				if(err.response.status === 401) {
					// Reporta el mensaje que los datos son incorrectos.
					setErrorMessages({ name: "pass", message: "Los datos son incorrectos."});
				}
			}
		)
	}

	// Hora de generar el formulario.
	const Formulario = (
		<div className='form'>
			<form onSubmit={handleSubmit}>
				<div className='input-container'>
					<label>Nombre de usuario</label>
					<input type="text" name="uname" required />
					{renderErrorMessage("uname")}
				</div>
				<div className='input-container'>
					<label>Contraseña</label>
					<input type="password" name="pass" required />
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
				<div className="title">Inicio de sesión</div>
				{isSubmitted ? <Redirect to="/" /> : Formulario}
			</div>
		</div>
	)
}