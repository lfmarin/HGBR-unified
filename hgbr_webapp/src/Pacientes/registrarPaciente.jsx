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
  // const [hospital, setHospital] = useState([])

  // const [entidadNacimiento, setEntidadNacimiento] = useState([])
  const [sexo, setSexo] = useState([])
  const [estadoConyugal, setEstadoConyugal] = useState([])
  const [tipoVialidad, setTipoVialidad] = useState([])
  const [tipoAsentamiento, setTipoAsentamiento] = useState([])
  // const [entidadFederativa, setEntidadFederativa] = useState([])

  // const [lugar, setLugar] = useState([])
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
    fk_sexo: '',
    peso: 0.0,
    talla: 0.0,
    fk_estado_conyugal: '',
    insabi: null,
    gratuitidad: null,
    indigena: null,
    lengua_indigena: null,
    cual_lengua: '',
    fk_tipo_vialidad: '',
    nombre_vialidad: '',
    num_ext: 0,
    num_int: 0,
    fk_tipo_asentamiento: '',
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

  // useEffect(() => {
  //   axios
  //     .get(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/hospitales/all', {
  //       headers: {
  //         'Content-type': 'application/json',
  //       },
  //     })
  //     .then(
  //       response => {
  //         if (response.status === 200) {
  //           setHospital(response.data)
  //           setErrorbd(false)
  //         }
  //       },
  //       error => {
  //         if (!error.response) setErrorbd(true)
  //       }
  //     )
  // }, [])

  // useEffect(() => {
  //   axios
  //     .get(process.env.REACT_APP_SERVIDOR + '/hgbr_api/catalogos/entidad_nacimiento', {
  //       headers: {
  //         'Content-type': 'application/json',
  //       },
  //     })
  //     .then(
  //       response => {
  //         if (response.status === 200) {
  //           setEntidadNacimiento(response.data)
  //           setErrorbd(false)
  //         }
  //       },
  //       error => {
  //         if (!error.response) setErrorbd(true)
  //       }
  //     )
  // }, [])

  useEffect(() => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + '/hgbr_api/catalogos/sexo', {
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
      .get(process.env.REACT_APP_SERVIDOR + '/hgbr_api/catalogos/estadoConyugal', {
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
      .get(process.env.REACT_APP_SERVIDOR + '/hgbr_api/catalogos/tipoVialidad', {
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
      .get(process.env.REACT_APP_SERVIDOR + '/hgbr_api/catalogos/tipoAsentamiento', {
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

  // useEffect(() => {
  //   axios
  //     .get(process.env.REACT_APP_SERVIDOR + '/hgbr_api/catalogos/entidad_federativa', {
  //       headers: {
  //         'Content-type': 'application/json',
  //       },
  //     })
  //     .then(
  //       response => {
  //         if (response.status === 200) {
  //           setEntidadFederativa(response.data)
  //           setErrorbd(false)
  //         }
  //       },
  //       error => {
  //         if (!error.response) setErrorbd(true)
  //       }
  //     )
  // }, [])

  const guardaPaciente = () => {
    axios
      .post(
        process.env.REACT_APP_SERVIDOR + '/hgbr_api/paciente/save',
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

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <Typography className={style.line} variant="h5" style={{ color: '#000000' }}>
              Datos personales
            </Typography>
          </Grid>
        </Grid>
        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <TextField
              required
              id="nombre"
              label="Nombre"
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
              label="Primer Apellido"
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
              id="segundo_apellido"
              label="Segundo Apellido"
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
              id="curp"
              label="CURP"
              variant="outlined"
              name="curp"
              defaultValue={datos.curp}
              eeor={datos.curp === '' && isFail}
              onChange={handleChange}
              InputLabelProps={{ maxLength: 18}}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              required
              id="fecha_nacimiento"
              label="Fecha de Nacimiento"
              type="datetime"
              variant="outlined"
              name="fecha_nacimiento"
              defaultValue={datos.fecha_nacimiento}
              error={datos.fecha_nacimiento === '' && isFail}
              onChange={handleChange}
              InputLabelProps={{ shrink: true }}
              fullWidth
            />
          </Grid>

          {/* <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="entidad_nacimiento">Entidad de Nacimiento</InputLabel>
              <Select
                required
                labelId="entidad_nacimiento"
                id="entidad_nacimiento"
                label="Entidad de Nacimiento"
                name="entidad_nacimiento"
                defaultValue={datos.entidad_nacimiento}
                onChange={handleChange}
                error={datos.entidad_nacimiento === '' && isFail}
              >
                {entidadNacimiento.map(n => {
                  return <MenuItem value={n.id}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid> */}
          
        </Grid>

        <Grid container spacing={1} justifyContent="center">
                {/** ESTE GRID SERA PARA LA EDAD */}
        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="nacido_hospital">¿Nació en el Hospital?</InputLabel>
              <Select
                required
                labelId='nacido_hospital'
                id='nacido_hospital'
                label='¿Nació en el Hospital?'
                name='nacido_hospital'
                defaultValue={datos.nacido_hospital}
                onChange={handleChange}
                error={datos.nacido_hospital === null && isFail}
              >
                <MenuItem value={true}>Sí</MenuItem>
                <MenuItem value={false}>No</MenuItem>
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="fk_sexo">Sexo</InputLabel>
              <Select
                required
                labelId="fk_sexo"
                id="fk_sexo"
                label="Sexo"
                name="fk_sexo"
                defaultValue={datos.fk_sexo}
                onChange={handleChange}
                error={datos.fk_sexo === '' && isFail}
              >
                {sexo.map(n => {
                  return <MenuItem value={n.idSexo}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="peso"
              label="Peso (kg.gr)"
              type='decimal'
              variant="outlined"
              name="peso"
              defaultValue={datos.peso}
              onChange={handleChange}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="talla"
              label="Talla (cm)"
              type='number'
              variant="outlined"
              name="talla"
              defaultValue={datos.talla}
              onChange={handleChange}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="fk_estado_conyugal">Estado Conyugal</InputLabel>
              <Select
                required
                labelId="fk_estado_conyugal"
                id="fk_estado_conyugal"
                label="Estado Conyugal"
                name="fk_estado_conyugal"
                defaultValue={datos.fk_estado_conyugal}
                onChange={handleChange}
                error={datos.fk_estado_conyugal === '' && isFail}
              >
                {estadoConyugal.map(n => {
                  return <MenuItem value={n.idEstadoConyugal}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

        </Grid>

        <Grid container spacing={1} justifyContent="center">
        <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="insabi">Afiliacion INSABI</InputLabel>
              <Select
                required
                labelId='insabi'
                id='insabi'
                label='Afiliacion INSABI'
                name='insabi'
                defaultValue={datos.insabi}
                onChange={handleChange}
                error={datos.insabi === null && isFail}
              >
                <MenuItem value={true}>Sí</MenuItem>
                <MenuItem value={false}>No</MenuItem>
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="gratuitidad">Gratuitidad</InputLabel>
              <Select
                required
                labelId='gratuitidad'
                id='gratuitidad'
                label='Gratuitidad'
                name='gratuitidad'
                defaultValue={datos.gratuitidad}
                onChange={handleChange}
                error={datos.gratuitidad === null && isFail}
              >
                <MenuItem value={true}>Sí</MenuItem>
                <MenuItem value={false}>No</MenuItem>
              </Select>
            </FormControl>
          </Grid>
        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <Typography className={style.line} variant="h5" style={{ color: '#000000' }}>
              Situación indígena
            </Typography>
          </Grid>
        </Grid>

        <Grid container spacing={1} justifyContent="center">
        <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="indigena">¿Se considera indígena?</InputLabel>
              <Select
                required
                labelId='indigena'
                id='indigena'
                label='¿Se considera indígena?'
                name='indigena'
                defaultValue={datos.indigena}
                onChange={handleChange}
                error={datos.indigena === null && isFail}
              >
                <MenuItem value={true}>Sí</MenuItem>
                <MenuItem value={false}>No</MenuItem>
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="lengua_indigena">¿Habla alguna lengua indígena?</InputLabel>
              <Select
                required
                labelId='lengua_indigena'
                id='lengua_indigena'
                label='¿Habla alguna lengua indígena?'
                name='lengua_indigena'
                defaultValue={datos.lengua_indigena}
                onChange={handleChange}
                error={datos.lengua_indigena === null && isFail}
              >
                <MenuItem value={true}>Sí</MenuItem>
                <MenuItem value={false}>No</MenuItem>
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="cual_lengua"
              label="¿Cual lengua?"
              variant="outlined"
              name="cual_lengua"
              defaultValue={datos.cual_lengua}
              onChange={handleChange}
              fullWidth
              required
              error={datos.cual_lengua === '' && isFail}
              inputProps={{ maxLength: 100 }}
            />
          </Grid>

        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <Typography className={style.line} variant="h5" style={{ color: '#000000' }}>
              Domicilio y contacto
            </Typography>
          </Grid>
        </Grid>

        <Grid container spacing={1} justifyContent="center">
        <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="fk_tipo_vialidad">Tipo de Vialidad</InputLabel>
              <Select
                required
                labelId="fk_tipo_vialidad"
                id="fk_tipo_vialidad"
                label="Tipo de Vialidad"
                name="fk_tipo_vialidad"
                defaultValue={datos.fk_tipo_vialidad}
                onChange={handleChange}
                error={datos.fk_tipo_vialidad === '' && isFail}
              >
                {tipoVialidad.map(n => {
                  return <MenuItem value={n.idTipoVialidad}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="nombre_vialidad"
              label="Nombre de la Vialidad"
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
              required
              id="num_ext"
              label="Número Exterior"
              variant="outlined"
              name="num_ext"
              type="number"
              defaultValue={datos.num_ext}
              onChange={handleChange}
              error={datos.nombre_vialidad === '' && isFail}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="num_int"
              label="Número Interior"
              variant="outlined"
              name="num_int"
              type="number"
              defaultValue={datos.num_int}
              onChange={handleChange}
              fullWidth
            />
          </Grid>

        </Grid>

        <Grid container spacing={1} justifyContent="center">

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="fk_tipo_asentamiento">Tipo de Asentamiento Humano</InputLabel>
              <Select
                required
                labelId="fk_tipo_asentamiento"
                id="fk_tipo_asentamiento"
                label="Tipo de Asentameinto Humano"
                name="fk_tipo_asentamiento"
                defaultValue={datos.fk_tipo_asentamiento}
                onChange={handleChange}
                error={datos.fk_tipo_asentamiento === '' && isFail}
              >
                {tipoAsentamiento.map(n => {
                  return <MenuItem value={n.idTipoAsentamiento}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="nombre_asentamiento"
              label="Nombre del Asentamiento Humano"
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
          
        </Grid>

        <Grid container spacing={1} justifyContent="center">

          <Grid item xs margin={1}>
            <TextField
              id="cp"
              label="Código Postal"
              variant="outlined"
              name="cp"
              defaultValue={datos.cp}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 5 }}
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="localidad"
              label="Localidad"
              variant="outlined"
              name="localidad"
              defaultValue={datos.localidad}
              onChange={handleChange}
              inputProps={{maxLength: 100}}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="municipio_deleg"
              label="Municipio/Delegación"
              variant="outlined"
              name="municipio_deleg"
              defaultValue={datos.municipio_deleg}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 100 }}
            />
          </Grid>

        </Grid>

        <Grid container spacing={1} justifyContent="center">
        <Grid item xs margin={1}>
            <TextField
              id="telefono"
              label="Teléfono"
              variant="outlined"
              name="telefono"
              defaultValue={datos.telefono}
              onChange={handleChange}
              fullWidth
              required
              error={datos.TelCasa === '' && isFail}
              inputProps={{ maxLength: 10 }}
            />
          </Grid>

          {/* <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="entidad_federativa">Entidad Federativa</InputLabel>
              <Select
                required
                labelId="entidad_federativa"
                id="entidad_federativa"
                label="Entidad Federativa"
                name="entidad_federativa"
                defaultValue={datos.entidad_federativa}
                onChange={handleChange}
                error={datos.entidad_federativa === '' && isFail}
              >
                {entidadFederativa.map(n => {
                  return <MenuItem value={n.id}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid> */}

          <Grid item xs margin={1}>
            <TextField
              id="pais"
              label="Pais"
              variant="outlined"
              name="pais"
              defaultValue={datos.pais}
              onChange={handleChange}
              inputProps={{maxLength: 100}}
              fullWidth
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
          Se ha creado el expediente: {datos.folio}
        </Alert>
      </Snackbar>
    </div>
  )
}
