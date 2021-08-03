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
        if(isNaN(date.getTime())){
            return " ";
        }
        else{
            var day = date.getDate(),
            month = date.getMonth() +1,
            year = date.getFullYear();
            
            day = day<10 ? '0'+day : day
            month = month<10 ? '0'+month : month
            return day + '/'+month+'/'+year
        }
    }
    
    /**
     * Xử lý hiển thị tiền
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
    
}


export default new Format()