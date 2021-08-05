<template>
    <div :class="'base-input' + id" class="input-embrace">
        <div class='form-group'>
            <h3 class="input-header title2">
            <div v-if="binding == true">
            {{value}}(<span class="correct">*</span>)
            </div>
            <div v-else>
            {{value}}
            </div>
            </h3>
            <div v-if="iconMoney == true">
                <input :type="type" class="input input-money" :id=id :value="nameInput" @input="formatAndSubmit"> 
                <span class="input-icon input-vnd">(VNĐ)</span>
            </div>
            <div v-else>
                <input :type="type" class="input" :id=id :value="nameInput" :format="type" @focus="validate" @input="formatAndSubmit"> 
            </div>
            <div v-if="binding == true">
            <div class="form-message"></div>
            </div> 
        </div>
    </div>
</template>

<script>
import Format from '../../untils/Format.js'
import $ from 'jquery'
export default {
    name : 'Input',
    props : {
        name :{
            type : [String,Number],
            default: '',
            required : true,
        },
        id :{
            type : String,
            required : true,
        },
        value :{
            type : String,
            required : true,
        },
        type :{
            type : String,
            required : true,
        },
        binding :{
            type : Boolean,
            required : false,
        },
        iconMoney :{
            type : Boolean,
            required : false,
        },
        isFocus : {
            type : Boolean,
        }
    },
    methods: {
        /**
         * Hàm xử lý khi nhập tiền lương trong form và truyền dữ liệu lên cha để submit
         * creatAt : PVM.Quân (03/08/2021)
         */
        formatAndSubmit(){
           if(this.iconMoney == true){
                $('.input-money').on('input', function(){
                var value = $('.input-money').val();
                var afterformat = String(value).replaceAll('.','');
                $('.input-money').val(Format.salaryFormat(afterformat));
            })
           }
            var value = $(`#${this.id}`).val()
            this.$emit('sendValueInput',value,this.id)
        },

        /**
         * Hàm xử lý khi một ô input được focus mặc định
         * creatAt : PVM.Quân (03/08/2021)
         */
        focusInput(){
            if(this.isFocus == true){
                $(document).ready(function () {
                    $(".input").focus();
                });
            }
        },
         /**
         * Gửi form lên cha để validate dữ liệu
         * creatAt : PVM.Quân (03/08/2021)
         */
        validate(){
            if(this.binding == true){
                this.$emit('sendDomValidate',this.formGroup,this.formMessage)
            }
        },

    },
    watch: {
        /**
         * Xử lý định dạng các thành phần khi api về
         * PVM.Quân (04/08/2021)
         */
        name: function() {
            this.nameInput = this.name
        },

    }
    ,
    data() {
        return {
            nameInput: '',
            typeInput : '',
            formGroup : 'form-group',
            formMessage : 'form-message',
        }
    },
    
}

</script>

<style scoped>
@import url('../../assets/css/form/Staff_information.css');
@import url('../../assets/css/base/Input.css');
@import url('../../assets/css/base/Vadilator.css');
</style>