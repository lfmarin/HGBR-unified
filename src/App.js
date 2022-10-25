import {React, useState} from 'react'
import NavBar from './Main/AppBar';
import { createTheme, ThemeProvider} from '@material-ui/core/styles';
import MainRoutes from './Main/MainRoutes';
import { BrowserRouter } from 'react-router-dom';
import useStyles from './Styles/Styles';
import Drawer from './Main/Drawer';
// import { PrivateRoute } from './Components/PrivateRoute';
// import { Login } from './Session/Login';

const theme = createTheme({
  palette: {
    primary: {
      light: '#A3DDCB',
      main: '#0A043C',
      dark: '#03506F',
      contrastText: '#FFFFFF',
    },
  }
});

export default function App() {
  const [isOpen, setIsOpen] = useState(false);
  const classes = useStyles();
  const [curUserName, changeUsername] = useState(false);

  const handleDrawer = () => {
    setIsOpen(!isOpen);
  }

  return (
    <BrowserRouter>
      <div className="App">
        <ThemeProvider theme = {theme}>
          <header>
            <NavBar userName = {curUserName} menuCallBack = {handleDrawer}/>
            <Drawer open={isOpen} menuCallBack = {handleDrawer}/>
          </header>
          <main className={classes.main}>
            <MainRoutes userName = {curUserName} changeUsr = {changeUsername} />
          </main>
        </ThemeProvider>
      </div>
    </BrowserRouter>
  );
}
