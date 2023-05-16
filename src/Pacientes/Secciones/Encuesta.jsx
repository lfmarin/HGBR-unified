import React, {useState} from 'react'
import { AccordionDetails, Button, CircularProgress } from '@material-ui/core'
import { makeStyles } from '@material-ui/core/styles'
import GetAppRoundedIcon from '@material-ui/icons/GetAppRounded'
import { Link } from 'react-router-dom'
import { useParams } from 'react-router-dom'
import axios from 'axios'


const useStyles = makeStyles(theme => ({
  center: {
    display: 'flex',
    padding: theme.spacing(5),
    justifyContent: 'space-around',
  },
}))

export default function SeccionEncuesta({expediente, token}) {
  const styles = useStyles()
  const { noExpediente } = useParams()
  const [isLoad, togLoad] = useState(false);

  const GenerarEncuesta = (event) => {
    console.log("Gen encu")
    event.preventDefault();

    togLoad(true)

    axios
		.get(process.env.REACT_APP_SERVIDOR + `/hospitalBoca/encuestaSeguimiento/generar/${noExpediente}`, {
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
        alert("Este paciente no ha tomado su encuesta.")
        togLoad(false)
        console.log(err)
			}
		)
  }

  return (
    <form onSubmit={GenerarEncuesta} autoComplete="off" className={styles.fullWidth}>
      <AccordionDetails className={styles.center}>
        <Button disabled={isLoad} component={Link} to={`/pacientes/detalles/${noExpediente}/encuesta`} variant="outlined" size="large">
          Abrir Encuesta de Seguimiento
        </Button>
        <Button disabled={isLoad} type="submit" variant="outlined" size="large" startIcon={
          (isLoad ? <CircularProgress size={24} /> : <GetAppRoundedIcon />)
        }>
          Descargar Encuesta de Seguimiento
        </Button>
      </AccordionDetails>
    </form>
  )
}
