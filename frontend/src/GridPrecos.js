import './App.css';
import React, { useEffect, useState } from "react";
import api from './api.ts';
import Button from '@mui/material/Button';
import AddIcon from '@mui/icons-material/Add';
import {
  DataGrid,
  GridToolbarContainer,
} from '@mui/x-data-grid';

const Toolbar = () => {
  const handleClick = () => {
    alert('Não implementei cadastro, é igual o cadastro do outro grid');
  };

  return (
    <GridToolbarContainer style={{ padding: 20 }}>
      <Button color="primary" startIcon={<AddIcon />} onClick={handleClick}>
        Add
      </Button>
    </GridToolbarContainer>
  );
}

export default function GridPrecos() {
  const columns = [
    {
      field: 'inicioVigencia', headerName: 'Início da vigência', width: 200,
      valueFormatter: (value) => {
        return `${new Date(value).toLocaleDateString()}`;
      },
    },
    {
      field: 'fimVigencia', headerName: 'Fim da vigência', width: 200,
      valueFormatter: (value) => {
        return `${new Date(value).toLocaleDateString()}`;
      },
    },
    { field: 'horaInicial', headerName: 'Valor da hora inicial', width: 200 },
    { field: 'horaAdicional', headerName: 'Valor da hora adicional', width: 200 },
  ];

  const [precos, setPrecos] = useState([]);

  const getPrecos = async () => {
    const { data } = await api.get('Preco');
    setPrecos(data);
  };
  useEffect(() => {
    getPrecos();
  }, []);

  return <DataGrid
    columns={columns}
    rows={precos}
    slots={{
      toolbar: Toolbar,
    }}
  />;
}
