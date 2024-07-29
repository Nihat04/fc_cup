import "./App.module.css";

import { Routes, Route } from "react-router-dom";

import PlayerPage from "./pages/PlayerPage/PlayerPage";
import MainPage from "./pages/MainPage/MainPage";
import AuthorizationPage from "./pages/AuthorizationPage/AuthorizationPage";
import RegistrationPage from "./pages/AuthorizationPage/RegistrationPage/RegistrationPage";
import Forum from "./pages/Forum/Forum";

function App() {
    return (
        <>
            <Routes>
                <Route path="/" element={<MainPage />} />
                <Route path="/player/:id/" element={<PlayerPage />} />
                <Route path="/forum" element={<Forum />} />
                <Route path="/auth" element={<AuthorizationPage />} />
                <Route path="/register" element={<RegistrationPage />} />
            </Routes>
        </>
    );
}

export default App;
