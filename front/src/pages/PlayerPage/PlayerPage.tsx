import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getPlayer } from "../../api/playerApi";
import style from "./PlayerPage.module.css";
import globalStyles from "../../App.module.css";
import ObjectOverview from "../../components/ObjectOverview/ObjectOverview";
import InformationPanel from "../../components/InformationPanel/InformationPanel";

const PlayerPage = () => {
    const { id } = useParams();
    const [player, setPlayer] = useState({});

    const tabs = [
        {
            name: "Основное",
            informations: [{
                name: "статистика",
                information: [{ name: "Сыграно матчей", score: "198" }, {name: "GAY", score: "neGay"}],
            }],
        },
        {
            name: "Комнады",
            informations: {
                name: "статистика",
                information: [{ name: "Сыграно матчей", score: "198" }],
            },
        },
        {
            name: "Матчи",
            informations: {
                name: "статистика",
                information: [{ name: "Сыграно матчей", score: "198" }],
            },
        },
    ];

    useEffect(() => {
        getPlayer(id).then((res) => setPlayer(res));
    }, []);

    return (
        <section className={style["player"]}>
            <div className={globalStyles["container"]}>
                <ObjectOverview object={player} />
                <InformationPanel tabs={tabs} />
            </div>
        </section>
    );
};

export default PlayerPage;
