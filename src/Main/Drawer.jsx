import {React, useState} from 'react'
import clsx from 'clsx'
import { makeStyles } from '@material-ui/core/styles'
import { Drawer, List, Divider, ListItem, ListItemIcon, ListItemText } from '@material-ui/core'
import ExitToAppIcon from '@material-ui/icons/ExitToApp'
import Send from '@material-ui/icons/Send'
import PersonIcon from '@mui/icons-material/Person'
import LocalHospitalIcon from '@mui/icons-material/LocalHospital'
import { Link } from 'react-router-dom'
import { Fragment } from 'react'

const useStyles = makeStyles({
  list: {
    width: 250,
  },
  img: {
    marginRight: 30,
    width: 25,
  },
  enlace: {
    textDecoration: 'none',
    color: 'black',
  },
})

export default function TempDrawer(props) {
  const classes = useStyles()
  const [token, setToken] = useState(sessionStorage.getItem('jwtToken'));
  const IsLoggedIn = token.length === 0

  const toggleDrawer = open => event => {
    if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) return

    props.menuCallBack()
  }

  const SetLoginOrLogout = () => (
      <List>
        <Link className={classes.enlace} to={IsLoggedIn ? "/login" : "/logout"}>
          <ListItem button key="salir">
            <ListItemIcon>
              {!IsLoggedIn && <ExitToAppIcon />}
            </ListItemIcon>
            <ListItemText primary={IsLoggedIn ? "Iniciar Sesión" : "Salir"} />
          </ListItem>
        </Link>
      </List>
  )

  const list = () => (
    <div
      className={clsx(classes.list)}
      role="presentation"
      onClick={toggleDrawer(false)}
      onKeyDown={toggleDrawer(false)}
    >
      <List>
        <Link className={classes.enlace} to="/pacientes">
          <ListItem button key="pacientes">
            <ListItemIcon>
              <PersonIcon />
            </ListItemIcon>
            <ListItemText primary="Pacientes" />
          </ListItem>
        </Link>
      </List>

      <Divider />

      <List>
        <Link className={classes.enlace} to="/doctores">
          <ListItem button key="doctores">
            <ListItemIcon>
              <LocalHospitalIcon />
            </ListItemIcon>
            <ListItemText primary="Doctores" />
          </ListItem>
        </Link>
      </List>

      <Divider />

      {SetLoginOrLogout()}
    </div>
  )

  return (
    <div>
      <Fragment>
        <Drawer open={props.open} onClose={toggleDrawer(false)}>
          {list()}
        </Drawer>
      </Fragment>
    </div>
  )
}
