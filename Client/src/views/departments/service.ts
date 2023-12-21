import type { MessageResponse } from "@/models/messageResponse";
import httpClient from "@/plugins/http-client";

const RESOURCE = "Lookups/Departments";

function fetch() {
  return httpClient.get<MessageResponse>(`${RESOURCE}`);
}
// function create(department: FormData) {
//   return httpClient.post<MessageResponse>(`${RESOURCE}`, category);
// }

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
