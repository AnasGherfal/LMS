import { useHttpClient } from "@/network/httpClient";
import type { MessageResponse } from "@/models/messageResponse";
import httpClient from "@/plugins/http-client";

const RESOURCE = "products";

function fetch(quaryString: string) {
  return httpClient.get<MessageResponse>(`${RESOURCE}`, quaryString);
}
function create(product: FormData) {
  return httpClient.post<MessageResponse>(`${RESOURCE}`, product);
}

function fetchById(id: number) {
  return httpClient.get<MessageResponse>(`${RESOURCE}/${id}`);
}
function deleteProduct(id: number) {
  return httpClient.delete<MessageResponse>(`${RESOURCE}/${id}`);
}
export const productService = {
  create,
  fetch,
  fetchById,
  deleteProduct,
};
