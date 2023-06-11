import {React} from 'react'
import clsx from 'clsx'
import { makeStyles } from '@material-ui/core/styles'
import { Drawer, List, Divider, ListItem, ListItemIcon, ListItemText } from '@material-ui/core'
import ExitToAppIcon from '@mui/icons-material/ExitToApp'
import PersonIcon from '@mui/icons-material/Person'
import LocalHospitalIcon from '@mui/icons-material/LocalHospital'
import Usericon from '@mui/icons-material/Person3Outlined'
import HomeIcon from '@mui/icons-material/Home'
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

export default function TempDrawer({open, menuCallBack}) {
  const classes = useStyles()

  const toggleDrawer = open => event => {
    if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) return

    menuCallBack()
  }

  const list = () => (
    <div
      className={clsx(classes.list)}
      role="presentation"
      onClick={toggleDrawer(false)}
      onKeyDown={toggleDrawer(false)}
    >
      <Divider/>
      
      <List>
        <Link className={classes.enlace} to="/">
          <ListItem button key="home">
            <ListItemIcon>
              <HomeIcon />
            </ListItemIcon>
            <ListItemText primary="Página principal" />
          </ListItem>
        </Link>
      </List>

      <Divider />

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
        <Link className={classes.enlace} to="/admisiones">
          <ListItem button key="admisiones">
            <ListItemIcon>
              <LocalHospitalIcon />
            </ListItemIcon>
            <ListItemText primary="Urgencias y Admisiones" />
          </ListItem>
        </Link>
      </List>

      <Divider />
      
    </div>
  )

  return (
    <div>
      <Fragment>
        <Drawer open={open} onClose={toggleDrawer(false)}>
          {list()}
        </Drawer>
      </Fragment>
    </div>
  )
}
