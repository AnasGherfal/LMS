import type { MessageResponse } from "@/models/messageResponse";
//import type { MessionListItem } from "./create/model";
import type { MissionListResponse } from "./list/model";
import type { MissionResponse } from "./view/model";
import httpClient from "../../plugins/http-client";

const RESOURCE = "missions";

function fetch(quaryString: string) {
    return httpClient.get<MissionListResponse>(`${RESOURCE}?${quaryString}`);
}

function fetchById(id: number) {
    return httpClient.get<MissionResponse>(`${RESOURCE}/${id}`);
}

function fetchFileById(id: number) {
    return httpClient.get<Blob>(`${RESOURCE}/${id}/file`, { responseType: 'blob' });
}
function create(mession: FormData) {
    return httpClient.post<MessageResponse>(`${RESOURCE}`, mession);
}

function createUpdate(id: number, content: any) {
    return httpClient.put<MessageResponse>(`${RESOURCE}/${id}/update`, content);
}

function createComment(id: number, content: any) {
    return httpClient.put<MessageResponse>(`${RESOURCE}/${id}/comment`, content);
}

function done(id: number) {
    return httpClient.put<MessageResponse>(`${RESOURCE}/${id}/done`,);
}

export const messionsService = {
    create,
    fetch,
    fetchById,
    createUpdate,
    createComment,
    fetchFileById,
    done,
};

