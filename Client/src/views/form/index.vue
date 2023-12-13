<template>
    <v-card class="mx-auto">
        <v-card-item>
            <v-card-title class="align-center pe-2">
                عنوان الجدول

                <v-spacer></v-spacer>


            </v-card-title>
        </v-card-item>

        <v-card-text>
            <v-form @submit.prevent>
                <v-text-field v-model="firstName" :rules="rules" label="First name"></v-text-field>
                <v-btn type="submit" block class="mt-2">Submit</v-btn>
            </v-form>
        </v-card-text>
    </v-card>
</template>