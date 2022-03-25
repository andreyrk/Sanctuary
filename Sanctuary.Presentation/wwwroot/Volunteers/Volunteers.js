new Vue({
    el: "#app",
    vuetify: vuetifyConfig,
    data: {
        org: org,
        entities: [],
        entitiesHeaders: [
            { text: 'Nome', value: 'name' },
            { text: 'Telefone', value: 'phone' },
            { text: 'Email', value: 'email' },
            { text: 'Nascimento', value: 'birthdate' },
            { text: 'Ações', value: 'actions' },
        ],
        entitiesLoaded: false
    },
    mounted() {
        org.mounted(this)

        fetch("/Volunteers/Data", {
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
                org.showAlert("Ocorreu um erro", "Não foi possível carregar a lista de voluntários")
            }
        })
    },
    methods: {

    }
})
