export interface licenseListItem{
      Id : string | null;
      Contact : string | null;
      ImpactLevel : number | null
      StartDate : string | null;
      ExpireDate : string | null;
      ProductName : string | null;
      DepartmentName : string | null;
      IsActive : boolean | null;
      CreatedOn : string | null;
}

export interface licenseListFilter {
    pageNo: number;
    pageSize: number;
    DepartmentId: string | null;
    ProductId: string | null;
}
export interface header {
    title: string,
    key: string
}
export interface licenseListResponse {
    content: licenseListItem[];
    msg: string;
    totalPages: number;
}


