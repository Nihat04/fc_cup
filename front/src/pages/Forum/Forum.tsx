import globalStyles from "../../App.module.css";
import styles from "./Forum.module.css";

import Header from "../../components/Header/Header";

import { useEffect, useRef, useState } from "react";
import { getForums, createForum } from "../../api/forum";
import { useNavigate } from "react-router-dom";
import { isLoged } from "../../api/user";
import classNames from "classnames";

const Forum = () => {
    const [newForumName, setNewForumName] = useState("");
    const [loged, setLoged] = useState(false);
    const [forums, setForums] = useState([]);
    const navigate = useNavigate();
    const modalRef = useRef(null);

    useEffect(() => {
        getForums().then((res) => setForums(res));

        isLoged().then((response) => setLoged(response));
    }, []);

    async function createForumBtn(): void {
        await createForum(newForumName);

        setNewForumName("");
        modalRef.current.close();
    }

    return (
        <>
            <Header />
            <main>
                <div className={globalStyles["container"]}>
                    <section className={styles["forum"]}>
                        <div className={styles["forum__top"]}>
                            <h1 className={styles["forum__top__header"]}>
                                Форум
                            </h1>
                            {loged && (
                                <button
                                    className={classNames(
                                        globalStyles["big-interaction-btn"],
                                        styles["forum__top__create-btn"]
                                    )}
                                    onClick={() => modalRef.current.showModal()}
                                >
                                    Создать
                                </button>
                            )}
                        </div>
                        <ul className={styles["forum__threads"]}>
                            {forums.map((forumEl) => (
                                <li
                                    key={forumEl.id}
                                    className={styles["forum__thread"]}
                                    onClick={() => navigate(`./${forumEl.id}`)}
                                >
                                    <p
                                        className={
                                            styles["forum__thread__title"]
                                        }
                                    >
                                        {forumEl.title}
                                    </p>
                                    <p
                                        className={
                                            styles["forum__thread__small-info"]
                                        }
                                    >
                                        {
                                            forumEl.publishedDateTime.split(
                                                "T"
                                            )[0]
                                        }
                                    </p>
                                </li>
                            ))}
                        </ul>
                    </section>
                </div>
            </main>
            <dialog
                className={classNames(globalStyles["modal"], styles["modal"])}
                ref={modalRef}
                onClick={(e) => {
                    const rect = e.target.getBoundingClientRect();

                    if (
                        rect.left > e.clientX ||
                        rect.right < e.clientX ||
                        rect.top > e.clientY ||
                        rect.bottom < e.clientY
                    ) {
                        e.target.close();
                    }
                }}
            >
                <div className={styles["modal__container"]}>
                    <h3>Саздание треда</h3>
                    <input
                        className={styles["modal__input"]}
                        type="text"
                        placeholder="Название"
                        onChange={(e) => setNewForumName(e.target.value)}
                    />
                    <button
                        className={classNames(
                            globalStyles["big-interaction-btn"],
                            styles["modal__btn"]
                        )}
                        onClick={() => createForumBtn()}
                    >
                        Создать
                    </button>
                </div>
            </dialog>
        </>
    );
};

export default Forum;
