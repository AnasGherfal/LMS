export interface productListItem {
  id: string;
  photo: string;
  name: string;
  category: number;
  numberOfLicense: number;
  isActive: boolean;
  createdOn: "string";
}

export interface ProductsListFilter {
  pageNo: number;
  pageSize: number;
  name: string | null;
}

export interface header {
  title: string;
  key: string;
}
export interface productListResponse {
  content: productListItem;
  msg: string;
  totalPages: number;
}