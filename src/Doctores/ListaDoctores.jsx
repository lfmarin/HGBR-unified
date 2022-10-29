import React, { useState, useEffect } from 'react'
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
import { Button } from '@material-ui/core'
import axios from 'axios'
import { makeStyles } from '@material-ui/core/styles'
import EnhancedTableToolbar from '../Components/EnhancedTableToolbar'

const headCells = [
  { id: 'nombre', numeric: false, label: 'Nombre' },
  { id: 'apPaterno', numeric: false, label: 'Apellido Paterno' },
  { id: 'apMaterno', numeric: false, label: 'Apellido Materno' },
  { id: 'edit', numeric: false, label: 'Accion' },
]

const useStyles = makeStyles(theme => ({
  root: {
    width: '100%',
  },
  paper: {
    width: '100%',
    marginBottom: theme.spacing(2),
    padding: theme.spacing(2),
  },
  table: {
    minWidth: 750,
    marginTop: theme.spacing(2),
    border: '1px solid #ccc',
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
    textDecoration: 'none',
  },
}))

export default function ListaDoctores(props) {
  const [doctores, setDoctores] = useState([])
  const [page, setPage] = useState(0)
  const [rowsPerPage, setRowsPerPage] = useState(5)
  const [order, setOrder] = useState('asc')
  const [orderBy, setOrderBy] = useState('idDoctor')
  const [errorbd, setErrorbd] = useState(false)
  const [noAutorizado, AutRedir] = useState(false)
  const [refresh, setRefresh] = useState(true)

  const [token, setToken] = useState(sessionStorage.getItem('jwtToken'));
  //const location = useLocation();
  const [search, setSearch] = useState('')
  const classes = useStyles()

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
      setDoctores(SortTable.searchTableDoctores(doctores, search))
    }
  }

  const handleSearch = event => {
    setSearch(event.target.value)
  }

  const handleCancelSearch = event => {
    // console.log(doctores)
    setRefresh(true)
    setSearch('')
  }

  useEffect(() => {
    if (refresh) {
      axios
        .get('https://localhost:5001/hospitalBoca/doctores/all', {
          headers: {
            'Content-type': 'application/json',
            'Authorization': `Bearer ${token}`
          },
        })
        .then(
          response => {
            if (response.status === 200) {
              setDoctores(response.data)
              setErrorbd(false)
            }
          },
          error => {
            if (error.response.status === 401) {
              setToken('');
              AutRedir(true);
            }
          }
        )
      setRefresh(false)
    }
  }, [refresh, token])

  if (noAutorizado) return <Redirect to="/login" />
  if (errorbd) return <Redirect to="/error" />

  return (
    <div className={classes.root}>
      <Paper className={classes.paper}>
        <EnhancedTableToolbar
          handleEnterSearch={handleEnterSearch}
          search={search}
          handleSearch={handleSearch}
          handleCancelSearch={handleCancelSearch}
          title="Listado de doctores"
          buttonTitle="AGREGA DOCTOR"
          link="/doctores/registro"
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
              {SortTable.stableSort(doctores, SortTable.getComparator(order, orderBy))
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map(item => {
                  return (
                    <TableRow key={item.idDoctor}>
                      <TableCell>{item.nombre}</TableCell>
                      <TableCell>{item.apPaterno}</TableCell>
                      <TableCell>{item.apMaterno}</TableCell>
                      <TableCell align='center' >
                        <Button variant="contained" type="submit" component={Link} to={`/doctores/detalles/${item.idDoctor}`}>
                          Editar
                        </Button>
                        <text>&nbsp;&nbsp;&nbsp;&nbsp;</text>
                        <Button variant="contained" type="submit" component={Link} to={`/doctores/eliminar/${item.idDoctor}`}>
                          Eliminar
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
          count={doctores.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
      </Paper>
    </div>
  )
}
