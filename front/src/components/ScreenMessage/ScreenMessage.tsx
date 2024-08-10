import classNames from 'classnames';
import styles from './ScreenMessage.module.css';

export enum messageTypes {
    error,
    warning,
    success,
    notification,
    tip,
}

const ScreenMessage = (props: { type: messageTypes; header: string | null; children: string }) => {
    const { type, header, children } = props;

    return (
        <div className={classNames(styles['message'])}>
            {header && <p className={styles['message__header']}>{header}</p>}
            <p className={styles['messgae__body']}>{children}</p>
        </div>
    );
};

export default ScreenMessage;
