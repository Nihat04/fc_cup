import styles from "./AuthorizationPage.module.css";

import axios from "axios";

import { useState } from "react";
import { useNavigate } from "react-router-dom";

const AuthorizationPage = () => {
    const [authorizationData, setAuthorizationData] = useState({});
    const navigate = useNavigate();

    const updateAuthoriazationData = (propertyName: string, value: string) => {
        setAuthorizationData({ ...authorizationData, [propertyName]: value });
    };

    const authorize = async () => {
        await axios
            .post("https://localhost:7295/accounts/login", authorizationData)
            .then((response) => response.data)
            .then((data) => {
                localStorage.setItem("tkId", data.token);
                localStorage.setItem("tkIdRc", data.refreshToken);
            });

        navigate(-1);
    };

    return (
        <>
            <div className={styles["login-form"]}>
                <h2 className={styles["login-form__header"]}>АВТОРИЗАЦИЯ</h2>
                <div className={styles["login-form__inputs"]}>
                    <input
                        className={styles["login-form__input"]}
                        type="text"
                        placeholder="Почта"
                        name="email"
                        onChange={(e) =>
                            updateAuthoriazationData(
                                e.target.name,
                                e.target.value
                            )
                        }
                    />
                    <input
                        className={styles["login-form__input"]}
                        type="password"
                        placeholder="Пароль"
                        name="password"
                        onChange={(e) =>
                            updateAuthoriazationData(
                                e.target.name,
                                e.target.value
                            )
                        }
                    />
                </div>
                <div className={styles["login-form__btns"]}>
                    <button
                        className={styles["login-form__btn"]}
                        onClick={() => authorize()}
                    >
                        Войти
                    </button>
                </div>
                <div className={styles["login-form__bottom-links"]}>
                    <p>
                        Забыли пароль? <a href="#">Восстановить</a>
                    </p>
                    <a href="/register">Создать аккаунт</a>
                </div>
            </div>
        </>
    );
};

export default AuthorizationPage;
