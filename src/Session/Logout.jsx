import React, { useEffect, useState } from "react";
import { Redirect } from 'react-router-dom'
import axios from "axios";

export default function Login(changeUser) {
	const token = useState(sessionStorage.getItem('jwtToken'));
	const [loggedOut, setlogout] = useState(false)
	useEffect(() => {
		changeUser("")
		// eslint-disable-next-line react-hooks/exhaustive-deps
		axios
		.post(process.env.REACT_APP_SERVIDOR + '/api/Users/logout',{},{
			headers: {
				'Content-type': 'application/json',
				'Authorization': `Bearer ${token}`
			},
		})
		.then(
			response => {
				if (response.status === 200) {
					sessionStorage.removeItem('jwtToken');
					sessionStorage.removeItem('Dusername');
					setlogout(true)
				}
			}
		)
		.catch(
			err => {
				if(err.response.status === 401) {
					// Reporta el mensaje que los datos son incorrectos.
					//setErrorMessages({ name: "pass", message: "Los datos son incorrectos."});
					console.error("No se logró cerrar sesión.")
				}
			}
		)
	}, [changeUser, token]);

	if(loggedOut)
		return <Redirect to="/login" />;
	
	return (
		<div>
			<p>Cerrando sesión...</p>
		</div>
	)
}