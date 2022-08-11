import React from 'react'
import { AccordionDetails, Button } from '@material-ui/core'
import { makeStyles } from '@material-ui/core/styles'
import GetAppRoundedIcon from '@material-ui/icons/GetAppRounded'
import { Link } from 'react-router-dom'
import { useParams } from 'react-router'

const useStyles = makeStyles(theme => ({
  center: {
    display: 'flex',
    paddingTop: theme.spacing(5),
    paddingBottom: theme.spacing(5),
    justifyContent: 'space-around',
  },
}))

export default function SeccionNotaMedica() {
  const styles = useStyles()
  const { noExpediente } = useParams()

  return (
    <AccordionDetails className={styles.center}>
      <Button variant="outlined" size="large">
        Crear nota médica
      </Button>
      <Button component={Link} to={`/pacientes/detalles/${noExpediente}/nota-medica`} variant="outlined" size="large">
        Ver nota médica
      </Button>
      {/* <Button variant="outlined" size="large" startIcon={<GetAppRoundedIcon/>}>
        Descargar Notas Médicas
      </Button> */}
    </AccordionDetails>
  )
}
