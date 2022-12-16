import React, { useState, useEffect } from 'react'
import { Accordion, AccordionSummary, Typography } from '@material-ui/core'
import ExpandMoreIcon from '@material-ui/icons/ExpandMore'
import useStyles from '../Styles/detallesStyles'
import Paper from '@material-ui/core/Paper'
import SeccionHistoriaClinica from './Secciones/HistoriaClinica'
import SeccionNotaMedica from './Secciones/NotaMedica'
import CartaConsentimiento from './Secciones/CartaConsentimiento'
import InstruccionesPost from './Secciones/InstruccionesPost'
import SeccionEncuesta from './Secciones/Encuesta'
import SeccionExamenes from './Secciones/Examenes'
import { Navigate, useParams } from 'react-router'
import axios from 'axios'

export default function DetallesPaciente({token}) {
  const { noExpediente } = useParams()
  const classes = useStyles()
  const [datos, setDatos] = useState({
    NoExpediente: '',
    Nombre: '',
    ApPaterno: '',
    ApMaterno: '',
  })
  const [load, setLoad] = useState(true)
  const [noAutorizado, AutRedir] = useState(false)
  const [errorDB, setDBerr] = useState(false)
  const cargaPaciente = () => {
    axios
      .get( process.env.REACT_APP_SERVIDOR + `/hospitalBoca/pacientes/${noExpediente}`, {
        headers: {
          'Content-type': 'application/json',
          'Authorization': `Bearer ${token}`
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setLoad(false)
            setDatos({
              NoExpediente: response.data.noExpediente,
              Nombre: response.data.nombre,
              ApPaterno: response.data.apPaterno,
              ApMaterno: response.data.apMaterno,
            })
          }
        },
        error => {
          // console.log(error.response)
          if (error.response.status === 401) {
            AutRedir(true)
          }

          if (error.response.status === 404) {
            setDBerr(true)
          }
        }
      )
  }

  useEffect(() => {
    if (load) {
      cargaPaciente()
    }
  });

  if( errorDB )
    return <Navigate to="/error" />

  if( noAutorizado )
    return <Navigate to="/login" />

  return (
    <div className={classes.root}>
      <Typography variant="h6"> Número de expediente: {datos.NoExpediente}</Typography>
      <Typography variant="h6">
        {' '}
        Paciente: {datos.Nombre} {datos.ApPaterno} {datos.ApMaterno}
      </Typography>
      <Paper className={classes.paper}>
        <Accordion className={classes.datoSuperior}>
          <AccordionSummary
            className={classes.head}
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1a-content"
            id="panel1a-header"
          >
            <Typography className={classes.heading}>Historia clínica</Typography>
          </AccordionSummary>
          <SeccionHistoriaClinica />
        </Accordion>

        <Accordion>
          <AccordionSummary
            className={classes.head}
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel2a-content"
            id="panel2a-header"
          >
            <Typography className={classes.heading}>Nota médica</Typography>
          </AccordionSummary>
          <SeccionNotaMedica />
        </Accordion>

        <Accordion>
          <AccordionSummary
            className={classes.head}
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel3a-content"
            id="panel3a-header"
          >
            <Typography className={classes.heading}>Carta de consentimiento</Typography>
          </AccordionSummary>
          <CartaConsentimiento expediente={datos.NoExpediente} token={token} />
        </Accordion>

        <Accordion>
          <AccordionSummary
            className={classes.head}
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel4a-content"
            id="panel4a-header"
          >
            <Typography className={classes.heading}>Instrucciones Postoperatorias</Typography>
          </AccordionSummary>
          <InstruccionesPost />
        </Accordion>

        <Accordion>
          <AccordionSummary
            className={classes.head}
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel5a-content"
            id="panel5a-header"
          >
            <Typography className={classes.heading}>Encuesta de seguimiento</Typography>
          </AccordionSummary>
          <SeccionEncuesta />
        </Accordion>

        <Accordion>
          <AccordionSummary
            className={classes.head}
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel6a-content"
            id="panel6a-header"
          >
            <Typography className={classes.heading}>Solicitud de exámenes de laboratorio</Typography>
          </AccordionSummary>
          <SeccionExamenes />
        </Accordion>
      </Paper>
    </div>
  )
}
