<script lang="ts" setup>
const props = withDefaults(
    defineProps<{
        modelValue?: File[];
        label: string;
        rules?: string[] | boolean[];
        variant?: "outlined" | "solo" | "filled" | "plain" | "underlined" | "solo-inverted" | "solo-filled" | undefined;
        density?: 'default' | 'comfortable' | 'compact';
        disabled?: boolean;
        hideDetails?: boolean;
        clearable?: boolean;
        solo?: boolean;
        hint?: string | undefined;
    }>(),
    {
        label: 'اختر',
        variant: 'outlined',
        density: 'compact',
        disabled: false,
        hideDetails: false,
        solo: false,
    }
);
//const emit = defineEmits(["update:modelValue"]);

//const value = computed({
//  get() {
//    return props.modelValue;
//  },
//  set(value) {
//    console.log(value)
//    emit("update:modelValue", value);
//  },
//});

//    watch(value, (newVal) => {
//        value.value = newVal;
//        emit("update:modelValue", newVal);
//});
</script>


<template>
    <v-file-input
        :model-value="modelValue"
        :rules="rules" :label="label"
        :hide-details="hideDetails" :density="density" class="rounded-xl"
        :variant="variant"
        :solo="solo" :hint="hint" :disabled="disabled"  
    ></v-file-input>
  </template>
