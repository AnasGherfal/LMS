export interface departmentListItem {
  id: string | null;
  icon: string | null;
  name: string | null;
  isActive: boolean | null;
  createdOn: string | null;
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
