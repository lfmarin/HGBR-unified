import React, { useState, useEffect } from 'react'
import useStyles from '../../Styles/formularioStyles'
import { Button, TextField, Typography } from '@material-ui/core'
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined'
import clsx from 'clsx'
import axios from 'axios'
import { useParams } from 'react-router-dom'
import { Navigate } from 'react-router-dom'
import { FormControl } from '@material-ui/core'
import { InputLabel } from '@material-ui/core'
import { Select } from '@material-ui/core'
import { MenuItem } from '@material-ui/core'

export default function NotaMedica({expediente, token}) {
  const style = useStyles()
  const [datos, setDatos] = useState({
    fkFicha: '',
    fechaHora: '',
    signosVitales: '',
    diagnosticoPre: '',
    cirugiaProgramada: '',
    fechaCirugia: '',
    tipoAnestesia: '',
    preparacion: '',
    fkDoctor: '',
    diagnosticoPost: '',
    complicaciones: '',
    descripcion: '',
  })
  const [doctores, setDoctores] = useState([])
  const [ficha, setFicha] = useState({
    idFicha: '',
    fkPaciente: '',
    servicio: '',
    diagnostico: '',
  })

  const { noExpediente } = useParams()
  const [isFail, setIsFail] = useState(false)
  const [errorbd, setErrorbd] = useState(false)
  // const [finish, setFinish] = useState(false)
  const [loadFicha, setLoadFicha] = useState(true)
  const [load, setLoad] = useState(false)
  const [show, setShow] = useState(false)

  const handleChange = event => {
    setDatos({
      ...datos,
      [event.target.name]: event.target.value,
    })
  }

  const handleChangeFicha = event2 => {
    setFicha({
      ...ficha,
      [event2.target.name]: event2.target.value,
    })
  }

  const cargaFicha = () => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + `/hospitalBoca/fichaIdent/${noExpediente}`, {
        headers: {
          'Content-type': 'application/json',
          'Authorization': `Bearer ${token()}`
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setFicha({
              idFicha: response.data.idFicha,
              fkPaciente: response.data.fkPaciente,
              servicio: response.data.servicio,
              diagnostico: response.data.diagnostico
            })
            setLoad(true)
          }
        },
        error => {
          if (!error.response) {
            setErrorbd(true)
            setLoad(false)
          }
        }
      )
  }

  const carga = () => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + `/hospitalBoca/NotaMedica/${noExpediente}`, {
        headers: {
          'Content-type': 'application/json',
          'Authorization': `Bearer ${token()}`
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            var fechaCirugia
            if (response.data.fechaCirugia != null) {
              fechaCirugia = response.data.fechaCirugia.substring(0, response.data.fechaCirugia.indexOf('T'))
            } else {
              fechaCirugia = response.data.fechaCirugia
            }
            setDatos({
              fkFicha: response.data.fkFicha,
              fechaHora: response.data.fechaHora,
              signosVitales: response.data.signosVitales,
              diagnosticoPre: response.data.diagnosticoPre,
              cirugiaProgramada: response.data.cirugiaProgramada,
              fechaCirugia: fechaCirugia,
              tipoAnestesia: response.data.tipoAnestesia,
              preparacion: response.data.preparacion,
              fkDoctor: response.data.fkDoctor,
              diagnosticoPost: response.data.diagnosticoPost,
              complicaciones: response.data.complicaciones,
              descripcion: response.data.descripcion,
            })
            setShow(true)
          }
        },
        error => {
          if (error.response) {
            // setErrorbd(true)
            setShow(true)
          }
        }
      )
  }

  useEffect(() => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/doctores/all', {
        headers: {
          'Content-type': 'application/json',
          'Authorization': `Bearer ${token()}`
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
          if (!error.response) setErrorbd(true)
        }
      )
  }, [token])

  const guardaNotaMedica = () => {
    axios
      .post(
        process.env.REACT_APP_SERVIDOR + '/hospitalBoca/NotaMedica/update',
        {
          fkFicha: datos.fkFicha,
          fechaHora: datos.fechaHora,
          signosVitales: datos.signosVitales,
          diagnosticoPre: datos.diagnosticoPre,
          cirugiaProgramada: datos.cirugiaProgramada,
          fechaCirugia: datos.fechaCirugia,
          tipoAnestesia: datos.tipoAnestesia,
          preparacion: datos.preparacion,
          fkDoctor: datos.fkDoctor,
          diagnosticoPost: datos.diagnosticoPost,
          complicaciones: datos.complicaciones,
          descripcion: datos.descripcion,
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

  const guardaFicha = () => {
    axios
      .post(
        process.env.REACT_APP_SERVIDOR + '/hospitalBoca/fichaIdent/update',
        {
          idFicha: ficha.idFicha,
          fkPaciente: ficha.fkPaciente,
          servicio: ficha.servicio,
          diagnostico: ficha.diagnostico,
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
            // setFinish(true)
          }
        },
        error => {
          if (!error.response) setErrorbd(true)
        }
      )
  }

  const handleSave = () => {
    if (datos.fechaHora === '') {
      setIsFail(true)
      return
    } else {
      guardaFicha()
      guardaNotaMedica()
    }
  }

  if (errorbd) return <Navigate to="/error" />

  if (loadFicha) {
    cargaFicha()
    setLoadFicha(false)
  }

  if(load){
    carga()
    setLoad(false)
  }

  if (show) {
    return (
      <div className={style.fullWidth}>
        <form className={style.fullWidth}>
          <Typography className={style.line} variant="h6">
            Nota Médica
          </Typography>
          <div className={style.justify}>
            <div className={clsx(style.fullWidth)}>
              <TextField
                className={clsx(style.input, style.input30)}
                label="Número de ficha de identificación"
                variant="outlined"
                name="fkFicha"
                defaultValue={ficha.idFicha}
                fullWidth
                inputProps={{ readOnly: true }}
              />

              <TextField
                className={clsx(style.input, style.input30)}
                label="Paciente"
                variant="outlined"
                name="fkPaciente"
                defaultValue={ficha.fkPaciente}
                fullWidth
                inputProps={{ readOnly: true }}
              />

              <TextField
                className={clsx(style.input, style.input30)}
                label="Servicio"
                variant="outlined"
                name="servicio"
                defaultValue={ficha.servicio}
                fullWidth
                onChange={handleChangeFicha}
              />

            <TextField
                className={clsx(style.input, style.input30)}
                label="Diagnóstico"
                variant="outlined"
                name="diagnostico"
                defaultValue={ficha.diagnostico}
                fullWidth
                onChange={handleChangeFicha}
              />
            </div>

            <TextField
              className={clsx(style.input, style.input30)}
              label="Fecha y hora"
              variant="outlined"
              name="fechaHora"
              defaultValue={datos.fechaHora}
              fullWidth
              required
              error={datos.fechaHora === '' && isFail}
              onChange={handleChange}
              type="datetime-local"
              InputLabelProps={{ shrink: true }}
            />

            <TextField
              className={clsx(style.input)}
              label="Signos vitales"
              variant="outlined"
              name="signosVitales"
              defaultValue={datos.signosVitales}
              fullWidth
              onChange={handleChange}
            />

            <TextField
              className={clsx(style.input)}
              label="Diagnostico preoperatorio"
              variant="outlined"
              name="diagnosticoPre"
              defaultValue={datos.diagnosticoPre}
              fullWidth
              onChange={handleChange}
            />
            <div className={clsx(style.fullWidth, style.justify)}>
              <TextField
                className={clsx(style.input, style.input30)}
                label="Cirugía programada"
                variant="outlined"
                name="cirugiaProgramada"
                defaultValue={datos.cirugiaProgramada}
                fullWidth
                onChange={handleChange}
              />
              <TextField
                className={clsx(style.input, style.input30)}
                label="Fecha de la cirugía"
                variant="outlined"
                name="fechaCirugia"
                defaultValue={datos.fechaCirugia}
                type="date"
                InputLabelProps={{ shrink: true }}
                fullWidth
                onChange={handleChange}
              />
              <TextField
                className={clsx(style.input, style.input30)}
                label="Tipo de anestesia"
                variant="outlined"
                name="tipoAnestesia"
                defaultValue={datos.tipoAnestesia}
                fullWidth
                onChange={handleChange}
              />
            </div>
            <TextField
              className={clsx(style.input)}
              label="Preparación"
              variant="outlined"
              name="preparacion"
              defaultValue={datos.preparacion}
              fullWidth
              onChange={handleChange}
            />

            <FormControl variant="outlined" fullWidth className={clsx(style.input)}>
              <InputLabel id="fkDoctor">Cirujano</InputLabel>
              <Select
                labelId="fkDoctor"
                id="fkDoctor"
                label="Cirujano"
                name="fkDoctor"
                variant="outlined"
                onChange={handleChange}
                defaultValue={datos.fkDoctor}
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
              className={clsx(style.input)}
              label="Diagnostico postoperatorio"
              variant="outlined"
              name="diagnosticoPost"
              defaultValue={datos.diagnosticoPost}
              fullWidth
              onChange={handleChange}
            />

            <TextField
              className={clsx(style.input)}
              label="Complicaciones"
              variant="outlined"
              name="complicaciones"
              defaultValue={datos.complicaciones}
              fullWidth
              onChange={handleChange}
            />

            <TextField
              className={clsx(style.input)}
              label="Descripción de la técnica"
              variant="outlined"
              name="descripcion"
              defaultValue={datos.descripcion}
              fullWidth
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
