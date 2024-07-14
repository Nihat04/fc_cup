import React from "react";
import styles from "./Header.module.css";
import globalStyles from "../../App.module.css";
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
            <div className={styles["container"]}>
                <a className={styles["header__logo__link"]} href="/">
                    <img
                        className={styles["header__logo"]}
                        src={logo}
                        alt="логотип кубка фиферов"
                    />
                </a>
                <nav className={styles["haeder__nav"]}>
                    <ul className={styles["header__nav__list"]}>
                        {navLinks.map((navEl, index) => (
                            <li
                                className={styles["header__nav__list__item"]}
                                key={index}
                            >
                                <Link to={navEl.link}>{navEl.label}</Link>
                            </li>
                        ))}
                    </ul>
                </nav>
                <div className={styles["header__search--wrapper"]}>
                    <input
                        className={styles["header__search__input"]}
                        type="text"
                        placeholder="Искать..."
                    />
                </div>
            </div>
        </header>
    );
};

export default Header;
