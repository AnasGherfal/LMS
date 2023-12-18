<template src="./create.html"></template>
<script setup lang="ts">

import { useRouter } from "vue-router";
import type { Department } from "/.model";

// New product data to be filled in the form
const newProduct = ref<Department>({
  departmentName: "",
  contact: "",
});

// Product details mapping
const productDetails = {
  "إسم القسم": "departmentName",
  تواصل: "contact",
};

const router = useRouter();

// Method to submit the form and add the new product
const submitForm = () => {
  // Add validation logic if needed
  // Push the new product to the products array (or perform any other action)
  // In a real application, you might want to send this data to a server
  // Navigate back to the product list page
  router.push("/departments");
};
</script>
