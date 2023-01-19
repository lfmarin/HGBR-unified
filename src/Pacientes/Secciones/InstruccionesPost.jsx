import React, {useState, useEffect} from 'react'
import { AccordionDetails, TextField, Button, FormControl, MenuItem, InputLabel, Select, CircularProgress } from '@material-ui/core'
import GetAppRoundedIcon from '@material-ui/icons/GetAppRounded'
import { makeStyles } from '@material-ui/core/styles'
import axios from 'axios'
import clsx from 'clsx'

const useStyles = makeStyles(theme => ({
  fullWidth: {
    width: '100%',
    display: 'flex',
    flexWrap: 'wrap',
    justifyContent: 'center',
  },
  marginTop: {
    marginTop: theme.spacing(2),
  },
}))

export default function InstruccionesPost({expediente, token}) {
  const classes = useStyles()
  const [isLoad, togLoad] = useState(false)
  const [doctores, setDoctores] = useState([])

  const [datos, setDatos] = useState({
    fkPersonal: '',
    fkMedico: ''
  })

  const handleChange = event => {
    setDatos({
      ...datos,
      [event.target.name]: event.target.value,
    })
  }

  const GenerarInstrucciones = (event) => {
    event.preventDefault();
    togLoad(true)

    // const med = document.getElementById("medico").value
    const uni = document.getElementById("unidad").value

    axios
		.post(process.env.REACT_APP_SERVIDOR + `/hospitalBoca/pacientes/instrucciones`,
    {
      // TODO: Aplicar relación por medio de Historia Clinica.
      pacienteID: expediente,
      medicoResponsable: datos.fkMedico,
      unidadMedica: uni,
    },{
      responseType: 'arraybuffer',
      headers: {
			  'Content-type': 'application/json',
			  'Authorization': `Bearer ${token()}`,
        // SOLO acepta PDFs.
        'Accept': 'application/pdf'
			},
    })
		.then(
			response => {
				if (response.status === 200) {
          const url = window.URL.createObjectURL(new Blob([response.data]));
          window.location.href = url;
				}
			}
		)
		.catch(
			err => {
        alert("Ocurrió un error al generar las instrucciones. El paciente no parece tener un Motivo registrado.")
        togLoad(false)
        console.log(err)
			}
		)
  }

  useEffect(() => {
    axios
      .get(process.env.REACT_APP_SERVIDOR + '/hospitalBoca/doctores/all', {
        headers: {
          'Content-type': 'application/json',
          'Authorization': `Bearer ${token()}`,
        },
      })
      .then(
        response => {
          if (response.status === 200) {
            setDoctores(response.data)
            // setErrorbd(false)
          }
        },
        error => {
          // if (!error.response) setErrorbd(true)
        }
      )
  }, [token])

  return (
    <AccordionDetails>
      <form onSubmit={GenerarInstrucciones} autoComplete="off" className={classes.fullWidth}>
          <FormControl variant="outlined" fullWidth className={clsx(classes.input)}>
            <InputLabel id="fkMedico">Médico responsable</InputLabel>
            <Select
              required
              labelId="fkMedico"
              id="fkMedico"
              variant="outlined"
              name='fkMedico'
              fullWidth
              onChange={handleChange}
              disabled={isLoad}
              defaultValue=""
              label="Médico responsable"
            >
              {doctores.map(n => {
                return (
                  <MenuItem value={n.idDoctor}>
                    {n.nombre} {n.apPaterno} {n.apMaterno}
                  </MenuItem>
                )
              })}
            </Select>
          </FormControl>

          <TextField
            id="unidad"
            variant="outlined"
            fullWidth
            required
            disabled={isLoad}
            className={classes.marginTop}
            label="Unidad Médica"
          />

          <Button
            variant="outlined"
            size="large"
            disabled={isLoad}
            startIcon={
              (isLoad ? <CircularProgress size={24} /> : <GetAppRoundedIcon />)
            }
            type="submit"
            className={classes.marginTop}
          >
            Generar Aviso
          </Button>
      </form>
    </AccordionDetails>
  )
}
