export interface User {
    userId: number | null;
    empId: number | null;
    empCode: string | null;
    userName: string | null;
    fullName: string | null;
    jobDesc: string | null;
    entity: string | null;
    entityId: number | null;
    actJobDesc: string | null,
    actEntity: string | null,
    actEntityId: number |null,
    roleId: any;
}

export interface EmpInfo {
    empId: number | null;
    empCode: string | null;
    userName: string | null;
    fullName: string | null;
    jobDesc: string | null;
    entity: string | null;
    entityId: number | null;
    actJobDesc: string | null,
    actEntity: string | null,
    actEntityId: number |null,
}

export interface EmpData {
    content: EmpInfo,
    msg: string
}
export interface EmpItem {
    userId: number | null,
    empId: number | null,
    fullName: string | null
}