import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { AuthProvider } from './context/AuthContext';
import Login from './components/Login';
import SolicitarPrestamo from './components/SolicitarPrestamo';
import EstadoPrestamos from './components/EstadoPrestamos';

const App = () => {
    return (
        <AuthProvider>
            <Router>
                <Routes>
                    <Route path="/" element={<Login />} />
                    <Route path="/solicitar" element={<SolicitarPrestamo />} />
                    <Route path="/estado" element={<EstadoPrestamos />} />
                </Routes>
            </Router>
        </AuthProvider>
    );
};

export default App;