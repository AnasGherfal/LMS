<script lang="ts" setup>
const props = withDefaults(
    defineProps<{
        value?: any | undefined;
        label: string;
        itemValue?: string;
        itemText?: string;
        variant?: "outlined" | "solo" | "filled" | "plain" | "underlined" | "solo-inverted" | "solo-filled" | undefined;
        density?: 'default' | 'comfortable' | 'compact';
        returnObject?: boolean;
        items: any[];
        disabled?: boolean;
        clearable?: boolean;
        hideDetails?: boolean;
        multiple? : boolean;
    }>(),
    {
        label: 'ادخل',
        itemValue: 'value',
        itemText: 'text',
        variant: 'outlined',
        density: 'compact',
        returnObject: false,
        items: function () { return [] },
        disabled: false,
        clearable: false,
        hideDetails: false,
        multiple: false,
    }
);
</script>
<template>
    <v-autocomplete :label="label" :v-model="value" :items="items" :variant="variant" :clearable="clearable" :multiple="multiple"
        :item-value="itemValue" :item-title="itemText" :density="density" :disabled="disabled" :hide-details="hideDetails"
        class="rounded-xl" :return-object="returnObject">
    </v-autocomplete>
</template>