import axiosInstance from './main';

export type user = {
    id: number;
    userName: string;
    displayName: string;
    registrationDateTime: string;
    rating: number;
    userComments: [];
};

export async function getLogedUser(): Promise<user> {
    try {
        const response = await axiosInstance.get(`accounts/user-info`);
        const data = await response.data;

        return data;
    } catch (error) {
        if (error.response.status === 401) {
            throw new Error('unauthorized');
        }

        throw new Error();
    }
}
