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
import { Link, Navigate } from 'react-router-dom'
import axios from 'axios'
import useStyles from '../Styles/listaPacientesStyles'
import EnhancedTableToolbar from '../Components/EnhancedTableToolbar'
import Button from '@mui/material/Button'

const headCells = [
  { id: 'folio', numeric: false, label: 'Folio' },
  { id: 'nombre', numeric: false, label: 'Nombre' },
  { id: 'primerApellido', numeric: false, label: 'Apellido Paterno' },
  { id: 'segundoApellido', numeric: false, label: 'Apellido Materno' },
  { id: 'fechaNacimiento', numeric: false, label: 'Fecha de Nacimiento' },
  { id: 'accion', numeric: false, label: "Acciones" },
]

export default function AllAdmisiones({}) {
  const [admisiones, setAdmisiones] = useState([])
  const [page, setPage] = useState(0)
  const [rowsPerPage, setRowsPerPage] = useState(25)
  const [order, setOrder] = useState('asc')
  const [orderBy, setOrderBy] = useState('folio')
  const [errorbd, setErrorbd] = useState(false)
  const [refresh, setRefresh] = useState(true)
  
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
      setAdmisiones(SortTable.searchTableAdmisiones(admisiones, search))
    }
  }

  const handleSearch = event => {
    setSearch(event.target.value)
  }

  const handleCancelSearch = event => {
    // console.log(admisiones)
    setRefresh(true)
    //setAdmisiones(admisiones);
    setSearch('')
  }

  useEffect(() => {
    if (refresh) {
      axios
        .get(process.env.REACT_APP_SERVIDOR + '/hgbr_api/admisiones/all', {
          headers: {
            'Content-type': 'application/json',
            //'Authorization': `Bearer ${token()}`
          },
        })
        .then(
          response => {
            if (response.status === 200) {
              console.log("RESPUESTA DE ADMISIONES")
              console.log(response.data)
              setAdmisiones(response.data)
              console.log(admisiones);
              setErrorbd(false)
              setRefresh(false)
            }
          },
          error => {
            if (error.response.status === 401){
              //revokeToken()
              setErrorbd(true)
            }
          }
        )
      }
  }, [refresh])

  const dateFormatter = date => {
    var formatter = new Intl.DateTimeFormat('es-MX', 'dd-mm-yyyy')
    return formatter.format(new Date(date))
  }

  const getAge = d1 => {
    d1 = new Date(d1.slice(0, 10))
    const d2 = new Date()
    const diff = d2.getTime() - d1.getTime()
    return Math.floor(diff / (1000 * 60 * 60 * 24 * 365.25))
  }

  //if (errorbd) return <Navigate to="/login" />

  return (
    <div className={classes.root}>
      <Paper className={classes.paper}>
        <EnhancedTableToolbar
          handleEnterSearch={handleEnterSearch}
          search={search}
          handleSearch={handleSearch}
          handleCancelSearch={handleCancelSearch}
          title="Registro de admisiones"
          buttonTitle="NUEVO INGRESO"
          link="/admisiones/add"
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
              {SortTable.stableSort(admisiones, SortTable.getComparator(order, orderBy))
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map(p => {
                  return (
                    <TableRow key={p.folio}>
                      <TableCell>{p.folio}</TableCell>
                      <TableCell>{p.nombre}</TableCell>
                      <TableCell>{p.primerApellido}</TableCell>
                      <TableCell>{p.segundoApellido}</TableCell>
                      {/* <TableCell>{getAge(p.fechaNacimiento)} años</TableCell> */}
                      <TableCell>{dateFormatter(p.fechaNacimiento)}</TableCell>
                      <TableCell>
                        <Button
                          component={Link}
                          to={`/admisiones/archive/${p.folio}`}
                          variant="outlined"
                          sx={{ borderColor: '#AC3833', color: '#AC3833' }}
                        >
                          DETALLES
                        </Button>
                      </TableCell>
                    </TableRow>
                  )
                })}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[25, 50, 100]}
          component="div"
          count={admisiones.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
      </Paper>
    </div>
  )
}
