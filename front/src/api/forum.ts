import axiosInstance from './main';

export type forumShort = {
    id: number;
    title: string;
    authorDisplayName: string;
    publishedDateTime: string;
    numberOfComments: string;
};

export type forum = {
    id: number;
    forumId: number;
    authorId: number;
    commentId: number | null;
    commentText: string;
    isDeleted: boolean;
    publishedDateTime: Date;
    rating: number;
};

export async function getForums(): Promise<forum[]> {
    const response = await axiosInstance.get('forum/get-forums');
    const data = await response.data;

    return data;
}

export async function getForum(id: number): Promise<forum> {
    const response = await axiosInstance.get(`forum/\$${id}`);
    const data = await response.data;
    console.log(data)
    return data[0];
}

export async function createForum(forumName: string) {
    const response = await axiosInstance.post(`forum/create-forum?title=${forumName}`);
    const data = await response.data;

    return data;
}

export async function getForumComments(forumId: number, commentsPage: number) {
    const response = await axiosInstance.get(`forum/\$${id}`);
    const data = await response.data;

    return data;
}
