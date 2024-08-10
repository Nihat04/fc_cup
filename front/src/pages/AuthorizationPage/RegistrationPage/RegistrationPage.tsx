import styles from '../AuthorizationPage.module.css';

import axios from 'axios';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const RegistrationPage = () => {
    const [registrationData, setRegistrationData] = useState({ firstName: '', lastName: '' });
    const navigate = useNavigate();

    const updateAuthoriazationData = (propertyName: string, value: string) => {
        setRegistrationData({ ...registrationData, [propertyName]: value });
    };

    const register = async (e: React.FormEvent<HTMLInputElement>) => {
        e.preventDefault();
        console.log(registrationData);

        if (registrationData.password !== registrationData.passwordConfirm) {
            console.log('passwords are different');
            return;
        }

        await axios
            .post('https://localhost:7295/accounts/register', registrationData)
            .then((response) => response.data)
            .then((data) => {
                localStorage.setItem('tkId', data.token);
                localStorage.setItem('tkIdRc', data.refreshToken);
            });

        navigate(-1);
    };

    return (
        <>
            <form className={styles['login-form']}>
                <h2 className={styles['login-form__header']}>РЕГИСТРАЦИЯ</h2>
                <div className={styles['login-form__inputs']}>
                    <input
                        className={styles['login-form__input']}
                        type="text"
                        placeholder="Никнейм"
                        name="displayName"
                        onChange={(e) => updateAuthoriazationData(e.target.name, e.target.value)}
                        required
                    />
                    <input
                        className={styles['login-form__input']}
                        type="text"
                        placeholder="Почта"
                        name="email"
                        onChange={(e) => updateAuthoriazationData(e.target.name, e.target.value)}
                        required
                    />
                    <input
                        className={styles['login-form__input']}
                        type="password"
                        placeholder="Пароль"
                        name="password"
                        onChange={(e) => updateAuthoriazationData(e.target.name, e.target.value)}
                        required
                    />
                    <input
                        className={styles['login-form__input']}
                        type="password"
                        placeholder="Подтверждение Пароля"
                        name="passwordConfirm"
                        onChange={(e) => updateAuthoriazationData(e.target.name, e.target.value)}
                        required
                    />
                </div>
                <div className={styles['login-form__btns']}>
                    <button className={styles['login-form__btn']} onClick={(e) => register(e)}>
                        Создать
                    </button>
                </div>
            </form>
        </>
    );
};

export default RegistrationPage;
