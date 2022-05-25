import React, { useState } from 'react';
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

export default function MotivoSolicitud() {
  const style = useStyles();
  const [datos, setDatos] = useState({
    FkHistoria: '',
    antFamiliares: '',
    antPersonalesNoPat: '',
    antPersonalesPat: '',
    ta: null,
    peso: null,
    talla: null,
    fc: null,
    fr: null,
    tem: null,
    expOrganos: '',
    tipoPaciente: '',
  })
  const [datosHC, setDatosHC] = useState({
    fkPaciente: '',
    fkHospital: '',
    fechaElab: '',
  })
  const {noExpediente} = useParams();
  const [isFail, setIsFail] = useState(false)
  const [errorbd, setErrorbd] = useState(false);
  const [finish, setFinish] = useState(false);
  const [delay, setDelay] = useState(false);
  const [load, setLoad] = useState(true);
  const [loadExploracion, setLoadExploracion] = useState(false);
  const [show, setShow] = useState(false);

  const handleChange = (event) => {
    setDatos({
    ...datos,
    [event.target.name] : event.target.value
    })
  };

  
  const cargaHC = () => {
    axios.get(`https://localhost:5001/hospitalBoca/historiaClinica/${noExpediente}`, {
      headers : {
        'Content-type' : 'application/json',
      }
    }).then((response) => {
      if (response.status === 200){
        var fecha = response.data.fechaElab.substring(0, response.data.fechaElab.indexOf("T"));
        setDatosHC({
          fkPaciente: response.data.fkPaciente,
          fkHospital: response.data.fkHospital,
          fechaElab: fecha,
        });
        setDatos({
          ...datos,
          FkHistoria: response.data.idHistoriaClinica
        })
        setLoadExploracion(true);
      }
    }, (error) => {
      if(!error.response){
        setErrorbd(true);
        setLoadExploracion(false);
      }
    });
    setLoadExploracion(true);
  };

  const cargaExploracion = () => {
    axios.get(`https://localhost:5001/hospitalBoca/historiaClinica/historiaExploracion/${datos.FkHistoria}`,{
      headers : {
        'Content-type' : 'application/json',
      }
    }).then((response) => {
      if (response.status === 200){
        setDatos({
          FkHistoria: response.data.fkHistoria,
          antFamiliares: response.data.antFamiliares,
          antPersonalesNoPat: response.data.antPersonalesNoPat,
          antPersonalesPat: response.data.antPersonalesPat,
          ta: response.data.ta,
          peso: response.data.peso,
          talla: response.data.talla,
          fc: response.data.fc,
          fr: response.data.fr,
          tem: response.data.tem,
          expOrganos: response.data.expOrganos,
          tipoPaciente: response.data.tipoPaciente
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

  const guardaExploracion = () => {
    axios.post ("https://localhost:5001/hospitalBoca/historiaClinica/historiaExploracion/update", {
      FkHistoria: datos.FkHistoria,
      AntFamiliares: datos.antFamiliares,
      AntPersonalesNoPat: datos.antPersonalesNoPat,
      AntPersonalesPat: datos.antPersonalesPat,
      Ta: datos.ta,
      Peso: datos.peso,
      Talla: datos.talla,
      Fc: datos.fc,
      Fr: datos.fr,
      Tem: datos.tem,
      ExpOrganos: datos.expOrganos,
      TipoPaciente: datos.tipoPaciente,
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
    if (datos.antFamiliares === null || datos.antPersonalesNoPat === null || datos.antPersonalesPat === null || datos.expOrganos === null || datos.tipoPaciente === null){
      setIsFail(true)
      return;
    }
    else{
      guardaExploracion();
    }
  };

  if(errorbd) return <Redirect to='/error'/>;

  if (load){
    cargaHC();
    setLoad(false);
  }

  if (loadExploracion){
    cargaExploracion();
    setLoadExploracion(false);
    //setShow(true);
  }

  if(show){
    return (
      <div className={style.fullWidth}>
        <TextField
            className={clsx(style.input, style.input30)}
            label="No. de Expediente"
            variant="outlined"
            name = "NoExpediente"
            defaultValue={datosHC.fkPaciente}
            fullWidth
            inputProps={{ readOnly: true }}
        />
        <TextField
            className={clsx(style.input, style.input30)}
            name="fechaElab"
            variant="outlined"
            required type="date"
            defaultValue={datosHC.fechaElab}
            inputProps={{ readOnly: true }}
        />

        <form className={style.fullWidth}>        
          <Typography className={style.line} variant="h6" style={{color: "#AC3833", fontWeight: "bold"}}>
            Antecedentes
          </Typography>
          <div className={style.justify}>
            <TextField
              label="Antecedentes heredo-familiares"
              name="antFamiliares"
              className={clsx(style.input, style.input30) }
              variant="outlined"
              error={datos.antFamiliares === null && isFail}
              defaultValue={datos.antFamiliares}
              onChange={handleChange}
              required
            />

            <TextField
              label="Antecedentes personales no patológicos (higiene, alimentación, deportes)"
              name="antPersonalesNoPat"
              fullWidth
              className={clsx(style.input, style.input100) }
              variant="outlined"
              required
              error={datos.antPersonalesNoPat === null && isFail}
              defaultValue={datos.antPersonalesNoPat}
              onChange={handleChange}
            />
              
            <TextField
              label="Antecedentes personales patológicos"
              helperText="(Antecedentes alérgicos, traumatismo en área genital, infecciones urinarias, parotiditis. ITS, SIDA)."
              name="antPersonalesPat"
              fullWidth
              className={clsx(style.input, style.input100) }
              variant="outlined"
              required
              error={datos.antPersonalesPat === null && isFail}
              defaultValue={datos.antPersonalesPat}
              onChange={handleChange}
            />
          </div>
  
          <Typography className={style.line} variant="h6" style={{color: "#AC3833", fontWeight: "bold"}}>
            Exploración
          </Typography>
          <div className={style.justify}>
            
            <div className={clsx(style.fullWidth, style.justify)}>
              <TextField
                label="TA" 
                name="ta"
                className={clsx(style.input, style.input15) }
                variant="outlined"
                defaultValue={datos.ta}
                onChange={handleChange}
              />

              <TextField
                label="PESO" 
                name="peso"
                className={clsx(style.input, style.input15) }
                variant="outlined"
                defaultValue={datos.peso}
                onChange={handleChange}
              />

              <TextField
                label="TALLA" 
                name="talla"
                className={clsx(style.input, style.input15) }
                variant="outlined"
                defaultValue={datos.talla}
                onChange={handleChange}
              />

              <TextField
                label="FC" 
                name="fc"
                className={clsx(style.input, style.input15) }
                variant="outlined"
                defaultValue={datos.fc}
                onChange={handleChange}
              />

              <TextField
                label="FR" 
                name="fr"
                className={clsx(style.input, style.input15) }
                variant="outlined"
                defaultValue={datos.fr}
                onChange={handleChange}
              />

              <TextField
                label="TEM" 
                name="tem"
                className={clsx(style.input, style.input15) }
                variant="outlined"                
                defaultValue={datos.tem}
                onChange={handleChange}
              />
            </div>
            
            <TextField
              label="Exploración de órganos genitales "
              name="expOrganos"
              className={clsx(style.input, style.input60) }
              variant="outlined"
              required
              error={datos.expOrganos === null && isFail}
              defaultValue={datos.expOrganos}
              onChange={handleChange}
            />
            
            <TextField
              label="Tipo de paciente"
              name="tipoPaciente"
              className={clsx(style.input, style.input100) }
              variant="outlined"
              required
              error={datos.tipoPaciente === null && isFail}
              defaultValue={datos.tipoPaciente}
              onChange={handleChange}
            />
          </div>
          
          <div className={style.contenedorButton}>
            <Button
              variant="contained"
              color="secondary"
              type="submit"
              size="large"
              startIcon={<SaveOutlinedIcon/>}
              onClick={handleSave}
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
