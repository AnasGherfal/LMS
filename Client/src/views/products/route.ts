export default [
  {
    path: "/products",
    name: "Products",
    component: () => import("./index.vue"),
    meta: {
      title: "المنتجات",
      hasChildren: false,
      icon: "mdi-file-document-multiple-outline",
      // roles: [1,2]
    },
    children: [
      {
        path: "",
        name: "ProductList",
        component: () => import("./list/list.vue"),
        meta: {
          title: "قائمة المنتجات",
          isSideBar: true,
        },
      },
      {
        path: "create",
        name: "CreateProducts",
        component: () => import("./create/create.vue"),
        meta: {
          title: "منتج جديد",
        },
      },
      {
        path: ":id",
        name: "Product",
        component: () => import("./view/view.vue"),
        meta: {
          title: "عرض المنتج",
        },
      },
    ],
  },
];
