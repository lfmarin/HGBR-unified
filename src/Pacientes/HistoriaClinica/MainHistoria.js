import React from 'react';
import { useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import PropTypes from 'prop-types';
import {
    Tabs,
    Tab,
    Box
} from "@material-ui/core";
import MotivoSolicitud from './motivoSolicitud';
import DatosIdentificacion from './datosIdentificacion';

const useStyles = makeStyles((theme) => ({
  form: {
    marginTop: theme.spacing(2),
    border: "1px solid black",
    borderRadius: 5,
    padding: 8,
  },
  root: {
    flexGrow: 1,
    backgroundColor: theme.palette.background.paper,
    display: 'flex',
  },
  tabs: {
    borderRight: `1px solid ${theme.palette.divider}`,
  },
  fullWidth: {
    width: "100%",
  }
}));

function TabPanel(props) {
    const { children, value, index, ...other } = props;
    return (
        <div
        role="tabpanel"
        hidden={value !== index}
        id={`vertical-tabpanel-${index}`}
        aria-labelledby={`vertical-tab-${index}`}
        {...other}
        >
        {value === index && (
            <Box p={3}>
            {children}
            </Box>
        )}
        </div>
    );
}

TabPanel.propTypes = {
    children: PropTypes.node,
    index: PropTypes.any.isRequired,
    value: PropTypes.any.isRequired,
};

function a11yProps(index) {
    return {
        id: `vertical-tab-${index}`,
        'aria-controls': `vertical-tabpanel-${index}`,
    };
}


export default function MainHistoriaClinica() {
  const styles = useStyles();
  const classes = useStyles();
  const [value, setValue] = useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <div>
        <div className ={styles.form}>
            <div className={classes.root}>
                <Tabs
                    orientation="vertical"
                    value={value}
                    onChange={handleChange}
                    aria-label="Vertical tabs example"
                    className={classes.tabs}
                    centered={true}
                >
                    <Tab label="I. Datos de identificación" {...a11yProps(0)} />
                    <Tab label="II. Motivo de solicitud de procedimiento" {...a11yProps(1)} />
                    <Tab label="III. Historia Clínica y Exploración Física" {...a11yProps(2)} />
                    <Tab label="IV. Procedimiento quirúrgico" {...a11yProps(3)} />
                    <Tab label="V. Estudio anatomopatológico" {...a11yProps(4)} />
                    <Tab label="VI. Evolución" {...a11yProps(5)} />
                </Tabs>
                <TabPanel className={classes.fullWidth} value={value} index={0}>
                    <DatosIdentificacion/>
                </TabPanel>
                <TabPanel className={classes.fullWidth} value={value} index={1}>
                    <MotivoSolicitud/>
                </TabPanel>
                <TabPanel className={classes.fullWidth} value={value} index={2}>
                    {/* <HistoriaClinicaEF/> */}
                </TabPanel>
                <TabPanel className={classes.fullWidth} value={value} index={3}>
                    {/* <ProcedimientoQuirurgico/> */}
                </TabPanel>
                <TabPanel className={classes.fullWidth} value={value} index={4}>
                    {/* <EstudioAnatomo/> */}
                </TabPanel>
                <TabPanel className={classes.fullWidth} value={value} index={5}>
                    {/* <Evolucion/> */}
                </TabPanel>
            </div>
        </div>
    </div>
  );
}