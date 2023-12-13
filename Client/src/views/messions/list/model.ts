import type { StatusLookup } from "@/utils/status";

export interface MissionsListFilter {
    pageNo: number;
    pageSize: number;
    title: string | null;
    date: string | null;
    entityId: number | null,
    status: number | null;
}

export interface MissionListItem {
    id: number;
    title: string;
    entity: string;
    date: string;
    createdBy: string;
    createdOn: string;
    status: number;
}

export interface MissionListResponse {
    content: MissionListItem[];
    totalPages: number;
    msg: string;
}

export interface header {
    title: string,
    key: string
}

export const status = {
    entry: 0,
    done: 1,
};

export const missionStatusLookup: StatusLookup[] = [
    { text: "قيد الإجراء", value: status.entry },
    { text: "منجزة", value: status.done },
];

