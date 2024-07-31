import './App.module.css';

import { Routes, Route, Navigate } from 'react-router-dom';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../src/store/store';

import { getLogedUser } from './api/user';
import { loginUser } from './store/user/userSlice';

import PlayerPage from './pages/PlayerPage/PlayerPage';
import MainPage from './pages/MainPage/MainPage';
import AuthorizationPage from './pages/AuthorizationPage/AuthorizationPage';
import RegistrationPage from './pages/AuthorizationPage/RegistrationPage/RegistrationPage';
import Forum from './pages/Forum/Forum';
import UserPage from './pages/UserPage/UserPage';

type page = {
    path: string;
    pageComponent: JSX.Element;
};

function App() {
    const isLogedIn = useSelector((state: RootState) => state.user.logedIn);
    const dispatch = useDispatch();

    const unauthorizedRoutes: page[] = [
        { path: '/auth', pageComponent: <AuthorizationPage /> },
        { path: '/register', pageComponent: <RegistrationPage /> },
    ];

    const authorizedRoutes: page[] = [
        { path: '/me', pageComponent: <UserPage /> },
    ];

    const publicRoutes: page[] = [
        { path: '/', pageComponent: <MainPage /> },
        { path: '/player/:id/', pageComponent: <PlayerPage /> },
        { path: '/forum', pageComponent: <Forum /> },
        { path: '/user/:id', pageComponent: <UserPage /> },
    ];

    useEffect(() => {
        getLogedUser()
            .then((user) => dispatch(loginUser(user)))
            .catch((err) => '');
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    return (
        <>
            <Routes>
                {publicRoutes.map((route, index) => (
                    <Route
                        key={index}
                        path={route.path}
                        element={route.pageComponent}
                    />
                ))}
                {isLogedIn
                    ? authorizedRoutes.map((route, index) => (
                          <Route
                              key={index}
                              path={route.path}
                              element={route.pageComponent}
                          />
                      ))
                    : unauthorizedRoutes.map((route, index) => (
                          <Route
                              key={index}
                              path={route.path}
                              element={route.pageComponent}
                          />
                      ))}
                <Route path="*" element={<Navigate to={'/'} replace />} />
            </Routes>
        </>
    );
}

export default App;
