new Vue({
    el: "#app",
    vuetify: vuetifyConfig,
    data: {
        org: org,
        entities: [],
        entitiesHeaders: [
            { text: 'Nome', value: 'name' },
        ],
        entitiesLoaded: false,
        addModel: {
            Name: null
        },
        isAdding: false,
        isProcessing: false
    },
    mounted() {
        org.mounted(this)

        fetch("/Species/Data", {
            method: "POST",
        }).then(res => {
            if (res.ok) {
                res.json().then(obj => {
                    Vue.set(this, "entities", obj)
                    Vue.set(this, "entitiesLoaded", true)
                })
            } else {
                org.showAlert("Ocorreu um erro", "Não foi possível carregar a lista de espécies")
            }
        })
    },
    methods: {
        add() {
            this.isProcessing = true

            fetch("/Species/Add", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(this.addModel),
            }).then(res => {
                if (res.ok) {
                    location.reload()
                } else {
                    org.showAlert("Ocorreu um erro", "Não foi possível salvar os dados")
                }

                this.isProcessing = false
            })
        }
    }
})
