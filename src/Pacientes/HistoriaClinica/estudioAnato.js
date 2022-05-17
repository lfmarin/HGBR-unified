import React from 'react';
import useStyles from '../../Styles/formularioStyles';
import { 
  Button, 
  TextField, 
  Typography,
} from '@material-ui/core';
import SaveOutlinedIcon from '@material-ui/icons/SaveOutlined';
import clsx from 'clsx';
import GetHistoriaClinica from './getHistoriaClin';


export default function EstudioAnato() {
  const style = useStyles();

  return (
    <div className={style.fullWidth}>
      <form className={style.fullWidth}>        
        <Typography className={style.line} variant="h6">
          Estudio
        </Typography>
        <div className={style.justify}>
          <TextField label="Fecha de envío" type="date" InputLabelProps={{shrink: true}} 
            name="fechaEnvio" className={clsx(style.input, style.input30) } variant="outlined" required/>

          <TextField label="Clave"
            name="clave" className={clsx(style.input, style.input60) } variant="outlined" required/>
            
          <TextField label="Resultado"
            name="resultado" fullWidth className={clsx(style.input, style.input100) } variant="outlined"/>
        
        </div>
        
        <div className={style.contenedorButton}>
          <Button variant="contained" color="secondary"
            type="submit" size="large"
            startIcon={<SaveOutlinedIcon/>}>
            GUARDAR
          </Button>
        </div>
      </form>
    </div>
  );
}
