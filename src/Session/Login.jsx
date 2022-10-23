import React, { useState } from "react";
import ReactDOM from "react-dom";
import axios from 'axios'

export default function Login(props) {
	// Declara estados para verificar la sesion.
	const [errorMessages, setErrorMessages] = useState({});
	const [isSubmitted, setIsSubmitted] = useState(false);
	const [errorbd, setErrorbd] = useState(false)

	const renderErrorMessage = (name) => {
		name === errorMessages.name && (
			<div className='error'>{errorMessages.message}</div> 
		);
	}

	const handleSubmit = (event) => {
		event.preventDefault();

		var {uname, pass} = document.forms[0];

		console.log(uname.value, pass.value)

		// Pide el API la información con lo escrito del usuario.
		const opcionesPOST = {username: uname.value, password: pass.value}

		console.log(opcionesPOST)

		axios
		.post('https://localhost:5001/api/Users/authenticate', opcionesPOST)
		.then(
			response => {
				if (response.status === 200) {
					console.log(response.data)
					// Verifica si recibimos un Token.
					if( response.data.token && uname.value === response.data.userName )
					{
						// Hora de guardar el token.
						//console.log("TENEMOS SESION")
						sessionStorage.setItem('jwtToken',response.data.token);

					}
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