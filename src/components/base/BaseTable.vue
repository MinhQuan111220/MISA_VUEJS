<template>
    <div> 
        <div class="content-table">
                    <table >
                        <thead>
                            <tr>
                                <th class="check"> <input type="checkbox" @click="btnDeleteAllOnClick" ref="deleteAll"> </th> 
                                <th class="stt between">#</th> 
                                <th :class='item[checkclass]' 
                                    :prop-name='item[propname]' 
                                    v-for="item in arrayTH" :key="item[id]">{{item[name]}}
                                </th>
                            
                            </tr>
                        </thead>
                        <tbody class="staffTable"> 
                                <tr v-for="(value,index) in options" :key="value[id]" 
                                @dblclick="trDbOnClick(value[id],index)" 
                                :id=id 
                                :class="[itemExist(checkedId,value[id]) == true ? 'checked' : '' 
                                ,isdbClick == true && index ==indexFocus ? 'focus' : '']"
                                >
                                    <td  class="check"> <input type="checkbox"  :value=value[id] v-model="checkedId" @change="itemExist(checkedId,value[id])"></td>
                                    <td class="stt between">{{index+1+(pageSize*(pageIndex-1))}}</td>   
                                    <td  v-for="td in arrayTH" :key="value[td[id]]" 
                                        :format='td[format]'
                                        :id='[id]' 
                                        :class='td[checkclass]'>{{formatTH(td[format],value[td[propname]])}}</td> 
                                </tr>
                        </tbody>
                    </table>
             
        </div>
        <div class="content__pagination">
                    <div class="show-number__person">Hiển thị <span>{{this.totalPage > 0 ?(this.pageSize*(this.pageIndex-1)+1) : 0}}-{{this.pageSize*(this.pageIndex)>this.totalRecord?this.totalRecord : this.pageSize*(this.pageIndex)}}/{{this.totalRecord}}</span> nhân viên</div>
                    <div class='pagination-item'>
                        <div class="content__pagination-icon" :class="{'active':isHide}" @click="btnFirstPage">
                            <img src="../../assets/icon/btn-firstpage.svg" alt="">
                        </div>
                        <div class="content__pagination-icon" @click="btnBackOnePage">
                            <img src="../../assets/icon/btn-prev-page.svg" alt="">
                        </div>
                        <ul class="content__pagination-button">
                                <li class="content__pagination-numbers" v-for="int in sumPage" :key="int" :class="int<pageIndex&&int<=(sumPage-4) ?'active' : ''" >
                                     <div 
                                        :class="int==pageIndex ?'focus' : ''" 
                                        class="content__pagination-numbers-item " 
                                        @click="btnClick(int)">{{int}}
                                    </div>
                                </li>
                                
                        </ul>
                        <div class="content__pagination-icon" @click="btnNextOnePage">
                            <img src="../../assets/icon/btn-next-page.svg" alt="">
                        </div>
                        <div class="content__pagination-icon" @click="btnLastPage">
                            <img src="../../assets/icon/btn-lastpage.svg" alt="">
                        </div>
                    </div>
                    <div class="content__pagination-numbershowed">
                        <select v-model="pageSize">
                            <option>20</option>
                            <option>30</option>
                            <option>40</option>
                            <option>500</option>
                            <option>{{totalRecord}}</option>
                        </select> nhân viên/trang 
                    </div>
                </div>
    </div>      
</template>


<script>
import Format from '../../untils/Format.js'

export default {
    name : 'Table',

    props :{
        /**
         * Mảng chứa dữ liệu th Api về
         * PVM.Quân (29/07/2021)
         */
        arrayTH : {
            type : [Array,Object],
            requied: true,
        },

        /**
         * mảng chứa dữ liệu tr Api về
         * PVM.Quân (29/07/2021)
         */
        options : {
            type : [Array,Object],
            requied: true,
        },

        /**
         * Lấy tên id
         * PVM.Quân (29/07/2021)
         */
        id : {
            type: String,
            requied: true,
        },
        /**
         * Lấy các prop-name cho th
         * PVM.Quân (29/07/2021)
         */
        propname : {
            type: String,
            requied: true,
        },
        /**
         * Hiển thị tên cho các th
         * PVM.Quân (29/07/2021)
         */
        name : {
            type: String,
            requied: true,
        },
        /**
         * Check xem có tr,th nào cần căn giữa,phải hay không
         * PVM.Quân (29/07/2021)
         */
        checkclass :{
            type: String,
            requied: true,
        },
         /**
         * tên mã 
         * PVM.Quân (29/07/2021)
         */
        code : {
            type: String,
            requied: true,
        },
        /**
         * Lấy các định dạng dữ liệu cho table
         * PVM.Quân (29/07/2021)
         */
        format :{
            type: String,
            requied: true,
        },
        /**
         * Lấy value để thực hiện tìm kiếm
         */
        dataValue :{
            type : Array,
            requied : true,
        },
        /**
         * Lấy value để thực hiện tìm kiếm
         */
        value :{
            type : String,
            requied : true,
        },
        /**
         * Danh sách các tr bị xóa
         */
        deleteList : {
            type : Array,
            requied : true,
        },
        /**
         * Vị trí tr dbClick
         */
        indexTrdbClick : {
            type : Number,
            requied : true,
        },
        totalRecord : {
            type : Number,
            requied : true,
        },
        totalPage : {
            type : Number,
            requied : true,
        }
    },
    methods: {
        /**
         * Chuyển background tr khi checked
         * * PVM.Quân (29/07/2021)
         */
        itemExist(array,item){
        var check = false;
           if(array.length > 0){
               for(let i = 0 ;i < array.length ; i++){
                   if(array[i]==item){
                       check = true
                   }
               }
           }
           return check
        },
        /**
         * Xử lý khi click vào các tr   
         * PVM.Quân (29/07/2021)
         */
        trDbOnClick(id,index){
            this.$emit('trDbOnClick',id,index)
            this.isdbClick = true
            this.indexFocus = index
        },
        /**
         * Xử lý định dạng các thành phần
         * PVM.Quân (29/07/2021)
         */
        formatTH(format,value){
            switch (format) {
                    case 'date':
                        return Format.formatDate(value)
                       
                    case '$':
                        return Format.formatMoney(value)
                    case 'status':
                        return Format.workStatusFormat(value)
                    default:
                        return value
                    }
        },
        /**
         * Khi chọn checked tất cả của 1 trang
         */
        btnDeleteAllOnClick(){
            var _this = this
            this.index ++
            if(this.index == 1){
                this.options.forEach((item)=>{
                    this.deleteList.push(item[_this.id])
                })
            }else{
                this.index = 0
                this.$emit('removebtnCheckAll')
            }
            
        },
        /**
         * Click vào từng trang hiển thị tr
         */
        btnClick(index){
            this.pageIndex = index
        },
        // /**
        //  * Khi tăng 1 page
        //  */
        btnNextOnePage(){
            this.pageIndex ++
            if(this.pageIndex > this.sumPage){
                this.pageIndex = 1
            }
        },
        // /**
        //  * Khi quay lại 1 page
        //  */
        btnBackOnePage(){
        this.pageIndex --
            if(this.pageIndex == 0){
                this.pageIndex = this.sumPage
            }
        },
        // /**
        //  * Click đến trang cuối
        //  */
        btnLastPage(){
            this.pageIndex = this.sumPage
        },
        // /**
        //  * Click đến trang đầu
        //  */
        btnFirstPage(){
            this.pageIndex = 1
        },
        
    },

    data() {
        return {
            arrayTdHTML : [],
            checkedId: [],
            checkNum : 0,
            intPagination : 0,
            index : 0,
            isHide : false,
            indexChecked : -1,
            isdbClick : false,
            indexFocus : -1,
            pageSize : 20,
            pageIndex : 1,
            sumPage : 0,
        }
    },
    watch: {
        
        /**
         * Gửi các tr được check để xóa lên cha và hiện background khi được check
         * PVM.Quân (29/07/2021)
         */
        checkedId: function() {
            this.$emit('sendDeleteList', this.checkedId);

            console.log(this.checkedId)
        },

        deleteList : function(){
            this.checkedId = this.deleteList
        },

        // /**
        //  * Ẩn background tr khi hủy 
        //  */
        indexTrdbClick : function(){
            this.indexFocus = this.indexTrdbClick
        },
        
        pageSize : function(){
            this.$emit('filter',this.pageIndex,this.pageSize)
        },

        pageIndex : function(){
            this.$emit('filter',this.pageIndex,this.pageSize)

        },


        totalRecord : function(){
            if(this.totalRecord < this.pageSize || this.totalRecord == 0){
                this.pageIndex = 1
            } 
        },
        totalPage : function(){
            this.sumPage = this.totalPage>0 ? this.totalPage : 1
             if(this.pageIndex > this.totalPage){
                this.pageIndex = this.totalPage
            }
            if(this.totalPage == 0){
                this.pageIndex = 1
            }
        },
    },
    
}
</script>

<style scoped>
@import url('../../assets/css/base/Table.css');
</style>