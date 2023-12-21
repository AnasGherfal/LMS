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
  title: string | null;
  date: string | null;
  status: number | null;
}

export interface header {
  title: string;
  key: string;
}
