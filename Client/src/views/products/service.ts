import { useHttpClient } from "@/network/httpClient";
import type { MessageResponse } from "@/models/messageResponse";
import httpClient from "@/plugins/http-client";
import { productListResponse } from "./list/model";
import { productInfoResponse } from "./view/model";

const RESOURCE = "products";

function fetch(pageNumber?: number, pageSize?: number, name?: string) {
  return httpClient.get<productListResponse>(`${RESOURCE}`, {
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
  return httpClient.get<productInfoResponse>(`${RESOURCE}/${id}`);
}

function edit(id: any, product: FormData) {
  return httpClient.put<MessageResponse>(`${RESOURCE}/${id}`, product);
}

function deleteProduct(id: number) {
  return httpClient.delete<MessageResponse>(`${RESOURCE}/${id}`);
}

function toggleLock(id: number, action: "unlock" | "lock") {
  return httpClient.put<MessageResponse>(`${RESOURCE}/${id}/${action}`);
}

export const productService = {
  create,
  fetch,
  fetchById,
  edit,
  deleteProduct,
  toggleLock,
};
