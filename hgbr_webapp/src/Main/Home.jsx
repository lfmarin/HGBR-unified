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
            imgPath="./media/paciente.png"
            imgText="Secretaria de Salud Pacientes"
            Title="Registro de Pacientes"
            link="/pacientes"
            alignment="center"
          />
        </Grid>

        <Grid item xs margin={1}>
          <ExtendedCard
            imgPath="./media/hospital.png"
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
