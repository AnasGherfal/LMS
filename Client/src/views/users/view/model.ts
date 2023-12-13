export interface UserInfo {
    userId: number | null;
    empId: number | null;
    userName: string | null;
    fullName: string | null;
    jobDesc: string | null;
    entity: string | null;
    actJobDesc: string | null,
    actEntity: string | null,
    role: any,
    createdBy: string | null,
    createdOn: string | null,
    status: number | null,
}

export interface UserData {
    content: UserInfo,
    msg: string
}
export interface EmpItem {
    userId: number | null,
    empId: number | null,
    fullName: string | null
}