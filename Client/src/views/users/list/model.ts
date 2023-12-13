export interface UserListFilter {
    pageNo: number;
    pageSize: number;
    empName: string;
    status: any;
}

export interface UserListItem {
    id: number;
    fullName: string;
    entity: string;
    createdBy: string;
    createdOn: string;
    role: string;
    status: number;
}
export interface UsersData {
    totalPages: number,
    content: UserListItem[],
    msg: string
}

export interface Header {
    title: string,
    key: string
}

export interface Status {
    value: number,
    text: string
}