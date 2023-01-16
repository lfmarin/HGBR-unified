import React, {useState} from 'react'
import { AccordionDetails, Button, CircularProgress } from '@material-ui/core'
import { makeStyles } from '@material-ui/core/styles'
import GetAppRoundedIcon from '@material-ui/icons/GetAppRounded'
import { Link } from 'react-router-dom'
import axios from 'axios'

const useStyles = makeStyles(theme => ({
  center: {
    display: 'flex',
    paddingTop: theme.spacing(5),
    paddingBottom: theme.spacing(5),
    justifyContent: 'space-around',
  },
}))

export default function SeccionNotaMedica({expediente, token}) {
  const styles = useStyles()

  const [isLoad, togLoad] = useState(false);

  const GenerarNota = (event) => {
    event.preventDefault();
    togLoad(true)

    axios
		.get(process.env.REACT_APP_SERVIDOR + `/hospitalBoca/pacientes/generarNotaMedica/${expediente}`,
    {
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
    <form onSubmit={GenerarNota} autoComplete="off" className={styles.fullWidth}>
      <AccordionDetails className={styles.center}>
        <Button variant="outlined" size="large">
          Crear nota médica
        </Button>
        <Button component={Link} to={`/pacientes/detalles/${expediente}/nota-medica`} variant="outlined" size="large">
          Ver nota médica
        </Button>
        <Button type="submit" variant="outlined" size="large" startIcon={
          (isLoad ? <CircularProgress size={24} /> : <GetAppRoundedIcon />)
        }>
          Descargar Nota Médica
        </Button>
        {/*<Button component={Link} to={`/pacientes/detalles/${noExpediente}/nota-medica/lista`} variant="outlined" size="large">
          Lista de notas médicas
          </Button>*/}
        {/* <Button variant="outlined" size="large" startIcon={<GetAppRoundedIcon/>}>
          Descargar Notas Médicas
        </Button> */}
      </AccordionDetails>
    </form>
  )
}
