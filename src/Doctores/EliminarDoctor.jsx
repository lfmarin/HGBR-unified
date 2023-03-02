import React, { useState, useEffect } from 'react'
import useStyles from '../Styles/detallesStyles'
import { useParams, Navigate } from 'react-router-dom'
import axios from 'axios'
import './editar.css'
import {Button} from '@mui/material'
import Alert from '@mui/material/Alert'
import Snackbar from '@mui/material/Snackbar'

export default function EliminarDoctor({token, revokeToken}) {
  const { noDoctor } = useParams()
  const classes = useStyles()
  const [delay, setDelay] = useState(false)
  const [cancelado, setCancelado] = useState(false)
  const [NoPermitido, setPermit] = useState(false)
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
	.post(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/doctores/delete',
	datos.IdDoctor,
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

  const cancelarOp = () => {
	setCancelado(true);
	confirmarFin(true);
  }

  useEffect(() => {
	if( datos.IdDoctor !== '' )
		setLoad(false)
    if (load) {
      const cargaPaciente = () => {
        axios
          .get(`${process.env.REACT_APP_DOCTORES}${noDoctor}`, {
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
              }
            },
            error => {
              // console.log(error.response)
              if (error.response.status === 401) {
                revokeToken("")
                AutRedir(true)
              }
              setPermit(error.response.status === 403)
            }
          )
      }
      cargaPaciente()
    }
  }, [load, datos.IdDoctor, datos, noDoctor, token, revokeToken]);

  if (Finalizado) {
	if(!cancelado)
    	setTimeout(() => setDelay(true), 2000)
    if (delay || cancelado) return <Navigate to="/doctores" />
  }

  if( noAutorizado )
    return <Navigate to="/login" />

  return (
    <div className={classes.root}>
      {NoPermitido ? <div>
        <h2>Acceso Denegado</h2>
        <p>Usted no tiene los permisos necesarios para modificar el contenido.</p>
      </div> : null}
		{!load ?
			<div className='input-container'>
				<p>¿Estas seguro de eliminar al doctor {datos.Nombre} {datos.ApMaterno} {datos.apPaterno} ?</p>
				<form onSubmit={modificarDoctor}>
					<div className='button-container'>
						<Button variant="contained" color="secondary" type="submit" size="large" >
							Eliminar
						</Button>
						<Button variant="contained" color="primary" type="submit" size="large" onClick={cancelarOp} >
							Cancelar
						</Button>
					</div>
				</form>
			</div>
		: null}
		<Snackbar open={Finalizado}>
			<Alert variant="filled" severity="success" sx={{ width: '100%' }}>
				Doctor eliminado con éxito, redirigiendo...
			</Alert>
		</Snackbar>
    </div>
  )
}
