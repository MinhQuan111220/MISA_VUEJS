<template>
    <div class="header">
            <div class="header-left__logo">
                <div class="icon-box">
                    <img class="icon-toggle" src="../../assets/img/toggle.png" alt="">
                </div>
                <div class="logo-box">
                    <img class="logo" src="../../assets/img/cukcuk-logo.png" alt="">
                </div>
            </div>
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
    </div>
</template>

<script>
export default {
    name : "TheMenu",
}
</script>

<style scoped>
@import url('../../assets/css/layout/Menu.css');
</style>