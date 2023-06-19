import React, { useState, useEffect } from 'react'
import { Typography } from '@material-ui/core'
import axios from 'axios'
import { Navigate } from 'react-router-dom'
import { TextField, Grid } from '@mui/material'
import useStyles from '../Styles/formularioStyles'
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined'
import { useParams } from 'react-router-dom'
import Paper from '@material-ui/core/Paper'
import { Button, FormControl, InputLabel, Select, MenuItem } from '@material-ui/core'
import Alert from '@mui/material/Alert'
import Snackbar from '@mui/material/Snackbar'

export default function DetailsPaciente() {
  const { folio } = useParams()
  const [isFail, setIsFail] = useState(false)

  const [sexo, setSexo] = useState([])
  const [estadoConyugal, setEstadoConyugal] = useState([])
  const [tipoVialidad, setTipoVialidad] = useState([])
  const [tipoAsentamiento, setTipoAsentamiento] = useState([])
  const [estado, setEstado] = useState([])

  const [datos, setDatos] = useState({
    folio: '',
    nombre: '',
    primerApellido: '',
    segundoApellido: '',
    curp: '',
    fechaNacimiento: '',
    horaNacimiento: '',
    entidadNacimiento: '',
    edad: '',
    edadYears: '',
    edadMonths: '',
    edadDays: '',
    edadHours: '',
    nacidoHospital: null,
    fkSexo: 0,
    peso: '',
    talla: '',
    fkEstadoConyugal: 0,
    insabi: null,
    gratuitidad: null,
    indigena: null,
    lenguaIndigena: null,
    cualLengua: '',
    fkTipoVialidad: 0,
    nombreVialidad: 0,
    numExt: '',
    numInt: '',
    fkTipoAsentamiento: 0,
    nombreAsentamiento: '',
    cp: '',
    localidad: '',
    municipio: '',
    entidadFederativa: '',
    pais: '',
    telefono: '',
  })
  
  const [errorbd, setErrorbd] = useState(false)
  const [finish, setFinish] = useState(false)
  const style = useStyles()
  const [delay, setDelay] = useState(false)
  const [load, setLoad] = useState(true)
  const [show, setShow] = useState(false)

  const cargaPaciente = () => {
    axios
      .get( process.env.REACT_APP_SERVIDOR + `/hgbr_api/pacientes/${folio}`, {
        headers: {
          'Content-type': 'application/json',
          // 'Authorization': `Bearer ${token()}`
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            var fechaNac = response.data.fechaNac.substring(0, response.data.fechaNac.indexOf('T'))
            setDatos({
              folio: response.data.noExpediente,
              nombre: response.data.nombre,
              primerApellido: response.data.apPaterno,
              segundoApellido: response.data.apMaterno,
              curp: response.data.curp,
              fechaNacimiento: fechaNac,
              horaNacimiento: response.data.horaNac,
              entidadNacimiento: response.data.entidadNac,
              edadYears: response.data.edadYears,
              edadMonths: response.data.edadMonths,
              edadDays: response.data.edadDays,
              edadHours: response.data.edadHours,
              nacidoHospital: response.data.nacidoHospital,
              fkSexo: response.data.fkSexo,
              peso: response.data.peso,
              talla: response.data.talla,
              fkEstadoConyugal: response.data.fkEstadoCivil,
              insabi: response.data.insabi,
              gratuitidad: response.data.gratuitidad,
              indigena: response.data.indigena,
              lenguaIndigena: response.data.lenguaIndigena,
              cualLengua: response.data.cualLengua,
              fkTipoVialidad: response.data.fkTipoCalleCasa,
              nombreVialidad: response.data.nombreVialidad,
              numExt: response.data.numCasa,
              numInt: response.data.numCasaInt,
              fkTipoAsentamiento: response.data.fkTipoColCasa,
              nombreAsentamiento: response.data.colCasa,
              cp: response.data.cp,
              localidad: response.data.localidad,
              municipio: response.data.municipio,
              entidadFederativa: response.data.entidadFederativa,
              pais: response.data.pais,
              telefono: response.data.telCasa,
            })
            setShow(true)

            if( response.status === 204 ) {
              setErrorbd(true)
              setShow(false)
            }

            if(response.data.edadHours != null){
              setDatos({
                edad: "Edad: "+response.data.edadHours+" horas",
              })
              return;
            }else if(response.data.edadDays != null){
              setDatos({
                edad: "Edad: "+response.data.edadDays+" dias",
              })
              return;
            }else if(response.data.edadMonths != null){
              setDatos({
                edad: "Edad: "+response.data.edadMonths+" meses",
              })
              return;
            }else if(response.data.edadYears != null){
              setDatos({
                edad: "Edad: "+response.data.edadYears+" años",
              })
              return;
            }
          }
        },
        error => {
          if (error.response) {
            setErrorbd(true)
            setShow(false)
          }
        }
      )
  }

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
      .get(process.env.REACT_APP_SERVIDOR + '/hgbr_api/catalogos/estadoCivil', {
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

  useEffect(() => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + '/hgbr_api/catalogos/estado', {
        headers: {
          'Content-type': 'application/json',
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setEstado(response.data)
            setErrorbd(false)
          }
        },
        error => {
          if (!error.response) setErrorbd(true)
        }
      )
  }, [])

  const handleChange = event => {
    //const {name, value} = e.target;
    setDatos({
      ...datos,
      [event.target.name]: event.target.value,
    })
  }

  const actualizaPaciente = () => {

    if (datos.fechaNacimiento != '') {
      var fNac = new Date(datos.fechaNacimiento);
      var yearNac = fNac.getFullYear();
      var monthNac = fNac.getMonth();
      var dayNac = fNac.getDate();

      var fechaFormateada = fNac.toISOString();
      datos.fechaNacimiento = fechaFormateada;

      monthNac = monthNac + 1;
      var hourNac = datos.horaNacimiento;

      var currentDate = new Date(Date.now());
      var yearCurr = currentDate.getFullYear();
      var monthCurr = currentDate.getMonth()+1;
      var dayCurr = currentDate.getDate();
      var hourCurr = currentDate.getTime();
      //CALCULAR LA EDAD EN LA ACTUALIZACION
    }

    if (datos.horaNacimiento != '') {
      var partesHora = datos.horaNacimiento.split(":");
      var horas = partesHora[0];
      var minutos = partesHora[1];
      datos.horaNacimiento = horas + ":" + minutos + ":00";
    }

    axios
      .post(
        process.env.REACT_APP_SERVIDOR + '/hgbr_api/pacientes/update',
        {
          noExpediente: datos.folio,
          nombre: datos.nombre,
          apPaterno: datos.primerApellido,
          apMaterno: datos.segundoApellido,
          curp: datos.curp,
          fechaNac: datos.fechaNacimiento,
          horaNac: datos.horaNacimiento,
          entidadNac: datos.entidadNacimiento,
          edadYears: datos.edadYears, //CALCULAR
          edadMonths: datos.edadMonths,
          edadDays: datos.edadDays,
          edadHours: datos.edadHours,
          nacidoHospital: datos.nacidoHospital,
          fkSexo: datos.fkSexo,
          peso: datos.peso,
          talla: datos.talla,
          fkEstadoCivil: datos.fkEstadoConyugal,
          insabi: datos.insabi,
          gratuitidad: datos.gratuitidad,
          indigena: datos.indigena,
          lenguaIndigena: datos.lenguaIndigena,
          cualLengua: datos.cualLengua,
          fkTipoCalleCasa: datos.fkTipoVialidad,
          calleCasa: datos.nombreVialidad,
          numCasa: datos.numExt,
          numCasaInt: datos.numInt,
          fkTipoColCasa: datos.fkTipoAsentamiento,
          colCasa: datos.nombreAsentamiento,
          cp: datos.cp,
          localidad: datos.localidad,
          municipio: datos.municipio,
          entidadFederativa: datos.entidadFederativa,
          pais: datos.pais,
          telCasa: datos.telefono,
        },
        {
          headers: {
            'Content-type': 'application/json',
            // 'Authorization': `Bearer ${token()}`
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
    if (
      datos.nombre === '' ||
      datos.primerApellido === '' ||
      datos.segundoApellido === '' ||
      datos.fechaNacimiento === '' ||
      datos.fkSexo === '' ||
      datos.insabi === null ||
      datos.gratuitidad === null ||
      datos.fkTipoVialidad === '' ||
      datos.nombreVialidad === '' ||
      datos.numExt === '' ||
      datos.fkTipoAsentamiento === '' ||
      datos.nombreAsentamiento === '' ||
      datos.localidad === '' ||
      datos.municipio === '' ||
      datos.entidadFederativa === '' ||
      datos.pais === '' ||
      datos.telefono === ''
    ) {
      setIsFail(true)
      return
    } else {
      actualizaPaciente()
    }
  }

  // Si hay un error en la base de datos, entonces significa que hay que
  // iniciar sesión. Sino, entonces hay que reportar.
  if (errorbd) return <Navigate to="/error" />

  if (finish) {
    setTimeout(() => setDelay(true), 3500)
    if (delay) return <Navigate to="/pacientes" />
  }

  if (load) {
    cargaPaciente()
    setLoad(false)
  }

  console.log("EDAD: "+datos.edad);

  if (show) {
    return (
      <div className={style.fullWidth}>
        <Paper elevation={3}>
          <Grid container spacing={1} justifyContent="flex-end" alignItems="center">
            <Grid item xs margin={1}>
              <TextField
                id="NoExpediente"
                label="No. de Expediente"
                variant="outlined"
                name="NoExpediente"
                defaultValue={datos.folio}
                fullWidth
                inputProps={{ readOnly: true }}
              />
            </Grid>

            <Grid item xs margin={1}></Grid>
          </Grid>

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
              id="primerApellido"
              label="Primer Apellido"
              variant="outlined"
              name="primerApellido"
              error={datos.primerApellido === '' && isFail}
              defaultValue={datos.primerApellido}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 50 }}
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              required
              id="segundoApellido"
              label="Segundo Apellido"
              variant="outlined"
              name="segundoApellido"
              error={datos.segundoApellido === '' && isFail}
              defaultValue={datos.segundoApellido}
              onChange={handleChange}
              fullWidth
              inputProps={{ maxLength: 50 }}
            />
          </Grid>
        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <TextField
              id="curp"
              label="CURP"
              variant="outlined"
              name="curp"
              defaultValue={datos.curp}
              // error={datos.curp === '' && isFail}
              onChange={handleChange}
              InputLabelProps={{ maxLength: 18}}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              required
              id="fechaNacimiento"
              label="Fecha de Nacimiento"
              type="date"
              variant="outlined"
              name="fechaNacimiento"
              defaultValue={datos.fechaNacimiento}
              error={datos.fechaNacimiento === '' && isFail}
              onChange={handleChange}
              InputLabelProps={{ shrink: true }}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="horaNacimiento"
              label="Hora de Nacimiento (Si tiene menos de 24 hrs de nacido)"
              type="time"
              variant="outlined"
              name="horaNacimiento"
              defaultValue={datos.horaNacimiento}
              // error={datos.horaNacimiento === '' && isFail}
              onChange={handleChange}
              InputLabelProps={{ shrink: true }}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="entidadNacimiento">Entidad de Nacimiento</InputLabel>
              <Select
                labelId="entidadNacimiento"
                id="entidadNacimiento"
                label="Entidad de Nacimiento"
                name="entidadNacimiento"
                defaultValue={datos.entidadNacimiento}
                onChange={handleChange}
                // error={datos.entidadNacimiento === '' && isFail}
              >
                {estado.map(n => {
                  return <MenuItem value={n.nombre}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>
          
        </Grid>

        <Grid container spacing={1} justifyContent="center">
                {/** ESTE GRID SERA PARA LA edadYears */}
        </Grid>

        <Grid container spacing={1} justifyContent="center">
          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="nacidoHospital">¿Nació en el Hospital?</InputLabel>
              <Select
                labelId='nacidoHospital'
                id='nacidoHospital'
                label='¿Nació en el Hospital?'
                name='nacidoHospital'
                defaultValue={datos.nacidoHospital}
                onChange={handleChange}
                // error={datos.nacidoHospital === null && isFail}
              >
                <MenuItem value={true}>Sí</MenuItem>
                <MenuItem value={false}>No</MenuItem>
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="fkSexo">Sexo</InputLabel>
              <Select
                required
                labelId="fkSexo"
                id="fkSexo"
                label="Sexo"
                name="fkSexo"
                defaultValue={datos.fkSexo}
                onChange={handleChange}
                error={datos.fkSexo === '' && isFail}
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
            <TextField
              id="edad"
              label={datos.edad}
              variant="outlined"
              name="edad"
              defaultValue={datos.edad}
              fullWidth
              inputProps={{ readOnly: true }}
            />
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="fkEstadoConyugal">Estado Conyugal</InputLabel>
              <Select
                labelId="fkEstadoConyugal"
                id="fkEstadoConyugal"
                label="Estado Conyugal"
                name="fkEstadoConyugal"
                defaultValue={datos.fkEstadoConyugal}
                onChange={handleChange}
                // error={datos.fkEstadoConyugal === '' && isFail}
              >
                {estadoConyugal.map(n => {
                  return <MenuItem value={n.idEstadoCivil}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

        </Grid>

        <Grid container spacing={1} justifyContent="center">
        <Grid item xs margin={1}>
            {/** espacio para el elemento para el link de coonsulta insabi */}
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
                inputProps={{readOnly: true}}
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
                labelId='indigena'
                id='indigena'
                label='¿Se considera indígena?'
                name='indigena'
                defaultValue={datos.indigena}
                onChange={handleChange}
                // error={datos.indigena === null && isFail}
              >
                <MenuItem value={true}>Sí</MenuItem>
                <MenuItem value={false}>No</MenuItem>
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="lenguaIndigena">¿Habla alguna lengua indígena?</InputLabel>
              <Select
                labelId='lenguaIndigena'
                id='lenguaIndigena'
                label='¿Habla alguna lengua indígena?'
                name='lenguaIndigena'
                defaultValue={datos.lenguaIndigena}
                onChange={handleChange}
                // error={datos.lenguaIndigena === null && isFail}
              >
                <MenuItem value={true}>Sí</MenuItem>
                <MenuItem value={false}>No</MenuItem>
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="cualLengua"
              label="¿Cual lengua?"
              variant="outlined"
              name="cualLengua"
              defaultValue={datos.cualLengua}
              onChange={handleChange}
              fullWidth
              // error={datos.cualLengua === '' && isFail}
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
              <InputLabel id="fkTipoVialidad">Tipo de Vialidad</InputLabel>
              <Select
                required
                labelId="fkTipoVialidad"
                id="fkTipoVialidad"
                label="Tipo de Vialidad"
                name="fkTipoVialidad"
                defaultValue={datos.fkTipoVialidad}
                onChange={handleChange}
                error={datos.fkTipoVialidad === '' && isFail}
              >
                {tipoVialidad.map(n => {
                  return <MenuItem value={n.idTipoVialidad}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="nombreVialidad"
              label="Nombre de la Vialidad"
              variant="outlined"
              name="nombreVialidad"
              defaultValue={datos.nombreVialidad}
              onChange={handleChange}
              fullWidth
              required
              error={datos.nombreVialidad === '' && isFail}
              inputProps={{ maxLength: 50 }}
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              required
              id="numExt"
              label="Número Exterior"
              variant="outlined"
              name="numExt"
              type="number"
              defaultValue={datos.numExt}
              onChange={handleChange}
              error={datos.nombreVialidad === '' && isFail}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="numInt"
              label="Número Interior"
              variant="outlined"
              name="numInt"
              type="number"
              defaultValue={datos.numInt}
              onChange={handleChange}
              fullWidth
            />
          </Grid>

        </Grid>

        <Grid container spacing={1} justifyContent="center">

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="fkTipoAsentamiento">Tipo de Asentamiento Humano</InputLabel>
              <Select
                required
                labelId="fkTipoAsentamiento"
                id="fkTipoAsentamiento"
                label="Tipo de Asentameinto Humano"
                name="fkTipoAsentamiento"
                defaultValue={datos.fkTipoAsentamiento}
                onChange={handleChange}
                error={datos.fkTipoAsentamiento === '' && isFail}
              >
                {tipoAsentamiento.map(n => {
                  return <MenuItem value={n.idTipoAsentamiento}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              id="nombreAsentamiento"
              label="Nombre del Asentamiento Humano"
              variant="outlined"
              name="nombreAsentamiento"
              defaultValue={datos.nombreAsentamiento}
              onChange={handleChange}
              fullWidth
              required
              error={datos.nombreAsentamiento === '' && isFail}
              inputProps={{ maxLength: 50 }}
            />
          </Grid>
          
        </Grid>

        <Grid container spacing={1} justifyContent="center">

          <Grid item xs margin={1}>
            <TextField
              required
              id="cp"
              label="Código Postal"
              variant="outlined"
              name="cp"
              defaultValue={datos.cp}
              onChange={handleChange}
              fullWidth
              error={datos.cp === '' && isFail}
              inputProps={{ maxLength: 5 }}
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              required
              id="localidad"
              label="Localidad"
              variant="outlined"
              name="localidad"
              defaultValue={datos.localidad}
              error={datos.localidad === '' && isFail}
              onChange={handleChange}
              inputProps={{maxLength: 100}}
              fullWidth
            />
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              required
              id="municipio"
              label="Municipio/Alcaldía"
              variant="outlined"
              name="municipio"
              defaultValue={datos.municipio}
              onChange={handleChange}
              fullWidth
              error={datos.municipio === '' && isFail}
              inputProps={{ maxLength: 100 }}
            />
          </Grid>

        </Grid>

        <Grid container spacing={1} justifyContent="center">

          <Grid item xs margin={1}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="entidadFederativa">Entidad Federativa</InputLabel>
              <Select
                required
                labelId="entidadFederativa"
                id="entidadFederativa"
                label="Entidad Federativa"
                name="entidadFederativa"
                defaultValue={datos.entidadFederativa}
                onChange={handleChange}
                error={datos.entidadFederativa === '' && isFail}
              >
                {estado.map(n => {
                  return <MenuItem value={n.nombre}>{n.nombre}</MenuItem>
                })}
              </Select>
            </FormControl>
          </Grid>

          <Grid item xs margin={1}>
            <TextField
              required
              id="pais"
              label="Pais"
              variant="outlined"
              name="pais"
              defaultValue={datos.pais}
              error={datos.pais === '' && isFail}
              onChange={handleChange}
              inputProps={{maxLength: 100}}
              fullWidth
            />
          </Grid>

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
              error={datos.telefono === '' && isFail}
              inputProps={{ maxLength: 10 }}
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
            Paciente actualizado con éxito
          </Alert>
        </Snackbar>
      </div>
    )
  } else {
    return <Typography> Cargando información...</Typography>
  }
}
