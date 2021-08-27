<template>
    <div class="contents">
        <div class="content">
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
                                <input type="text" class="field__search " name="search" placeholder="Tìm kiếm theo Mã, Tên, Số điện thoại" v-model="valueSearch">   
                                <div class="delete__value" 
                                @click="btnDeleteSearch"
                                :class="valueSearch.length > 0 ? 'active' : ''"
                                >
                                    <img
                                        src="../../assets/icon/x.svg"
                                        alt=""
                                    />
                                </div>
                            </div>
                            <ComBoBox :values='"Tất cả phòng ban"'
                                        :options='departments'
                                        :name= '"DepartmentName"'
                                        :id= '"DepartmentId"'
                                        @sendValueComboboxDepartmentId="getValueComboboxDepartmentId"
                            />
                            <ComBoBox :values='"Tất cả các vị trí"'
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
                        :value="value"
                        :deleteList="deleteList"
                        :indexTrdbClick="indexTrdbClick"
                        :totalPage ="totalPage"
                        :totalRecord="totalRecord"
                        @filter="filter"
                        @removebtnCheckAll ="removebtnCheckAll"
                    />
                
            </div>
       
            <div class="delete-scroll">
            </div>
    </div > 
        <EmployeeDetail :isHide='isHideDiaLogDetail' 
        @btnCancelOnclick ="btnCancelOnclick"
        :employeeId='employeeId'
        :mode='mode'
        :department='departmentsDropDown'
        :position='positionsDropDown'
        :arrayEmployeeCode="arrayEmployeeCode"
        :arrayIdentityNumber="arrayIdentityNumber"
        :employeeNewCode ="employeeNewCode"
        @toastMessenger="toastMessenger"
        @addEmployee="getEmployeeApi"
        @warningUpdate="warningUpdate"
        @setIndexTrDbClick="getIndexTrDbClick"
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
            :isError="isError"
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
import MessengerEmployee from "../../constants/MessengerEmployee"
import MessengerError from "../../constants/MessengerError"
import EmployeesApi from '../../api/components/EmployeesApi'


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
                var employees = res.data
                employees.forEach((item,index)=>{
                _this.arrayEmployeeCode[index] = item.EmployeeCode
                _this.arrayIdentityNumber[index] = item.IdentityNumber
                })
            }).catch(error =>{
                            _this.consoleError(error.response.status)
                        })

         /**
         * Lấy dữ liệu nhân viên theo phân trang
         * creatAt : PVM.Quân (29/07/2021)
         */
        EmployeesApi.paging(this.employeeFilter,this.departmentId,this.positionId,this.pageIndex,this.pageSize).then(res =>{
            _this.totalPage = res.data.totalPage
            _this.totalRecord = res.data.totalRecord
            _this.employees = res.data.data
            _this.isHideLoader = true
            }).catch(error =>{
            _this.consoleError(error.response.status)
            })
        /**
             * Lấy dữ liệu newCode mới vào
             * PVM.Quân (04/08/2021) 
             */  
            EmployeesAPI.get("NewEmployeeCode")
            .then((res) => {
                _this.employeeNewCode = res.data
            })
            .catch((error) => {
                _this.consoleError(error.response.status);
            });
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
            this.isDelete = true
            this.deleteList = []
            
            EmployeesAPI.getAll().then(res =>{
           var employees = res.data
            employees.forEach((item,index)=>{
                _this.arrayEmployeeCode[index] = item.EmployeeCode
                _this.arrayIdentityNumber[index] = item.IdentityNumber
            })
            _this.isHideLoader = true
            }).catch(error =>{
            _this.consoleError(error.response.status)
            })

            /**
         * Lấy dữ liệu nhân viên theo phân trang
         * creatAt : PVM.Quân (29/07/2021)
         */
        EmployeesApi.paging(this.employeeFilter,this.departmentId,this.positionId,this.pageIndex,this.pageSize).then(res =>{
            _this.totalPage = res.data.totalPage
            _this.totalRecord = res.data.totalRecord
            _this.employees = res.data.data
            _this.isHideLoader = true
            }).catch(error =>{
            _this.consoleError(error.response.status)
            })
        },
        /**
         * Hiển thị form chi tiết khi nhấn cancel
         * Author : PVM.Quân (29/07/2021)
         */
        btnCancelOnclick(){
            this.isHideDiaLogDetail = true
            this.indexTrdbClick = -1
        },
       
        /**
         * Hiển thị form chi tiết khi nhấn button thêm nhân viên
         * Author : PVM.Quân (29/07/2021)
         */
        btnAddOnclick(){
            this.isHideDiaLogDetail = false
            this.mode = 2
            this.$refs.employeeModal.focusInput()
           
        },

        /**
         * Hiển thị form chi tiết khi Sửa nhân viên
         * Author : PVM.Quân (29/07/2021)
         */
        trDbOnClick(employeeId,index){
            this.isHideDiaLogDetail = false
            this.employeeId = employeeId
            this.mode = 1
            this.indexTrdbClick = index
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
            if(this.isHideLoader == true){
                setTimeout(()=>{
                    this.isShowToast = isShowToast
                this.lable = lable
                this.isWarning = false
                this.isSuccess = true
                this.isError = false;
                setTimeout(() => {
                    this.isShowToast = true
                }, 5000);
                },100)
            }
        },

        /**
         * Hiển thị cảnh báo khi không sửa gì
         */
        warningUpdate(){
            this.isShowToast = false;
            this.isSuccess = false;
            this.isError = true;
            this.isWarning = false;
            this.lable = MessengerError.Warning
            setTimeout(() => {
                this.isShowToast = true
            }, 5000);
        },
        /**
         * Tạo form hiển thị khi thất bại
         * creatBy : PVM.Quân(06/08)
         */
         consoleError(error) {
            var _this = this;
            _this.isShowToast = false;
            _this.isSuccess = false;
            _this.isError = false;
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
        /**
         * Lấy dữ liệu từ combobox truyền lên 
         */
        getValueComboboxDepartmentId(id){
            this.departmentId = id
            this.pageIndex = 1
            this.isHideLoader = false
            this.getPaging()
        },
        getValueComboboxPositionId(id){
           this.positionId = id
           this.pageIndex=1
            this.isHideLoader = false
           this.getPaging()
        },
        

        /**
        / Lấy dữ liệu mới khi thêm thành công
         */
        getEmployeeApi(){
             var _this = this
              _this.isHideLoader = false
            /**
             * Lấy dữ liệu nhân viên sau khi bị thay đổi
             * creatAt : PVM.Quân (29/07/2021)
             */
            EmployeesAPI.getAll().then(res =>{
                var employees = res.data
                employees.forEach((item,index)=>{
                _this.arrayEmployeeCode[index] = item.EmployeeCode
                _this.arrayIdentityNumber[index] = item.IdentityNumber
                _this.isHideLoader = true
                })
            }).catch(error =>{
                            _this.consoleError(error.response.status)
                        })
            
            /**
             * Lấy dữ liệu newCode mới vào
             * PVM.Quân (04/08/2021) 
             */  
            EmployeesAPI.get("NewEmployeeCode")
            .then((res) => {
                _this.employeeNewCode = res.data
                _this.isHideLoader = true
                
            })
            .catch((error) => {
                _this.consoleError(error.response.status);
            });

            /**
         * Lấy dữ liệu nhân viên theo phân trang
         * creatAt : PVM.Quân (29/07/2021)
         */
        EmployeesApi.paging(this.employeeFilter,this.departmentId,this.positionId,this.pageIndex,this.pageSize).then(res =>{
            _this.totalPage = res.data.totalPage
            _this.totalRecord = res.data.totalRecord
            _this.employees = res.data.data
            _this.isHideLoader = true
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
                var employees = res.data
                // Lấy lại mảng sau khi xóa
                employees.forEach((item,index)=>{
                    _this.arrayEmployeeCode[index] = item.EmployeeCode
                    _this.arrayIdentityNumber[index] = item.IdentityNumber
                })

                _this.isHideLoader = true
                
                // Hiển thị thông báo tương ứng
                _this.isShowToast = false
                _this.lable = MessengerEmployee.DeleteCorrect
                _this.isWarning = false
                _this.isError = false
                _this.isSuccess = true
                setTimeout(() => {
                    _this.isShowToast = true
                }, 5000);
                _this.isDelete = true
            }).catch(error =>{
                 _this.consoleError(error.response.status)
            })

            /**
             * Lấy dữ liệu newCode mới vào
             * PVM.Quân (04/08/2021) 
             */  
            EmployeesAPI.get("NewEmployeeCode")
            .then((res) => {
                _this.employeeNewCode = res.data
            })
            .catch((error) => {
                _this.consoleError(error.response.status);
            });

            /**
         * Lấy dữ liệu nhân viên theo phân trang
         * creatAt : PVM.Quân (29/07/2021)
         */
        EmployeesApi.paging(this.employeeFilter,this.departmentId,this.positionId,this.pageIndex,this.pageSize).then(res =>{
            _this.totalPage = res.data.totalPage
            _this.totalRecord = res.data.totalRecord
            _this.employees = res.data.data
            _this.isHideLoader = true
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
         * Xóa value của ô input tìm kiếm
         */
        btnDeleteSearch(){
            this.valueSearch = ""
        },

        /**
         * Xóa background tr khi hủy form
         */
        getIndexTrDbClick(){
            this.indexTrdbClick = -1
        },

        filter(pageIndex,pageSize){
            this.pageIndex = pageIndex
            this.pageSize = pageSize
            this.isHideLoader = false
            this.getPaging()
        },
        /**
         * Tạo phương thức lấy dữ liệu phân trang
         */
        getPaging(){
            var _this = this
            EmployeesApi.paging(this.employeeFilter,this.departmentId,this.positionId,this.pageIndex,this.pageSize).then(res =>{
            _this.totalPage = res.data.totalPage
            _this.totalRecord = res.data.totalRecord
            _this.employees = res.data.data
            _this.isHideLoader = true
            }).catch(error =>{
            _this.consoleError(error.response.status)
            })
        },
        removebtnCheckAll(){
            this.deleteList = []
        }
    },


    watch : {
        /**
         * Xử lý ẩn hiện button xóa 
         */
        deleteList: function(){
                if(this.deleteList.length ==0){
                    this.isDelete = true
                } else{
                    this.isDelete = false
                }
            },
            /**
             * Xử lý lọc tìm kiếm theo tên,mã sinh viên 
             */
        valueSearch(){
            var _this = this
            clearTimeout(this.timeout);
                this.timeout = setTimeout(function () {
                    _this.employeeFilter = _this.valueSearch
                    _this.pageIndex = 1
                    _this.isHideLoader = false
                    _this.getPaging()
                }, 300);
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
            isError :'',
            value : '',
            showFormDetail : false,
            isHideLoader : false,
            index : 0,
            isMargin : true,
            valueSearch : '',
            indexTrdbClick : -2,
            employeeNewCode : '',
            employeeFilter : '',
            departmentId : '',
            positionId : '', 
            pageIndex : 1,
            pageSize : 20,
            totalPage : 0,
            totalRecord : 0,
            timeout: null,
            
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
                    checkclass : '',
                    format : "status"
                },
            ]
        }
    },
}
</script>

<style scoped>
@import url('../../assets/css/layout/Content.css');
</style>