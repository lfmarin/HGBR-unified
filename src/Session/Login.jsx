import React, { useState } from "react";
import ReactDOM from "react-dom";
import axios from 'axios'

export default function Login(props) {
	// Declara estados para verificar la sesion.
	const [errorMessages, setErrorMessages] = useState({});
	const [isSubmitted, setIsSubmitted] = useState(sessionStorage.getItem('jwtToken'));
	const [Redirect, setRedirect] = useState(false)

	const renderErrorMessage = (name) => {
		name === errorMessages.name && (
			<div className='error'>{errorMessages.message}</div> 
		);
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
						setRedirect(true)
					}
				}
			}
		)
		.catch(
			err => {
				if(err.response.status === 401) {
					setErrorMessages({ name: "uname", message: "Wrong username"});
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
					<input type="text" name="pass" required />
					{renderErrorMessage("pass")}
				</div>
				<div className='button-container'>
					<input type="submit" />
				</div>
			</form>
		</div>
	)

	return (
		<div className="login">
			<div className="login-form">
				<div className="title">Inicio de sesión</div>
				{isSubmitted ? <div>Ya inicio sesión</div> : Formulario}
			</div>
		</div>
	)
}