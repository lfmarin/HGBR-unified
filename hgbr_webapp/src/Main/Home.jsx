import { React } from 'react'
import ExtendedCard from '../Components/ExtendedCard'
import { Grid } from '@material-ui/core'
import useStyles from '../Styles/formularioStyles'

export default function Home() {
  const style = useStyles()
  return (
    <div className={style.fullWidth}>
      <Grid container justifyContent="center">
        <Grid item xs margin={1}>
          <ExtendedCard
            Title="Registro de Pacientes"
            imgPath="./media/paciente.png"
            imgText="Secretaria de Salud Pacientes"
            link="/pacientes"
            alignment="center"
          />
        </Grid>

        <Grid item xs margin={1}>
          <ExtendedCard
            imgText="Secretaria de Salud Urgencias"
            imgPath="./media/hospital.png"
            Title="Servico de Urgencias y Admisiones"
            link="/admisiones"
            alignment="center"
          />
        </Grid>

      </Grid>
    </div>
  )
}
