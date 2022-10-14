<template>
  <v-card height="400px">
    <v-footer v-bind="localAttrs" color="white" :padless="padless" >
      <v-card flat tile width="99%" style="margin: 1em;" class="footer lighten-1 text-center" >
        <v-card-text>
          <v-btn  v-for="icon in icons" :key="icon" class="mx-4" icon>
            <v-icon size="24px">
              {{ icon }}
            </v-icon>
          </v-btn>
        </v-card-text>

        <v-divider></v-divider>

        <v-card-text class="black--text">
          {{ new Date().getFullYear() }} — <strong>Gestion Academica</strong>
        </v-card-text>
      </v-card>
    </v-footer>

  </v-card>
</template>
<script>
  export default {
    data: () => ({
      icons: [
        'mdi-home',
        'mdi-email',
        'mdi-calendar',
        'mdi-delete',
      ],
      padless: false,
      variant: 'fixed',
    }),
    computed: {
      localAttrs () {
        const attrs = {}

        if (this.variant === 'default') {
          attrs.absolute = false
          attrs.fixed = false
        } else {
          attrs[this.variant] = true
        }
        return attrs
      },
    },
  }
</script>