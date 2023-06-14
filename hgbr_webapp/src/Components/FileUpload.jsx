import axios from 'axios';//este componente es para mandar el archivoal servidor
import React, { useState } from 'react';
import {Button} from '@material-ui/core';
import { CloudUploadOutlined } from '@material-ui/icons';
import { Alert } from '@mui/material';
import useStyles from '../Styles/formularioStyles';

const FileUpload = () => {
  const [selectedFile, setSelectedFile] = useState(null);
  const [dragging, setDragging] = useState(false);
  const style = useStyles();

  const handleFileChange = (event) => {
    setSelectedFile(event.target.files[0]);
  };

  const handleUpload = () => {
    // Aquí se puede realizar acciones con el archivo seleccionado, como enviarlo a un servidor
    if (selectedFile) {
      console.log('Archivo seleccionado:', selectedFile);
      // Aquí va la lógica para enviar el archivo al servidor

      <Alert variant="filled" severity="success" sx={{ width: '100%' }}>
          Se ha subido el archivo
      </Alert>
    }
  };

  const handleDragEnter = (event) => {
    event.preventDefault();
    setDragging(true);
  };

  const handleDragLeave = (event) => {
    event.preventDefault();
    setDragging(false);
  };

  const handleDragOver = (event) => {
    event.preventDefault();
  };

  const handleDrop = (event) => {
    event.preventDefault();
    setDragging(false);
    const file = event.dataTransfer.files[0];
    setSelectedFile(file);
  };

  return (
    <div
      onDragEnter={handleDragEnter}
      onDragLeave={handleDragLeave}
      onDragOver={handleDragOver}
      onDrop={handleDrop}
    >
      <input type="file" onChange={handleFileChange} />
      <Button
          variant="contained"
          type="submit"
          size="small"
          onClick={handleUpload}
          startIcon={<CloudUploadOutlined />}
        >
          Subir archivo
        </Button>
      {selectedFile && <p>Archivo seleccionado: {selectedFile.name}</p>}
    </div>
  );
};

export default FileUpload;
