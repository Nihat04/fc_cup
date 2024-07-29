import globalStyles from "../../App.module.css";
import styles from "./Forum.module.css";

import Header from "../../components/Header/Header";
import { useEffect, useState } from "react";
import { getForums } from "../../api/forum";
import { useNavigate } from "react-router-dom";

const Forum = () => {
    const [forums, setForums] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        getForums()
            .then((res) => setForums(res))
            .then((aa) => console.log(forums));
    }, []);

    return (
        <>
            <Header />
            <main>
                <div className={globalStyles["container"]}>
                    <section className={styles["forum"]}>
                        <h1 className={styles["forum__header"]}>Форум</h1>
                        <ul className={styles["forum__threads"]}>
                            {forums.map((forumEl) => (
                                <li
                                    className={styles["forum__thread"]}
                                    onClick={() => navigate(`./${forumEl.id}`)}
                                >
                                    <p className={styles['forum__thread__title']}>{forumEl.title}</p>
                                    <p className={styles['forum__thread__small-info']}>{forumEl.publishedDateTime.split('T')[0]}</p>
                                </li>
                            ))}
                        </ul>
                    </section>
                </div>
            </main>
        </>
    );
};

export default Forum;
