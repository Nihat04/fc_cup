import axiosInstance from "./main";

export async function getPlayer(id: string) {
    const response = await axiosInstance.get(`Players/${id}`);
    const data = await response.data;

    return data;
}
