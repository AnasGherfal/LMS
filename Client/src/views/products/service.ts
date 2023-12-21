import { useHttpClient } from "@/network/httpClient";
import type { MessageResponse } from "@/models/messageResponse";
import httpClient from "@/plugins/http-client";

const RESOURCE = "products";

function fetch(pageNumber?: number, pageSize?: number, name?: string) {
  return httpClient.get<MessageResponse>(`${RESOURCE}`, {
    params: {
      PageNumber: pageNumber,
      PageSize: pageSize,
      Search: name,
    },
  });
}
function create(product: FormData) {
  return httpClient.post<MessageResponse>(`${RESOURCE}`, product);
}

function fetchById(id: number | any) {
  return httpClient.get<MessageResponse>(`${RESOURCE}/${id}`);
}
function edit(id: any, product: FormData) {
  return httpClient.put<MessageResponse>(`${RESOURCE}/${id}`, product);
}
function deleteProduct(id: number) {
  return httpClient.delete<MessageResponse>(`${RESOURCE}/${id}`);
}
export const productService = {
  create,
  fetch,
  fetchById,
  edit,
  deleteProduct,
};
