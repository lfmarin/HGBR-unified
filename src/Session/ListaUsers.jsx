/*
	Lista usuario:
	Esta página muestra la lista de los usuarios que están registrados en la página.
*/
import React from 'react'
import Table from '@material-ui/core/Table'
import TableBody from '@material-ui/core/TableBody'
import TableCell from '@material-ui/core/TableCell'
import TableContainer from '@material-ui/core/TableContainer'
import TableRow from '@material-ui/core/TableRow'
import Paper from '@material-ui/core/Paper'
import TablePagination from '@mui/material/TablePagination'
import SortTable from '../Components/SortTable'
import EnhancedTableHead from '../Components/HeadSortTable'
import { visuallyHidden } from '@mui/utils'
import { Link, Redirect, useLocation } from 'react-router-dom'
import axios from 'axios'
import { withStyles } from '@material-ui/core/styles';
import useStyles from '../Styles/listaPacientesStyles'
import EnhancedTableToolbar from '../Components/EnhancedTableToolbar'
import Button from '@mui/material/Button'

/*
{
	"id": 1,
	"userName": "josevarela",
	"idDoctor": 1,
	"idRole": 0,
	"token": null
},
*/
const headCells = [
	{ id: 'id', numeric: false, label: 'ID' },
	{ id: 'userName', numeric: false, label: 'Nombre de Usuario' },
	{ id: 'idDoctor', numeric: false, label: 'Doctor asignado' },
	{ id: 'idRole', numeric: false, label: 'Rol asignado' }
  ]

/**
 * Pagina de inicio de sesión.
 * @param {*} props 
 */
class ListaUsuarios extends React.Component {
	constructor (props) {
		super(props);

		this.state = {
			token : sessionStorage.getItem('jwtToken'),
			listaUsr : [],
			doctoresLista : [],
			page : 0,
			rowsPerPage : 5,
			order : 'asc',
			orderBy : 'noExpediente',
			noAutorizado : false,
			isFetched : true,
			search : '',
			// 
			UsrObtenido : false,
			DocObtenido : false,
		}

		this.classes = withStyles(useStyles)

		this.Usuarios_URL = process.env.REACT_APP_USUARIOS + process.env.REACT_APP_GET_ALL
		this.Doctores_URL = process.env.REACT_APP_DOCTORES + process.env.REACT_APP_GET_ALL
	}

	ObtenerDoctor = ( id ) => {
		if (this.state.doctoresLista.length === 0)
			return ""
		if (id === 0 || id === null)
			return "N/A"
		return this.state.doctoresLista[id].nombre
	}

	handleChangePage = (event, newPageToUse) => {
		this.setState({page: newPageToUse})
	}
	
	handleChangeRowsPerPage = event => {
		this.setState({rowsPerPage: +event.target.value, page: 0})
	}
	
	handleRequestSort = (event, property) => {
		const isAsc = this.orderBy === property && this.order === 'asc'
		this.setState({order: isAsc ? 'desc' : 'asc', orderBy: property})
	}
	
	handleEnterSearch = event => {
		if (event.key === 'Enter') {
			this.setState({listaUsr: SortTable.searchTable(this.listaUsr, this.search)})
		}
	}
	
	handleSearch = event => {
		this.setState({search: event.target.value})
	}
	
	handleCancelSearch = event => {
		this.setState({isFetched : true, search: ''})
	}

	// Corre la función cuando el componente ha sido construido.
	componentDidMount() {
		// this.setState({token: sessionStorage.getItem('jwtToken')})

		axios.get(this.Usuarios_URL, {
		headers: {
			'Content-type': 'application/json',
			'Authorization': `Bearer ${this.state.token}`
		},
		})
		.then(
			response => {
				if (response.status === 200) {
					this.setState({listaUsr: response.data, UsrObtenido: true})
				}
			},
			error => {
				if( !error.status )
					console.warn("what did i recieve?")
			}
		)

		axios.get(this.Doctores_URL, {
		headers: {
			'Content-type': 'application/json',
			'Authorization': `Bearer ${this.state.token}`
		},
		})
		.then(
			response => {
				if (response.status === 200) {
					this.setState({doctoresLista: response.data, DocObtenido: true})
				}
			},
			error => {}
		)

		if( this.state.UsrObtenido && this.state.DocObtenido )
			this.setState({isFetched: true})
	}

	render() {
		if (this.state.noAutorizado) return <Redirect to="/login" />

		if (!this.state.isFetched) {
			return (
				<div>
					<h2>Cargando...</h2>
				</div>
			)
		}

		return (
			<div className={this.classes.root}>
				<Paper className={this.classes.paper}>
				<EnhancedTableToolbar
					handleEnterSearch={this.handleEnterSearch}
					search={this.search}
					handleSearch={this.handleSearch}
					handleCancelSearch={this.handleCancelSearch}
					title="Listado de usuarios"
					buttonTitle="AGREGA USUARIO"
					link="/usuarios/registrarusuario"
				/>
				<TableContainer>
				<Table className={this.classes.table} aria-labelledby="tableTitle" size="medium" aria-label="enhanced table">
					<EnhancedTableHead
						sx={visuallyHidden}
						order={this.order}
						orderBy={this.orderBy}
						headCells={headCells}
						onRequestSort={this.handleRequestSort}
					/>
		
					<TableBody>
						{SortTable.stableSort(this.state.listaUsr, SortTable.getComparator(this.state.order, this.state.orderBy))
						.slice(this.state.page * this.state.rowsPerPage,
							this.state.page * this.state.rowsPerPage + this.state.rowsPerPage)
						.map(item => {
						return (
							<TableRow key={item.id}>
								<TableCell>{item.id}</TableCell>
								<TableCell>{item.userName}</TableCell>
								<TableCell>{this.ObtenerDoctor(item.idDoctor)}</TableCell>
								<TableCell>{item.idRole}</TableCell>
								<TableCell>
									<Button
										component={Link}
										to={`/usuarios/detalles/${item.id}`}
										variant="outlined"
										sx={{ borderColor: '#AC3833', color: '#AC3833' }}
									>
									Expediente
									</Button>
								</TableCell>
							</TableRow>
							)
						})}
					</TableBody>
				</Table>
				</TableContainer>
				<TablePagination
					rowsPerPageOptions={[5, 10, 50]}
					component="div"
					count={this.state.listaUsr.length}
					rowsPerPage={this.state.rowsPerPage}
					page={this.state.page}
					onPageChange={this.handleChangePage}
					onRowsPerPageChange={this.handleChangeRowsPerPage}
				/>
			</Paper>
			</div>
		)
	}
}

//other necessary hack to get around react-router v6
//heavy hooks utlization
function WithRouter (Component) {
    function ComponentWithRouterProps (props) {
        let location = useLocation ();
        return (
            <Component {...props}{...{location}} />
        )
    }

    return ComponentWithRouterProps;
}

export default WithRouter(ListaUsuarios);