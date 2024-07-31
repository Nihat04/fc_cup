import globalStyles from '../../App.module.css';
import style from './PlayerPage.module.css';

import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getPlayer } from '../../api/playerApi';

import ObjectOverview from '../../components/ObjectOverview/ObjectOverview';
import InformationPanel from '../../components/InformationPanel/InformationPanel';
import Header from '../../components/Header/Header';

const PlayerPage = () => {
    const { id } = useParams();
    const [player, setPlayer] = useState({});

    const tabs = [
        {
            name: 'Основное',
            informations: [
                {
                    name: 'статистика',
                    information: [
                        { name: 'Сыграно матчей', score: '198' },
                        { name: 'GAY', score: 'neGay' },
                    ],
                },
            ],
        },
        {
            name: 'Комнады',
            informations: {
                name: 'статистика',
                information: [{ name: 'Сыграно матчей', score: '198' }],
            },
        },
        {
            name: 'Матчи',
            informations: {
                name: 'статистика',
                information: [{ name: 'Сыграно матчей', score: '198' }],
            },
        },
    ];

    useEffect(() => {
        getPlayer(id).then((res) => setPlayer(res));
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    return (
        <>
            <Header />
            <main>
                <section className={style['player']}>
                    <div className={globalStyles['container']}>
                        <ObjectOverview object={player} />
                        <InformationPanel tabs={tabs} />
                    </div>
                </section>
            </main>
        </>
    );
};

export default PlayerPage;
