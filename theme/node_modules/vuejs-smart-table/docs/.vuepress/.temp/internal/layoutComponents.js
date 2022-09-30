import { defineAsyncComponent } from 'vue'

export const layoutComponents = {
  "404": defineAsyncComponent(() => import("/Users/tochoromero/git/vuejs-smart-table/node_modules/@vuepress/theme-default/lib/client/layouts/404.vue")),
  "Layout": defineAsyncComponent(() => import("/Users/tochoromero/git/vuejs-smart-table/node_modules/@vuepress/theme-default/lib/client/layouts/Layout.vue")),
}
