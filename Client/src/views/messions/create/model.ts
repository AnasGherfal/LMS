export interface Mission {
    title: string| null;
    content: string | null;
    date: any;
    expectedEndDate: any;
    remarks: string | null;
    entities: number[];
    file: any;
}

export interface UserType {
    value: number,
    text: string
}
export interface EmpList {
    value: number,
    text: string,
    entityId?: number
}
export interface EntityItem {
    value: number,
    text: string
}