import React from 'react'
import { useState } from 'react'
import PropTypes from 'prop-types'
import { Tabs, Tab, Box } from '@material-ui/core'
import DetailsPaciente from './infoPaciente'
import useStyles from '../Styles/archivoStyles'

function TabPanel(props) {
  const { children, value, index, ...other } = props
  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`vertical-tabpanel-${index}`}
      aria-labelledby={`vertical-tab-${index}`}
      {...other}
    >
      {value === index && <Box p={3}>{children}</Box>}
    </div>
  )
}

TabPanel.propTypes = {
  children: PropTypes.node,
  index: PropTypes.any.isRequired,
  value: PropTypes.any.isRequired,
}

function a11yProps(index) {
  return {
    id: `vertical-tab-${index}`,
    'aria-controls': `vertical-tabpanel-${index}`,
  }
}

export default function ArchivePaciente({token, changeToken}) {
  const classes = useStyles()
  const [value, setValue] = useState(0)

  const handleChange = (event, newValue) => {
    setValue(newValue)
  }

  return (
    <div className={classes.form}>
      <div className={classes.root}>
        <Tabs
          orientation="vertical"
          value={value}
          onChange={handleChange}
          aria-label="Vertical tabs example"
          className={classes.tabs}
          centered={true}
        >
          <Tab label="Datos personales" {...a11yProps(0)} />
          <Tab label="Hoja médica y expediente electrónico" {...a11yProps(1)} />
          <Tab label="Control de insumos" {...a11yProps(2)} />
          <Tab label="Tablero de indicadores" {...a11yProps(3)} />
        </Tabs>
        <TabPanel className={classes.fullWidth} value={value} index={0}>
          <DetailsPaciente /* token={token} changeToken={changeToken} */ />
        </TabPanel>
      </div>
    </div>
  )
}
