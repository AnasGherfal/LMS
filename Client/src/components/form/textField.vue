<script lang="ts" setup>
const props = withDefaults(
    defineProps<{
        value?: any;
        label: string;
        rules?: string[] | boolean[];
        variant?: "outlined" | "solo" | "filled" | "plain" | "underlined" | "solo-inverted" | "solo-filled" | undefined;
        density?: 'default' | 'comfortable' | 'compact';
        disabled?: boolean;
        hideDetails?: boolean;
        clearable?: boolean;
        type?: string;
        prepend_icon?: any;
        solo?: boolean;
        hint?: string | undefined;
    }>(),
    {
        label: 'ادخل',
        variant: 'outlined',
        density: 'compact',
        disabled: false,
        hideDetails: false,
        clearable: false,
        type: 'text',
        prepend_icon: null,
        solo: false,
    }
);
</script>

<template>
    <v-text-field :model-value="value" :rules="rules" :label="label" @input="$emit('input', $event)"
        :hide-details="hideDetails" :density="density" class="rounded-xl" :type="type" :variant="variant"
        :prepend-icon="prepend_icon" :solo="solo" :hint="hint" @click:append="$emit('append', $event)" :disabled="disabled">
    </v-text-field>
</template>
