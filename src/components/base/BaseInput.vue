<template>
  <div :class="'base-input' + id" class="input-embrace">
    <div class="form-group">
      <h3 class="input-header label-field__input">
        <div v-if="binding == true">
          {{ value }}(<span class="correct">*</span>)
        </div>
        <div v-else>
          {{ value }}
        </div>
      </h3>
      <div v-if="iconMoney == true">
        <input
          :type="type"
          class="input input-money"
          :id="id"
          v-model="nameInput"
          @focus="validate"
          @input="formatAndSubmit"
        />
        <span class="input-icon input-vnd">(VNĐ)</span>
      </div>
      <div v-else>
        <input
          :type="type"
          class="input"
          :id="id"
          v-model="nameInput"
          :format="type"
          @focus="validate"
          @input="formatAndSubmit"
          :autofocus="autofocus"
        />
      </div>
      <div v-if="binding == true">
        <div class="form-message"></div>
      </div>
    </div>
  </div>
</template>

<script>
import Format from "../../untils/Format.js";
import $ from "jquery";
export default {
  name: "Input",
  props: {
    autofocus :{
      type : Boolean,
      required : false,
    },
    name: {
      type: [String, Number],
      default: "",
      required: true,
    },
    id: {
      type: String,
      required: true,
    },
    value: {
      type: String,
      required: true,
    },
    type: {
      type: String,
      required: true,
    },
    binding: {
      type: Boolean,
      required: false,
    },
    iconMoney: {
      type: Boolean,
      required: false,
    },
    isFocus: {
      type: Boolean,
      default: false,
    },
  },
  methods: {
    /**
     * Hàm xử lý khi nhập tiền lương trong form và truyền dữ liệu lên cha để submit
     * creatAt : PVM.Quân (03/08/2021)
     */
    formatAndSubmit() {
      if (this.iconMoney == true) {
        $(".input-money").on("input", function () {
          var value = $(".input-money").val();
          var afterformat = String(value).replaceAll(".", "");
          $(".input-money").val(Format.salaryFormat(afterformat));
        });
      }
    },
    /**
     * Hàm xử lý khi một ô input được focus mặc định
     * creatAt : PVM.Quân (03/08/2021)
     */
    focusInput() {
      this.$refs('input').focus()
    },
    /**
     * Gửi form lên cha để validate dữ liệu
     * creatAt : PVM.Quân (03/08/2021)
     */
    validate() {
      this.$emit("sendDomValidate", this.formGroup, this.formMessage);
    },
  },
  watch: {
    /**
     * Xử lý định dạng các thành phần khi api về
     * PVM.Quân (04/08/2021)
     */
    name: function () {
      this.nameInput = this.name;
    },

     /**
     * Gửi dữ liệu lên cha để submit
     * creatAt : PVM.Quân (03/08/2021)
     */
    nameInput: function () {
          var value = this.nameInput
          this.$emit("sendValueInput", value, this.id);
    },
  },
  data() {
    return {
      nameInput: "",
      typeInput: "",
      formGroup: "form-group",
      formMessage: "form-message",
    };
  },
};
</script>

<style scoped>
@import url("../../assets/css/form/Staff_information.css");
@import url("../../assets/css/base/Input.css");
@import url("../../assets/css/base/Vadilator.css");
</style>