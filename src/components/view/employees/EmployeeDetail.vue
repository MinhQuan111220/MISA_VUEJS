<template>
    <div class="staff-information" :class="{'active':isHide}">
        <div class="container">
                <div class="staff-information__person">
                    <form class="form-staff">
                        <div class="staff-information__header">
                            <span class="heading staff-information__header-heading">THÔNG TIN NHÂN VIÊN</span>
                            <img src="../../../assets/icon/x.svg" alt="" class="staff-information__header-img" @click="btnCancel">
                        </div>
                        <div class="row">
                            <div class="staff-information__img-person col-lg-3">
                                    <img src="../../../assets/img/default-avatar.jpg" alt="">
                                    <span>(Vui lòng chọn ảnh có định 
                                        dạng .jbg.,jebg,.png,.git )
                                    </span>
                               
                            </div>
                            <div class="staff-information__information-person col-lg-9">
                                <ul class="staff-information__general row">
                                    <li class="col-lg-12">
                                        <span class="title staff-information__general-title">A. THÔNG TIN CHUNG</span>
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group ">
                                        <h3 class="staff-information__general-item-title2 title2">Mã nhân viên(<span class="correct">*</span>)</h3>
                                        <input type="text" class="staff-information__input input auto-focus__input" name="EmployeeCode" value="" id="EmployeeCode" v-model="employee.EmployeeCode">
                                        <div class="form-message"></div>   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Họ và Tên(<span class="correct">*</span>)</h3>
                                        <input type="text" class="staff-information__input input" name="FullName"  id="FullName" value="" v-model="employee.FullName">
                                        <div class="form-message"></div>      
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Ngày sinh</h3>
                                        <div class="input-embrace">
                                            <input type="date" class="staff-information__input input" name="DateOfBirth"  id="DateOfBirth" v-model="employee.DateOfBirth">   
                                        </div>
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Giới tính</h3>
                                        <div class="dropdown dropdown__boy"> 
                                            <input class="dropdown-boy active input" value="Nam" name="GenderName" id="GenderName" readonly v-model="employee.GenderName">
                                            <i class="fas fa-chevron-down dropdown-icon dropdown-icon__boy"></i>
                                            <i class="fas fa-chevron-up dropup-icon dropup-icon__boy active"></i>
                                            <ul class="dropdown-list dropdown-list__boy">
                                                <li class="dropdown-list__item dropdown-list__item-boy dropdown-list__item-focus">
                                                    <i class="fas fa-check"></i>
                                                    <span style= "display: none; ">1</span>
                                                    <span>
                                                        Nam
                                                    </span>
                                                </li>
                                                <li class="dropdown-list__item dropdown-list__item-boy">
                                                    <i class="fas fa-check"></i>
                                                    <span style= "display: none; ">0</span>
                                                    <span>
                                                        Nữ
                                                    </span>
                                                </li>
                                                <li class="dropdown-list__item dropdown-list__item-boy">
                                                    <i class="fas fa-check"></i>
                                                    <span style= "display: none; ">2</span>
                                                    <span>
                                                        Không xác định
                                                    </span>
                                                </li>
                                            </ul>
                                        </div>  
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Số CMTMD/ Căn Cước(<span class="correct">*</span>)</h3>
                                        <input type="text" class="staff-information__input input" name="IdentityNumber"  id="IdentityNumber" v-model="employee.IdentityNumber">
                                        <div class="form-message"></div>   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Ngày cấp</h3>
                                        <div class="input-embrace">
                                            <input type="date" class="staff-information__input input" name="IdentityDate"  id="IdentityDate" v-model="employee.IdentityDate">   
                                            
                                        </div>
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Nơi cấp</h3>
                                        <input type="text" class="staff-information__input input" name="IdentityPlace"  id="IdentityPlace" v-model="employee.IdentityPlace">   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Email(<span class="correct">*</span>)</h3>
                                        <input type="text" class="staff-information__input input" name="Email" placeholder="quan111220@gmail.com" id="Email" v-model="employee.Email">   
                                        <div class="form-message"></div> 
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Số điện thoại(<span class="correct">*</span>)</h3>
                                        <input type="text" class="staff-information__input input" name="PhoneNumber"  id="PhoneNumber" v-model="employee.PhoneNumber">  
                                        <div class="form-message"></div> 
                                    </li>
                                    <li class="col-lg-12 staff-information__work-title">
                                        <span class="title staff-information__general-title">B.THÔNG TIN CÔNG VIỆC</span>
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Vị trí</h3>
                                        <div class="dropdown dropdown__staff-location"> 
                                            <input class="dropdown-staff__location active input" value="Giám đốc" name="PositionName" id="PositionName" readonly >
                                            
                                            <i class="fas fa-chevron-down dropdown-icon dropdown-icon__staff-location"></i>
                                            <i class="fas fa-chevron-up dropup-icon dropup-icon__staff-location active"></i>
                                            <ul class="dropdown-list dropdown-list__staff-location">
                                                
                                            </ul>
                                        </div>  
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Phòng ban</h3>
                                        <div class="dropdown dropdown__staff-room"> 
                                            <input class="dropdown-staff__room active input" value="Phòng Marketting" name="DepartmentName" id="DepartmentName" readonly >
                                            <i class="fas fa-chevron-down dropdown-icon dropdown-icon__staff-room"></i>
                                            <i class="fas fa-chevron-up dropup-icon dropup-icon__staff-room active"></i>
                                            <ul class="dropdown-list dropdown-list__staff-room">
                                               
                                            </ul>
                                        </div>  
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Mã số thuế cá nhân</h3>
                                        <input type="text" class="staff-information__input input" name="PersonalTaxCode"  id="PersonalTaxCode" v-model="employee.PersonalTaxCode">   
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Mức lương cơ bản</h3>
                                        <div class="input-embrace">
                                            <input  class="staff-information__input input input-money" name="Salary"  id="Salary" v-model="employee.Salary">   
                                            <span class="input-icon input-vnd">(VNĐ)</span>
                                        </div>
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Ngày gia nhập công ty</h3>
                                        <div class="input-embrace">
                                            <input type="date" class="staff-information__input input" name="JoinDate"  id="JoinDate" v-model="employee.JoinDate">   
                                        </div>
                                    </li>
                                    <li class="staff-information__general-item col-lg-6 form-group">
                                        <h3 class="staff-information__general-item-title2 title2">Tình trạng công việc</h3>
                                        <div class="dropdown dropdown__staff-job"> 
                                            <input class="dropdown-staff__job active input" value="Đang làm việc" id="WorkStatus" name="WorkStatus" readonly >
                                            
                                            <i class="fas fa-chevron-down dropdown-icon dropdown-icon__staff-job"></i>
                                            <i class="fas fa-chevron-up dropup-icon dropup-icon__staff-job active"></i>
                                            <ul class="dropdown-list dropdown-list__staff-job">
                                                <li class="dropdown-list__item dropdown-list__item-staff__job dropdown-list__item-focus">
                                                    <i class="fas fa-check"></i>
                                                    <span>
                                                        Đang làm việc
                                                    </span>
                                                </li>
                                                <li class="dropdown-list__item dropdown-list__item-staff__job">
                                                    <i class="fas fa-check"></i>
                                                    <span>
                                                        Sắp nghỉ rồi
                                                    </span>
                                                </li>
                                            </ul>
                                        </div>  
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
                    </form>
                </div>
        </div>
    </div>
</template>


<script>
        // Author : PVM.Quân (29/07/2021)

import axios from 'axios'

export default {
    
    name : "EmployeeDetail",
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
        }
    },
    methods: {
        // Click ẩn form add nhân viên 
        btnCancel (){
            this.$emit('btnAddOnclick',true)
        },

        btnSaveOnClick(){
            // Thêm nhân viên
            var _this = this
            if(this.mode === 0){
                axios.post(`http://cukcuk.manhnv.net/v1/Employees`,_this.employee)
                    .then(() => {
                        alert("Thành công")
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
                    axios.put(`http://cukcuk.manhnv.net/v1/Employees/${_this.employeeId}`,_this.employee)
                    .then(() => {
                        alert("Thành công")
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
            employee : {}
        }
    },

    watch :{
        employeeId : function(){
            // Gọi Api lấy thông tin chi tiết
            var _this = this
            axios.get(`http://cukcuk.manhnv.net/v1/Employees/${_this.employeeId}`)
            .then((res) => {
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
            }else{
                // console.log(1)
            }
        }
    }
}
</script>

<style scoped>
@import url('../../../assets/css/form/Staff_information.css');
</style>