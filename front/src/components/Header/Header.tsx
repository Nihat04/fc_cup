import globalStyles from "../../App.module.css";
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
        {
            label: "Форум",
            link: "/forum",
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
                <div className={styles["header__right"]}>
                    <input
                        className={styles["header__right__search-input"]}
                        type="text"
                        placeholder="Искать..."
                    />
                    <div className={styles["header__right__auths"]}>
                        <span className={styles["header__right__auth__input"]}>
                            <a href="/auth">Войти</a> |{" "}
                            <a href="/register">Регистрация</a>
                        </span>
                    </div>
                </div>
            </div>
        </header>
    );
};

export default Header;
