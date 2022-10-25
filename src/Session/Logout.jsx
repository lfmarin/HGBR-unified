import React, { useEffect } from "react";
import { Redirect } from 'react-router-dom'

export default function Login(props) {
	useEffect(() => {
		props.changeUser("")
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);
	sessionStorage.removeItem('jwtToken');
	return (
		<div>
			<p>Cerrando sesión...</p>
			<Redirect to="/login" />
		</div>
	)
}