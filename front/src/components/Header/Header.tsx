import styles from './Header.module.css';

import logo from '../../assets/svg/logo.svg';
import logoutIcon from '../../assets/svg/logout-icon.svg';
import { RootState } from '../../store/store';
import { logoutUser } from '../../store/user/userSlice';

import { Link } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';

type navigationLink = { label: string; link: string };

const NAVIGATION_LINKS: navigationLink[] = [
    {
        label: 'Матчи',
        link: '/matches',
    },
    {
        label: 'Исходы',
        link: '/results',
    },
    {
        label: 'Турниры',
        link: '/tournaments',
    },
    {
        label: 'Статистика',
        link: '/stats',
    },
    {
        label: 'Форум',
        link: '/forum',
    },
];

const Header = () => {
    const userLoged = useSelector((state: RootState) => state.user.logedIn);
    const user = useSelector((state: RootState) => state.user.user);
    const dispatch = useDispatch();

    const logout = () => {
        dispatch(logoutUser());
        localStorage.removeItem('tkId');
        localStorage.removeItem('tkIdRc');
    };

    return (
        <header className={styles['header']}>
            <div className={styles['container']}>
                <a className={styles['header__logo__link']} href="/">
                    <img className={styles['header__logo']} src={logo} alt="логотип" />
                </a>
                <nav className={styles['haeder__nav']}>
                    <ul className={styles['header__nav__list']}>
                        {NAVIGATION_LINKS.map((navEl, index) => (
                            <li className={styles['header__nav__list__item']} key={index}>
                                <Link to={navEl.link}>{navEl.label}</Link>
                            </li>
                        ))}
                    </ul>
                </nav>
                <div className={styles['header__right']}>
                    <input className={styles['header__right__search-input']} type="text" placeholder="Искать..." />
                    {userLoged ? (
                        <div className={styles['header__right__user']}>
                            <Link to={`/user/${user!.id}`} className={styles['header__right__user__username']}>
                                {user!.displayName}
                            </Link>
                            <button className={styles['header__right__user__logout-btn']} onClick={() => logout()}>
                                <img className={styles['header__right__user__logout-btn__icon']} src={logoutIcon} alt="Выйтий из профиля" />
                            </button>
                        </div>
                    ) : (
                        <div className={styles['header__right__auths']}>
                            <span className={styles['header__right__auth__links']}>
                                <a href="/auth">Войти</a> | <a href="/register">Регистрация</a>
                            </span>
                        </div>
                    )}
                </div>
            </div>
        </header>
    );
};

export default Header;
