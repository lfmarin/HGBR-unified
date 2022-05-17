import React, { useState, useEffect } from 'react';
import { 
  TextField
} from '@material-ui/core';
import clsx from 'clsx';
import axios from 'axios';
import useStyles from '../../Styles/formularioStyles';
import { Typography } from '@material-ui/core';
import { useParams } from 'react-router';

export default function GetHistoriaClinica(props){
    const style = useStyles();
    const {noExpediente} = useParams();
    const [datos, setDatos] = useState({
        idHistoriaClinica: '',
        fkPaciente: '',
        fkHospital: '',
        fechaElab: '',
    });
    const [errorbd, setErrorbd] = useState(false);
    const [load, setLoad] = useState(true);
    const [show, setShow] = useState(false);

    const cargaHC = () => {
      axios.get(`https://localhost:5001/hospitalBoca/historiaClinica/${noExpediente}`, {
        headers : {
          'Content-type' : 'application/json',
        }
      }).then((response) => {
        if (response.status === 200){
          var fecha = response.data.fechaElab.substring(0, response.data.fechaElab.indexOf("T"));
          setDatos({
            idHistoriaClinica: response.data.idHistoriaClinica,
            fkPaciente: response.data.fkPaciente,
            fkHospital: response.data.fkHospital,
            fechaElab: fecha,
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

    if (load){
      cargaHC();
      setLoad(false);
    }


  if(show){
    props.setIdHistoria(datos.idHistoriaClinica)
    return(
      <div className={style.justify}>
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
              name="fechaElab"
              label="Fecha de elaboración de la Historia Clínica"
              variant="outlined"
              required type="date"
              defaultValue={datos.fechaElab}
              inputProps={{ readOnly: true }}
          />
      </div>
    );
  }
  else{
    return(
      <Typography> Ha habido un problema cargando la información del usuario </Typography>
    );
  }
}