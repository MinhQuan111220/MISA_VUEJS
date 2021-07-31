<template>
    <div class="main">
        <div class="content">
        <div class="content__header">
                <div class="content__header-text">
                    <div class="BD"><h2>BĐ</h2></div>
                    <div class="text-title">
                        <h3 class="title2">Nhà hàng Biển Đông</h3>
                        <i class="fas fa-chevron-down"></i>
                    </div>
                </div>
                <div class="content__header-accout">
                    <div class="account">
                        <i class="far fa-bell account__notification"></i>
                        <img class="avatar" src="../../../assets/icon/avatar-default.png" alt="">
                        <h3 class="label-field__input account-name">Nguyễn Văn Mạnh</h3>
                        <i class="fas fa-ellipsis-h account__option"></i>
                    </div>
                </div>
            </div>
        <div class="content__body ">
                <div class="content__action">
                    <div class="content__action-title ">Danh sách nhân viên</div>
                    <div class="content__action-button">
                        <button class="button button-delete" :class="{'active':isDelete}" v-on:click="btnDeleteOnclick(false)">
                            <i class="far fa-trash-alt"></i>
                            <h3 class="button-text">Xóa Nhân Viên</h3>
                        </button>
                        <button class="button add" v-on:click="btnAddOnclick(false)">
                            <img class="button__icon-left" src="../../../assets/icon/add.png" alt="">
                            <h3 class="button-text">Thêm Nhân Viên</h3>
                        </button>
                    </div>
                </div>
                <div class="content__search">
                    <div class="content__field">
                        <div class="field">
                            <img src="../../../assets/icon/search.png" alt="" class="field__icon">
                            <input type="text" class="field__search " name="search" placeholder="Tìm kiếm theo Mã, Tên, Số điện thoại" >   
                        </div>
                        <ComBoBox />
                        
                    </div>
                    <div class="content__search-refresh">
                        <a href=""><img src="../../../assets/icon/refresh.png" alt=""></a>
                    </div>
                </div>
                 <div class="content-table">
                    <table >
                        <thead>
                            <tr>
                                <th prop-name=""> </th>
                                <th prop-name="EmployeeCode"> Mã nhân viên</th>
                                <th prop-name="FullName"> Họ và tên</th>
                                <th prop-name="GenderName"> Giới tính</th>
                                <th prop-name="DateOfBirth" class="between">Ngày sinh</th>
                                <th prop-name="PhoneNumber" class="between"> Điện thoại</th>
                                <th prop-name="Email"> Email</th>
                                <th prop-name="PositionName"> Chức vụ</th>
                                <th prop-name="DepartmentName"> Phòng ban</th>
                                <th prop-name="Salary" class="rigth">Mức lương cơ bản</th>
                                <th prop-name="WorkStatus"> Tình trạng công việc</th>
                                
                            </tr>
                        </thead>
                        <tbody class="staffTable"> 
                            <tr v-for="employee in employees" :key="employee.EmployeeId" @dblclick="trDbOnClick(employee.EmployeeId)">
                                <td  > <input type="checkbox" @click="tdChecked()" :value=employee.EmployeeId></td>
                                <td  > {{employee.EmployeeCode}}</td>
                                <td  > {{employee.FullName}}</td>
                                <td  > {{employee.GenderName}}</td>
                                <td class="between" > {{employee.DateOfBirth}}</td>
                                <td class="between"> {{employee.PhoneNumber}}</td>
                                <td  > {{employee.Email}}</td>
                                <td  > {{employee.DepartmentName}}</td>
                                <td  > {{employee.PositionName}}</td>
                                <td class="rigth" > {{employee.Salary}}</td>
                                <td  > {{employee.WorkStatus}}</td>
                            </tr>
                        </tbody>
                    </table>
            </div>
                <div class="content__pagination">
                    <div class="show-number__person">Hiển thị <span>1-20/1000</span> nhân viên</div>
                    <div class="content__pagination-button">
                        <div class="content__pagination-icon">
                            <a href=""><img src="../../../assets/icon/btn-firstpage.svg" alt=""></a>
                        </div>
                        <div class="content__pagination-icon">
                            <a href=""><img src="../../../assets/icon/btn-prev-page.svg" alt=""></a>
                        </div>
                        <ul class="list-pagination">
                            <li class="content__pagination-numbers content__pagination-numbers-focus">
                                <a href="" class="content__pagination-numbers-item">1</a>
                            </li>
                            <li class="content__pagination-numbers">
                                <a href="" class="content__pagination-numbers-item">2</a>
                            </li>
                            <li class="content__pagination-numbers">
                                <a href="" class="content__pagination-numbers-item">3</a>
                            </li>
                            <li class="content__pagination-numbers">
                                <a href="" class="content__pagination-numbers-item">4</a>
                            </li>
                        </ul>
                        <div class="content__pagination-icon">
                            <a href=""><img src="../../../assets/icon/btn-next-page.svg" alt=""></a>
                        </div>
                        <div class="content__pagination-icon">
                            <a href=""><img src="../../../assets/icon/btn-lastpage.svg" alt=""></a>
                        </div>
                    </div>
                    <div class="content__pagination-numbershowed">
                        <span>20</span> nhân viên/trang
                    </div>
                </div>
        </div>
       
        <div class="delete-scroll">
        </div>
    </div > 
        <EmployeeDetail v-bind:isHide='isHideDiaLogDetail' 
        @btnAddOnclick ="btnAddOnclick"
        v-bind:employeeId='employeeId'
        v-bind:mode='mode'
        />
        <EmployeePopUp v-bind:isHidePopUp='isHidePopUp' 
        @btnDeleteOnclick ="btnDeleteOnclick"
        />
    </div>
</template>

<script>
import axios from 'axios'
import EmployeeDetail from './EmployeeDetail.vue'
import EmployeePopUp from './EmployeePopUp.vue'
import ComBoBox from '../../base/BaseComBoBox.vue'


export default {
    name : "EmployeeList",
    components : {
        EmployeeDetail,
        EmployeePopUp,
        ComBoBox
    },
    // Gọi API lấy dữ liệu
    mounted() {
        var _this = this
        axios.get('http://cukcuk.manhnv.net/v1/employees').then((res) => {
            _this.employees = res.data
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

    methods: {
        // Hiển thị form chi tiết khi nhấn button thêm nhân viên
        // Author : PVM.Quân (29/07/2021)
        
        // hiển thị form thêm nv
        btnAddOnclick(isHide){
            this.isHideDiaLogDetail = isHide
            this.mode = 0
        },
        // hiển thị form sửa nhân viên
        trDbOnClick(employeeId){
            this.isHideDiaLogDetail = false
            this.employeeId = employeeId
            this.mode = 1
        },

        // hiển thị button xóa và lấy những id cần xóa
        tdChecked(){
            if(document.querySelectorAll('tbody tr td input:checked').length ===0){
                this.isDelete = true
            }else{
                this.isDelete = false
            }
        },

        // khi nhấn nút xóa  tất cả
        btnDeleteOnclick(isHidePopUp){
            this.isHidePopUp = isHidePopUp
        }
    },
    data() {
        return{
            employees : {},
            employeeId : '',
            mode : 0,
            isDelete : true,
            employeeIdDelete : [],
            isHideDiaLogDetail : true,
            isHidePopUp : true,
        }
    },
}
</script>

<style scoped>
@import url('../../../assets/css/layout/Content.css');
</style>