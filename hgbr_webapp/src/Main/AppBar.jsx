import React from 'react'
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Typography from '@material-ui/core/Typography'
import { Link, } from 'react-router-dom'
import { makeStyles, IconButton, Button } from '@material-ui/core'
import MenuIcon from '@material-ui/icons/Menu'

const useStyles = makeStyles(theme => ({
  logo: {
    height: 50,
    marginRight: theme.spacing(2),
  },
}))

/**
 * 
 * @param {string} nombre 
 * @returns 
 */
// const mostrarUsuario = (nombre) => {
//   return <div style={{right: 30, display:'flex', justifyContent:'space-evenly', alignItems:'center', width: '300px', position: 'absolute', color: '#000'}}>
//     {nombre}
//     {(nombre && nombre.length !== 0) && <Button component={Link} to={`/logout`} variant="outlined" size="small">
//         Cerrar Sesión
//     </Button>}
//   </div>
// }

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
            color="#000"
            aria-label="menu"
          >
            <MenuIcon />
          </IconButton>
          <a href="/">
            <img src="/media/logo.png" alt="logo" className={classes.logo} />
          </a>
          <Link to="/" style={{ textDecoration: 'none', color: '#000' }}>
            <Typography color="inherit">
              Hospital General de Boca del Río
            </Typography>
          </Link>
          {/* {mostrarUsuario(userName())} */}
        </Toolbar>
      </AppBar>
    </div>
  )
}
