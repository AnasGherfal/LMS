﻿import { defineStore } from "pinia";
import type { Lookup } from "@/models/lookups";
import httpClient from "@/plugins/http-client";

export interface LookupState {
    licenseTypesLookup: Lookup[];
    impactLevelLookup: Lookup[];
    // rolesLookup: Lookup[];
    // empsLookup: Lookup[];
}

export const useLookupStore = defineStore("lookupStore", {
    state: (): LookupState => {
        return {
            licenseTypesLookup: [],
            impactLevelLookup:[],
            // rolesLookup: [],
            // empsLookup: [],
        };
    },

    actions: {
        
        async getLicenseTypes() {
            try {
                    const { data } = await getLicenseTypes();
                    this.licenseTypesLookup = data;
                
            } catch (err) {
                return Promise.reject(err);
            }
        },
        async getImpactLevel() {
            try {
                    const { data } = await getLicenseTypes();
                    this.impactLevelLookup = data;
                
            } catch (err) {
                return Promise.reject(err);
            }
        },
        // async getRoles() {
        //     try {
        //         if (this.rolesLookup.length <= 0) {
        //             //const { data } = await lookupsService.getEntities();
        //             //this.entitiesLookup = data;
        //             // this.rolesLookup = [
        //             //     { text: 'مشرف', value: 1 },
        //             //     { text: 'موظف', value: 2 }
        //             // ];
        //         }
        //     } catch (err) {
        //         return Promise.reject(err);
        //     }
        // },
        
    },
    
});




const RESOURCE = "Lookups";
function getLicenseTypes() {
    return httpClient.get<Lookup[]>(`${RESOURCE}/License-Types`);
}
function getImpactLevel() {
    return httpClient.get<Lookup[]>(`${RESOURCE}/Impact-Levels`);
}