import React, { useEffect, useState } from 'react';
import axios from 'axios';

const EstadoPrestamos = () => {
    const [prestamos, setPrestamos] = useState([]);

    useEffect(() => {
        const fetchPrestamos = async () => {
            const token = localStorage.getItem('token');
            const response = await axios.get('http://localhost:5108/api/prestamos/estado/1', { // Cambia el ID según sea necesario
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
            setPrestamos(response.data);
        };
        fetchPrestamos();
    }, []);

    return (
        <div>
            <h2>Estado de Préstamos</h2>
            <ul>
                {prestamos.map(prestamo => (
                    <li key={prestamo.id}>{prestamo.monto} - {prestamo.estado}</li>
                ))}
            </ul>
        </div>
    );
};

export default EstadoPrestamos;