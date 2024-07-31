import React, { useState } from 'react';
import styles from './InformationPanel.module.css';
import classNames from 'classnames';

const InformationPanel = (props) => {
    const { tabs } = props;
    const [currentTab, setCurrentTab] = useState(tabs[0]);
    return (
        <div className={styles['information-panel']}>
            <div className={styles['information-panel__tabs']}>
                {tabs.map((tab, index) => (
                    <button
                        className={classNames(
                            styles['information-panel__tabs__btn'],
                            {
                                [styles[
                                    'information-panel__tabs__btn--active'
                                ]]: currentTab.name === tab.name,
                            }
                        )}
                        key={index}
                        onClick={() => setCurrentTab(tab)}
                    >
                        {tab.name}
                    </button>
                ))}
            </div>
            <div className={styles['information-panel__information']}>
                {currentTab.informations.map((infoGroup, groupIndex) => (
                    <div
                        className={
                            styles['information-panel__information__group']
                        }
                        key={groupIndex}
                    >
                        <h6>{infoGroup.name}</h6>
                        <div
                            className={
                                styles[
                                    'information-panel__information__group__plates'
                                ]
                            }
                        >
                            {infoGroup.information.map((info, index) => (
                                <div
                                    className={
                                        styles[
                                            'information-panel__information__group__plate'
                                        ]
                                    }
                                    key={index}
                                >
                                    <p>{info.name}</p>
                                    <p>{info.score}</p>
                                </div>
                            ))}
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default InformationPanel;
