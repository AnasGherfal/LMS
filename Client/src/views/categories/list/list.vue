<script lang="ts" setup>
import { ref, onMounted } from "vue";
import { useRouter } from "vue-router";

const pp = ref([]);

// Fetch data from ASP.NET API
const fetchData = async () => {
  try {
    const response = await fetch(
      "https://localhost:7246/v1.0/management/Categories"
    );
    const data = await response.json();
    pp.value = data; // Assuming data is an array of objects with the necessary properties
    console.log(data);
  } catch (error) {
    console.error("Error fetching data:", error);
  }
};

// Call fetchData when the component is mounted
onMounted(() => {
  fetchData();
});
const router = useRouter();

// Method to navigate to the create category page
const navigateToAddCategoryPage = () => {
  router.push({ name: "CreateCategories" });
};
</script>

<template src="./list.html"></template>
