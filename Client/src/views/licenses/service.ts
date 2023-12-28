import { useHttpClient } from "@/network/httpClient";
import type { MessageResponse } from "@/models/messageResponse";
import httpClient from "@/plugins/http-client";
import { licenseInfoResponse } from "./view/model";
import { licenseListResponse } from "./list/model";

const RESOURCE = "licenses";

function fetch(pageNumber?: number, pageSize?: number, productId?: string, departmentId?: string) {
  return httpClient.get<licenseListResponse>(`${RESOURCE}`, {
    params: {
      PageNumber: pageNumber,
      PageSize: pageSize,
      productId: productId,
      DepartmentId: departmentId
    },
  });
}
function create(license: FormData) {
  return httpClient.post<MessageResponse>(`${RESOURCE}`, license);
}

function fetchById(id: string | string[]) {
  return httpClient.get<licenseInfoResponse>(`${RESOURCE}/${id}`);
}

function lock(id: number | null) {
  return httpClient.put<MessageResponse>(`${RESOURCE}/${id}/lock`);
}
function unlock(id: number | null) {
  return httpClient.put<MessageResponse>(`${RESOURCE}/${id}/unlock`);
}

function deletelicense(id: number) {
  return httpClient.delete<MessageResponse>(`${RESOURCE}/${id}`);
}
export const licenseService = {
  create,
  fetch,
  fetchById,
  lock,
  unlock,
  deletelicense,
};
