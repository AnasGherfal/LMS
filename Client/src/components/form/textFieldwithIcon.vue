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
        place?: string | undefined;
        icon?: string | undefined;
        iconColor?: string | undefined;
        alert?: string | undefined;
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
 <v-tooltip bottom>
    <template v-slot:activator="{ props }">
      <v-text-field
        v-bind="props"
        :model-value="value"
        :rules="rules"
        :label="label"
        @input="$emit('input', $event)"
        :hide-details="hideDetails"
        :density="density"
        class="rounded-xl"
        :type="type"
        :variant="variant"
        :prepend-icon="prepend_icon"
        :solo="solo"
        :hint="hint"
        @click:append="$emit('append', $event)"
        :disabled="disabled"
      >
        <template v-slot:append-inner>
          <v-icon :icon="icon" :color="iconColor"></v-icon>
        </template>
      </v-text-field>
    </template>
    <span>{{ props.alert }}</span>
  </v-tooltip>
</template>
