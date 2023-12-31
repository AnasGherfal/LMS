import router from "@/router";
//import { useIdentityStore } from "@/stores/Identity";
//import { useWarningStore } from "@/stores/warning";
import type { AxiosError, AxiosRequestConfig } from "axios";
import axios from "axios";

const config = {
    baseURL: "http://localhost:5173/v1.0/management",
    timeout: 60000,
    headers: { "Content-type": "Application/json" },
};

const httpClient = axios.create(config);

httpClient.interceptors.request.use(
    
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    (config: any) => {
        const loading = useLoadingStore();
        loading.start();
        const store = useIdentityStore();
        // if (config.headers != undefined) {
        //     config.headers.Authorization = `Bearer ${store.token}`;
        // }
        return config;
    },
    // (error) => Promise.reject(error)
);

httpClient.interceptors.response.use(
    (response) => {
        const loading = useLoadingStore();
        //loading.stop();
        const snack = useSnackbarStore();
        console.log(response.data.msg)

        if (response.data.msg != undefined && response.data.msg != null && response.data.msg != '') {
        snack.showSnack(response.data.msg, 'success');
    }
    return response
},
    (error: AxiosError) => {
        const snack = useSnackbarStore();
        const identityStore = useIdentityStore();

        if (error.code === "ERR_NETWORK") {
            snack.showSnack("الرجاء التحقق من اتصالك بالشبكة", 'error');
            return Promise.reject(error);
        }

        if (error.response != undefined) {
            // eslint-disable-next-line @typescript-eslint/no-explicit-any
            const {
                status = null,
                data: { msg } = null,
            }: { status: any; data: any } = error.response;

            if (status === 401) {
                // identityStore.logout();
            } else if (status === 403) {
                window.location.replace(import.meta.env.VITE_LOGINPAGE);
            } else if (status === 404) {
                router.replace({ name: "not-found" });
                snack.showSnack(msg, 'error');
            } else if (status === 400) {
                console.log(msg)
                snack.showSnack(msg, 'error');
            } else {
                snack.showSnack(msg, 'error');
            }
        }

        return Promise.reject(error);
    }
);

export default httpClient;
