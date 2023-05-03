import React from 'react'
import AppBar from '@mui/material/AppBar'
import Toolbar from '@mui/material/Toolbar'
import Typography from '@mui/material/Typography'
import { Link, } from 'react-router-dom'
import { IconButton, Button } from '@mui/material'
import { makeStyles } from '@mui/styles'
import Menu from '@mui/material/Menu'

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
            <Menu />
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
