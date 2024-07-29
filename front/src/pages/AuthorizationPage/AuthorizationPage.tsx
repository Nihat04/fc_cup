import styles from "./AuthorizationPage.module.css";

import axios from "axios";

import { useState } from "react";

const AuthorizationPage = () => {
    const [authorizationData, setAuthorizationData] = useState({});

    const updateAuthoriazationData = (propertyName: string, value: string) => {
        setAuthorizationData({ ...authorizationData, [propertyName]: value });
    };

    const authorize = async () => {
        const responseData = await axios
            .post("https://localhost:7295/accounts/login", authorizationData)
            .then((res) => res.data);

        localStorage.setItem("tkId", responseData.token);
        localStorage.setItem("tkIdRc", responseData.refreshToken);
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
                <div className={styles['login-form__bottom-links']}>
                    <p>Забыли пароль? <a href="#">Восстановить</a></p>
                    <a href="#">Создать аккаунт</a>
                </div>
            </div>
        </>
    );
};

export default AuthorizationPage;
