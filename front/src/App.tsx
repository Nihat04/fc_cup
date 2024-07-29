import "./App.module.css";

import { useState } from "react";
import { Routes, Route } from "react-router-dom";

import PlayerPage from "./pages/PlayerPage/PlayerPage";
import Header from "./components/Header/Header";
import MainPage from "./pages/MainPage/MainPage";

function App() {
    return (
        <>
            <Header />
            <Routes>
                <Route path="/" element={<MainPage />} />
                <Route path="/player/:id/" element={<PlayerPage />} />
            </Routes>
        </>
    );
}

export default App;
