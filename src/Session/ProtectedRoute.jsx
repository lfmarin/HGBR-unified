import React, { Fragment } from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import Login from './Login';


const ProtectedRoute = () => {

  const checkValidToken = () => {
    const token = localStorage.getItem('jwtToken');

	return token !== null && token.length !== 0 && token !== ""
  }
  
  return checkValidToken ? <Outlet /> : <Login />
}

export default ProtectedRoute
