export interface categoryListItem{
    id: string;
    icon: string;
    name: string;
    numberOfCategories: number;
    isActive: boolean;
    createdOn: "string"

}


export interface CategoriesListFilter {
    pageNo: number;
    pageSize: number;
    title: string | null;
    date: string | null;
    entityId: number | null,
    status: number | null;
}

export interface header {
    title: string,
    key: string
}