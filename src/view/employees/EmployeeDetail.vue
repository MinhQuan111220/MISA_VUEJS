<template>
    <div class="staff-information" :class="{'active':isHide}">
        <div class="container">
                <div class="staff-information__person">
                    <div class="form-staff">
                        <div class="staff-information__header">
                            <span class="heading staff-information__header-heading">THÔNG TIN NHÂN VIÊN</span>
                            <img src="../../assets/icon/x.svg" alt="" class="staff-information__header-img" @click="btnCancel">
                        </div>
                        <div class="row">
                            <div class="staff-information__img-person col-lg-3">
                                    <img src="../../assets/img/default-avatar.jpg" alt="">
                                    <span>(Vui lòng chọn ảnh có định 
                                        dạng .jbg.,jebg,.png,.git )
                                    </span>
                               
                            </div>
                            <div class="staff-information__information-person col-lg-9">
                                <ul class="staff-information__general row">
                                    <li class="col-lg-12">
                                        <span class="title staff-information__general-title">A. THÔNG TIN CHUNG</span>
                                    </li>
                                    <li class="staff-information__general-item col-lg-6  ">
                                        <Input 
                                            :name ='employee.EmployeeCode'
                                            :binding="true"
                                            value="Mã nhân viên"
                                            id = 'EmployeeCode'
                                            type="text"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                        <Input 
                                            :name ='employee.FullName'
                                            :binding="true"
                                            value="Họ và Tên"
                                            id = 'FullName'
                                            type="text"
                                        />         
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                        <Input 
                                            :name ='employee.DateOfBirth'
                                            value="Ngày sinh"
                                            id = 'DateOfBirth'
                                            type="date"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                        <h3 class="input-header title2">Giới tính</h3>
                                        <DropDown 
                                                    v-bind:options='gender'
                                                    v-bind:check='check'
                                                    v-bind:select='employeeId'
                                                    name= 'GenderName'
                                                    id= 'Gender'
                                        />
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                       <Input 
                                            
                                            :name ='employee.IdentityNumber'
                                            :binding="true"
                                            value="Số CMTND/Căn cước"
                                            id = 'IdentityNumber'
                                            type="text"
                                        />     
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                       <Input 
                                            
                                            :name ='employee.IdentityDate'
                                            value="Ngày cấp"
                                            id = 'IdentityDate'
                                            type="date"

                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                       <Input 
                                            
                                            :name ='employee.IdentityPlace'
                                            value="Nơi cấp"
                                            id = 'IdentityPlace'
                                            type="text"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                     <Input 
                                            
                                            :name ='employee.Email'
                                            :binding="true"
                                            value="Email"
                                            id = 'Email'
                                            type="text"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                       <Input 
                                            
                                            :name ='employee.PhoneNumber'
                                            :binding="true"
                                            value="Số điện thoại"
                                            id = 'PhoneNumber'
                                            type="text"
                                        />   
                                    </li>
                                    <li class="col-lg-12 staff-information__work-title">
                                        <span class="title staff-information__general-title">B.THÔNG TIN CÔNG VIỆC</span>
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                        <h3 class="input-header title2">Vị trí</h3>
                                        <DropDown
                                                v-bind:options='position'
                                                v-bind:check='check'
                                                v-bind:select='employeeId'
                                                name= 'PositionName'
                                                id= 'PositionId'
                                        />
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                        <h3 class="input-header title2">Phòng ban</h3>
                                        <DropDown 
                                                v-bind:options='department'
                                                v-bind:check='check'
                                                v-bind:select='employeeId'
                                                name= 'DepartmentName'
                                                id= 'DepartmentId'
                                        />
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                       <Input 
                                            
                                            :name ='employee.PersonalTaxCode'
                                            value="Mã số thuế cá nhân"
                                            id = 'PersonalTaxCode'
                                            type="text"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                       <Input 
                                            :iconMoney="true"
                                            :name ='employee.Salary'
                                            value="Mức lương cơ bản"
                                            id = 'Salary'
                                            type="text"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <Input 
                                            
                                            :name ='employee.JoinDate'
                                            value="Ngày gia nhập công ty"
                                            id = 'JoinDate'
                                            type="date"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="input-header title2">Tình trạng công việc</h3>
                                        <DropDown 
                                                    v-bind:options='workStatus'
                                                    v-bind:check='check'
                                                    v-bind:select='employeeId'
                                                    name= 'WorkStatusName'
                                                    id= 'WorkStatus'
                                        />
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="div-btn">
                            <div class="button button-cancel" @click="btnCancel">
                                Hủy
                            </div>
                            <button class="button button-save" id="button-save" @click="btnSaveOnClick">
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

import DropDown from '../../components/base/BaseDropDown.vue'
import Input from '../../components/base/BaseInput.vue'
import EmployeesAPI from "../../api/components/EmployeesApi";


export default {
    
    name : "EmployeeDetail",
    components:{
        DropDown,
        Input
    },
    props : {
        isHide : {
            type : Boolean,
            default : true,
            required : true,
        },
        employeeId : {
            type : String,
            default : '',
            required : true,
        },
        mode : {
            type : Number,
            default : 0, // 0 thêm mới 1 sửa
            required : true,
        },
        department : {
            type : [Object,Array],
            required : true,
        },
        position: {
            type : [Object,Array],
            required : true,
        }
    },
    
    methods: {
        /**
         * Xử lý khi thoát khỏi form thêm nhân viên
         * PVM.Quân (29/07/2021)
         */
        btnCancel (){
            this.$emit('btnAddOnclick',true)
        },


        /**
         * Xử lý khi thêm và sửa nhân viên
         * PVM.Quân (29/07/2021)
         */
        btnSaveOnClick(){
            // Thêm nhân viên
            var _this = this
            if(this.mode === 0){
                    EmployeesAPI.post(_this.employee).then(() => {
                        alert("Thành công")
                        _this.$emit('btnAddOnclick',true)
                    }).catch(error =>{
                         switch (error.status) {
                            case 500:
                                console.log('Có lỗi từ server, vui lòng thử lại');
                                break;
                            case 400:
                                console.log('Dữ liệu không hợp lệ');
                                break;
                            default:
                                break;
                        }
                    })
            }else{
                // Sửa nhân viên
                    EmployeesAPI.put(_this.employeeId,_this.employee).then(() => {
                        alert("Thành công")
                        _this.$emit('btnAddOnclick',true)
                    }).catch(error =>{
                         switch (error.status) {
                            case 500:
                                console.log('Có lỗi từ server, vui lòng thử lại');
                                break;
                            case 400:
                                console.log('Dữ liệu không hợp lệ');
                                break;
                            default:
                                break;
                        }
                    })
            }
        }
    },
    
    data() {
        return {
            employee : {},
            check : this.mode,
            GenderNames : '',
            // mảng chứa các giới tính
            gender : [
                {GenderName : 'Nam',Gender:'1'},
                {GenderName : 'Nữ',Gender:'0'},
                {GenderName : 'Không xác định',Gender:'2'},
            ],

            // mảng chứa trạng thái công việc
            workStatus : [
                {WorkStatusName : 'Đang làm việc',WorkStatus :0},
                {WorkStatusName : 'Đã nghỉ việc',WorkStatus :1}
            ]
        }
    },

    watch :{
        /**
         * Xử lý lấy thông tin từng nhân viên theo Id
         * PVM.Quân (29/07/2021)
         */
        employeeId : function(){
            // Gọi Api lấy thông tin chi tiết
            var _this = this
            EmployeesAPI.get(_this.employeeId).then((res) => {
                _this.employee = res.data
            }).catch(error =>{
                         switch (error.status) {
                            case 500:
                                console.log('Có lỗi từ server, vui lòng thử lại');
                                break;
                            case 400:
                                console.log('Dữ liệu không hợp lệ');
                                break;
                            default:
                                break;
                        }
                    })
        },

        // Phân biệt nút thêm và nút sửa
        mode : function (){
            if(this.mode == 0){
                this.employee = {}
                this.check = 0
            }else{
                this.check=1
            }
        },

    }
}
</script>

<style scoped>
@import url('../../assets/css/form/Staff_information.css');
</style>