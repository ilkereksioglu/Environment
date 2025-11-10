const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  devServer: {
    proxy: process.env.BASE_URL,
  },
  transpileDependencies: true
})
