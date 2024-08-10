import axios from 'axios';

const BASE_URL = 'https://localhost:7295/';

const token = localStorage.getItem('tkId');

const axiosInstance = axios.create({
    baseURL: BASE_URL,
    headers: {
        'Content-Type': 'application/json',
        Authorization: token ? `Bearer ${localStorage.getItem('tkId')}` : null,
    },
});

export default axiosInstance;
