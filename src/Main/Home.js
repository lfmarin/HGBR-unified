import {React} from "react";
import ExtendedCard from "../Components/ExtendedCard";
import { Grid } from "@material-ui/core";

export default function Home() {
  return(
    <div>
      <Grid container spacing={2}>
        <ExtendedCard
          imgPath = "media/logo.png"
          imgText = "Secretaria de Salud Pacientes"
          Title = "Pacientes"
          link = "/pacientes"
          alineacion = "center"
          altura = "150"
        />
      </Grid>
    </div>
  );   
}