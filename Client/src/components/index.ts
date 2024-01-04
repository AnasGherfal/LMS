import autoComplete from "./form/autoComplete.vue";
import textfield from "./form/textField.vue";
import selectfield from "./form/selectField.vue";
import selectfieldIcon from "./form/textFieldwithIcon.vue";

import datePicker from "./form/datePicker.vue";
import textarea from "./form/textarea.vue";
import fileUpload from "./form/fileUpload.vue";
import snackbar from "./general/snackbar.vue";
import loading from "./general/loading.vue";

// Types
import type { App } from "vue";

export function registerComponents(app: App) {
  app.component("auto-complete", autoComplete);
  app.component("text-field", textfield);
  app.component("select-field", selectfield);
  app.component("select-field-icon", selectfieldIcon);
  app.component("date-picker", datePicker);
  app.component("text-area", textarea);
  app.component("file-upload", fileUpload);
  app.component("snackbar", snackbar);
  app.component("loading", loading);
}
