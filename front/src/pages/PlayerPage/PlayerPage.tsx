import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getPlayer } from "../../api/playerApi";

const PlayerPage = () => {
    const { id } = useParams();
    const [player, setPlayer] = useState({})

    useEffect(() => {
        getPlayer(1).then(res => setPlayer(res))
    }, [])
    
    return <></>;
};

export default PlayerPage;
