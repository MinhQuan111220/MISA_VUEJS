<template>
    <div class="dropdown"  :id="'dropdown'+name" @click="selectItem" :class="{'focus':isFocus}">
            <input type="text" class="dropdown-input active" :class="'dropdown-input'+name" v-model="nameShow"  readonly @keydown="keyDown">
            <i class="fas fa-chevron-down dropdown-icon" :class="{'active':isHideIconUp}"></i>
            <i class="fas fa-chevron-up dropup-icon " :class="{'active':isHideIconDown}"></i>
            <ul class="dropdown-list" :class="{'active':isHide,'last':isLast}">
                <li :id="'dropdown'+id" class="dropdown-list__item" 
                v-for="(item,index) in options" :key="item[id]" 
                v-on:click="showItemListCBB(item[name],index)"
                :class="index == itemIndex ? 'dropdown-list__item-focus' :'' " 
                >
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
    name : "DropDown",
    props : {
        name: {
            type: String,
            requied: true,
        },
        id: {
            type: String,
            requied: true,
        },
        options : {
            required: true,
            default :() =>{},
            type: [Object, Array]
        },
        
        select : {
            type : [String,Number],
            default : '',
            required : true,
        },

        check : {
            type : Number,
            default : 0,
        },

        isLast : {
            type : Boolean,
            default : false,
        }

    },
    methods: {
            /**
             * Xử lý khi tương tác với các phần tử của dropdown
             * PVM.Quân (29/07/2021)
             */
            selectItem(){
                var _this = this
                this.isHide = true
                this.isHideIconUp = true
                this.isHideIconDown = false
                this.isFocus = true
                
                /**
                 * Khi click ra ngoài Windown
                 */
                $(window).on("click.Bst", function(event){
                    if($(`#${'dropdown'+_this.name}`).has(event.target).length == 0 && !$(`#${'dropdown'+_this.name}`).is(event.target)){
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
             * Khi click vào từng dropdown 
             */
            showItemListCBB(nameShow,index){
                this.nameShow = nameShow
                this.itemIndex = index
            },
            
            keyDown(event){
                // var _this = this
                if(event.keyCode == 9){
                    this.isHide = true
                    this.isHideIconUp = true
                    this.isHideIconDown = false
                    this.isFocus = true
                }
            }
        },

    data() {
            return {
                isHide : false,
                isHideIconUp : false,
                isHideIconDown : true,
                isFocus : false,
                nameShow : this.options[0][this.name],
                idRequest : '',
                employee : {},
                index : 0,
                itemIndex : 0,
            }
    },

    watch :{
         /**
         * Hiển thị thông tin theo  id 
         * PVM.Quân (04/08/2021)
         */
        select : function(){
                this.options.forEach((item)=>{
                    if(item[this.id]==this.select){
                        this.nameShow = item[this.name]
                    }
                })
        },

         /**
         * Truyền dữ liệu lêm cha để submit
         * PVM.Quân (04/08/2021)
         */
        nameShow : function(){
            this.options.forEach((item,index)=>{
                if(this.nameShow == item[this.name]){
                    this.idRequest = item[this.id]
                    this.itemIndex = index
                }
            })
            this.$emit('sendValueDropDown',this.idRequest,this.id,this.select)
        },

         /**
         * Kiểm tra xem khi naò thêm khi nào sửa
         * PVM.Quân (04/08/2021)
         */
        check : function(){
            if(this.check==0){
                this.select = ''
                this.nameShow = this.options[0][this.name]
            }else{
                this.nameShow = ''
            }
        }
    }

}




// author : PVM.Quân
</script>

<style scoped>
@import url('../../assets/css/base/Dropdown.css');
@import url('../../assets/css/base/Input.css');

</style>