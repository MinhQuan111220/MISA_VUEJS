<template>
    <div id="pop-up-delete" class="pop-up" :class="{'show':isHidePopUp}">
            <div class="pop-up-content" >
                <button id="close-popup-delete" class="popup-close-btn" @click="btnCancel">
                        <img
                            src="../../assets/icon/x.svg"
                            alt=""
                            class="img-exit"
                            @click="btnCancel"
                        />
                </button>
                <div class="pop-up-info">
                <div class="pop-up-title">Xóa nhân viên</div>
                <div class="popup-icon-description">
                    <div class="pop-up-icon">
                        <i class="fas fa-exclamation-triangle"></i>
                    </div>
                    <div class="pop-up-description">
                        <span>{{value}}</span>
                    </div>
                </div>
            </div>
                <div class="div-btn">
                    <div class="button button-cancel" @click="btnCancel">
                        Hủy
                    </div>
                    <button class="button button-deletepopup" id="button-delete" @click="btnDeleteOnClick">
                        Xóa
                    </button>
                </div>
            </div>
    </div>
   
</template>


<script>
import EmployeesAPI from "../../api/components/EmployeesApi";




export default {
    name : "PopUp",
    props :{
        isHidePopUp : {
            type : Boolean,
            default : true,
            required : true,
        },
        deleteList :{
            type : Array,
            required : true,
        },
    },
    methods: {
        /**
         * Xử lý khi thoát khỏi PopUp
         * PVM.Quân (29/07/2021)
         */
        btnCancel (){
            this.$emit('btnDeleteOnclick',true)
        },

        /**
         * Xử lý khi xóa vĩnh viễn thông tin nhân viên
         * PVM.Quân (29/07/2021)
         */
        btnDeleteOnClick(){
            var _this = this
            _this.$emit('btnConfirmDelete',true)
            if(this.deleteList.length==1){
                 EmployeesAPI.delete(this.deleteList[0]).then(() => {
                         _this.$emit("refeshData")
                       
                    }).catch(error =>{
                        _this.$emit("deleteFail",error)
                    })
            }else{
                
               var lisId = []
               this.deleteList.forEach((id,index)=>{
                   lisId[index]=id
               })
                 EmployeesAPI.deleteListId(JSON.stringify(lisId)).then(() => {
                         _this.$emit("refeshData")
                       
                    }).catch(error =>{
                        _this.$emit("deleteFail",error)
                    })
                // console.log(lisId)
            }
            this.$emit('btnDeleteOnclick',true) 
        }, 
    },

    data() {
        return {
            employees : {},
            isShowToast : '',
            lable : '',
            isSuccess : '',
            isWarning :'',
            value : '',
        }
    },

    watch : {
        deleteList : function(){
            if(this.deleteList.length == 1){
                var _this = this;
                EmployeesAPI.get(_this.deleteList[0])
                    .then((res) => {
                        _this.value = `Bạn có chắc chắn muốn xóa nhân viên " ${res.data.FullName.toUpperCase()} " có mã nhân viên " ${res.data.EmployeeCode.toUpperCase()} " ra khỏi danh sách không ? Xóa là sẽ không khôi phục lại được !`
                    })
                    .catch((error) => {
                    _this.consoleError(error.response.status);
                    });
            }else{
                this.value = 'Bạn có chắc chắn muốn xóa nhân viên ra khỏi danh sách không ? Xóa là sẽ không khôi phục lại được !'
            }
        }
    }
    
}

</script>

<style scoped>
@import url('../../assets/css/form/FormWarning.css');
</style>