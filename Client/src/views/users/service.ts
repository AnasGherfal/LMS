import type { MessageResponse } from "@/models/messageResponse";
import type { User, EmpItem, EmpData } from "./create/model";
import type { UsersData } from "./list/model";
import httpClient from "../../plugins/http-client";
import type { UserData } from "./view/model";

const RESOURCE = "users";

function fetch(quaryString: string) {
    return httpClient.get<UsersData>(`${RESOURCE}?${quaryString}`);
}

function fetchById(id: number) {
    return httpClient.get<UserData>(`${RESOURCE}/${id}`);
}
function fetchEmpInfo(empId: number) {
    return httpClient.get<EmpData>(`${RESOURCE}/${empId}/emp-info`);
}

function fetchEmpList() {
    return httpClient.get<EmpItem[]>(`lookups/get-app-users-list`);
}
function create(user: User) {
    return httpClient.post<MessageResponse>(`${RESOURCE}`, user);
}

function update(user: User) {
    return httpClient.put<MessageResponse>(`${RESOURCE}/${user.empId}`, user);
}

function lock(id: number | null) {
    return httpClient.put<MessageResponse>(`${RESOURCE}/${id}/lock`);
}
function unlock(id: number | null) {
    return httpClient.put<MessageResponse>(`${RESOURCE}/${id}/unlock`);
}

function deleteUser(id: number | null) {
    return httpClient.delete<MessageResponse>(`${RESOURCE}/${id}`);
}

export const userService = {
    create,
    fetch,
    fetchById,
    lock,
    deleteUser,
    update,
    unlock,
    fetchEmpList,
    fetchEmpInfo
};
