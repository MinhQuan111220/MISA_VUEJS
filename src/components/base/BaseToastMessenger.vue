<template>
        <div class="toast-messenger" :class="{'active':isShowToast}">
           <div class="toast-messenger__show">
                <div class="toast-icon" :class="{'toast-success':isSuccess,'toast-warning':isWarning,'toast-error':isError}">
                <i class="fas fa-check-circle" :class="{'toast-success':isSuccess}"></i>
                <i class="fas fa-exclamation-circle" :class="{'toast-error':isError}"></i>
                <i class="fas fa-exclamation-triangle" :class="{'toast-warning':isWarning}"></i>
                </div>    
                <div class="toast-title">
                    {{lable}}
                </div>
                    <img
                    src="../../assets/icon/x.svg"
                    alt=""
                    class="toast-close"
                    :class="{'toast-success':isSuccess,'toast-warning':isWarning,'toast-error':isError}"
                    @click="btnExitOnClick"
                    />
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
        isError: {
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