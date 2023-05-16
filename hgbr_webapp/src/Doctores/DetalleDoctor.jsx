import React, { useState, useEffect } from 'react'
import useStyles from '../Styles/detallesStyles'
import { useParams, Navigate } from 'react-router-dom'
import axios from 'axios'
import { TextField } from '@mui/material'
import './editar.css'

export default function DetalleDoctor({token, revokeToken}) {
  const { noDoctor } = useParams()
  const classes = useStyles()
  const [datos, setDatos] = useState({
	IdDoctor: '',
	Nombre: '',
	ApPaterno: '',
	ApMaterno: '',
  })
  const [load, setLoad] = useState(true)
  const [NoPermitido, setPermit] = useState(false)
  const [noAutorizado, AutRedir] = useState(false)
  const [Finalizado, confirmarFin] = useState(false)

  const modificarDoctor = (event) => {
	// No permitas la pagina en recargar hasta que tengamos una respuesta del API..
	event.preventDefault();
	// Lee los datos.
	console.log(datos)

	// Envia el nuevo cambio al API.
	axios.post(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/doctores/update', datos,
	{
		headers: {
			'Content-type': 'application/json',
			'Authorization': `Bearer ${token()}`
		}
	}
	)
	.then(
		response => {
			// La operación fue exitosa, vamos a regresar.
			confirmarFin(response.status === 200)
		}
	)
	.catch(
		err => {
			// No estamos autorizados a estar aqui, regresa a la pantalla de inicio.
			AutRedir(err.response.status === 401)
		}
	)
  }

  const handleChange = event => {
	//const {name, value} = e.target;
	setDatos({
	  ...datos,
	  [event.target.name]: event.target.value,
	})
  }

  useEffect(() => {
	if( datos.IdDoctor !== '' )
		setLoad(false)
	if (load) {
		const cargaPaciente = () => {
		axios
			.get(process.env.REACT_APP_SERVIDOR + `/hospitalBoca/doctores/${noDoctor}`, {
			headers: {
				'Content-type': 'application/json',
				'Authorization': `Bearer ${token()}`
			},
			})
			.then(
			response => {
				if (response.status === 200) {
				setDatos({
					IdDoctor: response.data.idDoctor,
					Nombre: response.data.nombre,
					ApPaterno: response.data.apPaterno,
					ApMaterno: response.data.apMaterno,
				})
	
				console.log(datos)
				}
			},
			error => {
				// console.log(error.response)
				if (error.response.status === 401) {
					revokeToken()
					AutRedir(true)
				}
				setPermit(error.response.status === 403)
			}
			)
		}
		cargaPaciente()
	}
  }, [load, datos.IdDoctor, datos, noDoctor, revokeToken, token]);

  if( noAutorizado )
	return <Navigate to="/login" />

  if( Finalizado )
  	return <Navigate to="/doctores" />

  return (
	<div className={classes.root}>
	{NoPermitido ? <div>
		<h2>Acceso Denegado</h2>
		<p>Usted no tiene los permisos necesarios para modificar el contenido.</p>
	</div> : null}
	{/* Carga el formulario para editar información. */}
	{!load ?
		<div className='input-container'>
			<h2>ID de doctor: {datos.IdDoctor}</h2>
			<form onSubmit={modificarDoctor}>
				<div>
					<TextField
						required
						id="box"
						label="Nombre"
						variant="outlined"
						name="Nombre"
						defaultValue={datos.Nombre}
						onChange={handleChange}
						fullWidth
						inputProps={{ maxLength: 50 }}
					/>
					<p />
					<TextField
						required
						id="box"
						label="Apellido Paterno"
						variant="outlined"
						name="ApPaterno"
						defaultValue={datos.ApPaterno}
						onChange={handleChange}
						fullWidth
						inputProps={{ maxLength: 50 }}
					/>
					<p />
					<TextField
						required
						id="box"
						label="Apellido Materno"
						variant="outlined"
						name="ApMaterno"
						defaultValue={datos.ApMaterno}
						onChange={handleChange}
						fullWidth
						inputProps={{ maxLength: 50 }}
					/>
					<div className='button-container'>
						<input type="submit" value="Confirmar" />
					</div>
				</div>
			</form>
		</div>
	: null}
	</div>
  )
}
