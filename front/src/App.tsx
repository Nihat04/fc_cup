import { useState } from "react";
import "./App.module.css";
import { Routes, Route } from "react-router-dom";
import PlayerPage from "./pages/PlayerPage/PlayerPage";
import Header from "./components/Header/Header";

function App() {
    return (
        <>
            <Header />
            <Routes>
                <Route path="/player/:id/" element={<PlayerPage />} />
            </Routes>
        </>
    );
}

export default App;