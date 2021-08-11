/**
 * Class xử lý những sự kiện chung bằng js trong vue
 * creatBy : PVM.Quân (06/08/2021)
 */
import $ from 'jquery'
class HendalEvent{
    constructor(){
       
    }

    /**
     * Xử lý sự kiên keydown trong input cho các dropdown,combobox
     * @param {*} input  // lấy ô input cần keydown
     * @param {*} list // lấy ra danh sách các phần tử dropdown,combobox
     * @param {*} itemfocus // lấy ra  phần tử dropdown,combobox đã được focus trc đó
     * @param {*} label
     * creatBy : PVM.Quân (06/08/2021)
     */

     keyDownInput(input,listId,listClass,focus,values){
        var index= 0;
        var arrayKeydown = []
        $(`.${input}`).on('keydown',function(e){
            var value = document.querySelector(`.${input}`).value.toLowerCase();
            arrayKeydown = $(`#${listId}.${listClass}`).filter(function() {
                return this.innerText.toLowerCase().indexOf(value) > -1
            });
        
        if (e.keyCode == 40) {
            index ++
            if(index >=arrayKeydown.length){
                index = 0;
            }
            document.querySelector(`#${listId}.${focus}`).classList.remove(`${focus}`)
            arrayKeydown[index].classList.add(`${focus}`)
        }
        else if (e.keyCode == 38) {
            index--
            if(index <0){
                index = arrayKeydown.length-1;
            }
            document.querySelector(`#${listId}.${focus}`).classList.remove(`${focus}`)
            arrayKeydown[index].classList.add(`${focus}`)
        }  
        else if(e.keyCode ==13){
            if(arrayKeydown[index].innerText.toLowerCase() === values.toLowerCase()){
                return ""
            }
            else{
                return arrayKeydown[index].innerText
            }
            
        }
        })
    }
}

export default new HendalEvent()