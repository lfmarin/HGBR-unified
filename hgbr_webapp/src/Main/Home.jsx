import { React } from 'react'
import ExtendedCard from '../Components/ExtendedCard'
import { Grid } from '@material-ui/core'
import useStyles from '../Styles/formularioStyles'

export default function Home() {
  const style = useStyles()
  return (
    <div className={style.fullWidth}>
      <Grid container spacing={1} justifyContent="center">
        <Grid item xs margin={1}>
          <ExtendedCard
            imgPath="./media/pacientes.png"
            imgText="Secretaria de Salud Pacientes"
            Title="Registro de Pacientes"
            link="/pacientes"
            alignment="center"
          />
        </Grid>
      </Grid>

      <Grid container spacing={2}>
        <Grid item xs>
          <ExtendedCard
            imgPath="./media/urgencias.png"
            imgText="Secretaria de Salud Urgencias"
            Title="Servico de Urgencias y Admisiones"
            link="/admisiones"
            alignment="center"
          />
        </Grid>
      </Grid>
    </div>
  )
}
