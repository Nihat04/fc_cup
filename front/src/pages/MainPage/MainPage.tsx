import globalStyles from '../../App.module.css';
import styles from './MainPage.module.css';

import OngoingTournament from '../../components/OngoingTournament/OngoingTournament';
import Header from '../../components/Header/Header';

const MainPage = () => {
    return (
        <>
            <Header />
            <main className={globalStyles['main']}>
                <div className={globalStyles['container']}>
                    <OngoingTournament />
                    <section className={styles['featured-matches']}></section>
                    <section className={styles['ratings']}></section>
                    <section className={styles['players-streams']}></section>
                </div>
            </main>
        </>
    );
};

export default MainPage;
