export interface Mission {
    title: string | null;
    content: string | null;
    date: any;
    expectedEndDate: any;
    remarks: string | null;
    entitieName: string | null;
    entities: number[];
    comments: Comment[] | null;
    updates: Update[] | null;
    file: any;
}

interface Comment {
    content: string | null;
    createdBy: string | null;
    createdOn: string | null;
}

interface Update {
    content: string | null;
    createdBy: string | null;
    createdOn: string | null;
}

export interface Header {
    title: string,
    key: string
}

export interface MissionResponse {
    content: Mission;
    msg: string;
}