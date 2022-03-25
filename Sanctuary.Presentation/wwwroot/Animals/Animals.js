new Vue({
    el: "#app",
    vuetify: vuetifyConfig,
    data: {
        org: org,
        isAdding: false,
        isProcessing: false,
        addModel: {
            Name: null,
            RaceId: null,
            Birthdate: null,
            HasBirthdate: null,
            HasAccurateBirthdate: null
        },
        entities: [],
        entitiesLoaded: false,
        entitiesHeaders: [
            { text: 'Nome', value: 'name' },
            { text: 'Espécie', value: 'species' },
            { text: 'Raça', value: 'race' },
            { text: 'Sexo', value: 'sex' },
            { text: 'Idade', value: 'birthdate' },
            { text: 'Ações', value: 'actions' },
        ],
        species: [],
        speciesLoaded: false,
        races: [],
        racesLoaded: false,
        speciesRaces: [],
        birthdateType: null,
        birthdateApproximation: null,
        birthdateApproximationType: null,
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

        fetch("/Races/Data", {
            method: "POST",
        }).then(res => {
            if (res.ok) {
                res.json().then(obj => {
                    Vue.set(this, "races", obj)
                    Vue.set(this, "racesLoaded", true)
                })
            } else {
                org.showAlert("Ocorreu um erro", "Não foi possível carregar a lista de espécies")
            }
        })
    },
    methods: {
        onChangeSpecies(speciesId) {
            this.speciesRaces = this.getRaces(speciesId)
        },
        add() {
            this.isProcessing = true

            if (this.birthdateType == 1) {
                this.addModel.HasBirthdate = true
                this.addModel.HasAccurateBirthdate = true
            } else if (this.birthdateType == 2) {
                this.addModel.Birthdate = moment().subtract(this.birthdateApproximation, this.birthdateApproximationType)
                this.addModel.HasBirthdate = true
                this.addModel.HasAccurateBirthdate = false
            } else if (this.birthdateType == 3) {
                this.addModel.Birthdate = undefined
                this.addModel.HasBirthdate = false
                this.addModel.HasAccurateBirthdate = false
            }

            fetch("/Animals/Add", {
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
        getRaces(speciesId) {
            var data = []
            for (var item of this.races) {
                if (item.speciesId == speciesId) {
                    data.push(item)
                }
            }
            return data
        },
        getRaceById(raceId) {
            var data = {
                name: "Carregando...",
            }
            for (var item of this.races) {
                if (item.id == raceId) {
                    data = item
                    break
                }
            }
            return data
        },
        getSpeciesById(speciesId) {
            var data = {
                name: "Carregando...",
            }
            for (var item of this.species) {
                if (item.id == speciesId) {
                    data = item
                    break
                }
            }
            return data
        },
        getSpeciesByRace(raceId) {
            var data = {
                name: "Carregando...",
            }
            for (var item of this.races) {
                if (item.id == raceId) {
                    data = this.getSpeciesById(item.speciesId)
                }
            }
            return data
        }
    }
})
