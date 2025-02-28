import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './SolicitarPrestamo.css'; 

const SolicitarPrestamo = () => {
    const [monto, setMonto] = useState('');
    const [prestamos, setPrestamos] = useState([]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        const token = localStorage.getItem('token');
        try {
            await axios.post('http://localhost:5108/api/prestamos/solicitar', { monto }, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
            setMonto(''); 
            fetchPrestamos(); 
        } catch (error) {
            console.error("Error al solicitar préstamo:", error);
        }
    };

    const fetchPrestamos = async () => {
        const token = localStorage.getItem('token');
        try {
            const response = await axios.get('http://localhost:5108/api/prestamos', {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
            setPrestamos(response.data);
        } catch (error) {
            console.error("Error al obtener préstamos:", error);
        }
    };

    useEffect(() => {
        fetchPrestamos(); 
    }, []);

    return (
        <div className="solicitar-prestamo-container">
            <h2>Solicitar Préstamo</h2>
            <form onSubmit={handleSubmit}>
                <label htmlFor="monto">Monto</label>
                <input
                    type="number"
                    id="monto"
                    placeholder="Ingrese el monto"
                    value={monto}
                    onChange={(e) => setMonto(e.target.value)}
                    required
                />
                <button type="submit">Solicitar</button>
            </form>

            <h3>Mis Préstamos</h3>
            <ul>
                {prestamos.map((prestamo, index) => (
                    <li key={index}>
                        Monto: ${prestamo.monto} - Estado: {prestamo.estado}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default SolicitarPrestamo;
