<template>
    <div class="navbars" :class="{'active':isActive}">
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
                
                <div class="show-content" @click="btnShowContent" :class="{'active':isActive}">
                    <i class="fas fa-chevron-left" :class="{'active':isHideIconLeft}"></i>
                    <i class="fas fa-chevron-right" :class="{'active':isHideIconRigth}"></i>
                </div>
            </ul>
    </div>
</template>

<script>


export default {
    name : "TheNavbar",
    methods: {
        /**
         * Xử lý ẩn và hiện nội dung của menu
         */
        btnShowContent(){
            this.index++
            if(this.index == 1){
                this.isHideIconLeft = true
                this.isHideIconRigth = false
                this.isHideContentLeft = true
                this.isActive = false
            }else{
                this.index = 0
                this.isHideIconLeft = false
                this.isHideIconRigth = true
                this.isHideContentLeft = false
                this.isActive = true
            }
            this.$emit('active',this.index)
        },
    },
    data() {
        return {
            isHideIconLeft : false,
            isHideIconRigth : true,
            isHideContentLeft : false,
            index :0,
            isActive : true,
        }
    },
}
</script>

<style scoped>
@import url('../../assets/css/layout/Content.css');
</style>