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
}


export default new Format()