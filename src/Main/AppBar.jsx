import React from 'react'
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Typography from '@material-ui/core/Typography'
import { Link } from 'react-router-dom'
import { makeStyles, IconButton } from '@material-ui/core'
import MenuIcon from '@material-ui/icons/Menu'

const useStyles = makeStyles(theme => ({
  logo: {
    height: 50,
    marginRight: theme.spacing(2),
  },
}))

const mostrarUsuario = (nombre) => {
  return <div style={{right: 30, position: 'absolute'}}>
    {nombre}
  </div>
}

export default function NavBar({userName, menuCallBack}) {
  const classes = useStyles()
  return (
    <div>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            onClick={() => menuCallBack()}
            edge="start"
            sx={{ mr: 2 }}
            color="inherit"
            aria-label="menu"
          >
            <MenuIcon />
          </IconButton>
          <img src="/media/logo.png" alt="logo" className={classes.logo} />
          <Link to="/" style={{ textDecoration: 'none', color: '#FFF' }}>
            <Typography color="inherit">
              Hospital General de Boca del Río
            </Typography>
          </Link>
          {mostrarUsuario(userName())}
        </Toolbar>
      </AppBar>
    </div>
  )
}
