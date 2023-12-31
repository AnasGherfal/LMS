﻿export default [
    {
        path: '/categories',
        name: 'Categories',
        component: () => import('./index.vue'),
        meta: {
            title: 'الفئات',
            hasChildren: false,
            icon: "mdi mdi-shape",
            // roles: [1,2] 
        },
        children: [
            {
                path: '',
                name: 'CategoriesList',
                component: () => import('./list/list.vue'),
                meta: {
                    title: 'قائمة الفئات',
                    isSideBar: true,
                },
            },
            {
                path: 'create',
                name: 'CreateCategories',
                component: () => import('./create/create.vue'),
                meta: {
                    title: ' فئة جديدة',
                },
            },
            {
                path: ':id',
                name: 'Category',
                component: () => import('./view/view.vue'),
                meta: {
                    title: ' عرض الفئة',
                },
            },
            
        ]
    }
]