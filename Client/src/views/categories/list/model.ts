export interface categoryListItem{
    id: string;
    photo: string;
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
    status: number | null;
}

export interface header {
    title: string,
    key: string
}