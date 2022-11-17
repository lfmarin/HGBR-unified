/*
	Lista usuario:
	Esta página muestra la lista de los usuarios que están registrados en la página.
*/
import React, { useState } from 'react'
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
import { Link, Redirect } from 'react-router-dom'
import axios from 'axios'
import useStyles from '../Styles/listaPacientesStyles'
import EnhancedTableToolbar from '../Components/EnhancedTableToolbar'
import Button from '@mui/material/Button'
import { useEffect } from 'react'
// import ListaDoctores from '../Doctores/ListaDoctores'

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
export default function ListaUsuarios(props) {
	// Declara estados para verificar la sesion.
	// const [errorMessages, setErrorMessages] = useState({});
	const [token, setToken] = useState(sessionStorage.getItem('jwtToken'));
	const [listaUsr, setListaUsr] = useState([])
	const [doctoresLista, setDocs] = useState([])
	const [page, setPage] = useState(0)
	const [rowsPerPage, setRowsPerPage] = useState(5)
	const [order, setOrder] = useState('asc')
	const [orderBy, setOrderBy] = useState('noExpediente')
	const [noAutorizado, AutRedir] = useState(false)
	// const [errorbd, setErrorbd] = useState(false)
	const [refresh, setRefresh] = useState(true)
	const [search, setSearch] = useState('')
	const classes = useStyles()

	const ObtenerDoctor = ( id ) => {
		if (doctoresLista.length === 0)
			return ""
		if (id === 0 || id === null)
			return "N/A"
		return doctoresLista[id].nombre
	}

	const handleChangePage = (event, newPage) => {
		setPage(newPage)
	  }
	
	  const handleChangeRowsPerPage = event => {
		setRowsPerPage(+event.target.value)
		setPage(0)
	  }
	
	  const handleRequestSort = (event, property) => {
		const isAsc = orderBy === property && order === 'asc'
		setOrder(isAsc ? 'desc' : 'asc')
		setOrderBy(property)
	  }
	
	  const handleEnterSearch = event => {
		if (event.key === 'Enter') {
			setListaUsr(SortTable.searchTable(listaUsr, search))
		}
	  }
	
	  const handleSearch = event => {
		setSearch(event.target.value)
	  }
	
	  const handleCancelSearch = event => {
		// console.log(pacientes)
		setRefresh(true)
		//setPacientes(pacientes);
		setSearch('')
	  }

	useEffect(() => {
		if (refresh) {
			axios.get('https://localhost:5001/api/Users/all', {
			headers: {
				'Content-type': 'application/json',
				'Authorization': `Bearer ${token}`
			},
			})
			.then(
				response => {
					if (response.status === 200) {
						setListaUsr(response.data)
						console.log(response.data)
						setRefresh(false)
					}
				},
				error => {
					setToken("")
					AutRedir(true)
				}
			)

			axios.get('https://localhost:5001/hospitalBoca/doctores/all', {
			headers: {
				'Content-type': 'application/json',
				'Authorization': `Bearer ${token}`
			},
			})
			.then(
				response => {
					if (response.status === 200) {
						setDocs(response.data)
						setRefresh(false)
					}
				},
				error => {}
			)
		}
	})

	if (noAutorizado) return <Redirect to="/login" />

	return (
		<div className={classes.root}>
			<Paper className={classes.paper}>
			<EnhancedTableToolbar
				handleEnterSearch={handleEnterSearch}
				search={search}
				handleSearch={handleSearch}
				handleCancelSearch={handleCancelSearch}
				title="Listado de usuarios"
				buttonTitle="AGREGA USUARIO"
				link="/usuarios/registrarusuario"
			/>
			<TableContainer>
			  <Table className={classes.table} aria-labelledby="tableTitle" size="medium" aria-label="enhanced table">
				<EnhancedTableHead
					sx={visuallyHidden}
					order={order}
					orderBy={orderBy}
					headCells={headCells}
					onRequestSort={handleRequestSort}
				/>
	
				<TableBody>
					{SortTable.stableSort(listaUsr, SortTable.getComparator(order, orderBy))
					.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
					.map(item => {
					  return (
						<TableRow key={item.id}>
							<TableCell>{item.id}</TableCell>
							<TableCell>{item.userName}</TableCell>
							<TableCell>{ObtenerDoctor(item.idDoctor)}</TableCell>
							<TableCell>{item.idRole}</TableCell>
							{/* <TableCell>{getAge(item.fechaNacimiento)} años</TableCell> */}
							{/* <TableCell>{dateFormatter(item.fechaNacimiento)}</TableCell> */}
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
			  count={listaUsr.length}
			  rowsPerPage={rowsPerPage}
			  page={page}
			  onPageChange={handleChangePage}
			  onRowsPerPageChange={handleChangeRowsPerPage}
			/>
		  </Paper>
		</div>
	  )
}