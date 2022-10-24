import React from "react";
import { Redirect } from 'react-router-dom'

export default function Login(props) {
	sessionStorage.setItem('jwtToken',"");
	return (
		<div>
			<p>Cerrando sesión...</p>
			<Redirect to="/login" />
		</div>
	)
}