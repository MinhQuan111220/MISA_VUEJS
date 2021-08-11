<template>
        <div class="toast-messenger" :class="{'active':isShowToast}">
           <div class="toast-messenger__show">
                <div class="toast-icon" :class="{'toast-success':isSuccess,'toast-warning':isWarning}">
                <i class="fas fa-check-circle"></i>
                </div>    
                <div class="toast-title">
                    {{lable}}
                </div>
                <i class="fas fa-times toast-close" :class="{'toast-success':isSuccess,'toast-warning':isWarning}" @click="btnExitOnClick"></i>
           </div>
        </div>
</template>

<script>
export default {
    name : 'ToastMessenger',
    props:{

        isShowToast: {
            type: Boolean,
            default : true,
            required: true,
        },
        isSuccess: {
            type: Boolean,
            default : false,
            required: true,
        },
        isWarning: {
            type: Boolean,
            default : false,
            required: true,
        },
        lable : {
            type : String,
            required : 'true',
        }
    },
    methods: {
        /**
         * Ẩn toast
         */
        btnExitOnClick(){
            this.isShowToast = true
        }
    },
}   
</script>

<style >
   @import url('../../assets/css/base/ToastMessenger.css');
</style>