<template>
    <div class="page" :class="{'active':isActive}">
        <EmployeeList />
    </div>
</template>

<script>

import EmployeeList from '../../view/employees/EmployeesList.vue'

export default {
    name : "TheConTent",
    components :{EmployeeList},
    props :{
        isActive : {
            type : Boolean,
            default : true,
        }
    }
}
</script>

<style scoped>
@import url('../../assets/css/layout/Content.css');
</style>