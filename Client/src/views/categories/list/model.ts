﻿export interface categoryListItem {
  id: string;
  photo: string;
  name: string;
  numberOfProducts: number;
  isActive: boolean;
  createdOn: "string";
}

export interface CategoriesListFilter {
  pageNo: number;
  pageSize: number;
  name: string | null;
}

export interface header {
  title: string;
  key: string;
}

export interface categoryListResponse {
  content: categoryListItem[];
  totalPages: number;
  msg: string;
}