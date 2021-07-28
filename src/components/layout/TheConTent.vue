<template>
    <div class="content ">
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
                    <div class="content__action-button" v-on:click="showStaffInformation">
                        <button class="content__action-button-btn add">
                            <img class="button__icon-left" src="../../assets/icon/add.png" alt="">
                            <h3 class="button__text-add">Thêm Nhân Viên</h3>
                        </button>
                    </div>
                </div>
                <div class="content__search">
                    <div class="content__field">
                        <div class="field">
                            <img src="../../assets/icon/search.png" alt="" class="field__icon">
                            <input type="text" class="field__search " name="search" placeholder="Tìm kiếm theo Mã, Tên, Số điện thoại" >   
                        </div>
                        <div class="dropdown dropdown__room"> 
                            
                        </div>
                        <div class="dropdown dropdown__location">
                            
                        </div>
                    </div>
                    <div class="content__search-refresh">
                        <a href=""><img src="../../assets/icon/refresh.png" alt=""></a>
                    </div>
                </div>
               
                <div class="content-table">
                    <table >
                        <thead>
                            <tr>
                                <th prop-name="" class="content-table__column" > Xóa</th>
                                <th prop-name="EmployeeCode" class="content-table__column" > Mã nhân viên</th>
                                <th prop-name="FullName" class="content-table__column" > Họ và tên</th>
                                <th prop-name="GenderName" class="content-table__column" > Giới tính</th>
                                <th prop-name="DateOfBirth" class="content-table__column">Ngày sinh</th>
                                <th prop-name="PhoneNumber" class="content-table__column" > Điện thoại</th>
                                <th prop-name="Email" class="content-table__column" > Email</th>
                                <th prop-name="PositionName" class="content-table__column" > Chức vụ</th>
                                <th prop-name="DepartmentName" class="content-table__column" > Phòng ban</th>
                                <th prop-name="Salary" class="content-table__column money">Mức lương cơ bản</th>
                                <th prop-name="WorkStatus" class="content-table__column" > Tình trạng công việc</th>
                                
                            </tr>
                        </thead>
                        <tbody class="staffTable"> 
                            <tr v-for="employee in Employees" :key="employee.EmployeeID">
                                <td  > <i class="far fa-trash-alt"></i></td>
                                <td  > {{employee.EmployeeCode}}</td>
                                <td  > {{employee.FullName}}</td>
                                <td  > {{employee.GenderName}}</td>
                                <td  > {{employee.DateOfBirth}}</td>
                                <td  > {{employee.PhoneNumber}}</td>
                                <td  > {{employee.Email}}</td>
                                <td  > {{employee.DepartmentName}}</td>
                                <td  > {{employee.PositionName}}</td>
                                <td class="money" > {{employee.Salary}}</td>
                                <td  > {{employee.WorkStatus}}</td>
                            </tr>
                        </tbody>
                    </table>`
                </div>
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
    </div>
</template>

<script>
export default {
    name : "TheConTent",
    created() {
        var _this = this
        _this.axios.get('http://cukcuk.manhnv.net/v1/Employees').then((res) => {
            _this.Employees = res.data
        })
    },
    methods: {
        showStaffInformation(){
            console.log(1)
        }
    },
    data(Employees) {
        return{
            Employees
        }
    },
}
</script>

<style scoped>
@import url('../../assets/css/layout/Content.css');
</style>