function descendingComparator(a, b, orderBy) {
  if (b[orderBy] < a[orderBy]) {
    return -1
  }
  if (b[orderBy] > a[orderBy]) {
    return 1
  }
  return 0
}

const SortTable = {
  getComparator: (order, orderBy) => {
    return order === 'desc'
      ? (a, b) => descendingComparator(a, b, orderBy)
      : (a, b) => -descendingComparator(a, b, orderBy)
  },
  stableSort: (array, comparator) => {
    const stabilizedThis = array.map((el, index) => [el, index])
    stabilizedThis.sort((a, b) => {
      const order = comparator(a[0], b[0])
      if (order !== 0) return order
      return a[1] - b[1]
    })
    return stabilizedThis.map(el => el[0])
  },
  searchTablePacientes: (array, search) => {
    const expedienteFilter = array.filter(element => {
      return (
        element.folio.toLowerCase().indexOf(search.toLowerCase()) !== -1 ||
        element.nombre.toLowerCase().indexOf(search.toLowerCase()) !== -1 ||
        element.apPaterno.toLowerCase().indexOf(search.toLowerCase()) !== -1 ||
        element.apMaterno.toLowerCase().indexOf(search.toLowerCase()) !== -1
      )
    })

    return expedienteFilter
  },
  searchTableAdmisiones: (array, search) => {
    const expedienteFilter = array.filter(element => {
      return (
        element.folio.toString().indexOf(search) !== -1 ||
        element.nombre.toLowerCase().indexOf(search.toLowerCase()) !== -1 ||
        element.primerApellido.toLowerCase().indexOf(search.toLowerCase()) !== -1 ||
        element.segundoApellido.toLowerCase().indexOf(search.toLowerCase()) !== -1
      )
    })

    return expedienteFilter
  },
  searchTableDoctores: (array, search) => {
    const idFilter = array.filter(element => {
      return (
        element.idDoctor.toString().indexOf(search) !== -1 ||
        element.nombre.toLowerCase().indexOf(search.toLowerCase()) !== -1 ||
        element.primerApellido.toLowerCase().indexOf(search.toLowerCase()) !== -1 ||
        element.apMaterno.toLowerCase().indexOf(search.toLowerCase()) !== -1
      )
    })

    return idFilter
  },
  searchTablePersonal: (array, search) => {
    const idFilter = array.filter(element => {
      return (
        element.idPersonal.toString().indexOf(search) !== -1 ||
        element.nombre.toLowerCase().indexOf(search.toLowerCase()) !== -1 ||
        element.primerApellido.toLowerCase().indexOf(search.toLowerCase()) !== -1 ||
        element.apMaterno.toLowerCase().indexOf(search.toLowerCase()) !== -1
      )
    })

    return idFilter
  },
}

export default SortTable
