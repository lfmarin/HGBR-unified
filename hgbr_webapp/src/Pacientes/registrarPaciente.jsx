import React, { useState, useEffect } from 'react'
import Paper from '@material-ui/core/Paper'
import { Typography } from '@material-ui/core'
import axios from 'axios'
import { Navigate } from 'react-router-dom'
import { TextField } from '@mui/material'
import useStyles from '../Styles/formularioStyles'
import { FormControl } from '@material-ui/core'
import { InputLabel } from '@material-ui/core'
import { Select } from '@material-ui/core'
import { MenuItem } from '@material-ui/core'
import { Button } from '@material-ui/core'
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined'
import { Grid } from '@mui/material'
import Alert from '@mui/material/Alert'
import Snackbar from '@mui/material/Snackbar'

export default function AddPaciente() {
  const [isFail, setIsFail] = useState(false)
  const [hospital, setHospital] = useState([])
  const [estadoCivil, setEstadoConyugal] = useState([])
  const [escolaridad, setSexo] = useState([])
  const [ocupacion, setTipoVialidad] = useState([])
  const [religion, setTipoAsentamiento] = useState([])
  const [lugar, setLugar] = useState([])
  const [datos, setDatos] = useState({
    folio: '',
    nombre: '',
    primer_apellido: '',
    segundo_apellido: '',
    curp: '',
    fecha_nacimiento: '',
    entidad_nacimiento: '',
    edad: 0,
    nacido_hospital: null,
    fk_sexo: 0,
    peso: 0.0,
    talla: 0.0,
    fk_estado_conyugal: 0,
    insabi: null,
    gratuitidad: null,
    indigena: null,
    lengua_indigena: null,
    cual_lengua: '',
    fk_tipo_vialidad: 0,
    nombre_vialidad: '',
    num_ext: 0,
    num_int: 0,
    fk_tipo_asentamiento: 0,
    nombre_asentamiento: '',
    cp: 0,
    localidad: '',
    municipio_deleg: '',
    entidad_federativa: '',
    pais: '',
    telefono: '',
  })
  const [errorbd, setErrorbd] = useState(false)
  const [finish, setFinish] = useState(false)
  const style = useStyles()
  const [delay, setDelay] = useState(false)

  useEffect(() => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/hospitales/all', {
        headers: {
          'Content-type': 'application/json',
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setHospital(response.data)
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
      .get(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/catalogos/sexo', {
        headers: {
          'Content-type': 'application/json',
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setSexo(response.data)
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
      .get(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/catalogos/estadoConyugal', {
        headers: {
          'Content-type': 'application/json',
          //'Authorization': `Bearer ${token}`
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setEstadoConyugal(response.data)
            setErrorbd(false)
          }
        },
        error => {
          if (!error.response)
            setErrorbd(true)
          else{
              if (error.response.status === 401) {
                /*localStorage.removeItem("ACCESS_TOKEN");
                setToken('');*/
                setErrorbd(false);
              }
            }
        }
      )
  }, [])

  useEffect(() => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/catalogos/tipoVialidad', {
        headers: {
          'Content-type': 'application/json',
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setTipoVialidad(response.data)
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
      .get(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/catalogos/tipoAsentamiento', {
        headers: {
          'Content-type': 'application/json',
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setTipoAsentamiento(response.data)
            setErrorbd(false)
          }
        },
        error => {
          if (!error.response) setErrorbd(true)
        }
      )
  }, [])

  //USAR PARA OBTENER LOS CATALOGOS DE LA API DE CC PP
  useEffect(() => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/catalogos/lugarReferencia', {
        headers: {
          'Content-type': 'application/json',
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setLugar(response.data)
            setErrorbd(false)
          }
        },
        error => {
          if (!error.response) setErrorbd(true)
        }
      )
  }, [])

  const guardaPaciente = () => {
    axios
      .post(
        process.env.REACT_APP_SERVIDOR + '/hospitalBoca/pacientes/save',
        {
          paciente: {
            folio: datos.folio,//ESTO HAY QUE CALCULARLO
            nombre: datos.nombre,
            primer_apellido: datos.primer_apellido,
            segundo_apellido: datos.segundo_apellido,
            curp: datos.curp,
            fecha_nacimiento: datos.fecha_nacimiento,
            entidad_nacimiento: datos.entidad_nacimiento,
            edad: datos.edad, //CALCULAR
            nacido_hospital: datos.nacido_hospital,
            fk_sexo: datos.fk_sexo,
            peso: datos.peso,
            talla: datos.talla,
            fk_estado_conyugal: datos.fk_estado_conyugal,
            insabi: datos.insabi,
            gratuitidad: datos.gratuitidad,
            indigena: datos.indigena,
            lengua_indigena: datos.lengua_indigena,
            cual_lengua: datos.cual_lengua,
            fk_tipo_vialidad: datos.fk_tipo_vialidad,
            nombre_vialidad: datos.nombre_vialidad,
            num_ext: datos.num_ext,
            num_int: datos.num_int,
            fk_tipo_asentamiento: datos.fk_tipo_asentamiento,
            nombre_asentamiento: datos.nombre_asentamiento,
            cp: datos.cp,
            localidad: datos.localidad,
            municipio_deleg: datos.municipio_deleg,
            entidad_federativa: datos.entidad_federativa,
            pais: datos.pais,
            telefono: datos.telefono,
          },
          // hospital: datos.FkHospital,
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

  const handleChange = e => {
    const { name, value } = e.target
    setDatos({
      ...datos,
      [name]: value,
    })
  }

  const handleSave = () => {
    if (
      //DEFINIR LOS DATOS QUE SERAN OBLIGATORIOS PARA GUARDAR
      datos.folio === '' ||
      datos.nombre === '' ||
      datos.primer_apellido === '' ||
      datos.segundo_apellido === '' ||
      datos.fecha_nacimiento === '' ||
      datos.fk_estado_conyugal === '' ||
      datos.telefono === '' ||
      datos.nombre_vialidad === '' ||
      datos.nombre_asentamiento === ''
    ) {
      setIsFail(true)
      return
    } else guardaPaciente()
  }

  if (errorbd) return <Navigate to="/error" />

  if (finish) {
    setTimeout(() => setDelay(true), 2000)
    if (delay) return <Navigate to="/pacientes/all" />
  }

  return (
    <div className={style.fullWidth}>
      <Paper elevation={3}>
        <Grid container spacing={1} justifyContent="flex-end" alignItems="center">
          <Grid item xs margin={1}>
            <TextField
              required
              id="folio"
              label="No. de Expediente"
              variant="outlined"
              name="folio"
              error={datos.folio === '' && isFail}
              defaultValue={datos.folio}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 15 }}
            />
          </Grid>

          <Grid item xs margin={1}></Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="FkHospital">Hospital que remite</InputLabel>
              <Select
                required
                labelId="FkHospital"
                id="FkHospital"
                label="Hospital que remite"
                name="FkHospital"
                defaultValue={datos.FkHospital}
                onChange={handleChange}
                error={datos.FkHospital === '' && isFail}
              >
                {hospital.map(n => {
                  return <MenuItem value={n.idHospital}>{n.uMedica}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>
        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <Typography className={style.line} variant="h5" style={{ color: '#AC3833', fontWeight: 'bold' }}>
              Información básica
            </Typography>
          </Grid>
        </Grid>
        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <TextField
              required
              id="nombre"
              label="nombre del paciente"
              variant="outlined"
              name="nombre"
              error={datos.nombre === '' && isFail}
              defaultValue={datos.nombre}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 50 }}
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              required
              id="primer_apellido"
              label="Apellido paterno"
              variant="outlined"
              name="primer_apellido"
              error={datos.primer_apellido === '' && isFail}
              defaultValue={datos.primer_apellido}
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
              name="segundo_apellido"
              error={datos.segundo_apellido === '' && isFail}
              defaultValue={datos.segundo_apellido}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 50 }}
            />
          </Grid>
        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <TextField
              required
              id="fechaNac"
              label="Fecha de nacimiento"
              type="date"
              variant="outlined"
              name="fecha_nacimiento"
              defaultValue={datos.fecha_nacimiento}
              error={datos.fecha_nacimiento === '' && isFail}
              onChange={handleChange}
              InputLabelProps={{ shrink: true }}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="Ivs"
              label="IVS"
              type="number"
              variant="outlined"
              name="Ivs"
              defaultValue={datos.Ivs}
              onChange={handleChange}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="fk_estado_conyugal">Estado Civil</InputLabel>
              <Select
                required
                labelId="fk_estado_conyugal"
                id="fk_estado_conyugal"
                label="Estado Civil"
                name="fk_estado_conyugal"
                defaultValue={datos.fk_estado_conyugal}
                onChange={handleChange}
                error={datos.fk_estado_conyugal === '' && isFail}
              >
                {estadoCivil.map(n => {
                  return <MenuItem value={n.idEstadoCivil}>{n.nombreEstado}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>
        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="FkEscolaridad">Escolaridad</InputLabel>
              <Select
                required
                labelId="FkEscolaridad"
                id="FkEscolaridad"
                label="Escolaridad"
                name="FkEscolaridad"
                defaultValue={datos.FkEscolaridad}
                onChange={handleChange}
                error={datos.FkEscolaridad === '' && isFail}
              >
                {escolaridad.map(n => {
                  return <MenuItem value={n.idEscolaridad}>{n.nombreEscolaridad}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="FkOcupacion">Ocupación</InputLabel>
              <Select
                required
                labelId="FkOcupacion"
                id="FkOcupacion"
                label="Ocupacion"
                name="FkOcupacion"
                defaultValue={datos.FkOcupacion}
                onChange={handleChange}
                error={datos.FkOcupacion === '' && isFail}
              >
                {ocupacion.map(n => {
                  return <MenuItem value={n.idOcupacion}>{n.nombreOcupacion}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="FkReligion">Religión</InputLabel>
              <Select
                required
                labelId="FkReligion"
                id="FkReligion"
                label="Religion"
                name="FkReligion"
                defaultValue={datos.FkReligion}
                onChange={handleChange}
                error={datos.FkReligion === '' && isFail}
              >
                {religion.map(n => {
                  return <MenuItem value={n.idReligion}>{n.nombreReligion}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="FkLugarReferencia">Lugar de referencia</InputLabel>
              <Select
                required
                labelId="FkLugarReferencia"
                id="FkLugarReferencia"
                label="Lugar de Referencia"
                name="FkLugarReferencia"
                defaultValue={datos.FkLugarReferencia}
                onChange={handleChange}
                error={datos.FkLugarReferencia === '' && isFail}
              >
                {lugar.map(n => {
                  return <MenuItem value={n.idLugar}>{n.nombreLugar}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>
        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <Typography className={style.line} variant="h5" style={{ color: '#AC3833', fontWeight: 'bold' }}>
              Información familiar
            </Typography>
          </Grid>
        </Grid>
        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <TextField
              id="nombreEsposa"
              label="nombre de la esposa"
              variant="outlined"
              name="nombreEsposa"
              defaultValue={datos.nombreEsposa}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 100 }}
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="AosRelac"
              label="Años de relación"
              variant="outlined"
              name="AosRelac"
              defaultValue={datos.AosRelac}
              onChange={handleChange}
              type="number"
              fullWidth
            />
          </Grid>
        </Grid>
        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <TextField
              id="NumHijosVivos"
              label="Hijos vivos"
              variant="outlined"
              name="NumHijosVivos"
              defaultValue={datos.NumHijosVivos}
              onChange={handleChange}
              type="number"
              fullWidth
            />
          </Grid>
          <Grid item xs margin={1}>
            <TextField
              id="EdadHijoMenor"
              label="Edad del hijo menor"
              variant="outlined"
              name="EdadHijoMenor"
              defaultValue={datos.EdadHijoMenor}
              onChange={handleChange}
              type="number"
              fullWidth
            />
          </Grid>
        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <Typography className={style.line} variant="h5" style={{ color: '#AC3833', fontWeight: 'bold' }}>
              Información de contacto
            </Typography>
          </Grid>
        </Grid>
        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <Typography className={style.line} variant="h6" style={{ color: '#000000' }}>
              Domicilio particular
            </Typography>
          </Grid>
        </Grid>
        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <TextField
              id="nombre_vialidad"
              label="Calle"
              variant="outlined"
              name="nombre_vialidad"
              defaultValue={datos.nombre_vialidad}
              onChange={handleChange}
              fullWidth
              required
              error={datos.nombre_vialidad === '' && isFail}
              inputProps={{ maxLength: 50 }}
            />
          </Grid>
          <Grid item xs margin={1}>
            <TextField
              id="num_ext"
              label="Número"
              variant="outlined"
              name="num_ext"
              type="number"
              defaultValue={datos.num_ext}
              onChange={handleChange}
              fullWidth
            />
          </Grid>
          <Grid item xs margin={1}>
            <TextField
              id="nombre_asentamiento"
              label="Colonia"
              variant="outlined"
              name="nombre_asentamiento"
              defaultValue={datos.nombre_asentamiento}
              onChange={handleChange}
              fullWidth
              required
              error={datos.nombre_asentamiento === '' && isFail}
              inputProps={{ maxLength: 50 }}
            />
          </Grid>
          <Grid item xs margin={1}>
            <TextField
              id="TelCasa"
              label="Teléfono"
              variant="outlined"
              name="TelCasa"
              defaultValue={datos.TelCasa}
              onChange={handleChange}
              fullWidth
              required
              error={datos.TelCasa === '' && isFail}
              inputProps={{ maxLength: 12 }}
            />
          </Grid>
        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <Typography className={style.line} variant="h6" style={{ color: '#000000' }}>
              Domicilio de trabajo
            </Typography>
          </Grid>
        </Grid>
        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <TextField
              id="CalleTrabajo"
              label="Calle"
              variant="outlined"
              name="CalleTrabajo"
              defaultValue={datos.CalleTrabajo}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 50 }}
            />
          </Grid>
          <Grid item xs margin={1}>
            <TextField
              id="NumTrabajo"
              label="Número"
              variant="outlined"
              name="NumTrabajo"
              type="number"
              defaultValue={datos.NumTrabajo}
              onChange={handleChange}
              fullWidth
            />
          </Grid>
          <Grid item xs margin={1}>
            <TextField
              id="ColTrabajo"
              label="Colonia"
              variant="outlined"
              name="ColTrabajo"
              defaultValue={datos.ColTrabajo}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 50 }}
            />
          </Grid>
          <Grid item xs margin={1}>
            <TextField
              id="TelTrabajo"
              label="Teléfono"
              variant="outlined"
              name="TelTrabajo"
              defaultValue={datos.TelTrabajo}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 12 }}
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
          Paciente registrado con éxito, redirigiendo...
        </Alert>
      </Snackbar>
    </div>
  )
}
