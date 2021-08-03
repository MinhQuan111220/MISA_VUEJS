<template>
    <div class="dropdown"  :id="'dropdown'+name" @click="selectItem" :class="{'focus':isFocus}">
            <input type="text" class="dropdown-input active"  v-model="nameShow"  readonly>
            <i class="fas fa-chevron-down dropdown-icon" :class="{'active':isHideIconUp}"></i>
            <i class="fas fa-chevron-up dropup-icon " :class="{'active':isHideIconDown}"></i>
            <ul class="dropdown-list" :class="{'active':isHide}">
                <li :id="'dropdown'+id" class="dropdown-list__item" 
                v-for="(item,index) in options" :key="item[id]" 
                v-on:click="showItemListCBB(item[name],index+1)"
        
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
import EmployeesAPI from "../../api/components/EmployeesApi";


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
            type: [Object, Array]
        },
        check : {
            type : Number,
            default : 0, // 0 thêm mới 1 sửa
            required : true,
        },
        select : {
            type : String,
            default : '',
            required : true,
        }
    },
    methods: {
            /**
             * Xử lý khi tương tác với các phần tử của dropdown
             * PVM.Quân (29/07/2021)
             */
            // Xử lý chọn option trong dropdown
            selectItem(){
                var _this = this
                this.isHide = true
                this.isHideIconUp = true
                this.isHideIconDown = false
                this.isFocus = true
                // Hiển thị focus dropdown đang được hiển thị
                this.options.forEach((item,index)=>{
                    if(_this.nameShow.toUpperCase()===item[_this.name].toUpperCase()){
                      document.querySelectorAll(`#${'dropdown'+_this.id}`)[index].classList.add('dropdown-list__item-focus')
                    }
                })

                // khi click ra ngoài windowns
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

            // khi chọn từng option
            showItemListCBB(nameShow){
                this.nameShow = nameShow
                document.querySelector(`#${'dropdown'+this.id}.dropdown-list__item-focus`).classList.remove('dropdown-list__item-focus')
            },
        },

    data() {
            return {
                isHide : false,
                isHideIconUp : false,
                isHideIconDown : true,
                isFocus : false,
                nameShow : '' ,
                employee : {},
            }
    },

    watch :{
        /**
         * Xử lý lấy thông tin nhân viên theo  id
         * PVM.Quân (29/07/2021)
         */
        select : function(){
            // Gọi Api lấy thông tin chi tiết nhân viên
            var _this = this
            EmployeesAPI.get(_this.select).then((res) => {
                /**
                 * Gán hiển thị cho input sau khi lấy được dữ liệu
                 * PVM.Quân (29/07/2021)
                 */
                _this.options.forEach((item)=>{
                    if(res.data[_this.id]== item[_this.id]){
                        _this.nameShow = item[_this.name]
                    }
                })
            }).catch(error =>{
                         switch (error.status) {
                            case 500:
                                console.log('Có lỗi từ server, vui lòng thử lại');
                                break;
                            case 400:
                                console.log('Dữ liệu không hợp lệ');
                                break;
                            default:
                                break;
                        }
                    })
        },

        // Check khi nào thêm khi nào sửa
        check : function (){
            if(this.check == 1){
            //   
            }else{
                this.nameShow = this.options[0][this.name] 
            }
        },
    }

}




// author : PVM.Quân
</script>

<style scoped>
@import url('../../assets/css/base/Dropdown.css');
@import url('../../assets/css/base/Input.css');

</style>