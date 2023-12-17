export default [
  {
    path: "/departments",
    name: "Departments",
    component: () => import("./index.vue"),
    meta: {
      title: "الأقسام",
      hasChildren: false,
      icon: "mdi-file-document-multiple-outline",
      // roles: [1,2]
    },
    children: [
      {
        path: "",
        name: "DepartmentsList",
        component: () => import("./list/list.vue"),
        meta: {
          title: "قائمة الأقسام",
          isSideBar: true,
        },
      },
      {
        path: "create",
        name: "CreateDepartments",
        component: () => import("./create/create.vue"),
        meta: {
          title: " جديدة",
        },
      },
      {
        path: ":id",
        name: "Departments",
        component: () => import("./view/view.vue"),
        meta: {
          title: "عرض ",
        },
      },
    ],
  },
];
