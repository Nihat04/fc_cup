import globalStyles from '../../App.module.css';
import styles from './ForumPage.module.css';

import Header from '../../components/Header/Header';

import { useEffect, useRef, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import classNames from 'classnames';
import { useSelector } from 'react-redux';

import { getForums, createForum } from '../../api/forum';
import { RootState } from '../../store/store';
import { forumShort as forumObject } from '../../api/forum';

const Forum = () => {
    const [newForumName, setNewForumName] = useState('');
    const [forums, setForums] = useState([]);
    const navigate = useNavigate();
    const modalRef = useRef(null);
    const userLoged = useSelector((state: RootState) => state.user.logedIn);

    useEffect(() => {
        getForums().then((res) => setForums(res));
    }, []);

    async function createForumBtn(): Promise<void> {
        await createForum(newForumName);

        setNewForumName('');
        modalRef.current.close();
    }

    return (
        <>
            <Header />
            <main className={globalStyles['main']}>
                    <section className={styles['forum']}>
                        <div className={styles['forum__top']}>
                            <h1 className={styles['forum__top__header']}>Форум</h1>
                            {userLoged && (
                                <button
                                    className={classNames(globalStyles['big-btn'], styles['forum__top__create-btn'])}
                                    onClick={() => modalRef.current.showModal()}
                                >
                                    Создать
                                </button>
                            )}
                        </div>
                        <ul className={styles['forum__threads']}>
                            {forums.map((forumEl: forumObject) => (
                                <li key={forumEl.id} className={styles['forum__thread']} onClick={() => navigate(`./${forumEl.id}`)}>
                                    <div className={styles['']}>
                                        <p className={styles['forum__thread__title']}>{forumEl.title}</p>
                                        <p className={styles['forum__thread__author']}>
                                            <span className={styles['forum__thread__author-prefix']}>by </span>
                                            {forumEl.authorDisplayName}
                                        </p>
                                    </div>
                                    <div className={styles['forum__thread__info']}>
                                        <p
                                            className={classNames(
                                                styles['forum__thread__info__paragraph'],
                                                styles['forum__thread__info__comments']
                                            )}
                                        >
                                            {forumEl.numberOfComments}
                                        </p>
                                        <p className={styles['forum__thread__info__paragraph']}>
                                            {forumEl.publishedDateTime.split('T')[0]}
                                        </p>
                                    </div>
                                </li>
                            ))}
                        </ul>
                    </section>
            </main>
            <dialog
                className={classNames(globalStyles['modal'], styles['modal'])}
                ref={modalRef}
                onClick={(e) => {
                    const rect = e.target.getBoundingClientRect();

                    if (rect.left > e.clientX || rect.right < e.clientX || rect.top > e.clientY || rect.bottom < e.clientY) {
                        e.target.close();
                    }
                }}
            >
                <div className={styles['modal__container']}>
                    <h3>Саздание треда</h3>
                    <input
                        className={styles['modal__input']}
                        type="text"
                        placeholder="Название"
                        onChange={(e) => setNewForumName(e.target.value)}
                    />
                    <button className={classNames(globalStyles['big-btn'], styles['modal__btn'])} onClick={() => createForumBtn()}>
                        Создать
                    </button>
                </div>
            </dialog>
        </>
    );
};

export default Forum;
