
import { useHttpClient } from "@/network/httpClient";
import type { MessageResponse } from "@/models/messageResponse";
import httpClient from "@/plugins/http-client";


const RESOURCE = "licenses";


function fetch (quaryString : string){
    return httpClient.get<MessageResponse>(`${RESOURCE}`, quaryString )
}
function create (license : FormData){
    return httpClient.post<MessageResponse>(`${RESOURCE}`, license )
}

function fetchById(id : number){
    return httpClient.get<MessageResponse>(`${RESOURCE}/${id}`)
}
function deletelicense(id : number){
    return httpClient.delete<MessageResponse>(`${RESOURCE}/${id}`, )

}
export const licenseService = {

    create,
    fetch,
    fetchById,
    deletelicense,
}