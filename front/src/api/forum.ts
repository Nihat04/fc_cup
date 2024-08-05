import axiosInstance from './main';

export type forum = {
    id: number;
    title: string;
    authorDisplayName: string;
    publishedDateTime: string;
    numberOfComments: string;
};

export async function getForums() {
    const response = await axiosInstance.get('forum/get-forums');
    const data = await response.data;

    return data;
}

export async function getForum(id: number) {
    const response = await axiosInstance.get(`forum/\$${id}`);
    const data = await response.data;

    return data;
}

export async function createForum(forumName: string) {
    const response = await axiosInstance.post(
        `forum/create-forum?title=${forumName}`
    );
    const data = await response.data;

    return data;
}