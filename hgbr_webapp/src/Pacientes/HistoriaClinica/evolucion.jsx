import React, { useState } from 'react'
import useStyles from '../../Styles/formularioStyles'
import { Button, TextField, Typography } from '@material-ui/core'
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined'
import clsx from 'clsx'
import axios from 'axios'
import { useParams } from 'react-router-dom'
import { Navigate } from 'react-router-dom'

export default function Evolucion({token}) {
  const style = useStyles()
  const [datos, setDatos] = useState({
    fkHistoria: '',
    complicaciones: '',
    espermaconteo: '',
    fecha1: null,
    resultado1: '',
    fecha2: null,
    resultado2: '',
  })
  const [datosHC, setDatosHC] = useState({
    fkPaciente: '',
    fkHospital: '',
    fechaElab: '',
  })
  const { noExpediente } = useParams()
  const [errorbd, setErrorbd] = useState(false)
  // const [finish, setFinish] = useState(false)
  const [load, setLoad] = useState(true)
  const [loadEvolucion, setLoadEvolucion] = useState(false)
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
          'Authorization': `Bearer ${token()}`
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            if( response.data.status )
              setErrorbd(true)
            else {
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
              setLoadEvolucion(true)
            }
          }
        },
        error => {
          if (!error.response) {
            setErrorbd(true)
            setLoadEvolucion(false)
          }
        }
      )
    setLoadEvolucion(true)
  }

  const cargaEvolucion = () => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + `/hospitalBoca/historiaClinica/evolucion/${datos.fkHistoria}`, {
        headers: {
          'Content-type': 'application/json',
          'Authorization': `Bearer ${token()}`
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            var fecha1 = ""
            var fecha2 = ""
            if (response.data.fecha1 != null) {
              fecha1 = response.data.fecha1.substring(0, response.data.fecha1.indexOf('T'))
            } else {
              fecha1 = response.data.fecha1
            }

            if (response.data.fecha2 != null) {
              fecha2 = response.data.fecha2.substring(0, response.data.fecha2.indexOf('T'))
            } else {
              fecha2 = response.data.fecha2
            }

            setDatos({
              fkHistoria: response.data.fkHistoria,
              complicaciones: response.data.complicaciones,
              espermaconteo: response.data.espermaconteo,
              fecha1: fecha1,
              resultado1: response.data.resultado1,
              fecha2: fecha2,
              resultado2: response.data.resultado2,
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

  const guardaEvolucion = () => {
    axios
      .post(
        process.env.REACT_APP_SERVIDOR + '/hospitalBoca/historiaClinica/evolucion/update',
        {
          FkHistoria: datos.fkHistoria,
          Complicaciones: datos.complicaciones,
          Espermaconteo: datos.espermaconteo,
          Fecha1: datos.fecha1,
          Resultado1: datos.resultado1,
          Fecha2: datos.fecha2,
          Resultado2: datos.resultado2,
        },
        {
          headers: {
            'Content-type': 'application/json',
            'Authorization': `Bearer ${token()}`
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
    guardaEvolucion()
  }

  if (errorbd) return <Navigate to="/error" />

  if (load) {
    cargaHC()
    setLoad(false)
  }

  if (loadEvolucion) {
    cargaEvolucion()
    setLoadEvolucion(false)
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
            Evolución
          </Typography>
          <div className={style.justify}>
            <TextField
              label="Complicaciones"
              name="complicaciones"
              fullWidth
              className={clsx(style.input, style.input100)}
              variant="outlined"
              defaultValue={datos.complicaciones}
              onChange={handleChange}
            />

            <Typography className={clsx(style.fullWidth, style.input)}>Espermatoconteo</Typography>

            <TextField
              label="Fecha"
              type="date"
              InputLabelProps={{ shrink: true }}
              name="fecha1"
              className={clsx(style.input, style.input30)}
              variant="outlined"
              defaultValue={datos.fecha1}
              onChange={handleChange}
            />

            <TextField
              label="Resultado"
              name="resultado1"
              className={clsx(style.input, style.input60)}
              variant="outlined"
              defaultValue={datos.resultado1}
              onChange={handleChange}
            />

            <TextField
              label="Fecha 2"
              type="date"
              InputLabelProps={{ shrink: true }}
              name="fecha2"
              className={clsx(style.input, style.input30)}
              variant="outlined"
              defaultValue={datos.fecha2}
              onChange={handleChange}
            />

            <TextField
              label="Resultado 2"
              name="resultado2"
              className={clsx(style.input, style.input60)}
              variant="outlined"
              defaultValue={datos.resultado2}
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
