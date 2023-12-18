<template src="./list.html"></template>
<script setup lang="ts">
import { ref } from "vue";
import { type Product } from "./model";
import { useRouter } from "vue-router";

const products = ref<Product[]>([
  {
    productName: "المنتج 1",
    category: " فئة 1",
    totalLicense: 100,
    availability: "قيد التوفر",
    contact: "أنس قرفال",
    provider: "المزود 1",
    impactLevel: "عالي جدا",
  },
  {
    productName: "المنتج 1",
    category: " فئة 1",
    totalLicense: 100,
    availability: "قيد التوفر",
    contact: "أنس قرفال",
    provider: "المزود 1",
    impactLevel: "عالي جدا",
  },
  {
    productName: "المنتج 1",
    category: " فئة 1",
    totalLicense: 100,
    availability: "قيد التوفر",
    contact: "أنس قرفال",
    provider: "المزود 1",
    impactLevel: "عالي جدا",
  },
  {
    productName: "المنتج 1",
    category: " فئة 1",
    totalLicense: 100,
    availability: "قيد التوفر",
    contact: "أنس قرفال",
    provider: "المزود 1",
    impactLevel: "عالي جدا",
  },
  {
    productName: "المنتج 1",
    category: " فئة 1",
    totalLicense: 100,
    availability: "قيد التوفر",
    contact: "أنس قرفال",
    provider: "المزود 1",
    impactLevel: "عالي جدا",
  },
]);

const productDetails = {
  "إسم المنتج": "productName",
  الفئة: "category",
  "إجمالي الرخصة": "totalLicense",
  التوفر: "availability",
  التواصل: "contact",
  المزود: "provider",
  "مستوى التأثير": "impactLevel",
};

const router = useRouter();

const navigateToAddProductPage = () => {
  console.log("sss");
  router.push({ name: "CreateLicense" });
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
