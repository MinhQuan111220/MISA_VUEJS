<template>
    <div class="combobox"  :id="'combobox'+name" @click="selectItem" :class="{'focus':isFocus}">
            <input type="text" class="combobox-input active"  :class="'combobox-input'+name" v-model="nameShow" :placeholder="value" >
            <i class="fas fa-chevron-down combobox-icon" :class="{'active':isHideIconUp}"></i>
            <i class="fas fa-chevron-up combobox_dropup-icon " :class="{'active':isHideIconDown}"></i>
            <ul class="combobox-list" :class="{'active':isHide}">
                <li class="combobox-list__item combobox-list__item-focus" v-on:click="showItemListCBB(value,0)" :id="'combobox'+id">
                    <i class="fas fa-check"></i>
                    <span>
                        {{value}}
                    </span>
                </li>
                <li :id="'combobox'+id" class="combobox-list__item" v-for="(item,index) in options" :key="item[id]" v-on:click="showItemListCBB(item[name],index+1)">
                    <i class="fas fa-check"></i>
                    <span>
                        {{item[name]}}
                    </span>
                </li>
            </ul>
        </div>
</template>


<script>
import $ from 'jquery'
export default {
    name : "ComBoBox",
    props : {
        value: {
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
                this.keyDown()
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
                if(nameShow == this.value){
                    nameShow = ''
                }
                this.nameShow = nameShow
                document.querySelector(`#${'combobox'+this.id}.combobox-list__item-focus`).classList.remove('combobox-list__item-focus')
                document.querySelectorAll(`#${'combobox'+this.id}`)[index].classList.add('combobox-list__item-focus')
                this.$emit('sendValueCombobox',this.nameShow)
            },

            /**
             * Xử lý keydown cho combobox
             * creatBy : PVM.Quân (06/08/2021)
             */
            keyDown(){
                var _this = this
                var index= 0;
                var arrayKeydown = []
                    $(`.${'combobox-input'+this.name}`).on('keydown',function(e){
                    arrayKeydown = $(`#${'combobox'+_this.id}.combobox-list__item`).filter(function() {
                        return this.innerText.toLowerCase().indexOf("") > -1
                    });
                    if (e.keyCode == 40) {
                        index ++
                        document.querySelector(`#${'combobox'+_this.id}.combobox-list__item-focus`).classList.remove('combobox-list__item-focus')
                        if(index >=arrayKeydown.length){
                            index = 0;
                        }
                        arrayKeydown[index].classList.add('combobox-list__item-focus')
                    }
                    else if (e.keyCode == 38) {
                        index--
                        console.log(arrayKeydown)
                        if(index <0){
                            index = arrayKeydown.length-1;
                        }
                        document.querySelector(`#${'combobox'+_this.id}.combobox-list__item-focus`).classList.remove('combobox-list__item-focus')
                        arrayKeydown[index].classList.add('combobox-list__item-focus')
                    }  
                    else if(e.keyCode ==13){
                        if(arrayKeydown[index].innerText.toLowerCase() === _this.value.toLowerCase()){
                            _this.nameShow = ''
                        }
                        else{
                            _this.nameShow = arrayKeydown[index].innerText
                        }
                        console.log(index)
                    }
                })
                }
            
        },

    data() {
            return {
                isHide : false,
                isHideIconUp : false,
                isHideIconDown : true,
                isFocus : false,
                nameShow : '',
                index : 0,
                
            }
    },

    watch: {
        /**
         * Gửi value đang được hiển thị lên cha để thực hiện tìm kiếm 
         */
        nameShow : function(){
            this.$emit(`sendValueCombobox${this.id}`,this.nameShow)
        }
    }
}




// author : PVM.Quân
</script>

<style scoped>
@import url('../../assets/css/base/Combobox.css');
</style>