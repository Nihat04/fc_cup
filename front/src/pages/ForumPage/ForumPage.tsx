import globalStyles from '../../App.module.css';
import styles from './ForumPage.module.css';

import { useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';

import { comment, DownVoteComment, getForum, getForumComments, postComment, upVoteComment } from '../../api/forum';
import { forum } from '../../api/forum';

import Header from '../../components/Header/Header';
import classNames from 'classnames';

const ForumItemPage = () => {
    const { id } = useParams();

    const [forumInfo, setForumInfo] = useState<forum>();
    const [forumComment, setForumComment] = useState('');
    const [forumComments, setForumComments] = useState<comment[]>([]);

    const postCommentAction = async () => {
        if (!forumComment) return;

        await postComment({ forumId: forumInfo?.id, comment: forumComment });
        await getForumComments(id, 1).then((res) => setForumComments(res));
        setForumComment('');
    };

    const voteComment = async (voteFunc: Function, commentId: number) => {
        await voteFunc(commentId);
        await getForumComments(id, 1).then((res) => setForumComments(res));
    };

    useEffect(() => {
        getForum(id).then((res) => setForumInfo(res));
        getForumComments(id, 1).then((res) => setForumComments(res));
    }, []);

    return (
        <>
            <Header />
            <main className={globalStyles['main']}>
                <section className={styles['forum']}>
                    <div className={styles['forum__header']}>
                        <div className={styles['forum__header__top']}>
                            <p className={styles['forum__small-text']}>
                                <b>{forumInfo?.authorDisplayName}</b>
                            </p>
                            <p className={styles['forum__small-text']}>{forumInfo?.publishedDateTime.split('T')[0]}</p>
                        </div>
                        <h3 className={styles['forum__header__header']}>{forumInfo?.title}</h3>
                    </div>
                    <div className={styles['forum__body']}>{forumInfo?.body}</div>
                </section>
                <section className={styles['forum__comments']}>
                    <div className={styles['forum__comments__top']}>
                        <textarea
                            className={styles['forum__comments__input']}
                            placeholder="Комментарий"
                            value={forumComment}
                            onChange={(e) => setForumComment(e.target.value)}
                        />
                        <button
                            className={classNames(styles['forum__comments__btn'], {
                                [styles['forum__comments__btn-active:hover']]: forumComment,
                                [styles['forum__comments__btn-disabled']]: !forumComment,
                            })}
                            onClick={() => postCommentAction()}
                        >
                            Прокомментировать
                        </button>
                    </div>
                    <ul className={styles['forum__comments__list']}>
                        {forumComments
                            .sort((commentEl1, commentEl2) => commentEl2.rating - commentEl1.rating)
                            .map((commentEl) => (
                                <li className={styles['forum__comments__item']} key={commentEl.id}>
                                    <div className={styles['forum__comments__item__top']}>
                                        <p className={styles['forum__small-text']}>{commentEl.authorId}</p>
                                        <p className={styles['forum__small-text']}>{commentEl.publishedDateTime.split('T')[0]}</p>
                                    </div>
                                    <div className={styles['forum__comments__item__bottom']}>
                                        <div className="">
                                            <p className={styles['forum__comments__item__body']}>{commentEl.commentText}</p>
                                            <button className={styles['forum__comments__item__btn']}>Ответить</button>
                                            <button className={styles['forum__comments__item__btn']}>Показать ответы</button>
                                        </div>
                                        <div className={styles['forum__comments__item__vote']}>
                                            <button
                                                className={classNames(styles['forum__comments__item__vote__btn'])}
                                                onClick={() => voteComment(upVoteComment, commentEl.id)}
                                            ></button>
                                            <p className={styles['forum__comments__item__vote__paragr']}>{commentEl.rating}</p>
                                            <button
                                                className={classNames(
                                                    styles['forum__comments__item__vote__btn'],
                                                    styles['forum__comments__item__vote__btn-down']
                                                )}
                                                onClick={() => voteComment(DownVoteComment, commentEl.id)}
                                            ></button>
                                        </div>
                                    </div>
                                    <div className={styles['forum__comments__item__reply']}>
                                        <textarea className={styles['forum__comments__item__reply__input']} />
                                        <div className={styles['forum__comments__item__reply__btns']}>
                                            <button className={styles['forum__comments__item__reply__btn']}>Отмена</button>
                                            <button className={styles['forum__comments__item__reply__btn']}>Ответить</button>
                                        </div>
                                    </div>
                                </li>
                            ))}
                    </ul>
                </section>
            </main>
        </>
    );
};

export default ForumItemPage;
