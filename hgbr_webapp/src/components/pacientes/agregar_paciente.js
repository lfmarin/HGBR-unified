import { useEffect, useState } from "react";


import {
    Container,
    FormGroup,
    Button,
    Label,
    Input,
    Form,
    Col,
    Alert
} from 'reactstrap';

function Agregar_paciente(props) {
    
    const [info, setInfo] = useState({
        numSerie:  "",
        fabricante: "",
        fabricado: "",
        rutaUtilizar: "",
        capacidad: "",
    })

    return (
        <Container className="App">
            <h4 className="PageHeading">Ingrese la información a registrar del paciente</h4>
            <Form className="form">
                <Col>
                    <FormGroup row>
                        <Label for="name" sm={2}>CURP</Label>
                        <Col sm={2}>
                            <Input type="text" name="curp"   />
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="name" sm={2}>Número de Expediente</Label>
                        <Col sm={2}>
                            <Input type="text" name="numExpediente"  />
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="name" sm={2}>Nombre</Label>
                        <Col sm={2}>
                            <Input type="date" name="nombre"   />
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="name" sm={2}>Apellido Paterno</Label>
                        <Col sm={2}>
                            <Input type="date" name="apaterno"   />
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="name" sm={2}>Apellido Materno</Label>
                        <Col sm={2}>
                            <Input type="date" name="amaterno"   />
                        </Col>
                    </FormGroup>

                    {/* <FormGroup row>
                        <Label for="name" sm={2}>Sexo</Label>
                        <Col sm={2}>
                            <select  name="sexo" id="sexo">
                                {
                                    rutas.map((val,key) => {
                                        return <option ></option>
                                    })
                                }
                            </select>
                        </Col>
                    </FormGroup> */}
                    <FormGroup row>
                        <Label for="name" sm={2}>Capacidad</Label>
                        <Col sm={2}>
                            <Input type="text" name="capacidad"  />
                        </Col>
                    </FormGroup>
                </Col>
                <Col>
                    <FormGroup row>
                        <Col sm={5}>
                        </Col>
                        <Col sm={1}>
                            <Button color="primary"  >Agregar</Button>
                        </Col>
                        <Col sm={1}>
                            <Button color="secondary"  >Cancelar</Button>
                        </Col>
                        <Col sm={5}>
                        </Col>
                    </FormGroup>
                </Col>
            </Form>
        </Container>
    );
}

export default Agregar_paciente;