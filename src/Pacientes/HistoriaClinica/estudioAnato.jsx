import React, { useState } from 'react'
import useStyles from '../../Styles/formularioStyles'
import { Button, TextField, Typography } from '@material-ui/core'
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined'
import clsx from 'clsx'
import axios from 'axios'
import { useParams } from 'react-router'
import { Navigate } from 'react-router-dom'

export default function EstudioAnato({token}) {
  const style = useStyles()
  const [datos, setDatos] = useState({
    fkHistoria: '',
    fechaEnvio: '',
    clave: '',
    resultado: '',
  })
  const [datosHC, setDatosHC] = useState({
    fkPaciente: '',
    fkHospital: '',
    fechaElab: '',
  })
  const { noExpediente } = useParams()
  const [isFail, setIsFail] = useState(false)
  const [errorbd, setErrorbd] = useState(false)
  // const [finish, setFinish] = useState(false)
  const [load, setLoad] = useState(true)
  const [loadEst, setLoadEst] = useState(false)
  const [show, setShow] = useState(false)

  const handleChange = event => {
    setDatos({
      ...datos,
      [event.target.name]: event.target.value,
    })
  }

  const cargaHC = () => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + `/hospitalBoca/historiaClinica/${noExpediente}`, {
        headers: {
          'Content-type': 'application/json',
          'Authorization': `Bearer ${token}`
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
              fkHistoria: response.data.idHistoriaClinica,
            })
            setLoadEst(true)
          }
        },
        error => {
          if (!error.response) {
            setErrorbd(true)
            setLoadEst(false)
          }
        }
      )
    setLoadEst(true)
  }

  const cargaEstudio = () => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + `/hospitalBoca/historiaClinica/EstudioAnatomo/${datos.fkHistoria}`, {
        headers: {
          'Content-type': 'application/json',
          'Authorization': `Bearer ${token}`
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            var fecha = ""
            if (response.data.fechaEnvio != null) {
              fecha = response.data.fechaEnvio.substring(0, response.data.fechaEnvio.indexOf('T'))
            } else {
              fecha = response.data.fechaEnvio
            }
            setDatos({
              fkHistoria: response.data.fkHistoria,
              fechaEnvio: fecha,
              clave: response.data.clave,
              resultado: response.data.resultado,
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

  const guardaEstudio = () => {
    axios
      .post(
        process.env.REACT_APP_SERVIDOR + '/hospitalBoca/historiaClinica/estudioAnatomo/update',
        {
          FkHistoria: datos.fkHistoria,
          FechaEnvio: datos.fechaEnvio,
          Clave: datos.clave,
          Resultado: datos.resultado,
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
            // setFinish(true)
          }
        },
        error => {
          if (!error.response) setErrorbd(true)
        }
      )
  }

  const handleSave = () => {
    if (datos.fechaEnvio === null || datos.clave === null) {
      setIsFail(true)
      return
    } else {
      guardaEstudio()
    }
  }

  if (errorbd) return <Navigate to="/error" />

  if (load) {
    cargaHC()
    setLoad(false)
  }

  if (loadEst) {
    cargaEstudio()
    setLoadEst(false)
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
          <Typography className={style.line} variant="h6">
            Estudio Anatomopatológico
          </Typography>
          <div className={style.justify}>
            <TextField
              label="Fecha de envío"
              type="date"
              InputLabelProps={{ shrink: true }}
              name="fechaEnvio"
              className={clsx(style.input, style.input30)}
              variant="outlined"
              error={datos.fechaEnvio === null && isFail}
              defaultValue={datos.fechaEnvio}
              onChange={handleChange}
              required
            />

            <TextField
              label="Clave"
              name="clave"
              className={clsx(style.input, style.input60)}
              variant="outlined"
              required
              error={datos.clave === null && isFail}
              defaultValue={datos.clave}
              onChange={handleChange}
            />

            <TextField
              label="Resultado"
              name="resultado"
              fullWidth
              className={clsx(style.input, style.input100)}
              variant="outlined"
              defaultValue={datos.resultado}
              onChange={handleChange}
            />
          </div>

          <div className={style.contenedorButton}>
            <Button
              variant="contained"
              color="secondary"
              type="submit"
              size="large"
              startIcon={<SaveOutlinedIcon />}
              onClick={handleSave}
            >
              GUARDAR
            </Button>
          </div>
        </form>
      </div>
    )
  } else {
    return <Typography> Ha habido un problema cargando la información del usuario </Typography>
  }
}
