// Composables
import { createRouter, createWebHistory } from "vue-router";
import layouts from "@/layouts/default.vue";

import licenses from "@/views/licenses/route";
import products from "@/views/products/route";
import categories from "@/views/categories/route";
import departments from "@/views/departments/route";

const routes = [
  {
    path: "/",
    name: "Home",
    component: layouts,
    redirect:licenses,

    children: [...licenses, ...products, ...categories, ...departments],
  },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router;
