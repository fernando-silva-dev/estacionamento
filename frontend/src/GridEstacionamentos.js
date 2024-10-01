import './App.css';
import React, { useEffect, useState } from "react";
import api from './api.ts';
import Button from '@mui/material/Button';
import AddIcon from '@mui/icons-material/Add';
import { DataGrid, GridActionsCellItem, GridToolbarContainer, } from '@mui/x-data-grid';
import ExitToAppIcon from '@mui/icons-material/ExitToApp';

export default function GridEstacionamentos() {
    // TODO style
    const columns = [
        { field: 'horaEntrada', headerName: 'Entrada', width: 200 },
        { field: 'horaSaida', headerName: 'Saída', width: 200 },
        { field: 'placa', headerName: 'Placa', width: 200 },
        { field: 'horasCobradas', headerName: 'Tempo cobrado (horas)', width: 200 },
        { field: 'valorTotal', headerName: 'Valor a pagar', width: 200 },
        {
            field: 'actions',
            type: 'actions',
            headerName: '',
            width: 100,
            getActions: ({ id, row }) => {
                const { horaSaida } = row;
                if (horaSaida)
                    return [];
                return [
                    <GridActionsCellItem
                        icon={<ExitToAppIcon />}
                        label="Marcar saída"
                        sx={{
                            color: 'primary.main',
                        }}
                        onClick={async () => marcarSaida(id)}
                    />,
                ];
            },
        }


    ];

    const [estacionamentos, setEstacionamentos] = useState([]);

    const getEstacionamentos = async () => {
        const { data } = await api.get('Estacionamento');
        setEstacionamentos(data);
    };

    useEffect(() => {
        getEstacionamentos();
    }, []);

    // TODO
    const marcarSaida = async (id) => {
        await api.patch(`Estacionamento/${id}`, { horaSaida: new Date() });
    }

    const marcarEntrada = async (placa) => {
        await api.post('Estacionamento', { horaEntrada: new Date(), placa: placa });
    }

    const Toolbar = () => {
        const handleClick = () => {
            // TODO
            marcarEntrada('aaa-1234');
        };

        return (
            <GridToolbarContainer>
                <Button color="primary" startIcon={<AddIcon />} onClick={handleClick}>
                    Add
                </Button>
            </GridToolbarContainer>
        );
    }

    return <DataGrid
        columns={columns}
        rows={estacionamentos}
        slots={{
            toolbar: Toolbar,
        }} />;
}
