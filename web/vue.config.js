const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  devServer: {
    port: process.env.VUE_APP_PORT,
    proxy: process.env.BASE_URL,
  },
  transpileDependencies: true
})
