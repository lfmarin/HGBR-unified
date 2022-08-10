import React, { useState, useEffect } from 'react';
import useStyles from '../../Styles/formularioStyles';
import { 
  Button, 
  TextField, 
  Typography,
} from '@material-ui/core';
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined';
import clsx from 'clsx';
import axios from 'axios';
import { useParams } from 'react-router';
import { Redirect } from 'react-router-dom';
import { FormControl } from '@material-ui/core';
import { InputLabel } from '@material-ui/core';
import { Select } from '@material-ui/core';
import { MenuItem } from '@material-ui/core';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import FormGroup from '@mui/material/FormGroup';

export default function Encuesta() {
  const style = useStyles();
  const [datos, setDatos] = useState({
    fkPaciente: '',
    fkHospital: '',
    fechaEncuesta: '',
    fechaVasectomia: '',
    origenInfo: '',
    fkConsejeria: '',
    referido: '',
    fkHospitalReferencia: '',
    fkCalidad: '',
    satisfaccion: '',
    motivoSatisfaccion: '',
    complicacion: '',
    motivoComplicacion: '',
    fkCalidadRelacion: '',
    motivoCalidad: '',
    fechaNegativo: '',
    LugarEspermaconteo: '',
    recomendacion: '',
    motivoRecomendacion:'',
    LugarVasectomia: '',
    motivoLugar: '',
    recomendacionHospital: '',
    cualRecomendacion: ''
  })
  const [hospital, setHospital] = useState([]);
  const [personal, setPersonal] = useState([]);
  const [hospitalRef, setHospitalRef] = useState([]);
  const [calidad, setCalidad] = useState([]);
  const [calidadRel, setCalidadRel] = useState([]);
  const {noExpediente} = useParams();
  const [isFail, setIsFail] = useState(false)
  const [errorbd, setErrorbd] = useState(false);
  const [finish, setFinish] = useState(false);
  const [load, setLoad] = useState(true);
  const [show, setShow] = useState(false);

  const handleChange = (event) => {
    setDatos({
    ...datos,
    [event.target.name] : event.target.value
    })
  };

  const carga = () => {
    axios.get(`https://localhost:5001/hospitalBoca/EncuestaSeguimiento/${noExpediente}`, {
      headers : {
        'Content-type' : 'application/json',
      }
    }).then((response) => {
      if (response.status === 200){
        if (response.data.fechaEncuesta != null ) {var fechaEncuesta = response.data.fechaEncuesta.substring(0, response.data.fechaEncuesta.indexOf("T"));}
        else { var fechaEncuesta = response.data.fechaEncuesta;}

        if (response.data.fechaVasectomia != null ) {var fechaVasectomia = response.data.fechaVasectomia.substring(0, response.data.fechaVasectomia.indexOf("T"));}
        else { var fechaVasectomia = response.data.fechaVasectomia}

        if (response.data.fechaNegativo != null ) {var fechaNegativo = response.data.fechaNegativo.substring(0, response.data.fechaNegativo.indexOf("T"));}
        else { var fechaNegativo = response.data.fechaNegativo}

        setDatos({
            fkPaciente: response.data.fkPaciente,
            fkHospital: response.data.fkHospital,
            fechaEncuesta: fechaEncuesta,
            fechaVasectomia: fechaVasectomia,
            origenInfo: response.data.origenInfo,
            fkConsejeria: response.data.fkConsejeria,
            referido: response.data.referido,
            fkHospitalReferencia: response.data.fkHospitalReferencia,
            fkCalidad: response.data.fkCalidad,
            satisfaccion: response.data.satisfaccion,
            motivoSatisfaccion: response.data.motivoSatisfaccion,
            complicacion: response.data.complicacion,
            motivoComplicacion: response.data.motivoComplicacion,
            fkCalidadRelacion: response.data.fkCalidadRelacion,
            motivoCalidad: response.data.motivoCalidad,
            fechaNegativo: fechaNegativo,
            LugarEspermaconteo: response.data.LugarEspermaconteo,
            recomendacion: response.data.recomendacion,
            motivoRecomendacion: response.data.motivoRecomendacion,
            LugarVasectomia: response.data.LugarVasectomia,
            motivoLugar: response.data.motivoLugar,
            recomendacionHospital: response.data.recomendacionHospital,
            cualRecomendacion: response.data.cualRecomendacion
        })
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
    axios.get("https://localhost:5001/hospitalBoca/hospitales/all", {
      headers : {
        'Content-type': 'application/json',
      }
    }).then (
      (response) => {
        if (response.status === 200) {
          setHospital(response.data);
          setHospitalRef(response.data);
          setErrorbd(false);
        }
      },
      (error) => {
        if(!error.response) setErrorbd(true);
      }
    );
  },[])

  useEffect(() => {
    axios.get("https://localhost:5001/hospitalBoca/personalConsejeria/all", {
      headers : {
        'Content-type': 'application/json',
      }
    }).then (
      (response) => {
        if (response.status === 200) {
          setPersonal(response.data);
          setErrorbd(false);
        }
      },
      (error) => {
        if(!error.response) setErrorbd(true);
      }
    );
  },[])

  useEffect(() => {
    axios.get("https://localhost:5001/hospitalBoca/catalogos/calidadRelacion", {
      headers : {
        'Content-type': 'application/json',
      }
    }).then (
      (response) => {
        if (response.status === 200) {
          setCalidadRel(response.data);
          setErrorbd(false);
        }
      },
      (error) => {
        if(!error.response) setErrorbd(true);
      }
    );
    },[])

    useEffect(() => {
        axios.get("https://localhost:5001/hospitalBoca/catalogos/calidadServicio", {
        headers : {
            'Content-type': 'application/json',
        }
        }).then (
        (response) => {
            if (response.status === 200) {
            setCalidad(response.data);
            setErrorbd(false);
            }
        },
        (error) => {
            if(!error.response) setErrorbd(true);
        }
        );
    },[])

  /*const guardaEstudio = () => {
    axios.post ("https://localhost:5001/hospitalBoca/historiaClinica/estudioAnatomo/update", {
      FkHistoria: datos.fkHistoria,
      FechaEnvio: datos.fechaEnvio,
      Clave: datos.clave,
      Resultado: datos.resultado,
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
  }*/

  /*const handleSave = () => {
    if (datos.fechaEnvio === null || datos.clave === null){
      setIsFail(true)
      return;
    }
    else{
      guardaEstudio();
    }
  };*/

  if(errorbd) return <Redirect to='/error'/>;

  if (load){
    carga();
    setLoad(false);
  }

  if(show){
    return (
      <div className={style.fullWidth}>
        <form className={style.fullWidth}>        
          <Typography className={style.line} variant="h6">
            Encuesta de seguimiento
          </Typography>
          <div className={style.justify}>
            {/* 
            <Typography>Blablabla</Typography>
            <Typography>fkPaciente {datos.fkPaciente}</Typography>
            <Typography>fechaEncuesta{datos.fechaEncuesta}</Typography>

            <Typography>fkHospital {datos.fkHospital}</Typography>
            <Typography>fechaVasectomia{datos.fechaVasectomia}</Typography>

            <Typography>origenInfo{datos.origenInfo}</Typography>
            <Typography>fkConsejeria{datos.fkConsejeria}</Typography>
            <Typography>referido{datos.referido}</Typography>
            <Typography>fkHospitalReferencia{datos.fkHospitalReferencia}</Typography>
            <Typography>fkCalidad{datos.fkCalidad}</Typography>
            <Typography>satisfaccion{datos.satisfaccion}</Typography>
            <Typography>motivoSatisfaccion{datos.motivoSatisfaccion}</Typography>
            <Typography>complicacion{datos.complicacion}</Typography>
            <Typography>motivoComplicacion{datos.motivoComplicacion}</Typography>
            <Typography>fkCalidadRelacion{datos.fkCalidadRelacion}</Typography>
            <Typography>motivoCalidad{datos.motivoCalidad}</Typography>
            <Typography>fechaNegativo{datos.fechaNegativo}</Typography>
            <Typography>LugarEspermaconteo{datos.LugarEspermaconteo}</Typography>
            <Typography>recomendacion{datos.recomendacion}</Typography>
            <Typography>motivoRecomendacion{datos.motivoRecomendacion}</Typography>
            <Typography>LugarVasectomia{datos.LugarVasectomia}</Typography>
            <Typography>motivoLugar{datos.motivoLugar}</Typography>
            <Typography>recomendacionHospital{datos.recomendacionHospital}</Typography>
            <Typography>cualRecomendacion{datos.cualRecomendacion}</Typography> */}

            <div className={clsx(style.fullWidth)}>
                <TextField
                    className={clsx(style.input, style.input30)}
                    label="No. de Expediente"
                    variant="outlined"
                    name = "NoExpediente"
                    defaultValue={datos.fkPaciente}
                    fullWidth
                    inputProps={{ readOnly: true }}
                />
                <TextField
                    className={clsx(style.input, style.input30)}
                    label="Fecha de la encuesta"
                    variant="outlined"
                    name = "fechaEncuesta"
                    defaultValue={datos.fechaEncuesta}
                    fullWidth
                    inputProps={{ readOnly: true }}
                />
                
            </div>

            <div className={clsx(style.fullWidth)}>
                <FormControl variant="outlined" fullWidth className={clsx(style.input, style.input30)}>
                    <InputLabel id="fkHospital">Hospital donde se realizó la vasectomía</InputLabel>
                    <Select
                        required
                        labelId="fkHospital"
                        id="fkHospital"
                        label="Hospital donde se realizó la vasectomía"
                        name="fkHospital"
                        variant="outlined"
                        onChange={handleChange}
                        defaultValue={datos.fkHospital}
                    >
                        {hospital.map(n => {return (<MenuItem value={n.idHospital}>{n.uMedica}</MenuItem>)})}
                    </Select>
                </FormControl>

                <TextField
                    className={clsx(style.input, style.input30)}
                    label="Fecha de la vasectomía"
                    variant="outlined"
                    name = "fechaVasectomia"
                    defaultValue={datos.fechaVasectomia}
                    fullWidth
                    required
                    error={datos.fechaVasectomia === '' && isFail}
                    onChange={handleChange}
                    type="date"
                    InputLabelProps={{shrink: true}}
                />
            </div>

            <form className={style.fullWidth}>
              <div className={style.justify}>
                <TextField
                    className={clsx(style.input, style.input100) }
                    label="¿Cómo se informó de la Vasectomía sin bisturí? "
                    variant="outlined"
                    name = "origenInfo"
                    defaultValue={datos.origenInfo}
                    onChange={handleChange}
                    fullWidth
                />

                <FormControl variant="outlined" fullWidth className={clsx(style.input)}>
                    <InputLabel id="fkConsejeria">¿Quién le dio la orientación-conserjería en Vasectomía sin Bisturí?</InputLabel>
                    <Select
                        required
                        labelId="fkConsejeria"
                        id="fkConsejeria"
                        label="¿Quién le dio la orientación-conserjería en Vasectomía sin Bisturí?"
                        name="fkConsejeria"
                        variant="outlined"
                        onChange={handleChange}
                        defaultValue={datos.fkConsejeria}
                    >
                        {personal.map(n => {return (<MenuItem value={n.idPersonal}>{n.nombre} {n.apPaterno} {n.apMaterno}</MenuItem>)})}
                    </Select>
                </FormControl>
                
                <div className={clsx(style.justify)}>
                <FormGroup>
                    <FormControlLabel
                        label="Selecciona si el paciente fue referido de un centro de salud"
                        labelPlacement="start"
                        control={
                          <Checkbox
                            defaultChecked={datos.referido}
                            onChange={() => setDatos({...datos, referido: !datos.referido})}
                          />
                        }
                    />
                </FormGroup>

                <FormControl variant="outlined" disabled={!datos.referido} fullWidth className={clsx(style.input)}>
                    <InputLabel id="fkHospitalReferencia">¿Cuál centro de salud?</InputLabel>
                    <Select
                        required
                        labelId="fkHospitalReferencia"
                        id="fkHospitalReferencia"
                        label="¿Cuál centro de salud?"
                        name="fkHospitalReferencia"
                        variant="outlined"
                        onChange={handleChange}
                        defaultValue={datos.fkHospitalReferencia}
                    >
                        {hospital.map(n => {return (<MenuItem value={n.idHospital}>{n.uMedica}</MenuItem>)})}
                    </Select>
                </FormControl>
                </div>

                <FormControl variant="outlined" fullWidth className={clsx(style.input)}>
                    <InputLabel id="fkCalidad">¿Cómo fue el trato del personal desde su llegada hasta que salió del servicio en donde le realizaron la vasectomía?</InputLabel>
                    <Select
                        required
                        labelId="fkCalidad"
                        id="fkCalidad"
                        label="¿Cómo fue el trato del personal desde su llegada hasta que salió del servicio en donde le realizaron la vasectomía?"
                        name="fkCalidad"
                        variant="outlined"
                        onChange={handleChange}
                        defaultValue={datos.fkCalidad}
                    >
                        {calidad.map(n => {return (<MenuItem value={n.idCalidad}>{n.nombreCalidad}</MenuItem>)})}
                    </Select>
                </FormControl>

                <div className={clsx(style.justify)}>
                <FormGroup>
                    <FormControlLabel
                        label="Selecciona si el paciente quedó satisfecho con la atención brindada durante la cirugía"
                        labelPlacement="start"
                        control={
                          <Checkbox
                            defaultChecked={datos.satisfaccion}
                            onChange={() => setDatos({...datos, satisfaccion: !datos.satisfaccion})}
                            />
                          }
                    />
                </FormGroup>
                </div>

                <TextField
                    className={clsx(style.input, style.input100) }
                    label="¿Por qué? "
                    variant="outlined"
                    name = "motivoSatisfaccion"
                    defaultValue={datos.motivoSatisfaccion}
                    onChange={handleChange}
                    fullWidth
                />

                <div className={clsx(style.justify)}>
                    <FormGroup>
                        <FormControlLabel
                            label="Selecciona si el paciente tuvo alguna complicación después de la cirugía"
                            labelPlacement="start"
                            control={
                              <Checkbox
                                defaultChecked={datos.complicacion}
                                onChange={() => setDatos({...datos, complicacion: !datos.complicacion})}/>
                              }
                        />
                    </FormGroup>
                </div>

                <TextField
                    className={clsx(style.input, style.input100) }
                    label="¿Cuál? "
                    variant="outlined"
                    name = "motivoComplicación"
                    defaultValue={datos.motivoComplicacion}
                    onChange={handleChange}
                    disabled={!datos.complicacion}
                    fullWidth
                />

                <FormControl variant="outlined" fullWidth className={clsx(style.input)}>
                    <InputLabel id="fkCalidadRelacion">Después de los 3 meses de la cirugía su relación sexual es:</InputLabel>
                    <Select
                        required
                        labelId="fkCalidadRelacion"
                        id="fkCalidadRelacion"
                        label="Después de los 3 meses de la cirugía su relación sexual es:"
                        name="fkCalidadRelacion"
                        variant="outlined"
                        onChange={handleChange}
                        defaultValue={datos.fkCalidadRelacion}
                    >
                        {calidadRel.map(n => {return (<MenuItem value={n.idCalidadRelacion}>{n.nombreCalidadRelacion}</MenuItem>)})}
                    </Select>
                </FormControl>

                <TextField
                    className={clsx(style.input, style.input100) }
                    label="Si es peor, ¿por qué?"
                    variant="outlined"
                    name = "motivoCalidad"
                    defaultValue={datos.motivoCalidad}
                    onChange={handleChange}
                    fullWidth
                    disabled={datos.fkCalidadRelacion != 3}
                />

                <div className={clsx(style.fullWidth)}>
                    <TextField
                        className={clsx(style.input, style.input30)}
                        label="Fecha de negatividad de espermaconteo"
                        variant="outlined"
                        name = "fechaNegativo"
                        defaultValue={datos.fechaNegativo}
                        fullWidth
                        onChange={handleChange}
                        type="date"
                        InputLabelProps={{shrink: true}}
                    />  

                    <TextField
                        className={clsx(style.input, style.input30)}
                        label="¿Dónde se realizó el espermaconteo?"
                        variant="outlined"
                        name = "LugarEspermaconteo"
                        defaultValue={datos.LugarEspermaconteo}
                        fullWidth
                        onChange={handleChange}
                    />  
                </div>

                <div className={clsx(style.justify)}>
                    <FormGroup>
                        <FormControlLabel
                            label="Seleccione si recomendaría la realización de la Vasectomía Sin Bisturí"
                            labelPlacement="start"
                            control={
                            <Checkbox
                              defaultChecked={datos.recomendacion}
                              onChange={() => setDatos({...datos, recomendacion: !datos.recomendacion})}/>
                            }
                        />
                    </FormGroup>
                </div>

                <TextField
                    className={clsx(style.input, style.input100) }
                    label="¿Por qué? "
                    variant="outlined"
                    name = "motivoRecomendación"
                    defaultValue={datos.motivoRecomendacion}
                    onChange={handleChange}
                    fullWidth
                />

                <div className={clsx(style.justify)}>
                    <FormGroup>
                        <FormControlLabel
                            label="Seleccione si un hospital le parece mejor para realizarse la VSB. Deje en blanco si prefiere el Centro de Salud."
                            labelPlacement="start"
                            control={
                            <Checkbox
                              defaultChecked={datos.LugarVasectomia}
                              onChange={() => setDatos({...datos, LugarVasectomia: !datos.LugarVasectomia})}/>
                            }
                        />
                    </FormGroup>
                </div>

                <TextField
                    className={clsx(style.input, style.input100) }
                    label="¿Por qué? "
                    variant="outlined"
                    name = "motivoLugar"
                    defaultValue={datos.motivoLugar}
                    onChange={handleChange}
                    fullWidth
                />

                <div className={clsx(style.justify)}>
                    <FormGroup>
                        <FormControlLabel
                            label="Seleccione si tiene alguna recomendación para mejorar los servicios de salud"
                            labelPlacement="start"
                            control={
                            <Checkbox
                              defaultChecked={datos.recomendacionHospital}
                              onChange={() => setDatos({...datos, recomendacionHospital: !datos.recomendacionHospital})}/>}
                        />
                    </FormGroup>
                </div>

                <TextField
                    className={clsx(style.input, style.input100) }
                    label="¿Cuál? "
                    variant="outlined"
                    name = "cualRecomendacion"
                    defaultValue={datos.cualRecomendacion}
                    onChange={handleChange}
                    disabled={!datos.recomendacionHospital}
                    fullWidth
                />

              </div>
            </form>
          </div>
          
          <div className={style.contenedorButton}>
            <Button variant="contained" color="secondary"
              type="submit" size="large"
              startIcon={<SaveOutlinedIcon/>}
              >
              GUARDAR
            </Button>
          </div>
        </form>
    </div>
    );
  }
  else{
    return(
      <Typography> Ha habido un problema cargando la información del usuario </Typography>
    );
  }
}
