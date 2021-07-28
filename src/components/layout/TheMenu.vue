<template>
    <div class="menu-left">
            <!-- Menu left -->
            <div class="menu-left__logo">
                <div class="icon-box">
                    <img class="icon-toggle" src="../../assets/img/toggle.png" alt="">
                </div>
                <div class="logo-box">
                    <img class="logo" src="../../assets/img/cukcuk-logo.png" alt="">
                </div>
            </div>
            <!-- Menu Left Content -->
            <ul class="menu-left__content">
                <li class="menu-left__item ">
                    <div class="menu-left__list-icon">
                        <img src="../../assets/icon/dashboard.png" alt="" class="menu-left__icon">
                    </div>
                    <a href="" class="menu-left__name">Tổng quan</a>
                    
                </li>
                <li class="menu-left__item ">
                    <div class="menu-left__list-icon">
                        <img src="../../assets/icon/report.png" alt="" class="menu-left__icon">
                    </div>
                    <a href="" class="menu-left__name">Báo cáo</a>
                    
                </li>
                <li class="menu-left__item ">
                    <div class="menu-left__list-icon">
                        <img src="../../assets/icon/dashboard.png" alt="" class="menu-left__icon">
                    </div>
                    <a href="" class="menu-left__name"> Mua hàng</a>
                   
                </li>
                <li class="menu-left__item menu-left__item-focus">
                    <div class="menu-left__list-icon">
                        <img src="../../assets/icon/dic-employee.png" alt="" class="menu-left__icon">
                    </div>
                    <a href="" class="menu-left__name"> Danh mục nhân viên</a>
                   
                </li>
                <li class="menu-left__item ">
                    <div class="menu-left__list-icon">
                        <img src="../../assets/icon/setting.png" alt="" class="menu-left__icon">
                    </div>
                    <a href="" class="menu-left__name">Thiết lập hệ thống</a>
                </li>
            </ul>
    </div>
</template>

<script>
export default {
    name : "TheMenu"
}
</script>

<style scoped>
@import url('../../assets/css/layout/Menu.css');
</style>