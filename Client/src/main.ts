/**
 * main.ts
 *
 * Bootstraps Vuetify and other plugins then mounts the App`
 */

// Plugins
import { registerComponents } from '@/components'
import { registerPlugins } from '@/plugins'
import '@/assets/styles/main.scss'
// Components
import App from './App.vue'

// Composables
import { createApp } from 'vue'

const app = createApp(App)
registerComponents(app);

registerPlugins(app)

app.mount('#app')
