new Vue({
    el: "#app",
    vuetify: vuetifyConfig,
    data: {
        org: org,
        isAdding: false,
        isProcessing: false,
        addModel: {
            Name: null,
            SpeciesId: null
        },
        entities: [],
        entitiesLoaded: false,
        entitiesHeaders: [
            { text: "Espécie", width: "200px", value: "species-id" },
            { text: "Raça", value: "name" },
            { text: 'Ações', value: 'actions' },
        ],
        species: [],
        speciesLoaded: false,
    },
    mounted() {
        org.mounted(this)

        fetch("/Races/Data", {
            method: "POST",
            headers: {
                'Cache-Control': 'no-cache'
            }
        }).then(res => {
            if (res.ok) {
                res.json().then(obj => {
                    Vue.set(this, "entities", obj)
                    Vue.set(this, "entitiesLoaded", true)
                })
            } else {
                org.showAlert("Ocorreu um erro", "Não foi possível carregar a lista de raças")
            }
        })

        fetch("/Species/Data", {
            method: "POST",
        }).then(res => {
            if (res.ok) {
                res.json().then(obj => {
                    Vue.set(this, "species", obj)
                    Vue.set(this, "speciesLoaded", true)
                })
            } else {
                org.showAlert("Ocorreu um erro", "Não foi possível carregar a lista de espécies")
            }
        })
    },
    methods: {
        add() {
            this.isProcessing = true

            fetch("/Races/Add", {
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
        },
        getSpecies(id) {
            for (var item of this.species) {
                if (item.id === id) {
                    return item
                }
            }
        }
    }
})
