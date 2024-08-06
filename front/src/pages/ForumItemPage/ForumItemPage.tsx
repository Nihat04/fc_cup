import globalStyles from '../../App.module.css';
import styles from './ForumItemPage.module.css';

import { useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';

import { getForum } from '../../api/forum';
import { forum } from '../../api/forum';

import Header from '../../components/Header/Header';

const ForumItemPage = () => {
    const { id } = useParams();
    const [forumThread, setForumThread] = useState<forum>({});

    useEffect(() => {
        getForum(id).then((res) => setForumThread(res));
    }, []);

    return (
        <>
            <Header />
            <main className={globalStyles['main']}>
                <section className={styles['thread__header']}>
                    <p className={styles['thread__header__author']}>{forumThread.authorId}</p>
                    <h3>{forumThread.commentText}</h3>
                </section>
                <section className={styles['forum-thread__comments']}>
                    <form action="#">
                        <input type="text" />
                        <button>Прокомментировать</button>
                    </form>
                    <ul></ul>
                </section>
            </main>
        </>
    );
};

export default ForumItemPage;
