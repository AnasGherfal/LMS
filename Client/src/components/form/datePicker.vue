<script lang="ts" setup>
const props = withDefaults(
    defineProps<{
        label?: string;
        modelValue?: any;
        rules?: string[] | boolean[];
        variant?: "outlined" | "solo" | "filled" | "plain" | "underlined" | "solo-inverted" | "solo-filled" | undefined;
        density?: 'default' | 'comfortable' | 'compact';
        disabled?: boolean;
        hideDetails?: boolean;
        clearable?: boolean;
        type?: string;
        solo?: boolean;
        hint?: string | undefined;
    }>(),
    {
        label: 'اختر تاريخ',
        variant: 'outlined',
        density: 'compact',
        disabled: false,
        hideDetails: false,
        clearable: false,
        type: 'text',
        solo: false,
    }
);
const emit = defineEmits(["update:modelValue"]);
const menu = ref(false);
const value = ref(props.modelValue);

const formattedDate = computed(() => {
  return value.value ? value.value.toLocaleDateString("ar") : "";
});

 watch(value, (newDate) => {
   value.value = newDate;
 });

watch(value, (newDate) => {
    value.value = newDate;
    emit("update:modelValue", newDate.toLocaleDateString("en"));
    menu.value = false;
});
</script>

<template>
    <v-menu v-model="menu" :close-on-content-click="false" transition="scale-transition" offset-y min-width="auto">
        <template v-slot:activator="{ props }">
            <v-text-field :label="label" :model-value="formattedDate" append-inner-icon="mdi-calendar" v-bind="props" :rules="rules"
                :hide-details="hideDetails" :density="density" class="rounded-xl" :type="type" :variant="variant"
                :solo="solo" :hint="hint" :disabled="disabled">
            </v-text-field>
        </template>

        <v-date-picker v-model="value">
        </v-date-picker>
    </v-menu>
</template>