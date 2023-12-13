import { defineStore } from "pinia";
import type { Lookup } from "@/models/lookups";
import httpClient from "@/plugins/http-client";

export interface LookupState {
    entitiesLookup: Lookup[];
    rolesLookup: Lookup[];
    empsLookup: Lookup[];
}

export const useLookupStore = defineStore("lookupStore", {
    state: (): LookupState => {
        return {
            entitiesLookup: [],
            rolesLookup: [],
            empsLookup: [],
        };
    },

    actions: {
        async getEntities() {
            try {
                if (this.entitiesLookup.length <= 0) {
                    const { data } = await getEntities();
                    this.entitiesLookup = data;
                    //this.entitiesLookup = [
                    //    { text: 'مكتب 1', value: 1 },
                    //    { text: 'مكتب 2', value: 2 },
                    //    { text: 'إدارة 1', value: 3 },
                    //    { text: 'إدارة 2', value: 4 },
                    //];
                }
            } catch (err) {
                return Promise.reject(err);
            }
        },
        async getRoles() {
            try {
                if (this.rolesLookup.length <= 0) {
                    //const { data } = await lookupsService.getEntities();
                    //this.entitiesLookup = data;
                    this.rolesLookup = [
                        { text: 'مشرف', value: 1 },
                        { text: 'موظف', value: 2 }
                    ];
                }
            } catch (err) {
                return Promise.reject(err);
            }
        },
    },
});




const RESOURCE = "lookups";
function getEntities() {
    return httpClient.get<Lookup[]>(`${RESOURCE}/get-entities`);
}