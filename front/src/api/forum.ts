import axiosInstance from "./main";

export async function getForums() {
    const response = await axiosInstance.get("forum/get-forums");
    const data = await response.data;

    return data;
}

export async function createForum(forumName: string) {
    const response = await axiosInstance.post(`forum/create-forum?title=${forumName}`);
    const data = await response.data;

    return data;
}
