<template src="./create.html"></template>
<script setup lang="ts">
import { ref } from "vue";
import { useRouter } from "vue-router";
import type { Category } from "./model";

// New product data to be filled in the form
const newCategory = ref<Category>({
  categoryName: "",
  description: "",
});

const router = useRouter();

// Method to submit the form and add the new Category
const submitForm = async () => {
  try {
    // Send a POST request to the API endpoint with newCategory data
    await fetch("https://localhost:7246/v1.0/management/Categories", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newCategory.value),
    });

    // Navigate back to the product list page
    router.push("/categories");
  } catch (error) {
    console.error("Error submitting form:", error);
    // Handle error (show a message or take appropriate action)
  }
};
</script>
