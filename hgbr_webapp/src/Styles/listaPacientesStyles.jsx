import { styles } from '@mui/material/styles';

const useStyles = styles((theme) => ({
    paper: {
        width: '100%',
        marginBottom: theme.spacing(2),
        padding: theme.spacing(2)
    },
    table: {
        minWidth: 750,
        marginTop: theme.spacing(2),
        border: "1px solid #ccc",
    },
    visuallyHidden: {
        border: 0,
        clip: 'rect(0 0 0 0)',
        height: 1,
        margin: -1,
        overflow: 'hidden',
        padding: 0,
        position: 'absolute',
        top: 20,
        width: 1,
    },
    row: {
        textDecoration: "none"
    },
    button: {
        marginTop: theme.spacing(2),
        marginLeft: theme.spacing(1),
        borderColor: "#AC3833",
        color:"#AC3833"
    },
  }));

export default useStyles;