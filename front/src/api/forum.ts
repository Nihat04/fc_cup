import axiosInstance from "./main";

export async function getForums() {
    const response = await axiosInstance.get('forum/get-forums');
    const data = await response.data;

    return data;
}