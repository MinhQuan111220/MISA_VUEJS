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
                                            :name ='employee.EmployeeCode== null ? "" :employee.EmployeeCode'
                                            :binding="true"
                                            @sendDomValidate="getDomValidate"
                                            :isFocus="true"
                                            value="Mã nhân viên"
                                            id = 'EmployeeCode'
                                            type="text"
                                            @sendValueInput="getValueInput"
                                            @btnCancel="btnCancel"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                        <Input 
                                            :name ='employee.FullName== null ? "" :employee.FullName'
                                            :binding="true"
                                            @sendDomValidate="getDomValidate"
                                            value="Họ và Tên"
                                            id = 'FullName'
                                            type="text"
                                            @sendValueInput="getValueInput"
                                        />         
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                        <Input 
                                            :name ='employee.DateOfBirth== null ? "" :employee.DateOfBirth'
                                            value="Ngày sinh"
                                            id = 'DateOfBirth'
                                            type="date"
                                             @sendValueInput="getValueInput"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                        <h3 class="input-header title2">Giới tính</h3>
                                        <DropDown   
                                                    v-if="gender.length"
                                                    v-bind:options='gender'
                                                    v-bind:select='employee.Gender== null ? "" :employee.Gender'
                                                    name= 'GenderName'
                                                    id= 'Gender'
                                                    @sendValueDropDown="getValueDropDown"
                                                    :check="check"
                                            
                                        />
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                       <Input 
                                            
                                            :name ='employee.IdentityNumber== null ? "" :employee.IdentityNumber'
                                            :binding="true"
                                            @sendDomValidate="getDomValidate"
                                            value="Số CMTND/Căn cước"
                                            id = 'IdentityNumber'
                                            type="text"
                                            @sendValueInput="getValueInput"
                                        />     
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                       <Input 
                                            
                                            :name ='employee.IdentityDate== null ? "" :employee.IdentityDate'
                                            value="Ngày cấp"
                                            id = 'IdentityDate'
                                            type="date"
                                            @sendValueInput="getValueInput"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                       <Input 
                                            
                                            :name ='employee.IdentityPlace== null ? "" :employee.IdentityPlace'
                                            value="Nơi cấp"
                                            id = 'IdentityPlace'
                                            type="text"
                                            @sendValueInput="getValueInput"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                     <Input 
                                            
                                            :name ='employee.Email == null ? "" :employee.Email'
                                            :binding="true"
                                            @sendDomValidate="getDomValidate"
                                            value="Email"
                                            id = 'Email'
                                            type="text"
                                            @sendValueInput="getValueInput"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                       <Input 
                                            
                                            :name ='employee.PhoneNumber == null ? "" :employee.PhoneNumber'
                                            :binding="true"
                                            @sendDomValidate="getDomValidate"
                                            value="Số điện thoại"
                                            id = 'PhoneNumber'
                                            type="text"
                                            @sendValueInput="getValueInput"
                                        />   
                                    </li>
                                    <li class="col-lg-12 staff-information__work-title">
                                        <span class="title staff-information__general-title">B.THÔNG TIN CÔNG VIỆC</span>
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                        <h3 class="input-header title2">Vị trí</h3>
                                        <DropDown
                                                v-if="position.length"
                                                v-bind:options='position'
                                                v-bind:select='employee.PositionId == null ? "" :employee.PositionId'
                                                name= 'PositionName'
                                                id= 'PositionId'
                                                @sendValueDropDown="getValueDropDown"
                                                :check="check"
                                        
                                        />
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                        <h3 class="input-header title2">Phòng ban</h3>
                                        <DropDown 
                                                v-if="department.length"
                                                v-bind:options='department'
                                                v-bind:select='employee.DepartmentId == null ? "" :employee.DepartmentId'
                                                name= 'DepartmentName'
                                                id= 'DepartmentId'
                                                @sendValueDropDown="getValueDropDown"
                                                :check="check"
                                        
                                        />
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 ">
                                       <Input 
                                        
                                            :name ='employee.PersonalTaxCode == null ? "" : employee.PersonalTaxCode'
                                            value="Mã số thuế cá nhân"
                                            id = 'PersonalTaxCode'
                                            type="text"
                                            @sendValueInput="getValueInput"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                       <Input 
                                            :iconMoney="true"
                                            :name ='employee.Salary == null ? "" :employee.Salary'
                                            value="Mức lương cơ bản"
                                            id = 'Salary'
                                            type="text"
                                            @sendValueInput="getValueInput"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <Input 
                                            
                                            :name ='employee.JoinDate == null ? "" : employee.JoinDate'
                                            value="Ngày gia nhập công ty"
                                            id = 'JoinDate' 
                                            type="date" 
                                            @sendValueInput="getValueInput"
                                        />   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="input-header title2">Tình trạng công việc</h3>
                                        <DropDown   
                                                    v-if="workStatus.length"
                                                    v-bind:options='workStatus'
                                                    v-bind:select='employee.WorkStatus == null ? "" : employee.WorkStatus'
                                                    name= 'WorkStatusName'
                                                    id= 'WorkStatus' 
                                                    @sendValueDropDown="getValueDropDown"
                                                    :check="check"
                                            
                                        />
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="div-btn">
                            <div class="button button-cancel" @click="btnCancel">
                                Hủy
                            </div>
                            <button class="button button-save" id="button-save" >
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
import Vadilator from '../../untils/Vadilator.js'


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
         * Truyền dữ liệu từ BaseInput để submit
         * PVM.Quân (04/08/2021)
         */
        getValueInput(value,id){
           this.employee[id]=value
            console.log(this.employee[id])
        },

         /**
         * Truyền dữ liệu từ BaseDropDown để submit
         * PVM.Quân (04/08/2021)
         */
        getValueDropDown(value,id){
            this.employee[id]=value
        },
        /**
         * Xử lý khi thoát khỏi form  nhân viên và xóa các cảnh báo lỗi nếu có
         * PVM.Quân (29/07/2021)
         */
        btnCancel (){
            this.$emit('btnAddOnclick',true,0)
            document.querySelectorAll('.form-group.invalid').forEach((item,index)=>{
                item.classList.remove('invalid')
                document.querySelectorAll('.form-message')[index].innerText = ''
            })

        },

         /**
         * Hàm xử lý validate dữ liệu và submit dữ liệu
         * creatAt : PVM.Quân (03/08/2021)
         */
        getDomValidate(formGroup,formMessage){
             /**
             * Kiểm tra dữ liệu
             */
            var _this = this
            if(this.mode === 0){
                Vadilator.Vadilator ({
                    form:`.form-staff`,
                    formGroupSelector:`.${formGroup}`,
                    errorSelector : `.${formMessage}`,
                    submitBtn : '#button-save',
                    rules : [
                        Vadilator.isRequired('#EmployeeCode'),
                        Vadilator.isRequired('#FullName'),
                        Vadilator.isRequired('#Email'),
                        Vadilator.isRequired('#IdentityNumber'),
                        Vadilator.isRequired('#PhoneNumber'),
                        Vadilator.isEmail("#Email"),
                    ],
                    /**
                     * Thêm mới dữ liệu vào data
                     */
                        onSubmit : function(){
                            EmployeesAPI.post(_this.employee).then(() => {
                                alert("Thành công")
                                _this.$emit('btnAddOnclick',true,0)
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
                }) 
            }else{
                /**
                 * Kiểm tra dữ liệu 
                 */
                Vadilator.Vadilator ({
                    form:`.form-staff`,
                    formGroupSelector:`.${formGroup}`,
                    errorSelector : `.${formMessage}`,
                    submitBtn : '#button-save',
                    rules : [
                        Vadilator.isRequired('#EmployeeCode'),
                        Vadilator.isRequired('#FullName'),
                        Vadilator.isRequired('#Email'),
                        Vadilator.isRequired('#IdentityNumber'),
                        Vadilator.isRequired('#PhoneNumber'),
                        Vadilator.isEmail("#Email"),
                    ],
                        /**
                         * Khi lưu dữ liệu vào data
                         */
                        onSubmit : function(){
                            EmployeesAPI.put(_this.employeeId,_this.employee).then(() => {
                                alert("Thành công")
                                _this.$emit('btnAddOnclick',true,0)
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
                }) 
            }
        }
    },
    
    data() {
        return {
            employee : {},
            check : 0,
            /**
             * Mảng chứa giới tính 
             */
            gender : [
                {GenderName : 'Nam',Gender:'1'},
                {GenderName : 'Nữ',Gender:'0'},
                {GenderName : 'Không xác định',Gender:'2'},
            ],

            /**
             * Mảng chứa trạng thái công việc
             */
            workStatus : [
                {WorkStatusName : 'Đang làm việc',WorkStatus :1},
                {WorkStatusName : 'Đã nghỉ việc',WorkStatus :0}
            ]
        }
    },

    watch :{
        /**
         * Xử lý lấy thông tin từng nhân viên theo Id
         * PVM.Quân (29/07/2021)
         */
        employeeId : function(){
            /** 
             * Gọi Api lấy thông tin chi tiết theo id
            */
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

        /**
         * Phân biệt thi thêm và khi sửa
         * PVM.Quân (29/07/2021)
         */
        mode : function (){
            if(this.mode == 0){
                this.employee = {}
                this.check =0
            }else{
                var _this = this
                this.check = 1
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
            }
        },

    }
}
</script>

<style scoped>
@import url('../../assets/css/form/Staff_information.css');
</style>