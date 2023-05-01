import { styles } from '@mui/material/styles';

const useStyles = styles((theme) => ({
    fullWidth: {
      width: "100%",
    },
    justify: {
      display: "flex",
      flexWrap: "wrap",
      justifyContent: "space-between"
    },
    input: {
      marginLeft: theme.spacing(1),
      marginRight: theme.spacing(1),
      marginTop: theme.spacing(2)
    },
    input15: {
      width: `calc(15% - ${theme.spacing(2)}px)`
    },
    input25: {
      width: `calc(25% - ${theme.spacing(2)}px)`
    },
    input30: {
      width: "30%",
    },
    input50: {
      width: "46%",
    },
    input60: {
      width: "62%",
    },
    line: {
      marginTop: theme.spacing(2),
      color: theme.palette.secondary.dark,
      borderBottom: `1px solid ${theme.palette.divider}`,
      paddingLeft: theme.spacing(2),
    },
    contenedorButton: {
      padding: theme.spacing(2),
      display: 'flex',
      justifyContent: "center",
    },
    radioGroup: {
      display: "block !important",
    },
    radioButton: {
      justifyContent: "center",
    },
    button: {
        marginTop: theme.spacing(2),
        marginBottom: theme.spacing(2),
        marginLeft: theme.spacing(1),
        color: "white",
        backgroundColor: "#AC3833"
      },
    otbutton: {
      borderColor: "#AC3833",
      color:"#AC3833"
    },
    contenedor: {
      backgroundColor: "white",
      border: "1px solid #ccc",
      borderRadius: "5px",
      padding: theme.spacing(4),
    },
    heading: {
      fontSize: theme.typography.pxToRem(18),
      fontWeight: theme.typography.fontWeightRegular,
      color: "white",
    },
    head: {
      backgroundColor: "#AC3833",
    },
    datoSuperior: {
      marginTop: theme.spacing(4),
    },
    center: {
      display: "flex",
      padding: theme.spacing(5),
      justifyContent: "space-around",
    }
  }));
  
export default useStyles;