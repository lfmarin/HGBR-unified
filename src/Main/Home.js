import {React} from "react";
import ExtendedCard from "../Components/ExtendedCard";
import { Grid } from "@material-ui/core";
import useStyles from '../Styles/formularioStyles';

export default function Home() {
  const style = useStyles();
  return(
    <div className={style.fullWidth}>
      <Grid container spacing={1} justifyContent="center">
        <Grid item xs margin={1}>
          <ExtendedCard
            imgPath = "media/pacientes.jpg"
            imgText = "Secretaria de Salud Pacientes"
            Title = "Pacientes"
            link = "/pacientes"
            alineacion = "center"
            altura = "100"
          />
        </Grid>
      </Grid>

      <Grid container spacing={2} >
        <Grid item xs>
          <ExtendedCard
            imgPath = "media/doctores.jpg"
            imgText = "Secretaria de Salud Doctores"
            Title = "Doctores"
            link = "/doctores"
            alineacion = "center"
            altura = "100"
          />
        </Grid>
      </Grid>

      <Grid container spacing={2} >
        <Grid item xs>
          <ExtendedCard
            imgPath = "media/consejeria.jpg"
            imgText = "Secretaria de Salud Personal"
            Title = "Personal de Consejería"
            link = "/consejeria"
            alineacion = "center"
            altura = "100"
          />
        </Grid>
      </Grid>
    </div>
  );   
}