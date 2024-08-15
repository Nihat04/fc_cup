import axiosInstance from './main';

export type forumShort = {
    id: number;
    title: string;
    authorDisplayName: string;
    publishedDateTime: Date;
    numberOfComments: string;
};

export type forum = {
    id: number;
    title: string;
    body: string;
    comments: string[] | null;
    publishedDateTime: Date;
    authorDisplayName: string;
    numberOfComments: number;
};

const RATE_VALUE = 1;

export type comment = {
    id: number;
    forumId: number;
    authorId: number;
    commentText: string;
    commentId: null;
    rating: number;
    publishedDateTime: string;
    isDeleted: boolean;
};

export async function getForums(): Promise<forumShort[]> {
    const response = await axiosInstance.get('forum/get-forums');
    const data = await response.data;

    return data;
}

export async function getForum(id: number): Promise<forum> {
    const response = await axiosInstance.get(`forum/$${id}`);
    const data = await response.data;

    return data;
}

export async function createForum(forumName: string) {
    const response = await axiosInstance.post(`forum/create-forum?title=${forumName}`);
    const data = await response.data;

    return data;
}

export async function getForumComments(forumId: number, commentsPage: number): Promise<comment[]> {
    const pageSize = 30;

    const response = await axiosInstance.get(`forum/$${forumId}/comments?pageNumber=${commentsPage}&pageSize=${pageSize}`);
    const data = await response.data;

    return data.reverse();
}

export async function postComment({
    forumId,
    comment,
    parentCommentId = 0,
}: {
    forumId: number;
    comment: string;
    parentCommentId: number;
}) {
    const response = await axiosInstance.post(`forum/publish-comment?text=${comment}&forumId=${forumId}`);
    const data = await response.data;

    return data;
}

export async function upVoteComment(commentId: number): Promise<void> {
    const rate = RATE_VALUE;

    await axiosInstance.post(`forum/rate-comment?commentId=${commentId}&rate=${rate}`);
}

export async function DownVoteComment(commentId: number): Promise<void> {
    const rate = -RATE_VALUE;

    await axiosInstance.post(`forum/rate-comment?commentId=${commentId}&rate=${rate}`);
}
