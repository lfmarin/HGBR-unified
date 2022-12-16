import React from 'react'
import { AccordionDetails, Button, TextField } from '@material-ui/core'
import { makeStyles } from '@material-ui/core/styles'
import GetAppRoundedIcon from '@material-ui/icons/GetAppRounded'
import axios from 'axios'
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

  /**
   * 
   * @param {Event} event 
   */
  const ConvertirImagen = (event) => {
    event.preventDefault();

    var {Testigo1, Testigo2, Personal, Medico} = document.forms[0];

    const opcionesPOST = {
      pacienteID: expediente,
      fam1: Testigo1.value,
      fam2: Testigo2.value,
      personal: Personal.value,
      doc: Medico.value
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
            id="outlined-basic"
            variant="outlined"
            name='Testigo1'
            fullWidth
            required
            label="Nombre del (la) Testigo 1"
          />
          <TextField
            id="outlined-basic"
            variant="outlined"
            name='Testigo2'
            fullWidth
            required
            className={classes.marginLeft}
            label="Nombre del (la) Testigo 2"
          />
        </div>
        <div className={classes.center}>
          <TextField
            id="outlined-basic"
            variant="outlined"
            name='Personal'
            fullWidth
            required
            label="Personal que proporcionó la consejería"
          />
          <TextField
            id="outlined-basic"
            variant="outlined"
            name='Medico'
            fullWidth
            required
            className={classes.marginLeft}
            label="Nombre de la Médica o el Médico tratante que otorgó el método"
          />
        </div>
        <div className={classes.center}>
          <Box sx={{ m: 1, position: 'relative'}} >
            <Button variant="outlined" size="large" startIcon={<GetAppRoundedIcon />} type="submit">
              Generar Carta
            </Button>
            <CircularProgress
              size={24}
              sx={{
                position: 'absolute',
                top: '50%',
                left: '50%',
                marginTop: '-12px',
                marginLeft: '-12px',
              }}
            />
          </Box>
        </div>
      </form>
    </AccordionDetails>
  )
}
