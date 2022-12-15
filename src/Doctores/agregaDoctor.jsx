import React, { useState } from 'react'
import Paper from '@material-ui/core/Paper'
import { Typography } from '@material-ui/core'
import axios from 'axios'
import { Redirect } from 'react-router-dom'
import { TextField } from '@mui/material'
import useStyles from '../Styles/formularioStyles'
import { Button } from '@material-ui/core'
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined'
import { Grid } from '@mui/material'
import Alert from '@mui/material/Alert'
import Snackbar from '@mui/material/Snackbar'
import { useEffect } from 'react'

export default function RegistroDoctor() {
  const [isFail, setIsFail] = useState(false)
  const [datos, setDatos] = useState({
    Nombre: '',
    ApPaterno: '',
    ApMaterno: '',
  })
  const [token] = useState(sessionStorage.getItem('jwtToken'));
  const [NoPermitido, setPermit] = useState(false)
  const [errorbd, setErrorbd] = useState(false)
  const [finish, setFinish] = useState(false)
  const [delay, setDelay] = useState(false)
  const style = useStyles()

  const guardaDoctor = () => {
    axios
      .post(
        'https://localhost:5001/hospitalBoca/doctores/save',
        {
          nombre: datos.Nombre,
          apPaterno: datos.ApPaterno,
          apMaterno: datos.ApMaterno,
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
          if (!error.response) setErrorbd(true)
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

  if (errorbd) return <Redirect to="/error" />

  if (finish) {
    setTimeout(() => setDelay(true), 2000)
    if (delay) return <Redirect to="/doctores" />
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
                Registro de doctor
              </Typography>
            </Grid>
          </Grid>
          <Grid container spacing={1} justifyContent="center">
            <Grid item xs margin={1}>
              <TextField
                required
                id="nombre"
                label="Nombre del doctor"
                variant="outlined"
                name="Nombre"
                error={datos.Nombre === '' && isFail}
                defaultValue={datos.Nombre}
                onChange={handleChange}
                fullWidth
                inputProps={{ maxLength: 50 }}
              />
            </Grid>

            <Grid item xs margin={1}>
              <TextField
                required
                id="apPaterno"
                label="Apellido paterno"
                variant="outlined"
                name="ApPaterno"
                error={datos.ApPaterno === '' && isFail}
                defaultValue={datos.ApPaterno}
                onChange={handleChange}
                fullWidth
                inputProps={{ maxLength: 50 }}
              />
            </Grid>

            <Grid item xs margin={1}>
              <TextField
                required
                id="apMaterno"
                label="Apellido materno"
                variant="outlined"
                name="ApMaterno"
                error={datos.ApMaterno === '' && isFail}
                defaultValue={datos.ApMaterno}
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
