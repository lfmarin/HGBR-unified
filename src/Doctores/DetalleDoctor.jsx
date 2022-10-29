import React, { useState, useEffect } from 'react'
import useStyles from '../Styles/detallesStyles'
import { useParams, Redirect } from 'react-router'
import axios from 'axios'
import { TextField } from '@mui/material'
import './editar.css'

export default function DetalleDoctor() {
  const { noDoctor } = useParams()
  const classes = useStyles()
  const [token, setToken] = useState(sessionStorage.getItem('jwtToken'));
  const [datos, setDatos] = useState({
    IdDoctor: '',
    Nombre: '',
    ApPaterno: '',
    ApMaterno: '',
  })
  const [load, setLoad] = useState(true)
  const [noAutorizado, AutRedir] = useState(false)
  const [Finalizado, confirmarFin] = useState(false)

  const modificarDoctor = (event) => {
	// No permitas la pagina en recargar hasta que tengamos una respuesta del API..
	event.preventDefault();
	// Lee los datos.
	console.log(datos)

	// Envia el nuevo cambio al API.
	axios
	.post('https://localhost:5001/hospitalBoca/doctores/update', datos,
	{
		headers: {
			'Content-type': 'application/json',
			'Authorization': `Bearer ${token}`
		}
	}
	)
	.then(
		response => {
			if (response.status === 200) {
				// La operación fue exitosa, vamos a regresar.
				confirmarFin(true)
				// // Verifica si recibimos un Token.
				// if( response.data.token && uname.value === response.data.userName )
				// {
				// 	// Hora de guardar el token.
				// 	sessionStorage.setItem('jwtToken',response.data.token);
				// 	props.changeUser(response.data.userName)
				// 	setIsSubmitted(true)
				// }
			}
		}
	)
	.catch(
		err => {
			if(err.response.status === 401) {
				// Reporta el mensaje que los datos son incorrectos.
				// setErrorMessages({ name: "pass", message: "Los datos son incorrectos."});
			}
		}
	)
  }

  const handleChange = event => {
    //const {name, value} = e.target;
	console.log("chabge")
    setDatos({
      ...datos,
      [event.target.name]: event.target.value,
    })
  }

  const cargaPaciente = () => {
    axios
      .get(`https://localhost:5001/hospitalBoca/doctores/${noDoctor}`, {
        headers: {
          'Content-type': 'application/json',
          'Authorization': `Bearer ${token}`
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
            setToken("")
            AutRedir(true)
          }
        }
      )
  }

  useEffect(() => {
	if( datos.IdDoctor !== '' )
		setLoad(false)
    if (load) {
      cargaPaciente()
    }
  }, [load, datos.IdDoctor]);

  if( noAutorizado )
    return <Redirect to="/login" />

  if( Finalizado )
  	return <Redirect to="/doctores" />

  return (
    <div className={classes.root}>
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
						name="nombre"
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
						name="apPaterno"
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
						name="apMaterno"
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
