<template>
     <div class="content-table">
                    <table >
                        <thead>
                            <tr>
                                <th > </th> 
                                <th :class='item[checkclass]' 
                                    :prop-name='item[propname]' 
                                    v-for="item in arrayTH" :key="item[id]">{{item[name]}}
                                </th>
                            
                            </tr>
                        </thead>
                        <tbody class="staffTable"> 
                                <tr v-for="(value,index) in options" :key="value[id]" @dblclick="trDbOnClick(value[id],index)" :id=id :ref="value[id]">
                                    <td  > <input type="checkbox"  :value=value[id] v-model="checkedId" @change="selectRow(value[id])"></td>  
                                    <td  v-for="td in arrayTH" :key="value[td[id]]" 
                                        :format='td[format]'
                                        :id='[id]' 
                                        :class='td[checkclass]'>{{formatTH(td[format],value[td[propname]])}}</td> 
                                </tr>
                        </tbody>
                    </table>
                </div>
</template>


<script>
import Format from '../../untils/Format.js'
import $ from 'jquery'
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
        }
    },
    methods: {
        selectRow(val) {
            this.$refs[`${val}`][0].classList.add('checked')
            if(this.checkedId.length == 0){
                this.$refs[`${val}`][0].classList.remove('checked')
            }else{
                this.checkedId.forEach(item=>{
                    if(val == item){
                        this.$refs[`${val}`][0].classList.add('checked')
                    }else{
                         this.$refs[`${val}`][0].classList.remove('checked')
                    }
                })
            }
        },
        /**
         * Xử lý khi click vào các tr   
         * PVM.Quân (29/07/2021)
         */
        trDbOnClick(id,index){
            this.$emit('trDbOnClick',id,index)
            document.querySelectorAll('tbody tr')[index].classList.add('focus')
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
                       
                    default:
                        return value
                    }
        },
    },

    data() {
        return {
            arrayTdHTML : [],
            checkedId: [],
            checkNum : 0,
        }
    },
    watch: {
        /**
         * Tìm kiếm theo phòng ban và vị trí
         * creatBy : PVM.Quân (07/08/2021)
         */
        value : function(){
            var _this = this
            if(this.dataValue[0]!= null && this.dataValue[1]==null){
                $('.staffTable tr').filter(function() {
                    $(this).toggle($(this).text().toLowerCase().indexOf(_this.dataValue[0].toLowerCase())>-1)})
            }
            else if(this.dataValue[1]!= null && this.dataValue[0]==null){
                $('.staffTable tr').filter(function() {
                    $(this).toggle($(this).text().toLowerCase().indexOf(_this.dataValue[1].toLowerCase())>-1)})
            }
            else{
                $('.staffTable tr').filter(function() {
                        $(this).toggle($(this).text().toLowerCase().indexOf(_this.dataValue[0].toLowerCase())>-1
                        && $(this).text().toLowerCase().indexOf(_this.dataValue[1].toLowerCase())>-1);
                     });
            }
        },
        /**
         * Gửi các tr được check để xóa lên cha và hiện background khi được check
         * PVM.Quân (29/07/2021)
         */
        checkedId: function() {
            this.$emit('sendDeleteList', this.checkedId);
        },

        deleteList : function(){
            this.checkedId = this.deleteList
        }
    },
    
}
</script>

<style scoped>
@import url('../../assets/css/base/Table.css');
</style>