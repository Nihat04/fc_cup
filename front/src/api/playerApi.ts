import axiosInstance from './main';

export async function getPlayer(id: number) {
    const response = await axiosInstance.get(`api/Players/${id}`);
    const data = await response.data;

    return data;
}
