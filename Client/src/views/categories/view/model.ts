export interface categoryInfo{
    id: string | null;
    photo: any;
    name: string | null;
    description: string | null;
    isActive: boolean | null;
    createdOn: string | null;
}

export interface categoryInforResponse {
    content: categoryInfo;
    totalPages: number;
    msg: string;
}