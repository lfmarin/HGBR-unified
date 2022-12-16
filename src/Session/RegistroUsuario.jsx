import React, { useState } from 'react'
import Paper from '@material-ui/core/Paper'
import { Typography } from '@material-ui/core'
import axios from 'axios'
import { Navigate } from 'react-router-dom'
import { TextField } from '@mui/material'
import useStyles from '../Styles/formularioStyles'
import { Button } from '@material-ui/core'
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined'
import { Grid } from '@mui/material'
import Alert from '@mui/material/Alert'
import Snackbar from '@mui/material/Snackbar'
import { useEffect } from 'react'

export default function RegistroUsuario({token, revokeToken}) {
  const [isFail, setIsFail] = useState(false)
  const [datos, setDatos] = useState({
    userName: '',
    Password: '',
    IDDoctor: '',
	IdRole: ''
  })
  const [NoPermitido, setPermit] = useState(false)
  const [errorbd, setErrorbd] = useState(false)
  const [finish, setFinish] = useState(false)
  const [delay, setDelay] = useState(false)
  const style = useStyles()

  const guardaDoctor = () => {
    axios
      .post(
        process.env.REACT_APP_SERVIDOR + '/api/Users/adduser',
        {
          userName: datos.userName,
          Password: datos.pass,
          IDDoctor: datos.idDoctor,
		  IdRole: datos.role,
        },
        {
          headers: {
            'Content-type': 'application/json',
            'Authorization': `Bearer ${token}`
          },
        }
      )
      .then(
        response => {
          if (response.status === 200) {
            setErrorbd(false)
            setFinish(true)
          }
        },
        error => {
          if (!error.response)
            setErrorbd(true)
          else{
            if(error.response.status === 401)
              revokeToken()
          }
        }
      )
  }

  const cargaPaciente = () => {
    axios
      .get(`https://localhost:5001/hospitalBoca/doctores/1`, {
        headers: {
          'Content-type': 'application/json',
          'Authorization': `Bearer ${token}`
        },
      })
      .then(
        response => { /* No se hace nada, esto es solo para verificación. */ },
        error => {
          setPermit(error.response.status === 403)
        }
      )
  }

  useEffect(() => {
    cargaPaciente()
  })

  const handleChange = e => {
    const { name, value } = e.target
    setDatos({
      ...datos,
      [name]: value,
    })
  }

  const handleSave = () => {
    if (datos.Nombre === '' || datos.ApPaterno === '' || datos.ApMaterno === '') {
      setIsFail(true)
      return
    } else guardaDoctor()
  }

  if (errorbd) return <Navigate to="/error" />

  if (finish) {
    setTimeout(() => setDelay(true), 2000)
    if (delay) return <Navigate to="/doctores" />
  }

  return (
    <div>
      {NoPermitido ? <div>
        <h2>Acceso Denegado</h2>
        <p>Usted no tiene los permisos necesarios para modificar el contenido.</p>
      </div> :
      <div className={style.fullWidth}>
        <Paper elevation={3}>
          <Grid container spacing={1} justifyContent="center">
            <Grid item xs margin={1}>
              <Typography className={style.line} variant="h5" style={{ color: '#AC3833', fontWeight: 'bold' }}>
                Registro de usuario
              </Typography>
            </Grid>
          </Grid>
          <Grid container spacing={1} justifyContent="center">
            <Grid item xs margin={1}>
              <TextField
                required
                id="username"
                label="nombre de usuario"
                variant="outlined"
                name="userName"
                error={datos.userName === '' && isFail}
                defaultValue={datos.userName}
                onChange={handleChange}
                fullWidth
                inputProps={{ maxLength: 50 }}
              />
            </Grid>

            <Grid item xs margin={1}>
              <TextField
                required
                id="password"
                label="Contraseña"
                variant="outlined"
                name="Password"
                error={datos.Password === '' && isFail}
                defaultValue={datos.Password}
                onChange={handleChange}
                fullWidth
                inputProps={{ maxLength: 50 }}
              />
            </Grid>

            <Grid item xs margin={1}>
              <TextField
                required
                id="iddoctor"
                label="Doctor asignado"
                variant="outlined"
                name="idDoctor"
                error={datos.idDoctor === '' && isFail}
                defaultValue={datos.idDoctor}
                onChange={handleChange}
                fullWidth
                inputProps={{ maxLength: 50 }}
              />
            </Grid>
          </Grid>
          <Grid>
            <Button
              variant="contained"
              color="secondary"
              className={style.button}
              type="submit"
              size="large"
              onClick={handleSave}
              startIcon={<SaveOutlinedIcon />}
            >
              GUARDAR
            </Button>
          </Grid>
        </Paper>
        <Snackbar open={finish}>
          <Alert variant="filled" severity="success" sx={{ width: '100%' }}>
            Doctor registrado con éxito, redirigiendo...
          </Alert>
        </Snackbar>
      </div>}
    </div>
  )
}
