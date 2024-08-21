import styles from './Comment.styles.css';

const Comment = (props: { commentId: number }) => {
    const { commentId } = props;

    return (
        <div>
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
                        className={classNames(styles['forum__comments__item__vote__btn'], styles['forum__comments__item__vote__btn-down'])}
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
        </div>
    );
};

export default Comment;
