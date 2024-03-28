import { createApp } from 'vue'
import './style.css'
import App from './App.vue'

// UI
import Antd from 'ant-design-vue';
import 'ant-design-vue/dist/reset.css';

// router
import router from './router/index'

const vueApp = createApp(App);

vueApp
.use(Antd)
.use(router)
.mount('#app')
