<template>
    <div class="page-combobox">
        <div class="combobox" @click="cbbOnClick" v-for="(combobox,index) in baseComBoBox" :key="combobox">
            <input type="text" class=" combobox-input active" :placeholder=combobox[0] v-model="comBoBoxName">
            <i class="fas fa-chevron-down combobox-icon" :class="{'active':isHideIconUp}"></i>
            <i class="fas fa-chevron-up dropup-icon " :class="{'active':isHideIconDown}"></i>
            <ul class="combobox-list" :class="{'active':isHide}">
                <li class="combobox-list__item combobox-list__item-focus" v-on:click="showItemListCBB(combobox[0],0)">
                    <i class="fas fa-check"></i>
                    <span>
                        {{combobox[0]}}
                    </span>
                </li>
                <li class="combobox-list__item" v-for="(itemComBoBox, indexItem) in combobox[1]" :key="itemComBoBox[arrayApi[index] +'Ip']" 
                        v-on:click="showItemListCBB(itemComBoBox[arrayApi[index]+'Name'],indexItem+1)">
                    <i class="fas fa-check"></i>
                    <span>
                    {{itemComBoBox[arrayApi[index]+'Name']}}
                    </span>
                </li>
            </ul>
        </div>
    </div>
</template>


<script>
import axios from 'axios'

export default {
    name : "ComBoBox",
    methods: {
        // click ẩn hiện danh sách combobox và icon
        cbbOnClick(){
            this.isHide = true
            this.isHideIconUp = true
            this.isHideIconDown = false
        },

        // Hiển thị tên phòng trên input
        showItemListCBB(comBoBoxName,index){
            this.comBoBoxName = comBoBoxName
            document.querySelector('.combobox-list__item.combobox-list__item-focus').classList.remove('combobox-list__item-focus')
            document.querySelectorAll('.combobox-list__item')[index].classList.add('combobox-list__item-focus')
            
        }
    },
    // Gọi Api lấy dữ 
    mounted() {
        // // Gọi Api lấy dữ liệu phòng ban
        // this.departments = this.getData('api/Department')


        // // Gọi Api lấy dữ liệu vị trí
        // this.positions = this.getData('v1/Positions')

        var _this = this

        // // // Gọi Api lấy dữ liệu phòng ban
        axios.get(`http://cukcuk.manhnv.net/api/Department`).then((res) => {
                 _this.baseComBoBox[0][1]= res.data
                 _this.departments = res.data
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

        // // // Gọi Api lấy dữ liệu vị trí
        axios.get(`http://cukcuk.manhnv.net/v1/Positions`).then((res) => {
                 _this.baseComBoBox[1][1]= res.data
                 _this.positions = res.data
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

    data() {
        return {
            isHide : false,
            isHideIconUp : false,
            isHideIconDown : true,

            // Lấy danh sách các phòng
            departments : {},
            // Lấy tên từng phòng
            comBoBoxName : '',

            // Lấy danh sách các phòng
            positions : {},
            // Lấy tên từng phòng
            PositionName : '',


            // mảng chứa đuôi api để lấy ra các value trong các combobox tương sứng với thứ tự baseComBoBOX
            arrayApi  : ['Department','Position'],
            // mảng chứa các combobox cần xử lý
            baseComBoBox : [
                ['Tất cả phòng ban',this.departments],
                ['Tất cả các vị trí',this.positions]
            ],


            // getData : function(url){
            //     var object = {}
            //     axios.get(`http://cukcuk.manhnv.net/${url}`).then((res) => {

            //             object = res.data
            //             return object
            //         }).catch(error =>{
            //                     switch (error.status) {
            //                         case 500:
            //                             console.log('Có lỗi từ server, vui lòng thử lại');
            //                             break;
            //                         case 400:
            //                             console.log('Dữ liệu không hợp lệ');
            //                             break;
            //                         default:
            //                             break;
            //                     }
            //                 })
            // }
        }
    },
}




// author : PVM.Quân
</script>

<style scoped>
@import url('../../assets/css/layout/Content.css');
</style>