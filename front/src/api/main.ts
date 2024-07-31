import axios from 'axios';

const BASE_URL = 'https://localhost:7295/';

const axiosInstance = axios.create({
    baseURL: BASE_URL,
    headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${localStorage.getItem('tkId')}`,
    },
});

export default axiosInstance;
