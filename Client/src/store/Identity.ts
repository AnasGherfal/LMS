import { getToken, removeToken } from "../utils/tokenCookies";
import { defineStore } from "pinia";
import httpClient from "@/plugins/http-client";

export interface IdentityState {
    fullName: string;
    apps: number[];
    user: LoginResult;
}

export const useIdentityStore = defineStore({
    id: "identity",
    state: (): IdentityState => ({
        fullName: "",
        apps: [],
        user: {
            fullName: null,
            userName: null,
            roleId: null
        }
    }),
    getters: {
        token: () => getToken(),
    },
    actions: {
        async getUser() {
            try {
                const response = await authService.getUser();

                this.user.userName = response.userName;
                this.user.fullName = response.fullName;
                this.user.roleId = response.roleId;
            }
            catch (err) {
                window.location.replace(import.meta.env.VITE_LOGINPAGE);
                return Promise.reject(err);
            }
        },
        logout() {
            removeToken();
            window.location.replace(import.meta.env.VITE_LOGINPAGE);
        },
    },
});

const RESOURCE = "auth";

const getUser = async () => {
    const { data } = await httpClient.get<LoginResult>(`${RESOURCE}/get-user`);
    return data;
}

export const authService = {
    getUser,
};
export interface LoginResult {
    userName: string | null;
    fullName: string | null;
    roleId: number | null;
}