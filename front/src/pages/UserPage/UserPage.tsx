import globalStyles from '../../App.module.css';
import styles from './userPage.module.css';

import { RootState } from '../../store/store';
import { user } from '../../api/user';

import { Link, useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';

import Header from '../../components/Header/Header';

const UserPage = () => {
    const { id } = useParams();
    const logedUser = useSelector((state: RootState) => state.user.user);

    const isLogedUserPage = logedUser?.id == id;

    const [user, setUser] = useState<user | null>(null);

    useEffect(() => {
        if (isLogedUserPage) {
            setUser(logedUser);
            console.log(logedUser);
            return;
        }

        //get user by ID
    }, [logedUser]);

    return (
        <>
            <Header />
            <main className={globalStyles['container']}>
                <section className={styles['user']}>
                    <div>
                        <h2 className={styles['user__name']}>{user?.displayName}</h2>
                        <div className={styles['user__data']}>
                            <p className={styles['']}>
                                <strong>{user?.rating}</strong>
                                {` очков рейтинга`}
                            </p>
                            <p className={styles['']}>
                                {`дата регистрации: `}
                                <b>{user?.registrationDateTime.split('T')[0]}</b>
                            </p>
                        </div>
                    </div>
                    <div>{isLogedUserPage && <button className={globalStyles['btn']}>Редактировать</button>}</div>
                </section>
                <section className={styles['user-comments']}>
                    <h4 className={styles['user-comments__header']}>История комментариев</h4>
                    <ul className={styles['user-comments__list']}>
                        {user?.userComments.map((comment: any) => (
                            <Link key={comment.id} to={`/forum/${comment.forumId}`}>
                                <li className={styles['user-comments__item']}>
                                    <div className={styles['user__comments__item__header']}>
                                        <p>{comment.publishedDateTime.split('T')[0]}</p>
                                        <p>{comment.rating}</p>
                                    </div>
                                    <p>{comment.commentText}</p>
                                </li>
                            </Link>
                        ))}
                    </ul>
                </section>
            </main>
        </>
    );
};

export default UserPage;
