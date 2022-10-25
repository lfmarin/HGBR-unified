import React, { useState, useEffect } from 'react'
import Table from '@material-ui/core/Table'
import TableBody from '@material-ui/core/TableBody'
import TableCell from '@material-ui/core/TableCell'
import TableContainer from '@material-ui/core/TableContainer'
import TableRow from '@material-ui/core/TableRow'
import Paper from '@material-ui/core/Paper'
import TablePagination from '@mui/material/TablePagination'
import SortTable from '../../Components/SortTable'
import EnhancedTableToolbar from '../../Components/EnhancedTableToolbar'
import { visuallyHidden } from '@mui/utils'
import { Redirect } from 'react-router-dom'
import axios from 'axios'
import useStyles from '../../Styles/listaPacientesStyles'
import EnhancedTableHead from '../../Components/HeadSortTable'
import Button from '@mui/material/Button'

const headCells = [
  { id: 'fechaHora', numeric: false, label: 'Fecha y hora' },
]

export default function ListaNotas(props) {
  const [notas, setNotas] = useState([])
  const [page, setPage] = useState(0)
  const [rowsPerPage, setRowsPerPage] = useState(5)
  const [order, setOrder] = useState('asc')
  const [orderBy, setOrderBy] = useState('fechaHora')
  const [errorbd, setErrorbd] = useState(false)
  const [refresh, setRefresh] = useState(true)

  const [token] = useState(sessionStorage.getItem('jwtToken'));
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
      setNotas(SortTable.searchTable(notas, search))
    }
  }

  const handleSearch = event => {
    setSearch(event.target.value)
  }

  const handleCancelSearch = event => {
    // console.log(notas)
    setRefresh(true)
    //setPacientes(pacientes);
    setSearch('')
  }

  useEffect(() => {
    if (refresh) {
      axios
        .get('https://localhost:5001/hospitalBoca/notasMedicas/paciente', {
          headers: {
            'Content-type': 'application/json',
            'Authorization': `Bearer ${token}`
          },
        })
        .then(
          response => {
            if (response.status === 200) {
              setNotas(response.data)
              setErrorbd(false)
            }
          },
          error => {
            if (!error.response) setErrorbd(true)
            /*else{
            if (error.response.status === 401) {
              localStorage.removeItem("ACCESS_TOKEN");
              setToken('');
              setErrorbd(false);
            }
          }*/
          }
        )
      setRefresh(false)
    }
  }, [refresh, token])

  /*
  const dateFormatter = date => {
    var formatter = new Intl.DateTimeFormat('es-MX', 'dd-mm-yyyy')
    return formatter.format(new Date(date))
  }
  */

  if (errorbd) return <Redirect to="/error" />
  /*if(!token){
    return(
      //console.log(location.pathname),
      <Redirect to={
        {
          pathname:'/login',
          state:{
            from: location
          }
        }
      }/>
    )
  }*/

  return (
    <div className={classes.root}>
      <Paper className={classes.paper}>
        <EnhancedTableToolbar
          handleEnterSearch={handleEnterSearch}
          search={search}
          handleSearch={handleSearch}
          handleCancelSearch={handleCancelSearch}
          title="Listado de notas médicas"
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
              {SortTable.stableSort(notas, SortTable.getComparator(order, orderBy))
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map(item => {
                  return (
                    <TableRow key={item.fechaHora}>
                      <TableCell>
                        <Button
                          //component={Link}
                          //to={`/pacientes/detalles/${item.noExpediente}`}
                          variant="outlined"
                          sx={{ borderColor: '#AC3833', color: '#AC3833' }}
                        >
                          Ver nota
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
          count={notas.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
      </Paper>
    </div>
  )
}
