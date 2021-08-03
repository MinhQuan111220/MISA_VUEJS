<template>
    <div class="base-input">
        <h3 class="input-header title2">
            <div v-if="binding == true">
            {{value}}(<span class="correct">*</span>)
            </div>
            <div v-else>
            {{value}}
            </div>
        </h3>
        <div v-if="iconMoney == true">
            <input :type="type" class="heigth-input input input-money" :id=id v-model="name"> 
            <span class="input-icon input-vnd">(VNĐ)</span>
        </div>
        <div v-else>
            <input :type="type" class="heigth-input input auto-focus__input" :id=id v-model="name"> 
        </div>
        <div v-if="binding == true">
           <div class="form-message"></div>
        </div> 
    </div>
</template>

<script>
export default {
    name : 'Input',
    props : {
        name :{
            type : String,
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
    }
}
</script>

<style scoped>
@import url('../../assets/css/form/Staff_information.css');
@import url('../../assets/css/base/Input.css');
</style>