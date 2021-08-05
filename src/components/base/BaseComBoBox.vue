<template>
    <div class="combobox"  :id="'combobox'+name" @click="selectItem" :class="{'focus':isFocus}">
            <input type="text" class="combobox-input active" v-model="nameShow" :placeholder="value">
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
            // Xử lý chọn option trong dropdown
            selectItem(){
                var _this = this
                this.isHide = true
                this.isHideIconUp = true
                this.isHideIconDown = false
                this.isFocus = true

                // khi click ra ngoài windowns
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

            // khi chọn từng option
            showItemListCBB(nameShow,index){
                this.nameShow = nameShow
                document.querySelector(`#${'combobox'+this.id}.combobox-list__item-focus`).classList.remove('combobox-list__item-focus')
                document.querySelectorAll(`#${'combobox'+this.id}`)[index].classList.add('combobox-list__item-focus')
            }
        },

    data() {
            return {
                isHide : false,
                isHideIconUp : false,
                isHideIconDown : true,
                isFocus : false,
                nameShow : '',
            }
    },

}




// author : PVM.Quân
</script>

<style scoped>
@import url('../../assets/css/base/Combobox.css');
</style>