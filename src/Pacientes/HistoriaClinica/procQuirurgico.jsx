import React, { useState, useEffect } from 'react'
import useStyles from '../../Styles/formularioStyles'
import { Button, TextField, Typography } from '@material-ui/core'
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined'
import clsx from 'clsx'
import axios from 'axios'
import { useParams } from 'react-router'
import { Redirect } from 'react-router-dom'
import { FormControl } from '@material-ui/core'
import { InputLabel } from '@material-ui/core'
import { Select } from '@material-ui/core'
import { MenuItem } from '@material-ui/core'

export default function ProcedimientoQuirurgico() {
  const style = useStyles()
  const [datos, setDatos] = useState({
    fkHistoria: '',
    fechaCirugia: '',
    fkDoctor: '',
    notaQuirurgica: '',
    patologia: null,
  })
  const [datosHC, setDatosHC] = useState({
    fkPaciente: '',
    fkHospital: '',
    fechaElab: '',
  })
  const [doctores, setDoctores] = useState([])
  const { noExpediente } = useParams()
  const [isFail, setIsFail] = useState(false)
  const [errorbd, setErrorbd] = useState(false)
  // const [finish, setFinish] = useState(false)
  const [load, setLoad] = useState(true)
  const [loadProc, setLoadProc] = useState(false)
  const [show, setShow] = useState(false)
  const [token, setToken] = useState(sessionStorage.getItem('jwtToken'));

  const handleChange = event => {
    setDatos({
      ...datos,
      [event.target.name]: event.target.value,
    })
  }

  useEffect(() => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/doctores/all', {
        headers: {
          'Content-type': 'application/json',
          'Authentication': `Bearer ${token}`
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setDoctores(response.data)
            setErrorbd(false)
          }
        },
        error => {
          if (!error.response)
            setErrorbd(true)
          else {
            if (error.response.status === 401)
              setToken("")
          }
        }
      )
  }, [token])

  const cargaHC = () => {
    axios
      .get(`https://localhost:5001/hospitalBoca/historiaClinica/${noExpediente}`, {
        headers: {
          'Content-type': 'application/json',
          'Authentication': `Bearer ${token}`
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
            setLoadProc(true)
          }
        },
        error => {
          if (!error.response) {
            setErrorbd(true)
            setLoadProc(false)
          }
        }
      )
    setLoadProc(true)
  }

  const cargaProcedimiento = () => {
    axios
      .get(`https://localhost:5001/hospitalBoca/historiaClinica/procedimientoQuirurgico/${datos.fkHistoria}`, {
        headers: {
          'Content-type': 'application/json',
          'Authentication': `Bearer ${token}`
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            var fecha = ""
            if (response.data.fechaCirugia != null) {
              fecha = response.data.fechaCirugia.substring(0, response.data.fechaCirugia.indexOf('T'))
            } else {
              fecha = response.data.fechaCirugia
            }
            setDatos({
              fkHistoria: response.data.fkHistoria,
              fechaCirugia: fecha,
              fkDoctor: response.data.fkDoctor,
              notaQuirurgica: response.data.notaQuirurgica,
              patologia: response.data.patologia,
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

  const guardaProcedimiento = () => {
    axios
      .post(
        process.env.REACT_APP_SERVIDOR + '/hospitalBoca/historiaClinica/procedimientoQuirurgico/update',
        {
          FkHistoria: datos.fkHistoria,
          FechaCirugia: datos.fechaCirugia,
          FkDoctor: datos.fkDoctor,
          NotaQuirurgica: datos.notaQuirurgica,
          Patologia: datos.patologia,
        },
        {
          headers: {
            'Content-type': 'application/json',
            'Authentication': `Bearer ${token}`
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
    if (datos.fechaCirugia === null || datos.fkDoctor === null || datos.notaQuirurgica === null) {
      setIsFail(true)
      return
    } else {
      guardaProcedimiento()
    }
  }

  if (errorbd) return <Redirect to="/error" />

  if (load) {
    cargaHC()
    setLoad(false)
  }

  if (loadProc) {
    cargaProcedimiento()
    setLoadProc(false)
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
            Cirugía
          </Typography>
          <div className={style.justify}>
            <TextField
              label="Fecha de cirugía"
              type="date"
              InputLabelProps={{ shrink: true }}
              name="fechaCirugia"
              className={clsx(style.input, style.input30)}
              variant="outlined"
              required
              error={datos.fechaCirugia === null && isFail}
              defaultValue={datos.fechaCirugia}
              onChange={handleChange}
            />

            <FormControl variant="outlined" fullWidth>
              <InputLabel id="fkDoctor" className={clsx(style.input, style.input60)} required>
                {' '}
                Cirujano
              </InputLabel>
              <Select
                required
                labelId="fkDoctor"
                id="fkDoctor"
                label="Cirujano"
                name="fkDoctor"
                defaultValue={datos.fkDoctor}
                onChange={handleChange}
                error={datos.fkDoctor === null && isFail}
                className={clsx(style.input, style.input60)}
              >
                {doctores.map(n => {
                  return (
                    <MenuItem value={n.idDoctor}>
                      {n.nombre} {n.apPaterno} {n.apMaterno}
                    </MenuItem>
                  )
                })}
              </Select>
            </FormControl>

            <TextField
              label="Nota Quirúrgica"
              name="notaQuirurgica"
              fullWidth
              className={clsx(style.input, style.input100)}
              variant="outlined"
              required
              error={datos.notaQuirurgica === null && isFail}
              defaultValue={datos.notaQuirurgica}
              onChange={handleChange}
            />

            <TextField
              label="Patología encontrada"
              name="patologia"
              fullWidth
              className={clsx(style.input, style.input100)}
              variant="outlined"
              defaultValue={datos.patologia}
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
