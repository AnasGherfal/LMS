import { defineStore } from "pinia";

export interface snackbarState {
    show: boolean;
    message: string;
    icon: string;
    type: string;
}
export const useSnackbarStore = defineStore({
    id: "snack",
    state: (): snackbarState => ({
        show: false,
        message: "",
        icon: "",
        type: ""
    }),
    actions: {
        async showSnack(
            msg: string,
            type: "" | "success" | "warning" | "info" | "error" = "success"
        ) {
            this.message = msg;
            this.type = type;
            if (type == "success") {
                this.icon = "mdi-check-circle";
            } else if (type == "warning") {
                this.icon = "mdi-alert";
            } else if (type == "error") {
                this.icon = "mdi-alert-circle";
            } else if (type == "info") {
                this.icon = "mdi-information";
            }
            this.show = true;
            console.log(this.$state)
        }
    }
});