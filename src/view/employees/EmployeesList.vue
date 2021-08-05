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
                        <img class="avatar" src="../../assets/icon/avatar-default.png" alt="">
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
                            <img class="button__icon-left" src="../../assets/icon/add.png" alt="">
                            <h3 class="button-text">Thêm Nhân Viên</h3>
                        </button>
                    </div>
                </div>
                <div class="content__search">
                    <div class="content__field">
                        <div class="field">
                            <img src="../../assets/icon/search.png" alt="" class="field__icon">
                            <input type="text" class="field__search " name="search" placeholder="Tìm kiếm theo Mã, Tên, Số điện thoại" >   
                        </div>
                        <ComBoBox v-bind:value='"Tất cả phòng ban"'
                                    v-bind:options='departments'
                                    v-bind:name= '"DepartmentName"'
                                    v-bind:id= '"DepartmentId"'
                        />
                        <ComBoBox v-bind:value='"Tất cả các vị trí"'
                                    v-bind:options='positions'
                                    v-bind:name= '"PositionName"'
                                    v-bind:id= '"PositionId"'
                        />
                        
                    </div>
                    <div class="content__search-refresh">
                        <a href=""><img src="../../assets/icon/refresh.png" alt=""></a>
                    </div>
                </div>
                <Table 
                    :options='employees'
                    id= 'EmployeeId'
                    :arrayTH='arrayThEmployee'
                    propname='propname'
                    name= 'name'
                    checkclass='checkclass'
                    format="format"
                    @trDbOnClick ="trDbOnClick"
                    @sendDeleteList ="getDeleteList"
                />
                <div class="content__pagination">
                    <div class="show-number__person">Hiển thị <span>1-20/1000</span> nhân viên</div>
                    <div class="content__pagination-button">
                        <div class="content__pagination-icon">
                            <a href=""><img src="../../assets/icon/btn-firstpage.svg" alt=""></a>
                        </div>
                        <div class="content__pagination-icon">
                            <a href=""><img src="../../assets/icon/btn-prev-page.svg" alt=""></a>
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
                            <a href=""><img src="../../assets/icon/btn-next-page.svg" alt=""></a>
                        </div>
                        <div class="content__pagination-icon">
                            <a href=""><img src="../../assets/icon/btn-lastpage.svg" alt=""></a>
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
        v-bind:department='departmentsDropDown'
        v-bind:position='positionsDropDown'
        />
        <PopUp v-bind:isHidePopUp='isHidePopUp' 
        @btnDeleteOnclick ="btnDeleteOnclick"
        @btnConfirmDelete ="conFirm"
        />
    </div>
</template>

<script>

import EmployeeDetail from './EmployeeDetail.vue'
import PopUp from '../../components/base/BasePopUp.vue'
import ComBoBox from '../../components/base/BaseComBoBox.vue'
import Table from '../../components/base/BaseTable.vue'
import EmployeesAPI from "../../api/components/EmployeesApi";
import PositionAPI from "../../api/components/PositionApi.js";
import DepartmentAPI from "../../api/components/DepartmentsApi.js";


export default {
    name : "EmployeeList",
    components : {
        EmployeeDetail,
        PopUp,
        ComBoBox,
        Table
    },
    /**
     * Hàm gọi Api lấy dữ liệu
     * creatAt : PVM.Quân (29/07/2021)
     */
    created() {
        var _this = this

        /**
         * Lấy dữ liệu phòng ban
         * creatAt : PVM.Quân (29/07/2021)
         */
        DepartmentAPI.getAll().then(res =>{
            _this.departments = res.data
            _this.departmentsDropDown = res.data
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


        /**
         * Lấy dữ liệu các vị trí
         * creatAt : PVM.Quân (29/07/2021)
         */
        PositionAPI.getAll().then(res =>{ 
            _this.positions = res.data
            _this.positionsDropDown = res.data
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

         /**
         * Lấy dữ liệu nhân viên
         * creatAt : PVM.Quân (29/07/2021)
         */
        EmployeesAPI.getAll().then(res =>{
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

    /**
     * Hàm xử lý lấy dữ liệu nhân viên khi có sự thay đổi
     * creatAt : PVM.Quân (29/07/2021)
     */
    watch : {
        employees (){
        var _this = this
         /**
         * Lấy dữ liệu nhân viên sau khi bị thay đổi
         * creatAt : PVM.Quân (29/07/2021)
         */
        EmployeesAPI.getAll().then(res =>{
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
        deleteList: function(){
            if(this.deleteList.length ==0){
                this.isDelete = true
            } else{
                this.isDelete = false
            }
        }
    },
    methods: {
        conFirm(){
            this.isDelete = true;
        },

         /**
         * Lấy các danh sách cần xóa từ baseTable
         * PVM.Quân (04/08/2021)
         */
        getDeleteList(deleteList){
            this.deleteList = deleteList
        },

        /**
         * Hiển thị form chi tiết khi nhấn button thêm nhân viên
         * Author : PVM.Quân (29/07/2021)
         */
        btnAddOnclick(isHide,mode){
            this.isHideDiaLogDetail = isHide
            this.mode = mode
        },

        /**
         * Hiển thị form chi tiết khi Sửa nhân viên
         * Author : PVM.Quân (29/07/2021)
         */
        trDbOnClick(employeeId){
            this.isHideDiaLogDetail = false
            this.employeeId = employeeId
            this.mode = 1
        },

        /**
         * Khi nhấn nút xóa  tất cả
         * Author : PVM.Quân (29/07/2021)
         */
        btnDeleteOnclick(isHidePopUp){
            this.isHidePopUp = isHidePopUp
        },

        
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
            departments : {},
            positions : {},
            departmentsDropDown : {},
            positionsDropDown : {},
            deleteList: [],

            /**
             * Mảng chứa các th trong table
             */
            arrayThEmployee : [
                {
                    propname : 'EmployeeCode',
                    name : 'Mã nhân viên',
                    checkclass : '',
                },
                {
                    propname : 'FullName',
                    name : 'Họ và tên',
                    checkclass : ''
                },
                {
                    propname : 'GenderName',
                    name : 'Giới tính',
                    checkclass : ''
                },
                {
                    propname : 'DateOfBirth',
                    name : 'Ngày sinh',
                    checkclass : 'between',
                    format : 'date'
                },
                {
                    propname : 'PhoneNumber',
                    name : 'Điện thoại',
                    checkclass : 'between'
                },
                {
                    propname : 'Email',
                    name : 'Email',
                    checkclass : ''
                },
                {
                    propname : 'PositionName',
                    name : 'Chức vụ',
                    checkclass : '',
                },
                {
                    propname : 'DepartmentName',
                    name : 'Vị trí',
                    checkclass : '',
                },
                {
                    propname : 'Salary',
                    name : 'Mức lương cơ bản',
                    checkclass : 'rigth',
                    format : '$',
                },
                {
                    propname : 'WorkStatus',
                    name : 'Tình trạng công việc',
                    checkclass : ''
                },
            ]
        }
    },
}
</script>

<style scoped>
@import url('../../assets/css/layout/Content.css');
</style>