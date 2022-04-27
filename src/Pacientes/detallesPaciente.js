import React from 'react';
import { Accordion, AccordionSummary, Typography } from "@material-ui/core";
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import useStyles from "../Styles/detallesStyles";
import Paper from '@material-ui/core/Paper';
import SeccionHistoriaClinica from './Secciones/HistoriaClinica';
import SeccionNotaMedica from './Secciones/NotaMedica';
import CartaConsentimiento from './Secciones/CartaConsentimiento';
import InstruccionesPost from './Secciones/InstruccionesPost';
import SeccionEncuesta from './Secciones/Encuesta';
import SeccionExamenes from './Secciones/Examenes';
import { useParams } from 'react-router';

export default function DetallesPaciente() {
  const {noExpediente} = useParams();
  const classes = useStyles();
  return (
    <div className={classes.root}>
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
          <SeccionHistoriaClinica/>
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
          <SeccionNotaMedica/>
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
          <CartaConsentimiento/>
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
          <InstruccionesPost/>
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
          <SeccionEncuesta/>
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
            <SeccionExamenes/>
        </Accordion>
      </Paper>
   </div>
  );
}