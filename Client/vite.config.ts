// Plugins
import vue from "@vitejs/plugin-vue";
import vuetify, { transformAssetUrls } from "vite-plugin-vuetify";
import { VuetifyResolver } from "unplugin-vue-components/resolvers";
import AutoImport from "unplugin-auto-import/vite";
import Components from "unplugin-vue-components/vite";

// Utilities
import { defineConfig } from "vite";
import { fileURLToPath, URL } from "node:url";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [
    vue({
      template: { transformAssetUrls },
    }),
    // https://github.com/vuetifyjs/vuetify-loader/tree/master/packages/vite-plugin#readme
    vuetify({
      autoImport: true,
      styles: {
        configFile: "src/assets/styles/global/settings.scss",
      },
    }),
    AutoImport({
      imports: ["vue", "vue-router", "@vueuse/core"],
      dts: "src/auto-imports.d.ts",
      dirs: ["src/composables/**", "src/store", "src/view/"],
      vueTemplate: true,
      resolvers: [VuetifyResolver()],
    }),
    Components({
      extensions: ["vue"],
      dts: "src/vue-components.d.ts",
      resolvers: [VuetifyResolver()],
    }),
  ],
  define: { "process.env": {} },
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", import.meta.url)),
    },
    extensions: [".js", ".json", ".jsx", ".mjs", ".ts", ".tsx", ".vue"],
  },
  build: {
    outDir: "../wwwroot",
},
  server: {
    port: 5174,

  },
});
