new Vue({
    el: "#app",
    vuetify: vuetifyConfig,
    data: {
        org: org,
        entities: [],
        entitiesHeaders: [
            { text: 'Nome', value: 'name' },
            { text: 'Espécie', value: 'speciesId' },
            { text: 'Sexo', value: 'sex' },
            { text: 'Nascimento', value: 'birthdate' },
        ],
        entitiesLoaded: false
    },
    mounted() {
        org.mounted(this)

        fetch("/Animals/Data", {
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
                org.showAlert("Ocorreu um erro", "Não foi possível carregar a lista de animais")
            }
        })
    },
    methods: {

    }
})
