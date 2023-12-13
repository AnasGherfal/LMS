<!-- src/components/Login.vue -->
<template>
  <v-row class="login-container">
    <!-- Right Side -->
    <v-col class="right-side" cols="12" md="6">
      <v-container>
        <v-row class="rounded-card">
          <v-col>
            <!-- Include logo and text directly inside the rounded card -->
            <v-img src="/company_logo.png" class="background-logo-img"></v-img>
            <h2 class="text-center-1">مرحباً بك في</h2>
            <h1 class="text-center-2">نظام إدارة الرخص</h1>
          </v-col>
        </v-row>
      </v-container>
    </v-col>
    <!-- Left Side -->
    <v-col class="left-side" cols="12" md="6">
      <v-container>
        <v-row class="company-info" align="center">
          <v-col cols="2" class="pa-0">
            <v-img src="/company_logo.png" class="logo"></v-img>
          </v-col>
          <v-col>
            <div class="company-name">ليبيا<br />للإتصالات<br />والتقنية</div>
          </v-col>
        </v-row>

        <v-row class="mt-6">
          <v-col>
            <v-form @submit.prevent="signIn">
              <v-row>
                <v-col cols="12">
                  <v-text-field
                    v-model="email"
                    label="الحساب"
                    required
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="12">
                  <v-text-field
                    v-model="password"
                    label="كلمة المرور"
                    type="password"
                    required
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="12">
                  <v-btn type="submit" class="submit_button">تسجيل دخول</v-btn>
                </v-col>
              </v-row>
            </v-form>
          </v-col>
        </v-row>
      </v-container>
    </v-col>
  </v-row>
</template>

<script>
export default {
  data() {
    return {
      email: "",
      password: "",
    };
  },
  methods: {
    signIn() {
      // Implement login logic here
      console.log("Email:", this.email);
      console.log("Password:", this.password);
    },
  },
};
</script>

<style scoped>
.login-container {
  height: 100vh;
  padding: 45px 65px 65px 55px;
  box-sizing: border-box; /* Include padding in the element's total width and height */
}

.left-side {
  padding: 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.logo {
  width: 120px;
  margin: 0;
  padding: 0px 18px 0px 0px;
}

.company-name {
  margin-top: 10px;
  font-size: 18px;
  font-weight: bold;
  color: #8e8e8e;
}
.company-info {
  display: flex;
  padding: 0px;
}

/* Remove the grey color from text fields */
.v-text-field input {
  background-color: transparent !important;
}

.right-side {
  position: relative;
}

.background-logo {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 100%;
  text-align: center;
  margin-left: 85px;
}

.background-logo-img {
  width: 100%; /* Use 100% width to make it responsive */
  max-width: 580px; /* Set a max-width for larger screens */
  height: auto;
  opacity: 0.1;
  margin-right: auto;
  margin-left: auto;
}
.rounded-card {
  background: linear-gradient(
    135deg,
    #007bff 0%,
    #00bfff 100%
  ); /* Blue gradient color */
  border-radius: 20px;
  position: relative;
  padding: 20px;
  margin-top: 25px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  height: 100%; /* Make the card height cover the whole column */
  display: flex;
  flex-direction: column;
  align-items: center; /* Center content horizontally */
  justify-content: center; /* Center content vertically */
  color: #fff;
}

.text-center-1 {
  font-size: 38px;
  position: absolute;
  top: 42%;
  right: 10%;
  text-align: center;
  color: #fff;
}
.text-center-2 {
  font-size: 65px;
  position: absolute;
  top: 50%;
  right: 10%;
  text-align: center;
  color: #fff;
}

h2 {
  margin-bottom: 10px;
  font-size: 24px;
}

h1 {
  margin: 0;
  font-size: 36px;
  font-weight: bold;
}

/* Style the button */
.submit_button {
  border-radius: 20px;
  width: 35%; /* Make the button 25% of the width */
  background: linear-gradient(
    135deg,
    #ff3d47 0%,
    #ff7e5f 100%
  ); /* Red gradient color */
  color: #fff;
  text-transform: uppercase;
}
</style>
