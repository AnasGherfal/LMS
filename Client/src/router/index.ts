// Composables
import { createRouter, createWebHistory } from 'vue-router'
import layouts from '@/layouts/Default.vue';

import licenses from "@/views/licenses/route";
import products from "@/views/products/route";
import categories from "@/views/categories/route";


const routes = [
  {
    path: '/',
    name: 'Home',
    component: layouts,

    children: [
      
        ...licenses,
        ...products,
        ...categories,
      
    ],
  },
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

export default router
