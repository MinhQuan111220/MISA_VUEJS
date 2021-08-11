<template>
    <div class="bg-loader" :class="{'active':isHideLoader}">
        <div class="loader-container">
            <div class="loader"></div>
            <div class="loader-mess">Hệ thống đang xử lí, quý khách vui lòng chờ....</div>
        </div>
    </div>
</template>

<script>
export default {
    name : 'Loader',
    props :{
        isHideLoader:{
            type : Boolean,
             required : false,
        }
    }
}
</script>
<style scoped>
   @import url("../../assets/css/base/Loader.css");
</style>