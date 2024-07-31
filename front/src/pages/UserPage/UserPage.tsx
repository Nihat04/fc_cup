import { useParams } from 'react-router-dom';

const UserPage = () => {
    const { id } = useParams();

    return <div>UserPage</div>;
};

export default UserPage;
