import React, { useState } from 'react'
import { AccordionDetails, Button, TextField } from '@material-ui/core'
import { makeStyles } from '@material-ui/core/styles'
import axios from 'axios'
import GetAppRoundedIcon from '@material-ui/icons/GetAppRounded'
import {CircularProgress, Box } from '@material-ui/core'

const useStyles = makeStyles(theme => ({
  center: {
    display: 'flex',
    justifyContent: 'center',
    paddingTop: theme.spacing(2),
  },
  fullWidth: {
    width: '100%',
  },
  marginLeft: {
    marginLeft: theme.spacing(2),
  },
}))

export default function CartaConsentimiento({expediente, token}) {
  const classes = useStyles()
  const [isLoad, togLoad] = useState(false);

  /**
   * 
   * @param {Event} event 
   */
  const ConvertirImagen = (event) => {
    event.preventDefault();
    togLoad(true)

    const opcionesPOST = {
      pacienteID: expediente,
      fam1: document.getElementById("Testigo1").value,
      fam2: document.getElementById("Testigo2").value,
      doc: document.getElementById("Medico").value
    }

    axios
		.post(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/pacientes/consentimiento', opcionesPOST,{
      responseType: 'arraybuffer',
      headers: {
			  'Content-type': 'application/json',
			  'Authorization': `Bearer ${token()}`,
        // SOLO acepta PDFs.
        'Accept': 'application/pdf'
			},
    })
		.then(
			response => {
				if (response.status === 200) {
          const url = window.URL.createObjectURL(new Blob([response.data]));
          window.location.href = url;
				}
			}
		)
		.catch(
			err => {
        console.log(err)
			}
		)
  }

  return (
    <AccordionDetails>
      <form onSubmit={ConvertirImagen} autoComplete="off" className={classes.fullWidth}>
        <div className={classes.center}>
          <TextField
            id="Testigo1"
            variant="outlined"
            name='Testigo1'
            fullWidth
            disabled={isLoad}
            required
            label="Nombre del (la) Testigo 1"
          />
          <TextField
            id="Testigo2"
            variant="outlined"
            name='Testigo2'
            fullWidth
            disabled={isLoad}
            required
            className={classes.marginLeft}
            label="Nombre del (la) Testigo 2"
          />
        </div>
        <div className={classes.center}>
          <TextField
            id="Personal"
            variant="outlined"
            name='Personal'
            fullWidth
            disabled={isLoad}
            required
            label="Personal que proporcionó la consejería"
          />
          <TextField
            id="Medico"
            variant="outlined"
            name='Medico'
            fullWidth
            disabled={isLoad}
            required
            className={classes.marginLeft}
            label="Nombre de la Médica o el Médico tratante que otorgó el método"
          />
        </div>
        <div className={classes.center}>
          <Box sx={{ m: 1, position: 'relative'}} >
          <Button disabled={isLoad} type="submit" variant="outlined" size="large" startIcon={
              (isLoad ? <CircularProgress size={24} /> : <GetAppRoundedIcon />)
            }>
              Generar Carta
            </Button>
          </Box>
        </div>
      </form>
    </AccordionDetails>
  )
}
