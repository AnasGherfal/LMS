import { defineStore } from "pinia";

export interface alertState {
    message: string;
    show: boolean;
}
export const useAlertStore = defineStore({
    id: "alert",
    state: (): alertState => ({
        message: "",
        show: false,
    }),
    actions: {
         async showAlert(msg: string) {
            this.message = msg;
            this.show = true;
        }
    }
});