import './App.css';
import React, { useEffect, useState } from "react";
import api from './api.ts';
import Button from '@mui/material/Button';
import AddIcon from '@mui/icons-material/Add';
import { DataGrid, GridActionsCellItem, GridToolbarContainer, } from '@mui/x-data-grid';
import ExitToAppIcon from '@mui/icons-material/ExitToApp';
import { Input } from '@mui/material';

const Toolbar = ({ onSuccess }) => {
    const handleClick = () => {
        marcarEntrada(placa);
        setPlaca('');
    };

    const marcarEntrada = (placa) => {
        api.post('Estacionamento', { horaEntrada: new Date(), placa: placa }).then(onSuccess);
    }

    const [placa, setPlaca] = useState("");

    return (
        <GridToolbarContainer style={{ padding: 20 }}>
            <Input key={'placa'} value={placa} onChange={event => setPlaca(event.target.value)} />
            <Button color="primary" startIcon={<AddIcon />} onClick={handleClick}>
                Add
            </Button>
        </GridToolbarContainer>
    );
}

export default function GridEstacionamentos() {
    const columns = [
        {
            field: 'horaEntrada', headerName: 'Entrada', width: 200,
            valueFormatter: (value) => {
                return `${new Date(value).toLocaleString()}`;
            },
        },
        {
            field: 'horaSaida', headerName: 'Saída', width: 200,
            valueFormatter: (value) => {
                if (value == null) {
                    return '';
                }
                return `${new Date(value).toLocaleString()}`;
            },
        },
        { field: 'placa', headerName: 'Placa', width: 200 },
        { field: 'horasCobradas', headerName: 'Tempo cobrado (horas)', width: 200 },
        {
            field: 'valorTotal', headerName: 'Valor a pagar', width: 200,
            valueFormatter: (value) => {
                if (value == null) {
                    return '';
                }
                return `R$ ${value.toFixed(2)}`;
            },
        },
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

    const marcarSaida = async (id) => {
        await api.patch(`Estacionamento/${id}`, new Date());
        getEstacionamentos();
    }

    return <DataGrid
        columns={columns}
        rows={estacionamentos}
        slots={{
            toolbar: () => <Toolbar onSuccess={getEstacionamentos} />,
        }}
    />;
}
