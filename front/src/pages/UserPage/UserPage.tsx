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
            console.log(logedUser)
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
                        <h2 className={styles['user__name']}>
                            {user?.displayName}
                        </h2>
                        <p className={styles['user__rating']}>
                            {`${user?.rating} очков рейтинга`}
                        </p>
                    </div>
                    <div>
                        {isLogedUserPage && (
                            <button className={globalStyles['btn']}>
                                Редактировать
                            </button>
                        )}
                    </div>
                </section>
                <section className={styles['user__comments']}>
                    <h4>История комментариев</h4>
                    <ul>
                        {user?.userComments.map((comment: any) => (
                            <Link  key={comment.id} to={`/forum/${comment.forumId}`}>
                                <li>
                                    <p>
                                        {
                                            comment.publishedDateTime.split(
                                                'T'
                                            )[0]
                                        }
                                    </p>
                                    <p>{comment.commentText}</p>
                                    <p>{comment.rating}</p>
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
