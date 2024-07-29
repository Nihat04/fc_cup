import styles from "../AuthorizationPage.module.css";

import axios from "axios";
import { useState } from "react";

const RegistrationPage = () => {
    const [registrationData, setRegistrationData] = useState({});

    const updateAuthoriazationData = (propertyName: string, value: string) => {
        setRegistrationData({ ...registrationData, [propertyName]: value });
    };

    const register = async () => {
        const responseData = await axios
            .post("https://localhost:7295/accounts/register", registrationData)
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
                    <input
                        className={styles["login-form__input"]}
                        type="password"
                        placeholder="Подтверждение Пароля"
                        name="passwordConfirm"
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
                        onClick={() => register()}
                    >
                        Войти
                    </button>
                </div>
            </div>
        </>
    );
};

export default RegistrationPage;
