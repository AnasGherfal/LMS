import type { MessageResponse } from "@/models/messageResponse";
import httpClient from "@/plugins/http-client";
import { categoryListResponse } from "./list/model";
import { categoryInforResponse } from "./view/model";

const RESOURCE = "categories";

function fetch(pageNumber?: number, pageSize?: number, name?: string) {
  return httpClient.get<categoryListResponse>(`${RESOURCE}`, {
    params: {
      PageNumber: pageNumber,
      PageSize: pageSize,
      Search: name,
    },
  });
}
function create(category: FormData) {
  return httpClient.post<MessageResponse>(`${RESOURCE}`, category);
}

function fetchById(id: any) {
  return httpClient.get<categoryInforResponse>(`${RESOURCE}/${id}`);
}

function edit(id: any, category: FormData) {
  return httpClient.put<MessageResponse>(`${RESOURCE}/${id}`, category);
}
function deleteCategory(id: any) {
  return httpClient.delete<MessageResponse>(`${RESOURCE}/${id}`);
}
function toggleLock(id: number, action: "unlock" | "lock") {
  return httpClient.put<MessageResponse>(`${RESOURCE}/${id}/${action}`);
}

export const categoryService = {
  create,
  fetch,
  fetchById,
  edit,
  deleteCategory,
  toggleLock,
};
