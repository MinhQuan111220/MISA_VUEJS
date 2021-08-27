/**
 * File xử lý các kiểu định dạng
 * creatBy : PVM.Quân(29/07/2021)
 */



class Format{
    
    constructor(){
       
    }


    
    
    /**
     * Xử lý hiển thị ngày tháng
     * creatBy : PVM.Quân(29/07/2021)
     */
     formatDate(dateformat){
        var date = new Date(dateformat);
            var day = date.getDate(),
            month = date.getMonth() +1,
            year = date.getFullYear();
            
            day = day<10 ? '0'+day : day
            month = month<10 ? '0'+month : month
            return day + '/'+month+'/'+year
    }
     /**
     * Format vao modal
     * creatBy : PVM.Quân(29/07/2021)
     */
    formatDateToModal(dateformat){
        var date = new Date(dateformat);
            var day = date.getDate(),
            month = date.getMonth() +1,
            year = date.getFullYear();
            
            day = day<10 ? '0'+day : day
            month = month<10 ? '0'+month : month
            return year + '-'+month+'-'+day
    }
    /**
     * Xử lý hiển thị tiền trong table
     * creatBy : PVM.Quân(29/07/2021)
     */
     formatMoney(money){
        if(money === null){
            return ''
        }
        else{
            var num = money.toFixed().replace(/(\d)(?=(\d\d\d)+(?!\d))/g,"$1.")
            return num
        }
    }
    
    /**
     * Xử lý khi string rỗng thì ẩn di
     * creatBy : PVM.Quân(29/07/2021)
     */
     formatNull(value){
        if(value == 'null'.toLowerCase() || value == undefined){
            return ''
        }
        else return value
    }
    
    /**
     * Xử lý khi các phần tử trong mảng bị trùng
     * creatBy : PVM.Quân(29/07/2021)
     */
    
     listArray(arr){
        let isExist = (arr, x) => arr.indexOf(x) > -1;
        let ans = [];
    
        arr.forEach(element => {
            if(element !==''){
                if(!isExist(ans, element)) ans.push(element);
            }
        });
    
        return ans;
    }
    /**
     * Hàm định dạng tiền khi nhập vào input
     * creatBy : PVM.Quân(29/07/2021)
     */
    salaryFormat(salary) {
        var result = '';
        var number 
        if (salary != null) {
            for (var i = String(salary).length; i > 0; i = i - 3) {
                if (i > 3) {
                     number = String(salary).slice(i - 3, i);
                    result += number.split("").reverse().join("") + ".";
                } else {
                     number = String(salary).slice(0, i);
                    result += number.split("").reverse().join("");
                }
            }
            return result.split("").reverse().join("");
        } else return '';
    }

    /**
     * Hàm định dạng trang thái công việc
     * creatBy : PVM.Quân(29/07/2021)
     */
    workStatusFormat(value){
        if(value == 1){
            return 'Đang làm việc' 
        }else if(value == 0){
            return 'Đã nghỉ việc'
        }else{
            return ''
        }
    }

    /**
     * Hàm kiểm tra tồn tại trong mảng
     */
    itemExist(array,item){
        if(array.include(item)==true){
            return true;
        }
        return false;
    }
    /**
     * Hàm kiểm tra email
     */
    isEmail(value){
        var regex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
        if(regex.test(value)){
            return true;
        }
        return false;
    }
    /**
     * Hàm kiểm tra chỉ chứa chữ số 
     */
    isNumber(value){
        var number='';
        if(value.length > 3){
            for(var i = 0 ;i<value.length;i++){
                if(value[i] != '.'){
                    number +=value[i]
                }
            }
        }else{
            number = value
        }
         var regex = /^[0-9]*$/
         if(regex.test(number)){
            return true;
        }
        return false;
    }
}


export default new Format()