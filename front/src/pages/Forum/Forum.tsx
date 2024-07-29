import globalStyles from "../../App.module.css";
import styles from "./Forum.module.css";

import Header from "../../components/Header/Header";
import { useEffect } from "react";

const Forum = () => {

    useEffect(() => {
        
    }, [])

    return (
        <>
            <Header />
            <main>
                <div className={globalStyles["container"]}>
                    <section className={styles["forum"]}>
                        <h1>Форум</h1>
                        <ul className={styles["forum__threads"]}>

                        </ul>
                    </section>
                </div>
            </main>
        </>
    );
};

export default Forum;
