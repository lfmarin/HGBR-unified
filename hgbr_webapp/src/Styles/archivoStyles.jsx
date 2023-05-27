import { makeStyles } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
    form: {
      width: '100%',
      border: "1px solid black",
      borderRadius: 5,
      padding: 8,
    },
    root: {
      flexGrow: 1,
      backgroundColor: theme.palette.background.paper,
      display: 'flex',
      width: '100%',
    },
    tabs: {
      borderRight: `1px solid ${theme.palette.divider}`,
    },
    fullWidth: {
      width: "100%",
    }
  }));

  export default useStyles;