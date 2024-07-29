import styles from "./OngoingTournament.module.css";

import { useEffect, useState } from "react";

const HEADER_TEXT = "Текущий турнир";

const OngoingTournament = () => {
    const [tournament, setTournament] = useState({});
    useEffect(() => {}, []);
    return (
        <section className={styles["ongoing-tournament"]}>
            <h3 className={styles["ongoing-tournament__header"]}>
                {HEADER_TEXT}
            </h3>
            <div className={styles["ongoing-tournament__panel"]}>
                <div className={styles["ongoing-tournament__panel__name"]}>
                    {"Кубок Фиферов 2024"}
                </div>
                <div
                    className={styles["ongoing-tournament__panel__info"]}
                >
                    dfhakiald
                </div>
            </div>
        </section>
    );
};

export default OngoingTournament;
