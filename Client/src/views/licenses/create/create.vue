
<script setup lang="ts">

import type { License } from "./model";
import { licenseService} from '../service'
const license = reactive<License>({
    ProductId :  null,
    DepartmentId :  null,
    NumOfDevices :  null,
    SerialKey :  null,
    ImpactLevel :  null,
    ImpactDescription :  null,
    StartDate : null,
    ExpireDate :  null,
    Contact : null,
    TimeType :  null,
    PriceInUSD :  null,
    PriceInLYD :  null,
})


const router = useRouter();
const pageTitle = router.currentRoute.value.meta.title;

// Method to submit the form and add the new Category
const create = async () => {
const licenseForm = new FormData();

for (const [key, value] of Object.entries(license)) {
   
      
        licenseForm.append(`${key}`, value as any);
    }
 
  
    try {
        const { data } = await licenseService.create(licenseForm);
        //showNotification(data.msg);
        //loading.stop();
        router.go(-1);
    } catch {
        //loading.stop();
    }
};
</script>
<template src="./create.html"></template>
