<template>
  <div class="staff-information" :class="{ active: isHide }">
    <div class="container">
      <div class="staff-information__person">
        <div class="form-staff">
          <div class="staff-information__header">
            <span class="heading staff-information__header-heading"
              >THÔNG TIN NHÂN VIÊN</span
            >
            <img
              src="../../assets/icon/x.svg"
              alt=""
              class="staff-information__header-img"
              @click="btnCancel"
            />
          </div>
          <div class="row">
            <div class="staff-information__img-person col-lg-3">
              <img src="../../assets/img/default-avatar.jpg" alt="" />
              <span
                >(Vui lòng chọn ảnh có định dạng .jbg.,jebg,.png,.git )
              </span>
            </div>
            <div class="staff-information__information-person col-lg-9" ref="form">
              <ul class="staff-information__general row">
                <li class="col-lg-12">
                  <span class="title staff-information__general-title"
                    >A. THÔNG TIN CHUNG</span
                  >
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <Input
                    :name="mode == 1 ? employeeCode : employeeNewCode" 
                    :binding="true"
                    :isFocus="true"
                    value="Mã nhân viên"
                    id="EmployeeCode"
                    type="text"
                    @sendValueInput="getValueInput"
                    @btnCancel="btnCancel"
                    :autofocus ="autofocus"
                    ref="employeecode-input"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <Input
                    :name="employee.FullName == null ? '' : employee.FullName"
                    :binding="true"
                    value="Họ và Tên"
                    id="FullName"
                    type="text"
                    @sendValueInput="getValueInput"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <Input
                    :name="
                      employee.DateOfBirth == null ? '' : employee.DateOfBirth
                    "
                    value="Ngày sinh"
                    id="DateOfBirth"
                    type="date"
                    @sendValueInput="getValueInput"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <h3 class="input-header label-field__input">Giới tính</h3>
                  <DropDown
                    v-if="gender.length"
                    v-bind:options="gender"
                    v-bind:select="
                      employee.Gender == null ? '' : employee.Gender
                    "
                    name="GenderName"
                    id="Gender"
                    @sendValueDropDown="getValueDropDown"
                    :check="check"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <Input
                    :name="
                      employee.IdentityNumber == null
                        ? ''
                        : employee.IdentityNumber
                    "
                    :binding="true"
                    value="Số CMTND/Căn cước"
                    id="IdentityNumber"
                    type="text"
                    @sendValueInput="getValueInput"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <Input
                    :name="
                      employee.IdentityDate == null ? '' : employee.IdentityDate
                    "
                    value="Ngày cấp"
                    id="IdentityDate"
                    type="date"
                    @sendValueInput="getValueInput"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <Input
                    :name="
                      employee.IdentityPlace == null
                        ? ''
                        : employee.IdentityPlace
                    "
                    value="Nơi cấp"
                    id="IdentityPlace"
                    type="text"
                    @sendValueInput="getValueInput"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6"></li>
                <li class="staff-information__general-item col-lg-6">
                  <Input
                    :name="employee.Email == null ? '' : employee.Email"
                    :binding="true"
                    value="Email"
                    id="Email"
                    type="text"
                    @sendValueInput="getValueInput"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <Input
                    :name="
                      employee.PhoneNumber == null ? '' : employee.PhoneNumber
                    "
                    :binding="true"
                    value="Số điện thoại"
                    id="PhoneNumber"
                    type="text"
                    @sendValueInput="getValueInput"
                  />
                </li>
                <li class="col-lg-12 staff-information__work-title">
                  <span class="title staff-information__general-title"
                    >B.THÔNG TIN CÔNG VIỆC</span
                  >
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <h3 class="input-header label-field__input">Vị trí</h3>
                  <DropDown
                    v-if="position.length"
                    v-bind:options="position"
                    v-bind:select="
                      employee.PositionId == null ? '' : employee.PositionId
                    "
                    name="PositionName"
                    id="PositionId"
                    @sendValueDropDown="getValueDropDown"
                    :check="check"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <h3 class="input-header label-field__input">Phòng ban</h3>
                  <DropDown
                    v-if="department.length"
                    v-bind:options="department"
                    v-bind:select="
                      employee.DepartmentId == null ? '' : employee.DepartmentId
                    "
                    name="DepartmentName"
                    id="DepartmentId"
                    @sendValueDropDown="getValueDropDown"
                    :check="check"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6">
                  <Input
                    :name="
                      employee.PersonalTaxCode == null
                        ? ''
                        : employee.PersonalTaxCode
                    "
                    value="Mã số thuế cá nhân"
                    id="PersonalTaxCode"
                    type="text"
                    @sendValueInput="getValueInput"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6 form-group">
                  <Input
                    :iconMoney="true"
                    :name="employee.Salary == null ? '' : employee.Salary"
                    value="Mức lương cơ bản"
                    id="Salary"
                    type="text"
                    @sendValueInput="getValueInput"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6 form-group">
                  <Input
                    :name="employee.JoinDate == null ? '' : employee.JoinDate"
                    value="Ngày gia nhập công ty"
                    id="JoinDate"
                    type="date"
                    @sendValueInput="getValueInput"
                  />
                </li>
                <li class="staff-information__general-item col-lg-6 form-group">
                  <h3 class="input-header label-field__input">Tình trạng công việc</h3>
                  <DropDown
                    v-if="workStatus.length"
                    v-bind:options="workStatus"
                    v-bind:select="
                      employee.WorkStatus == null ? '' : employee.WorkStatus
                    "
                    name="WorkStatusName"
                    id="WorkStatus"
                    @sendValueDropDown="getValueDropDown"
                    :check="check"
                    :isLast= true
                  />
                </li>
              </ul>
            </div>
          </div>
          <div class="div-btn">
            <div class="button button-cancel" @click="btnCancel">Hủy</div>
            <button
              class="button button-save"
              id="button-save"
            >
              <i class="far fa-save"></i>
              Lưu
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// Author : PVM.Quân (29/07/2021)
// import $ from "jquery";
import DropDown from "../../components/base/BaseDropDown.vue";
import Input from "../../components/base/BaseInput.vue";
import EmployeesAPI from "../../api/components/EmployeesApi";
import Format from "../../untils/Format.js";
import MessengerEmployee from "../../constants/MessengerEmployee"
import MessengerError from "../../constants/MessengerError"
import Vadilator from "../../untils/Vadilator.js";

export default {
  name: "EmployeeDetail",
  components: {
    DropDown,
    Input,
  },
  props: {
    isHide: {
      type: Boolean,
      default: true,
      required: true,
    },
    employeeId: {
      type: String,
      default: "",
      required: true,
    },
    mode: {
      type: Number,
      default: 0, 
      required: true,
    },
    department: {
      type: [Object, Array],
      required: true,
    },
    position: {
      type: [Object, Array],
      required: true,
    },
    arrayEmployeeCode: {
      type: [Array],
      required: true,
    },
    arrayIdentityNumber: {
      type: [Array],
      required: true,
    },
    employeeNewCode: {
      type: String,
      default: "",
      required: true,
    },
  },

  methods: {
    focusInput(){
      this.$nextTick(() => {
        this.$refs['employeecode-input'].$el.childNodes[0].childNodes[1].querySelector('input').focus();
      })
    },
    /**
     * Lấy dữ liệu từ BaseInput để submit
     * PVM.Quân (04/08/2021) 
     */  
    getValueInput(value, id) {
      if(this.employee[id] != value){
        this.checkValueForm = true
        }else{
          this.checkValueForm = false
        }
        if(id == "Salary"){
          this.employee[id]=value.replaceAll(".",'')
        }
        else{
          this.employee[id]=value
        }
        
        this.validate()
    },

    /**
     * Hàm xử lý validate dữ liệu
     * creatAt : PVM.Quân (03/08/2021)
     */
    validate(){
      var _this= this
      Vadilator.Vadilator({
        form: `.form-staff`,
        formGroupSelector: `.form-group`,
        errorSelector: `.form-message`,
        submitBtn: "#button-save",
        rules: [
          Vadilator.isRequired("#EmployeeCode"),
          Vadilator.isRequired("#FullName"),
          Vadilator.isRequired("#Email"),
          Vadilator.isRequired("#IdentityNumber"),
          Vadilator.isRequired("#PhoneNumber"),
          Vadilator.isEmail("#Email"),
          /**
           * Kiểm tra khi trùng mã chứng minh thư
           */
          Vadilator.IdentityNumber("#IdentityNumber", function () {
            var check = "";
            for (var i = 0; i < _this.arrayIdentityNumber.length; i++) {
              if (
                _this.arrayIdentityNumber[i] != _this.employee.IdentityNumber
              ) {
                if (
                  document.querySelector("#IdentityNumber").value ===
                  _this.arrayIdentityNumber[i]
                ) {
                  check = _this.arrayIdentityNumber[i];
                  break;
                }
              }
            }
            return check;
          }),

          /**
           * Kiểm tra khi trùng mã nhân viên
           */
          Vadilator.Code("#EmployeeCode", function () {
            var check = "";
            for (var i = 0; i < _this.arrayEmployeeCode.length; i++) {
              if(_this.mode == 1){
                  if (_this.arrayEmployeeCode[i] != _this.employeeCode) {
                  if (
                    document.querySelector("#EmployeeCode").value ===
                    _this.arrayEmployeeCode[i]
                  ) {
                    check = _this.arrayEmployeeCode[i];
                    break;
                  }
                }
              }else{
                  if (
                    document.querySelector("#EmployeeCode").value ===
                    _this.arrayEmployeeCode[i]
                  ) {
                    check = _this.arrayEmployeeCode[i];
                    break;
                  }
              }
            }
            return check;
          }),
        ],
          /**
           * Thêm mới dữ liệu vào data
           */
          onSubmit: _this.mode == 2 ? function(){_this.post()} : function(){_this.put()}
      });
     
    },
    /**
     * Lấy dữ liệu từ BaseDropDown để submit
     * PVM.Quân (04/08/2021)
     */
    getValueDropDown(value, id) {
      if(this.employee[id] != value){
          this.employee[id] = value
          this.checkValueForm = true
        }else{
          this.checkValueForm = false
        }
    },
    /**
     * Xử lý khi thoát khỏi form  nhân viên và xóa các cảnh báo lỗi nếu có
     * PVM.Quân (29/07/2021)
     */
    btnCancel() {
      this.$emit("btnCancelOnclick", this.mode);
      this.$refs["form"].querySelectorAll('.form-group.invalid').forEach(item=>{
        item.classList.remove('invalid')
      })
      this.$refs["form"].querySelectorAll('.form-group .form-message').forEach(item=>{
        item.innerText = ""
      })
    },

    /**
     * Tạo phương thức post
     */
    post() {
      var _this = this;
      EmployeesAPI.post(_this.employee)
        .then(() => {
          _this.$emit("toastMessenger", false, MessengerEmployee.AddCorrect);
          _this.$emit("btnAddOnclick", true, 0);
          _this.$emit("addEmployee")
        this.btnCancel()
        })
        .catch((error) => {
          _this.consoleError(error.response.status);
        });
    },
    /**
     * Tạo phương thức put và kiểm tra xem có thay đổi gì không
     */
    put() {
      
        var _this = this;
        if(this.checkValueForm == true){
          _this.employee.Salary = String(_this.employee.Salary).replaceAll('.','')
          EmployeesAPI.put(_this.employeeId, _this.employee)
            .then(() => {
              _this.$emit("toastMessenger", false, MessengerEmployee.UpdateCorrect);
              _this.$emit("btnAddOnclick", true, 0);
              _this.$emit("addEmployee")
               this.btnCancel()
            })
            .catch((error) => {
              _this.consoleError(error.response.status);
            });
        }else{
            this.$emit("warningUpdate")
            
        }
       
    },

    /**
     * Tạo form hiển thị khi thất bại
     * creatBy : PVM.Quân(06/08)
     */
    consoleError(error) {
      var _this = this;
      MessengerError
      _this.isShowToast = false;
      _this.isSuccess = false;
      _this.isWarning = true;
      switch (error) {
        case 400:
          _this.lable = MessengerError.Error400
          break;
        case 401:
          _this.lable = MessengerError.Error401
          break;
        case 403:
          _this.lable = MessengerError.Error403
          break;
        case 404:
          _this.lable = MessengerError.Error404
          break;
        case 500:
          _this.lable = MessengerError.Error500
          break;
        default:
          break;
      }
      setTimeout(() => {
        _this.isShowToast = true;
      }, 5000);
    },
  },

  data() {
    return {
      check: 0,
      formGroup: "",
      formMessage: "",
      employee : {
          EmployeeCode: "",
            FullName: "",
            DateOfBirth: null,
            IdentityNumber: "",
            IdentityDate: null,
            IdentityPlace: "",
            Email: "",
            PhoneNumber: "",
            PositionName: "",
            DepartmentName: "",
            PersonalTaxCode: "",
            Salary: "",
            JoinDate: null,
            WorkStatus: "",
      },
      employeeCode: "",
      identityNumber :" ",
      isShowToast: "",
      lable: "",
      isSuccess: "",
      isWarning: "",
      isError : "",
      valueInput : '',
      idInput : '',
      autofocus : false,
      checkValueForm : false,
      isDoubleCode : false,
      isIdentityNumber : false,
      checkForm : 1,
      isRequired : true,
      /**
       * Mảng chứa giới tính
       */
      gender: [
        { GenderName: "Nam", Gender: "1" },
        { GenderName: "Nữ", Gender: "0" },
        { GenderName: "Không xác định", Gender: "2" },
      ],

      /**
       * Mảng chứa trạng thái công việc
       */
      workStatus: [
        { WorkStatusName: "Đang làm việc", WorkStatus: 1 },
        { WorkStatusName: "Đã nghỉ việc", WorkStatus: 0 },
      ],
    };
  },

  watch: {
    /**
     * Phân biệt thi thêm và khi sửa
     * PVM.Quân (29/07/2021)
     */
    mode: function () {
       if (this.mode == 2) {
          this.employee = {};
          this.check = 0;
          this.checkForm = 2
          this.employee.EmployeeCode = this.employeeNewCode
      } 
      else {
        this.check = 1;
        this.checkForm = 1
      }
    },
     /**
         * Load dữ liệu để lấy thông tin theo nhân viên
         */
    employeeId : function(){
       var _this = this;
        EmployeesAPI.get(_this.employeeId)
          .then((res) => {
            _this.employee = res.data;
            _this.employeeCode =_this.employee.EmployeeCode 
            _this.identityNumber = _this.employee.IdentityNumber
            _this.employee.DateOfBirth = Format.formatDateToModal(_this.employee.DateOfBirth);
            _this.employee.IdentityDate = Format.formatDateToModal(_this.employee.IdentityDate);
            _this.employee.JoinDate = Format.formatDateToModal(_this.employee.JoinDate);
            _this.employee.Salary = Format.salaryFormat(_this.employee.Salary);
          })
          .catch((error) => {
            _this.consoleError(error.response.status);
          });
    }
  },
};
</script>

<style scoped>
@import url("../../assets/css/form/Staff_information.css");
</style>