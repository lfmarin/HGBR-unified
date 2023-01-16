import React from 'react'
import { AccordionDetails, Button } from '@material-ui/core'
// import GetAppRoundedIcon from '@material-ui/icons/GetAppRounded'
import { Link } from 'react-router-dom'
import useStyles from '../../Styles/formularioStyles'
import { useParams } from 'react-router'

export default function SeccionHistoriaClinica() {
  const { noExpediente } = useParams()
  const classes = useStyles()
  return (
    <AccordionDetails className={classes.center}>
      <Button
        component={Link}
        to={`/pacientes/detalles/${noExpediente}/historia-clinica`}
        variant="outlined"
        size="large"
      >
        Abrir Historia Clinica
      </Button>
      {/* <Button variant="outlined" size="large" startIcon={<GetAppRoundedIcon />}>
        Descargar Historia Clinica
      </Button> */}
    </AccordionDetails>
  )
}
