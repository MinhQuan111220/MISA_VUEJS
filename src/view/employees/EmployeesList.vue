<template>
    <div class="page">
        <!--  Left Content -->
            <ul class="content-left__content">
                <li class="content-left__item ">
                    <div class="content-left__list-icon">
                        <img src="../../assets/icon/dashboard.png" alt="" class="content-left__icon">
                    </div>
                    <a href="" class="content-left__name" :class="{'active':isHideContentLeft}">Tổng quan</a>
                    
                </li>
                <li class="content-left__item ">
                    <div class="content-left__list-icon">
                        <img src="../../assets/icon/report.png" alt="" class="content-left__icon">
                    </div>
                    <a href="" class="content-left__name" :class="{'active':isHideContentLeft}">Báo cáo</a>
                    
                </li>
                <li class="content-left__item ">
                    <div class="content-left__list-icon">
                        <img src="../../assets/icon/dashboard.png" alt="" class="content-left__icon">
                    </div>
                    <a href="" class="content-left__name" :class="{'active':isHideContentLeft}"> Mua hàng</a>
                   
                </li>
                <li class="content-left__item content-left__item-focus">
                    <div class="content-left__list-icon">
                        <img src="../../assets/icon/dic-employee.png" alt="" class="content-left__icon">
                    </div>
                    <a href="" class="content-left__name" :class="{'active':isHideContentLeft}"> Danh mục nhân viên</a>
                   
                </li>
                <li class="content-left__item ">
                    <div class="content-left__list-icon">
                        <img src="../../assets/icon/setting.png" alt="" class="content-left__icon">
                    </div>
                    <a href="" class="content-left__name" :class="{'active':isHideContentLeft}">Thiết lập hệ thống</a>
                </li>
                
                <div class="show-content" @click="btnShowContent" :class="{'active':isMargin}">
                    <i class="fas fa-chevron-left" :class="{'active':isHideIconLeft}"></i>
                    <i class="fas fa-chevron-right" :class="{'active':isHideIconRigth}"></i>
                </div>
            </ul>
        <div class="content" :class="{'active':isMargin}">
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
                        <ComBoBox :value='"Tất cả phòng ban"'
                                    :options='departments'
                                    :name= '"DepartmentName"'
                                    :id= '"DepartmentId"'
                                    @sendValueComboboxDepartmentId="getValueComboboxDepartmentId"
                        />
                        <ComBoBox :value='"Tất cả các vị trí"'
                                    :options='positions'
                                    :name= '"PositionName"'
                                    :id= '"PositionId"'
                                    @sendValueComboboxPositionId="getValueComboboxPositionId"
                                    
                        />
                        
                    </div>
                    <div class="content__search-refresh" @click="loadDataEmployee">
                        <div href=""><img src="../../assets/icon/refresh.png" alt=""></div>
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
                    :dataValue="dataValue"
                    :value="value"
                    :deleteList="deleteList"
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
        <EmployeeDetail :isHide='isHideDiaLogDetail' 
        @btnAddOnclick ="btnAddOnclick"
        :employeeId='employeeId'
        :mode='mode'
        :department='departmentsDropDown'
        :position='positionsDropDown'
        :arrayEmployeeCode="arrayEmployeeCode"
        :arrayIdentityNumber="arrayIdentityNumber"
        @toastMessenger="toastMessenger"
        @addEmployee="getEmployeeApi"
        ref="employeeModal"
        />

        <PopUp :isHidePopUp='isHidePopUp' 
        @btnDeleteOnclick ="btnDeleteOnclick"
        :deleteList="deleteList"
        @refeshData="refeshData"
        @deleteFail ="deleteFail"
        @btnConfirmDelete="btnConfirmDelete"
        />

        <ToastMessenger
            :isShowToast="isShowToast"
            :lable="lable"  
            :isSuccess="isSuccess"
            :isWarning="isWarning" 
        />

        <Loader 
            :isHideLoader="isHideLoader"
        />
    </div>
</template>

<script>

import EmployeeDetail from './EmployeeDetail.vue'
import PopUp from '../../components/base/BasePopUp.vue'
import ComBoBox from '../../components/base/BaseComBoBox.vue'
import Table from '../../components/base/BaseTable.vue'
import ToastMessenger from '../../components/base/BaseToastMessenger.vue'
import Loader from '../../components/base/BaseLoader.vue'
import EmployeesAPI from "../../api/components/EmployeesApi";
import PositionAPI from "../../api/components/PositionApi.js";
import DepartmentAPI from "../../api/components/DepartmentsApi.js";


export default {
    name : "EmployeeList",
    components : {
        EmployeeDetail,
        PopUp,
        ComBoBox,
        Table,
        ToastMessenger,
        Loader
    },
    /**
     * Hàm gọi Api lấy dữ liệu
     * creatAt : PVM.Quân (29/07/2021)
     * 
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
                        _this.consoleError(error.response.status)
                    })


        /**
         * Lấy dữ liệu các vị trí
         * creatAt : PVM.Quân (29/07/2021)
         */
        PositionAPI.getAll().then(res =>{ 
            _this.positions = res.data
            _this.positionsDropDown = res.data
        }).catch(error =>{
                        _this.consoleError(error.response.status)
                    })

         /**
         * Lấy dữ liệu nhân viên
         * creatAt : PVM.Quân (29/07/2021)
         */
        EmployeesAPI.getAll().then(res =>{
            _this.employees = res.data
            _this.employees.forEach((item,index)=>{
                _this.arrayEmployeeCode[index] = item.EmployeeCode
                _this.arrayIdentityNumber[index] = item.IdentityNumber
            })
            _this.isHideLoader = true
            }).catch(error =>{
            _this.consoleError(error.response.status)
            })
        
    },
    methods: {
        /**
         * Ẩn xóa toàn bộ khi xóa thành công
         */
        btnConfirmDelete(isDelete){
            this.isDelete = isDelete
            this.isHideLoader = false
        },
         /**
         * Lấy các danh sách cần xóa từ baseTable
         * PVM.Quân (04/08/2021)
         */
        getDeleteList(deleteList){
            this.deleteList = deleteList
        },
        /**
         * Load lại data 
         */
        loadDataEmployee(){
            
            var _this = this
            this.isHideLoader = false
            this.employees = {}
            this.isDelete = true
            this.deleteList = []
            EmployeesAPI.getAll().then(res =>{
            _this.employees = res.data
            _this.employees.forEach((item,index)=>{
                _this.arrayEmployeeCode[index] = item.EmployeeCode
                _this.arrayIdentityNumber[index] = item.IdentityNumber
            })
            _this.isHideLoader = true
            }).catch(error =>{
            _this.consoleError(error.response.status)
            })
        },
        /**
         * Hiển thị form chi tiết khi nhấn button thêm nhân viên
         * Author : PVM.Quân (29/07/2021)
         */
        btnAddOnclick(isHide){
            this.isHideDiaLogDetail = isHide
            this.mode = 2
            this.showFormDetail = true
            this.$refs.employeeModal.focusInput();
        },

        /**
         * Hiển thị form chi tiết khi Sửa nhân viên
         * Author : PVM.Quân (29/07/2021)
         */
        trDbOnClick(employeeId){
            this.isHideDiaLogDetail = false
            this.employeeId = employeeId
            this.mode = 1
            this.$refs.employeeModal.focusInput();
        },

        /**
         * Khi nhấn nút xóa  tất cả
         * Author : PVM.Quân (29/07/2021)
         */
        btnDeleteOnclick(isHidePopUp){
            this.isHidePopUp = isHidePopUp
        },

        /**
         * Hiển thị toast-messenger tương ứng với các thông báo
         * Author : PVM.Quân (06/08/2021)
         */
        toastMessenger(isShowToast,lable){
            this.isShowToast = isShowToast
            this.lable = lable
            this.isWarning = false
            this.isSuccess = true
            setTimeout(() => {
                this.isShowToast = true
            }, 5000);
        },

        /**
         * Tạo form hiển thị khi thất bại
         * creatBy : PVM.Quân(06/08)
         */
        consoleError(error){
            var _this = this
            _this.isShowToast = false
            _this.isSuccess = false
            _this.isWarning = true
            switch (error) {
                case 500:
                    _this.lable = 'Có lỗi từ server vui lòng liên hệ MiSA để giải quyết'
                break;
                case 400:
                    _this.lable = 'Dữ liệu bạn gửi lên không hợp lệ'
                break;
                default:
                break;
            }
            setTimeout(() => {
                 _this.isShowToast = true
            }, 5000);
        },
        /**
         * Lấy dữ liệu từ combobox truyền lên 
         */
        getValueComboboxDepartmentId(value){
            this.dataValue[0] = value
            this.value = value
        },
        getValueComboboxPositionId(value){
            this.dataValue[1] = value
            this.value = value
        },

        /**
        / Lấy dữ liệu mới khi thêm thành công
         */
        getEmployeeApi(){
             var _this = this
            /**
             * Lấy dữ liệu nhân viên sau khi bị thay đổi
             * creatAt : PVM.Quân (29/07/2021)
             */
            EmployeesAPI.getAll().then(res =>{
                _this.employees = res.data
                _this.employees.forEach((item,index)=>{
                _this.arrayEmployeeCode[index] = item.EmployeeCode
                _this.arrayIdentityNumber[index] = item.IdentityNumber
                })
            }).catch(error =>{
                            _this.consoleError(error.response.status)
                        })
            
        },
        /**
         * Refresh lại bảng và hiện thông báo sau khi xóa thành công 
         */
        refeshData(){
             var _this = this
            EmployeesAPI.getAll().then(res =>{
                 _this.deleteList = []
                

                // Lấy lại mảng sau khi xóa
                _this.employees = res.data
                _this.employees.forEach((item,index)=>{
                    _this.arrayEmployeeCode[index] = item.EmployeeCode
                    _this.arrayIdentityNumber[index] = item.IdentityNumber
                })

                _this.isHideLoader = true
                
                // Hiển thị thông báo tương ứng
                _this.isShowToast = false
                _this.lable = 'Xóa nhân viên thành công'
                _this.isWarning = false
                _this.isSuccess = true
                setTimeout(() => {
                    _this.isShowToast = true
                }, 5000);
                _this.isDelete = true
            }).catch(error =>{
                 _this.consoleError(error.response.status)
            })
        },
        /**
         * Hiển lỗi nễu xóa không thành công
         */
        deleteFail(error){
            this.consoleError(error.response.status)
        },

        /**
         * Xử lý ẩn và hiện nội dung của menu
         */
        btnShowContent(){
            this.index++
            if(this.index == 1){
                this.isHideIconLeft = true
                this.isHideIconRigth = false
                this.isHideContentLeft = true
                this.isMargin = false
                document.querySelector('.content-left__content').style.width = 52 + 'px'
            }else{
                this.index = 0
                this.isHideIconLeft = false
                this.isHideIconRigth = true
                this.isHideContentLeft = false
                 this.isMargin = true
                document.querySelector('.content-left__content').style.width = 200 + 'px'
            }
        }
    },


    watch : {
        deleteList: function(){
                if(this.deleteList.length ==0){
                    this.isDelete = true
                } else{
                    this.isDelete = false
                }
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
            departments : {},
            positions : {},
            departmentsDropDown : {},
            positionsDropDown : {},
            deleteList: [],
            arrayEmployeeCode : [],
            arrayIdentityNumber : [],
            isShowToast : '',
            lable : '',
            isSuccess : '',
            isWarning :'',
            dataValue : [null,null], 
            value : '',
            showFormDetail : false,
            isHideLoader : false,
            isHideIconLeft : false,
            isHideIconRigth : true,
            isHideContentLeft : false,
            index : 0,
            isMargin : true,
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