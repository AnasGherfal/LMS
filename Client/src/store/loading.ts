import { defineStore } from "pinia";

export interface loadingState {
    loading: boolean;
}
export const useLoadingStore = defineStore({
    id: "loading",
    state: (): loadingState => ({
        loading: false,
    }),
    actions: {
        async start() {
            this.loading = true;
        },
        async stop() {
            this.loading = false;
        }
    }
});