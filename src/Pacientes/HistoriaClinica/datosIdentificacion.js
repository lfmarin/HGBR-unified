import React, {useState, useEffect} from 'react';
import { Typography } from '@material-ui/core';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import { TextField } from '@mui/material';
import useStyles from '../../Styles/formularioStyles';
import { Button } from '@material-ui/core';
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined';
import { Grid } from '@mui/material';
import { useParams } from 'react-router';
import Paper from '@material-ui/core/Paper';
import { FormControl } from '@material-ui/core';
import { InputLabel } from '@material-ui/core';
import { Select } from '@material-ui/core';
import { MenuItem } from '@material-ui/core';
import Alert from '@mui/material/Alert';
import Snackbar from '@mui/material/Snackbar';

export default function DatosIdentificacion(){
    const {noExpediente} = useParams();
    const [isFail, setIsFail] = useState(false);
    const [datos, setDatos] = useState({
        NoExpediente : "",
        Nombre : "",
        ApPaterno : "",
        ApMaterno : "",
        FechaNac : "",
        FkEstadoCivil : "",
        Ivs : 0,
        FkEscolaridad : "",
        FkOcupacion : "",
        FkReligion : "",
        FkLugarReferencia : "",
        NumHijosVivos : 0,
        EdadHijoMenor : 0,
        NombreEsposa : "",
        AosRelac : 0,
        CalleCasa : "",
        NumCasa : 0,
        ColCasa : "",
        TelCasa: "",
        CalleTrabajo: "",
        NumTrabajo : 0,
        ColTrabajo: "",
        TelTrabajo : "",
    });
    const [estadoCivil, setEstadoCivil] = useState([]);
    const [escolaridad, setEscolaridad] = useState([]);
    const [ocupacion, setOcupacion] = useState([]);
    const [religion, setReligion] = useState([]);
    const [lugar, setLugar] = useState([]);
    const [errorbd, setErrorbd] = useState(false);
    const [finish, setFinish] = useState(false);
    const style = useStyles();
    const [delay, setDelay] = useState(false);
    const [load, setLoad] = useState(true);
    const [show, setShow] = useState(false);

    const cargaPaciente = () => {
      axios.get(`https://localhost:5001/hospitalBoca/pacientes/${noExpediente}`,{
        headers : {
          'Content-type' : 'application/json',
        }
      }).then((response) => {
        if (response.status === 200){
          var fecha = response.data.fechaNac.substring(0, response.data.fechaNac.indexOf("T"));
          setDatos({
            NoExpediente : response.data.noExpediente,
            Nombre : response.data.nombre,
            ApPaterno : response.data.apPaterno,
            ApMaterno : response.data.apMaterno,
            FechaNac : fecha,
            FkEstadoCivil : response.data.fkEstadoCivil,
            Ivs : response.data.ivs,
            FkEscolaridad : response.data.fkEscolaridad,
            FkOcupacion : response.data.fkOcupacion,
            FkReligion : response.data.fkReligion,
            FkLugarReferencia : response.data.fkLugarReferencia,
            NumHijosVivos : response.data.numHijosVivos,
            EdadHijoMenor : response.data.edadHijoMenor,
            NombreEsposa : response.data.nombreEsposa,
            AosRelac : response.data.aosRelac,
            CalleCasa : response.data.calleCasa,
            NumCasa : response.data.numCasa,
            ColCasa : response.data.colCasa,
            TelCasa: response.data.telCasa,
            CalleTrabajo: response.data.calleTrabajo,
            NumTrabajo : response.data.numTrabajo,
            ColTrabajo: response.data.colTrabajo,
            TelTrabajo : response.data.telTrabajo,
          });
          setShow(true);
        }
      }, (error) => {
        if(!error.response){
          setErrorbd(true);
          setShow(false);
        }
      });
    };

    useEffect(() => {
      axios.get("https://localhost:5001/hospitalBoca/catalogos/estadoCivil", {
        headers : {
          'Content-type': 'application/json',
          //'Authorization': `Bearer ${token}`
        }
      }).then (
        (response) => {
          if (response.status === 200) {
            setEstadoCivil(response.data);
            setErrorbd(false);
          }
        },
        (error) => {
          if(!error.response) setErrorbd(true);
          /*else{
            if (error.response.status === 401) {
              localStorage.removeItem("ACCESS_TOKEN");
              setToken('');
              setErrorbd(false);
            }
          }*/
        }
      );
  },[])


  useEffect(() => {
      axios.get("https://localhost:5001/hospitalBoca/catalogos/escolaridad", {
        headers : {
          'Content-type': 'application/json',
        }
      }).then (
        (response) => {
          if (response.status === 200) {
            setEscolaridad(response.data);
            setErrorbd(false);
          }
        },
        (error) => {
          if(!error.response) setErrorbd(true);
        }
      );
  },[])

  useEffect(() => {
      axios.get("https://localhost:5001/hospitalBoca/catalogos/ocupacion", {
        headers : {
          'Content-type': 'application/json',
        }
      }).then (
        (response) => {
          if (response.status === 200) {
            setOcupacion(response.data);
            setErrorbd(false);
          }
        },
        (error) => {
          if(!error.response) setErrorbd(true);
        }
      );
  },[])

  useEffect(() => {
      axios.get("https://localhost:5001/hospitalBoca/catalogos/religion", {
        headers : {
          'Content-type': 'application/json',
        }
      }).then (
        (response) => {
          if (response.status === 200) {
            setReligion(response.data);
            setErrorbd(false);
          }
        },
        (error) => {
          if(!error.response) setErrorbd(true);
        }
      );
  },[])

  useEffect(() => {
      axios.get("https://localhost:5001/hospitalBoca/catalogos/lugarReferencia", {
        headers : {
          'Content-type': 'application/json',
        }
      }).then (
        (response) => {
          if (response.status === 200) {
            setLugar(response.data);
            setErrorbd(false);
          }
        },
        (error) => {
          if(!error.response) setErrorbd(true);
        }
      );
  },[])

    const handleChange = (event) => {
      //const {name, value} = e.target;
      setDatos({
      ...datos,
      [event.target.name] : event.target.value
      })
	  };

    const guardaPaciente = () => {
      axios.post ("https://localhost:5001/hospitalBoca/pacientes/update", {
        NoExpediente : datos.NoExpediente,
        Nombre : datos.Nombre,
        ApPaterno : datos.ApPaterno,
        ApMaterno : datos.ApMaterno,
        FechaNac : datos.FechaNac,
        FkEstadoCivil : datos.FkEstadoCivil,
        Ivs : datos.Ivs,
        FkEscolaridad : datos.FkEscolaridad,
        FkOcupacion : datos.FkOcupacion,
        FkReligion : datos.FkReligion,
        FkLugarReferencia : datos.FkLugarReferencia,
        NumHijosVivos : datos.NumHijosVivos,
        EdadHijoMenor : datos.EdadHijoMenor,
        NombreEsposa : datos.NombreEsposa,
        AosRelac : datos.AosRelac,
        CalleCasa : datos.CalleCasa,
        NumCasa : datos.NumCasa,
        ColCasa : datos.ColCasa,
        TelCasa: datos.TelCasa,
        CalleTrabajo: datos.CalleTrabajo,
        NumTrabajo : datos.NumTrabajo,
        ColTrabajo: datos.ColTrabajo,
        TelTrabajo : datos.TelTrabajo,
      },
      {
        headers : {
          'Content-type': 'application/json',
        }
      }).then ((response) => {
        if (response.status === 200) {
          setErrorbd(false);
          setFinish(true);
        }
      }, (error) => {
        if(!error.response) setErrorbd(true);
      })
    }

    const handleSave = () => {
      if (datos.NoExpediente==="" || datos.Nombre=== "" || datos.ApPaterno ==="" ||
      datos.ApMaterno==="" || datos.FechaNac=== "" || datos.FkEstadoCivil === "" || datos.FkEscolaridad === "" || datos.FkOcupacion === "" || datos.FkReligion === "" ||
      datos.FkLugarReferencia=== "" || datos.TelCasa=== "" || datos.CalleCasa ==="" || datos.ColCasa === "" || datos.FkHospital === ""
      ) {
          setIsFail(true)
          return;
      }
      else{
        guardaPaciente();
      }
    };


    if(errorbd) return <Redirect to='/error'/>;

    if(finish){
      setTimeout(() => setDelay(true), 3500);
      if (delay) return <Redirect to='/pacientes'/>;
    }

    if (load){
      cargaPaciente();
      setLoad(false);
    }

    if (show){
      return (
        <div className={style.fullWidth}>
        <Paper elevation={3}>
            <Grid container spacing={1} justifyContent="flex-end" alignItems="center">
              <Grid item xs margin={1}>
                <TextField
                    required
                    id="NoExpediente"
                    label="No. de Expediente"
                    variant="outlined"
                    name = "NoExpediente"
                    error={datos.NoExpediente === "" && isFail}
                    defaultValue={datos.NoExpediente}
                    onChange={handleChange}
                    fullWidth
                    inputProps={{ maxLength: 15 }}
                />
              </Grid>

              <Grid item xs margin={1}></Grid>
            </Grid>

            <Grid container spacing={1} justifyContent="center">
                <Grid item xs margin={1}>
                    <Typography className={style.line} variant="h6" style={{color: "#AC3833", fontWeight: "bold"}}>Información básica</Typography>
                </Grid>
            </Grid>
            <Grid container spacing={1} justifyContent="center">
                <Grid item xs margin={1}>
                    <TextField
                        required
                        id="nombre"
                        label="Nombre del paciente"
                        variant="outlined"
                        name = "Nombre"
                        error={datos.Nombre === "" && isFail}
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
                        name = "ApPaterno"
                        error={datos.ApPaterno === "" && isFail}
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
                        name = "ApMaterno"
                        error={datos.ApMaterno === "" && isFail}
                        defaultValue={datos.ApMaterno}
                        onChange={handleChange}
                        fullWidth
                        inputProps={{ maxLength: 50 }}
                    />
                </Grid>
            </Grid>

            <Grid container spacing={1} justifyContent="center" >
                <Grid item xs margin={1}>
                    <TextField
                        required
                        id="FechaNac"
                        label="Fecha de nacimiento" 
                        type="date"
                        variant="outlined"
                        name="FechaNac"
                        defaultValue={datos.FechaNac}
                        error={datos.FechaNac === "" && isFail}
                        onChange={handleChange}
                        InputLabelProps={{shrink: true}}
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
                    <InputLabel id="FkEstadoCivil">Estado Civil</InputLabel>
                    <Select
                        required
                        labelId="FkEstadoCivil"
                        id="FkEstadoCivil"
                        label="Estado Civil"
                        name="FkEstadoCivil"
                        defaultValue={datos.FkEstadoCivil}
                        onChange={handleChange}
                        error={datos.FkEstadoCivil === "" && isFail}
                    >
                        {estadoCivil.map(n => {return (<MenuItem value={n.idEstadoCivil}>{n.nombreEstado}</MenuItem>)})}
                    </Select>
                    </FormControl>
                </Grid>
            </Grid>

            <Grid container spacing={1} justifyContent="center" >
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
                        error={datos.FkEscolaridad === "" && isFail}
                    >
                        {escolaridad.map(n => {return (<MenuItem value={n.idEscolaridad}>{n.nombreEscolaridad}</MenuItem>)})}
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
                        error={datos.FkOcupacion === "" && isFail}
                    >
                        {ocupacion.map(n => {return (<MenuItem value={n.idOcupacion}>{n.nombreOcupacion}</MenuItem>)})}
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
                        error={datos.FkReligion === "" && isFail}
                    >
                        {religion.map(n => {return (<MenuItem value={n.idReligion}>{n.nombreReligion}</MenuItem>)})}
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
                        error={datos.FkLugarReferencia === "" && isFail}
                    >
                        {lugar.map(n => {return (<MenuItem value={n.idLugar}>{n.nombreLugar}</MenuItem>)})}
                    </Select>
                    </FormControl>
                </Grid>
            </Grid>

                
            <Grid container spacing={1} justifyContent="center">
                <Grid item xs margin={1}>
                    <Typography className={style.line} variant="h6" style={{color: "#AC3833", fontWeight: "bold"}}>Información familiar</Typography>
                </Grid>
            </Grid>
            <Grid container spacing={1} justifyContent="center">
                <Grid item xs margin={1}>
                    <TextField
                        id="nombreEsposa"
                        label="Nombre de la esposa"
                        variant="outlined"
                        name = "NombreEsposa"
                        defaultValue={datos.NombreEsposa}
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
                        name = "AosRelac"
                        defaultValue={datos.AosRelac}
                        onChange={handleChange}
                        type = "number"
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
                        name = "NumHijosVivos"
                        defaultValue={datos.NumHijosVivos}
                        onChange={handleChange}
                        type = "number"
                        fullWidth
                    />
                </Grid>
                <Grid item xs margin={1}>
                    <TextField
                        id="EdadHijoMenor"
                        label="Edad del hijo menor"
                        variant="outlined"
                        name = "EdadHijoMenor"
                        defaultValue={datos.EdadHijoMenor}
                        onChange={handleChange}
                        type = "number"
                        fullWidth
                    />
                </Grid>
            </Grid>

            <Grid container spacing={1} justifyContent="center">
                <Grid item xs margin={1}>
                    <Typography className={style.line} variant="h6" style={{color: "#AC3833", fontWeight: "bold"}}>Información de contacto</Typography>
                </Grid>
            </Grid>
            <Grid container spacing={1} justifyContent="center">
                <Grid item xs margin={1}>
                    <Typography className={style.line} variant="h6" style={{color: "#000000"}}>Domicilio particular</Typography>
                </Grid>
            </Grid>    
            <Grid container spacing={1} justifyContent="center">
                <Grid item xs margin={1}>
                    <TextField
                        id="CalleCasa"
                        label="Calle"
                        variant="outlined"
                        name = "CalleCasa"
                        defaultValue={datos.CalleCasa}
                        onChange={handleChange}
                        fullWidth
                        required
                        error={datos.CalleCasa === "" && isFail}
                        inputProps={{ maxLength: 50 }}
                    />
                </Grid>
                <Grid item xs margin={1}>
                    <TextField
                        id="NumCasa"
                        label="Número"
                        variant="outlined"
                        name = "NumCasa"
                        type="number"
                        defaultValue={datos.NumCasa}
                        onChange={handleChange}
                        fullWidth
                    />
                </Grid>
                <Grid item xs margin={1}>
                    <TextField
                        id="ColCasa"
                        label="Colonia"
                        variant="outlined"
                        name = "ColCasa"
                        defaultValue={datos.ColCasa}
                        onChange={handleChange}
                        fullWidth
                        required
                        error={datos.ColCasa === "" && isFail}
                        inputProps={{ maxLength: 50 }}
                    />
                </Grid>
                <Grid item xs margin={1}>
                    <TextField
                        id="TelCasa"
                        label="Teléfono"
                        variant="outlined"
                        name = "TelCasa"
                        defaultValue={datos.TelCasa}
                        onChange={handleChange}
                        fullWidth
                        required
                        error={datos.TelCasa === "" && isFail}
                        inputProps={{ maxLength: 12 }}
                    />
                </Grid>
            </Grid> 

            <Grid container spacing={1} justifyContent="center">
                <Grid item xs margin={1}>
                    <Typography className={style.line} variant="h6" style={{color: "#000000"}}>Domicilio de trabajo</Typography>
                </Grid>
            </Grid>    
            <Grid container spacing={1} justifyContent="center">
                <Grid item xs margin={1}>
                    <TextField
                        id="CalleTrabajo"
                        label="Calle"
                        variant="outlined"
                        name = "CalleTrabajo"
                        defaultValue={datos.CalleCasa}
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
                        name = "NumTrabajo"
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
                        name = "ColTrabajo"
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
                        name = "TelTrabajo"
                        defaultValue={datos.TelTrabajo}
                        onChange={handleChange}
                        fullWidth
                        inputProps={{ maxLength: 12 }}
                    />
                </Grid>
            </Grid> 
            
            <Grid>
              <Button variant="contained" color="secondary"
                className={style.button}
                type="submit" size="large"
                onClick={handleSave}
                startIcon={<SaveOutlinedIcon/>}>
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
    );
    }
    else{
      return(
        <Typography> Ha habido un problema cargando la información del usuario </Typography>
      );
    }
  }