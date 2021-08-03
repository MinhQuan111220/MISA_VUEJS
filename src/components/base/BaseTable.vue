<template>
     <div class="content-table">
                    <table >
                        <thead>
                            <tr>
                                <th > </th>
                                <!-- <th :prop-name='item[propname]' v-for="item in options" :key="item">{{item[name]}}</th> -->
                                <th :class='item[checkclass]' 
                                    :prop-name='item[propname]' 
                                    v-for="item in arrayTH" :key="item[id]">{{item[name]}}
                                </th>
                                
                            </tr>
                        </thead>
                        <tbody class="staffTable"> 
                                <tr v-for="value in options" :key="value[id]" @dblclick="trDbOnClick(value[id])">
                                    <td  > <input type="checkbox"  :value=value[id] v-model="checkedId"></td>  
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

export default {
    name : 'Table',

    props :{
        /**
         * Khởi tạo các giá trị có thể sử dụng lại từ cha
         * PVM.Quân (29/07/2021)
         */
        arrayTH : {
            type : [Array,Object],
            requied: true,
        },

        // mảng chứa dữ liệu api về
        options : {
            type : [Array,Object],
            requied: true,
        },

        id : {
            type: String,
            requied: true,
        },
        propname : {
            type: String,
            requied: true,
        },
        name : {
            type: String,
            requied: true,
        },
        checkclass :{
            type: String,
            requied: true,
        },
        format :{
            type: String,
            requied: true,
        }
    },
    methods: {

        /**
         * Xử lý khi click vào các tr
         * PVM.Quân (29/07/2021)
         */
        trDbOnClick(id){
            this.$emit('trDbOnClick',id)
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
        }
    },
    watch: {
        checkedId: function() {
            this.$emit('sendDeleteList', this.checkedId); // thang cha thg nay la thg nao
        }
    },
    data() {
        return {
            arrayTdHTML : [],
            checkedId: []
        }
    },
}
</script>

<style scoped>
@import url('../../assets/css/base/Table.css');
</style>