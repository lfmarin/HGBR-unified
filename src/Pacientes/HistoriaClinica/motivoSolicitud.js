import React, { useState, useEffect } from 'react'
import useStyles from '../../Styles/formularioStyles'
import { Button, TextField, Typography } from '@material-ui/core'
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined'
import clsx from 'clsx'
import axios from 'axios'
import { useParams } from 'react-router'
import { FormControl } from '@material-ui/core'
import { InputLabel } from '@material-ui/core'
import { Select } from '@material-ui/core'
import { MenuItem } from '@material-ui/core'
import Alert from '@mui/material/Alert'
import Snackbar from '@mui/material/Snackbar'
import { Redirect } from 'react-router-dom'

export default function MotivoSolicitud() {
  const style = useStyles()
  const [datos, setDatos] = useState({
    FkHistoria: '',
    CausaNoHijos: '',
    FkOpinion: '',
    FkMetodoPlanificacion: '',
  })
  const [datosHC, setDatosHC] = useState({
    fkPaciente: '',
    fkHospital: '',
    fechaElab: '',
  })
  const [opinion, setOpinion] = useState([])
  const [metodo, setMetodo] = useState([])
  const { noExpediente } = useParams()
  const [isFail, setIsFail] = useState(false)
  const [errorbd, setErrorbd] = useState(false)
  const [finish, setFinish] = useState(false)
  const [delay, setDelay] = useState(false)
  const [load, setLoad] = useState(true)
  const [loadMotivo, setLoadMotivo] = useState(false)
  const [show, setShow] = useState(false)

  const handleChange = event => {
    setDatos({
      ...datos,
      [event.target.name]: event.target.value,
    })
  }

  useEffect(() => {
    axios
      .get('https://localhost:5001/hospitalBoca/catalogos/opinionPareja', {
        headers: {
          'Content-type': 'application/json',
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setOpinion(response.data)
            setErrorbd(false)
          }
        },
        error => {
          if (!error.response) setErrorbd(true)
        }
      )
  }, [])

  useEffect(() => {
    axios
      .get('https://localhost:5001/hospitalBoca/catalogos/metodoPlanificacion', {
        headers: {
          'Content-type': 'application/json',
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setMetodo(response.data)
            setErrorbd(false)
          }
        },
        error => {
          if (!error.response) setErrorbd(true)
        }
      )
  }, [])

  const cargaHC = () => {
    axios
      .get(`https://localhost:5001/hospitalBoca/historiaClinica/${noExpediente}`, {
        headers: {
          'Content-type': 'application/json',
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            var fecha = response.data.fechaElab.substring(0, response.data.fechaElab.indexOf('T'))
            setDatosHC({
              fkPaciente: response.data.fkPaciente,
              fkHospital: response.data.fkHospital,
              fechaElab: fecha,
            })
            setDatos({
              ...datos,
              FkHistoria: response.data.idHistoriaClinica,
            })
            setLoadMotivo(true)
          }
        },
        error => {
          if (!error.response) {
            setErrorbd(true)
            setLoadMotivo(false)
          }
        }
      )
    setLoadMotivo(true)
  }

  const cargaMotivo = () => {
    axios
      .get(`https://localhost:5001/hospitalBoca/historiaClinica/motivoSolicitud/${datos.FkHistoria}`, {
        headers: {
          'Content-type': 'application/json',
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setDatos({
              FkHistoria: response.data.fkHistoria,
              CausaNoHijos: response.data.caudaNoHijos,
              FkOpinion: response.data.fkOpinion,
              FkMetodoPlanificacion: response.data.fkMetodoPlanificacion,
            })
            setShow(true)
          }
        },
        error => {
          if (!error.response) {
            setErrorbd(true)
            setShow(false)
          }
        }
      )
  }

  const guardaMotivo = () => {
    axios
      .post(
        'https://localhost:5001/hospitalBoca/historiaClinica/motivoSolicitud/update',
        {
          FkHistoria: datos.FkHistoria,
          CausaNoHijos: datos.CausaNoHijos,
          FkOpinion: datos.FkOpinion,
          FkMetodoPlanificacion: datos.FkMetodoPlanificacion,
        },
        {
          headers: {
            'Content-type': 'application/json',
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

  const handleSave = () => {
    if (datos.FkOpinion === null || datos.FkMetodoPlanificacion === null || datos.CausaNoHijos === null) {
      setIsFail(true)
      return
    } else {
      guardaMotivo()
    }
  }

  if (errorbd) return <Redirect to="/error" />

  if (load) {
    cargaHC()
    setLoad(false)
  }

  if (loadMotivo) {
    cargaMotivo()
    setLoadMotivo(false)
  }

  if (show) {
    return (
      <div className={style.fullWidth}>
        <TextField
          className={clsx(style.input, style.input30)}
          label="No. de Expediente"
          variant="outlined"
          name="NoExpediente"
          defaultValue={datosHC.fkPaciente}
          fullWidth
          inputProps={{ readOnly: true }}
        />
        <TextField
          className={clsx(style.input, style.input30)}
          name="fechaElab"
          variant="outlined"
          required
          type="date"
          defaultValue={datosHC.fechaElab}
          inputProps={{ readOnly: true }}
        />

        <form className={style.fullWidth}>
          <Typography className={style.line} style={{ color: '#AC3833', fontWeight: 'bold' }} variant="h6">
            Motivos de solicitud
          </Typography>
          <div className={style.justify}>
            <TextField
              className={clsx(style.input, style.input100)}
              required
              label="¿Cuál es la causa más importante para no tener más hijos? "
              variant="outlined"
              name="CausaNoHijos"
              error={datos.CausaNoHijos === null && isFail}
              defaultValue={datos.CausaNoHijos}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 60 }}
            />

            <FormControl variant="outlined" fullWidth>
              <InputLabel id="FkOpinion" className={clsx(style.input, style.input100)} required>
                {' '}
                ¿Que opinión tiene su pareja sobre su decisión?
              </InputLabel>
              <Select
                required
                labelId="FkOpinion"
                id="FkOpinion"
                label="¿Que opinión tiene su pareja sobre su decisión?"
                name="FkOpinion"
                defaultValue={datos.FkOpinion}
                onChange={handleChange}
                error={datos.FkOpinion === null && isFail}
                className={clsx(style.input, style.input100)}
              >
                {opinion.map(n => {
                  return <MenuItem value={n.idOpinion}>{n.nombreOpinion}</MenuItem>
                })}
              </Select>
            </FormControl>

            <FormControl variant="outlined" fullWidth>
              <InputLabel id="FkMetodoPlanificacion" className={clsx(style.input, style.input100)}>
                {' '}
                ¿Que método de planificación familiar está utilizando?
              </InputLabel>
              <Select
                required
                labelId="FkMetodoPlanificacion"
                id="FkMetodoPlanificacion"
                label="¿Que método de planificación familiar está utilizando?"
                name="FkMetodoPlanificacion"
                defaultValue={datos.FkMetodoPlanificacion}
                onChange={handleChange}
                error={datos.FkMetodoPlanificacion === null && isFail}
                className={clsx(style.input, style.input100)}
              >
                {metodo.map(n => {
                  return <MenuItem value={n.idMetodo}>{n.nombreMetodo}</MenuItem>
                })}
              </Select>
            </FormControl>
          </div>

          <div className={style.contenedorButton}>
            <Button
              variant="contained"
              color="secondary"
              type="submit"
              size="large"
              className={style.button}
              startIcon={<SaveOutlinedIcon />}
              onClick={handleSave}
            >
              GUARDAR
            </Button>
          </div>
        </form>
        <Snackbar open={finish}>
          <Alert variant="filled" severity="success" sx={{ width: '100%' }}>
            Datos guardados correctamente
          </Alert>
        </Snackbar>
      </div>
    )
  } else {
    return <Typography> Ha habido un problema cargando la información del usuario </Typography>
  }
}
