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
  title: string | null;
  date: string | null;
  status: number | null;
}

export interface header {
  title: string;
  key: string;
}
export interface departmentListResponse {
  content: departmentListItem[];
  msg: string;
}

