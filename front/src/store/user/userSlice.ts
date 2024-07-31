import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { user as userObject } from '../../api/user';

interface userState {
    user: userObject | null;
    logedIn: boolean;
}

const initialState: userState = {
    user: null,
    logedIn: false,
};

const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        loginUser: (state, action: PayloadAction<userObject>) => {
            state.user = action.payload;
            state.logedIn = true;
        },
        logoutUser: (state) => {
            state.user = null;
            state.logedIn = false;
        },
    },
});

export const { loginUser, logoutUser } = userSlice.actions;

export default userSlice.reducer;
