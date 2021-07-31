<template>
    <div class="form-warning" :class="{'active':isHidePopUp}">
            <div class="form-warning__delete" >
                <img src="../../../assets/icon/x.svg" alt="" class="form-warning__delete-exit" @click="btnCancel">
                <h3 class="title2 form-warning__delete-header">Xóa  nhân viên</h3>
                <div class="form-warning__delete-content">
                    <div class="form-warning__delete-icon">
                        <i class="fas fa-exclamation-triangle"></i>
                    </div>
                    <h3 class="lable">Bạn có chắc chắn muốn xóa nhân viên 
                        ra khỏi danh sách không ? Xóa là sẽ không khôi phục lại được !
                    </h3>
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
import axios from 'axios'
export default {
    name : "EmployeePopUp",
    props :{
        isHidePopUp : {
            type : Boolean,
            default : true,
            required : true,
        },
    },
    methods: {
        btnCancel (){
            this.$emit('btnDeleteOnclick',true)
            console.log(this.employeesPopUp)
        },

        // Khi xóa vĩnh viễn thông tin nhân viên
        btnDeleteOnClick(){
            document.querySelectorAll('tbody tr td input:checked').forEach((item,index)=>{
                this.delete(item.value)
                if(index == document.querySelectorAll('tbody tr td input:checked').length-1){
                    alert('Xóa thành công')
                }
            this.$emit('btnDeleteOnclick',true)
            })
        }, 
    },

    data() {
        return {
            // Gọi Api để xóa
            delete : function(id){
                axios.delete(`http://cukcuk.manhnv.net/v1/Employees/${id}`)
                    .then(() => {
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
            employees : {},
        }
    },
    
}

</script>

<style scoped>
@import url('../../../assets/css/form/FormWarning.css');
</style>