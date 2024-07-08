import styles from "./ObjectOverview.module.css";

const ObjectOverview = (props) => {
    const { object } = props;

    return (
        <div className={styles["overview"]}>
            <img
                className={styles["overview__image"]}
                src={object.imageUrl}
                alt={`фотография ${object.name}`}
            />
            <div className={styles["overview__content"]}>
                <h2 className={styles["overview__header"]}>{object.name}</h2>
                {object.additionalName && <p>{object.additionalName}</p>}
            </div>
        </div>
    );
};

export default ObjectOverview;
