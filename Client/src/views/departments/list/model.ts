export interface departmentListItem {
  id: string | null;
  name: string | null;
  ownerName: string;
  email: string;
  phoneNumber: string;
  domain: string;
}

export interface departmentsListFilter {
  pageNo: number;
  pageSize: number;
  name: string | null;
}

export interface header {
  title: string;
  key: string;
}
export interface departmentListResponse {
  content: departmentListItem[];
  totalPages: number;
  msg: string;
}
