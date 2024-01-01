import type { MessageResponse } from "@/models/messageResponse";
import httpClient from "@/plugins/http-client";
import { departmentListResponse } from "./list/model";

const RESOURCE = "Lookups/Departments";

function fetch(pageNumber?: number, pageSize?: number, name?: string) {
  return httpClient.get<departmentListResponse>(`${RESOURCE}`, {
    params: {
      PageNumber: pageNumber,
      PageSize: pageSize,
      Search: name,
    },
  });
}

function fetchById(id: number) {
  return httpClient.get<MessageResponse>(`${RESOURCE}/${id}`);
}
function deleteDepartment(id: number) {
  return httpClient.delete<MessageResponse>(`${RESOURCE}/${id}`);
}
export const departmentService = {
  fetch,
  fetchById,
  deleteDepartment,
};
