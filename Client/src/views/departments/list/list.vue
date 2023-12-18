<template src="./list.html"></template>
<script setup lang="ts">
import { ref } from "vue";
import { type Product } from "./model";
import { useRouter } from "vue-router";

const products = ref<Product[]>([
  {
    productName: "Product 1",
    contact: "Category A",
  },
  { productName: "Product 2", contact: "Category B" },
]);

const productDetails = {
  "إسم القسم": "productName",
  تواصل: "contact",
};

const router = useRouter();

const navigateToAddDepartmentPage = () => {
  console.log("sss");
  router.push({ name: "CreateDepartments" });
};
const deleteProduct = (index: number) => {
  products.value.splice(index, 1);
};

const editProduct = (index: number) => {
  // Implement your edit logic here
};

const lockProduct = (index: number) => {
  // Implement your lock logic here
};
</script>
