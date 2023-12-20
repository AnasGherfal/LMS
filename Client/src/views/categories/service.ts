import { useHttpClient } from "@/network/httpClient";
import type { MessageResponse } from "@/models/messageResponse";
import httpClient from "@/plugins/http-client";


const RESOURCE = "categories";


function fetch (quaryString : string){
    return httpClient.get<MessageResponse>(`${RESOURCE}`, quaryString )
}
function create (category : FormData){
    return httpClient.post<MessageResponse>(`${RESOURCE}`, category )
}

function fetchById(id : any){
    return httpClient.get<MessageResponse>(`${RESOURCE}/${id}`)
}

function edit(id : any, category: FormData){
    return httpClient.put<MessageResponse>(`${RESOURCE}/${id}`, category)
}
function deleteCategory(id : any){
    return httpClient.delete<MessageResponse>(`${RESOURCE}/${id}`, )

}


export const categoryService = {

    create,
    fetch,
    fetchById,
    edit,
    deleteCategory,
}