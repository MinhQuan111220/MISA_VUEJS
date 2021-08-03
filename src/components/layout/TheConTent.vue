<template>
    <div class="page">
        <EmployeeList />
    </div>
</template>

<script>

import EmployeeList from '../../view/employees/EmployeesList.vue'

export default {
    name : "TheConTent",
    components :{EmployeeList},
}
</script>

<style scoped>
@import url('../../assets/css/layout/Content.css');
</style>