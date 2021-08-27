<template>
    <div class="combobox"  :id="'combobox'+name" @click="selectItem" :class="{'focus':isFocus}">
            <input type="text" class="combobox-input active"  
            :class="'combobox-input'+name" 
            v-model="nameShow" 
            :placeholder="values" 
            @input="Input"
            :ref="'combobox-input'+name"
            >
            <i class="fas fa-chevron-down combobox-icon" :class="{'active':isHideIconUp}"></i>
            <i class="fas fa-chevron-up combobox_dropup-icon " :class="{'active':isHideIconDown}"></i>
            <ul class="combobox-list" :class="{'active':isHide}">
                <li class="combobox-list__item" v-on:click="showItemListCBB(values,0)" :class="itemIndex == 0 ?'combobox-list__item-focus' : ''">
                    <i class="fas fa-check"></i>
                    <span>
                        {{values}}
                    </span>
                </li>
                <li  class="combobox-list__item" v-for="(item,index) in options" :key="item[id]" 
                v-on:click="showItemListCBB(item[name],index+1)"
                :class="index +1 == itemIndex ? 'combobox-list__item-focus' : ''"
                >
                    <i class="fas fa-check"></i>
                    <span>
                        {{item[name]}}
                    </span>
                </li>
            </ul>
            <div class="delete__value" @click="btnDeleteValue" :class="{'active':isDeleteValue}">
                    <img
                        src="../../assets/icon/x.svg"
                        alt=""
                    />
                </div>
        </div>
</template>


<script>
import $ from 'jquery'
export default {
    name : "ComBoBox",
    props : {
        values: {
            type: String,
            requied: true,
        },
        label: {
            type: String,
            requied: true,
        },
        name: {
            type: String,
            requied: true,
        },
        id: {
            type: String,
            requied: true,
        },
        checked: {
            type: Boolean,
            requied: false,
            default: true,
        },
        options : {
            required: true,
            type: [Object, Array]
        }
    },
    methods: {
            /**
             * Xử lý chọn từng thành phần trong combobox
             */
            selectItem(){
                var _this = this
                this.isHide = true
                this.isHideIconUp = true
                this.isHideIconDown = false
                this.isFocus = true
                /**
                 * Khi click ra ngoài windown
                 */
                $(window).on("click.Bst", function(event){
                    if($(`#${'combobox'+_this.name}`).has(event.target).length == 0 && !$(`#${'combobox'+_this.name}`).is(event.target)){
                        _this.isHide = false
                        _this.isHideIconUp = false
                        _this.isHideIconDown = true
                        _this.isFocus = false
                    }else{
                        _this.isHide = true
                        _this.isHideIconUp = true
                        _this.isHideIconDown = false
                        _this.isFocus = true
                    }
                })
            },

            /**
             * khi chọn từng option
             */
            showItemListCBB(nameShow,index){
                if(nameShow == this.values){
                    nameShow = ''
                }
                this.nameShow = nameShow
                this.itemIndex = index
            },

            /**
             * Khi xóa value 
             */
            btnDeleteValue(){
                this.nameShow = ''
                this.isDeleteValue = false
            },
            /**
             * Hiển thị nút xóa khi nhập vào input 
             */
            Input(){
                var _this =this 
                 this.nameShow = this.$refs[`${'combobox-input'+_this.name}`].value
                    if(this.nameShow.length>0){
                        this.isDeleteValue = true
                    }else{
                        this.isDeleteValue = false
                    }
            },
            
        },

    data() {
            return {
                isHide : false,
                isHideIconUp : false,
                isHideIconDown : true,
                isFocus : false,
                nameShow : '',
                index : 0,
                isDeleteValue : false,
                itemIndex : 0,
            }
    },

    watch: {
        /**
         * Gửi value đang được hiển thị lên cha để thực hiện tìm kiếm 
         */
        nameShow : function(){
            var _this = this;
            var id = "";
            this.options.forEach(item=>{
                if(_this.nameShow == item[_this.name]){
                    id = item[_this.id]
                }
            })
            this.$emit(`sendValueCombobox${this.id}`,id)
            if(this.nameShow.length>0){
                this.isDeleteValue = true
            }else{
                this.isDeleteValue = false
                this.itemIndex = 0
            }
        }
    }
}




// author : PVM.Quân
</script>

<style scoped>
@import url('../../assets/css/base/Combobox.css');
</style>