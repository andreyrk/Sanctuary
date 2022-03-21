new Vue({
    el: "#app",
    vuetify: vuetifyConfig,
    data: {
        org: org,
        forgotPasswordDialog: false,
        forgotPasswordModel: {
            Email: ""
        },
        loginModel: {
            Name: "",
            Password: ""
        },
        registerModel: {
            Name: "",
            Birthdate: "",
            Email: "",
            Phone: "",
            Password: "",
            ConfirmPassword: "",
        },
        isLoggingIn: false,
        isRegistering: false,
        isRecovering: false,
    },
    mounted() {
        org.mounted(this)
    },
    methods: {
        index() {
            window.location.href = "/"
        },
        onForgotPassword() {
            if (!this.$refs.forgotPasswordForm.validate()) {
                return
            }

            //fetch("/Account/NewForgotPassword", {
            //    method: "POST",
            //    headers: { "Content-Type": "application/json" },
            //    body: JSON.stringify(this.forgotPasswordModel)
            //}).finally(() => {
            //    this.forgotPasswordDialog = false
            //    this.isRecovering = false
            //    this.org.showAlert("OK!", "Caso este e-mail esteja cadastrado, você em breve receberá o link de recuperação de senha na caixa de entrada")
            //})
        },
        onSuccess() {
            var searchParams = new URLSearchParams(window.location.search)
            var returnUrl = undefined
            for (let param of searchParams.keys()) {
                if (param.toLowerCase() == "returnurl") {
                    returnUrl = searchParams.get(param)
                }
            }

            window.location.href = returnUrl ? returnUrl : "/"
        },
        onLogin() {
            if (!this.$refs.loginForm.validate()) {
                return
            }

            this.isLoggingIn = true;

            fetch("/Authentication/Login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    Email: this.loginModel.Email,
                    Password: this.loginModel.Password,
                })
            }).then(response => {
                if (response.ok) {
                    response.json().then(data => {
                        if (data.success) {
                            this.onSuccess()
                        } else {
                            this.org.showAlert("Ocorreu um erro", data.message)
                        }
                    })
                }
            }).catch(error => {
                this.org.showAlert("Ocorreu um erro", error)
            }).finally(() => {
                this.isLoggingIn = false
            })
        },
        onRegister() {
            if (!this.$refs.registerForm.validate()) {
                return
            }

            if (this.registerModel.Password !== this.registerModel.ConfirmPassword) {
                this.org.showAlert("Erro", "A confirmação de senha deve ser igual a senha inserida")
            }

            this.isRegistering = true

            fetch("/Authentication/Register", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    Name: this.registerModel.Name,
                    Email: this.registerModel.Email,
                    Phone: this.registerModel.Phone,
                    Password: this.registerModel.Password,
                    Birthdate: new Date(this.registerModel.Birthdate.split("/").reverse().join("-"))
                })
            }).then(response => {
                if (response.ok) {
                    response.json().then(data => {
                        if (data.success) {
                            this.onSuccess()
                        } else {
                            this.org.showAlert("Ocorreu um erro", data.message)
                        }
                    })
                }
            }).catch(error => {
                this.org.showAlert("Ocorreu um erro", error)
            }).finally(() => {
                this.isRegistering = false
            });
        },
        formatDate(ev) {
            $(ev.target).mask("00/00/0000")
        }
    },
    computed: {
        genericRules() {
            return [
                v => v != "" || "Campo necessário"
            ]
        },
        dateRules() {
            return [
                v => v != "" || "Campo necessário",
                v => v.length == 10 || "Insira uma data válida",
                v => new Date(v.split("/").reverse().join("-")).toString() != "Invalid Date" || "Insira uma data válida",
            ]
        }
    },
})
