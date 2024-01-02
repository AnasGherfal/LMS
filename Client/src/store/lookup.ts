import { defineStore } from "pinia";
import type { Lookup } from "@/models/lookups";
import httpClient from "@/plugins/http-client";

export interface LookupState {
  licenseTypesLookup: Lookup[];
  impactLevelLookup: Lookup[];
  productTypesLookup: Lookup[];

  // rolesLookup: Lookup[];
  // empsLookup: Lookup[];
}

export const useLookupStore = defineStore("lookupStore", {
  state: (): LookupState => {
    return {
      licenseTypesLookup: [],
      impactLevelLookup: [],
      productTypesLookup:[],
      // rolesLookup: [],
      // empsLookup: [],
    };
  },

  actions: {
    async getLicenseTypes() {
      try {
        const { data } = await getLicenseTypes();
        this.licenseTypesLookup = data.content;
      } catch (err) {
        return Promise.reject(err);
      } 
    },
    async getImpactLevel() {
      try {
        const { data } = await getImpactLevel();
        this.impactLevelLookup = data.content;
      } catch (err) {
        return Promise.reject(err);
      }
    },
    async getProdcutsTypes() {
      try {
        const { data } = await getProdcutsTypes();
        this.productTypesLookup = data.content;
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
  return httpClient.get(`${RESOURCE}/License-Types`);
}
function getImpactLevel() {
  return httpClient.get(`${RESOURCE}/Impact-Levels`);
}
function getProdcutsTypes() {
  return httpClient.get(`${RESOURCE}/Product-Types`);
}
