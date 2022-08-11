import React from 'react'
import { AccordionDetails, Button } from '@material-ui/core'
import { makeStyles } from '@material-ui/core/styles'
import GetAppRoundedIcon from '@material-ui/icons/GetAppRounded'
import { Link } from 'react-router-dom'
import { useParams } from 'react-router'

const useStyles = makeStyles(theme => ({
  center: {
    display: 'flex',
    padding: theme.spacing(5),
    justifyContent: 'space-around',
  },
}))

export default function SeccionEncuesta() {
  const styles = useStyles()
  const { noExpediente } = useParams()

  return (
    <AccordionDetails className={styles.center}>
      <Button component={Link} to={`/pacientes/detalles/${noExpediente}/encuesta`} variant="outlined" size="large">
        Abrir Encuesta de Seguimiento
      </Button>
      <Button variant="outlined" size="large" startIcon={<GetAppRoundedIcon />}>
        Descargar Encuesta de Seguimiento
      </Button>
    </AccordionDetails>
  )
}
