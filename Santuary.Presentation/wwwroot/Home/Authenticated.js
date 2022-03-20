new Vue({
    el: "#app",
    vuetify: vuetifyConfig,
    data: {
        org: org,
    },
    mounted() {
        org.mounted(this)
    },
    methods: {

    }
})
