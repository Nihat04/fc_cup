import React from "react";
import styles from "./Header.module.css";
import logo from "../../assets/svg/logo.svg";
import { Link } from "react-router-dom";

const Header = () => {
    const navLinks = [
        {
            label: "Новости",
            link: "/news",
        },
        {
            label: "Матчи",
            link: "/matches",
        },
        {
            label: "Исходы",
            link: "/results",
        },
        {
            label: "Турниры",
            link: "/tournaments",
        },
        {
            label: "Статистика",
            link: "/stats",
        },
    ];

    return (
        <header className={styles["header"]}>
            <img
                className={styles["header__logo"]}
                src={logo}
                alt="логотип кубка фиферов"
            />
            <nav className={styles["haeder__nav"]}>
                <ul className={styles["header__nav__list"]}>
                    {navLinks.map((navEl) => (
                        <li className={styles["header__nav__list__item"]}>
                            <Link to={navEl.link}>{navEl.label}</Link>
                        </li>
                    ))}
                </ul>
            </nav>
            <div className={styles["header__search--wrapper"]}>
                <input className={styles["header__search__input"]} type="text" placeholder="Искать..." />
            </div>
        </header>
    );
};

export default Header;
