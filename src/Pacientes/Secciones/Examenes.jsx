import React from 'react'
import { AccordionDetails, Button } from '@material-ui/core'
import { makeStyles } from '@material-ui/core/styles'
import GetAppRoundedIcon from '@material-ui/icons/GetAppRounded'
import axios from 'axios'

const useStyles = makeStyles(theme => ({
  center: {
    display: 'flex',
    padding: theme.spacing(5),
    justifyContent: 'space-around',
  },
}))

export default function SeccionExamenes({expediente, token}) {
  const styles = useStyles()

  const GenerarSolicitud = (event) => {
    console.log("Gen encu")
    event.preventDefault();

    axios
		.post(process.env.REACT_APP_SERVIDOR + `/hospitalBoca/pacientes/vasectomia`,
    {
      // TODO: Aplicar relación por medio de Historia Clinica.
      pacienteID: expediente,
      causaHijos: 3,
      opinionPareja: 3,
      planificacionFamiliar: 2
    },{
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
    <AccordionDetails className={styles.center}>
      <form onSubmit={GenerarSolicitud} autoComplete="off" className={styles.fullWidth}>
        <Button variant="outlined" size="large">
          Abrir Solicitud de Examenes
        </Button>
        <Button type="submit" variant="outlined" size="large" startIcon={<GetAppRoundedIcon />}>
          Descargar Solicitud de Examenes
        </Button>
      </form>
    </AccordionDetails>
  )
}
