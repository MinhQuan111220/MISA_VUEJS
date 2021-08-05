class Vadilator{
    constructor(){

    }

    /**
     * Xét thẻ div chứa các input cần submit
     * @param {*} options 
     */
     Vadilator(options){
        var formElement = document.querySelector(options.form)
        var selectorRules={}
        function getParent(element,selector){
            while(element.parentElement){
                if(element.parentElement.matches(selector)){
                    return element.parentElement
                }
                element = element.parentElement
            }
        }
        function validate(inputelement,rule){
            var errorElement = getParent(inputelement,options.formGroupSelector).querySelector(options.errorSelector)
     
            var errorMesage
             // Lay ra cac rules cua selelec tor
             var rules= selectorRules[rule.selector]
             for(var i=0;i<rules.length;i++){
                 switch(inputelement.type){
                     case 'radio':
                     case 'checkbox':
                         errorMesage = rules[i](
                             formElement.querySelector(rule.selector + ':checked')
                         )
                         break
                     default:
                         errorMesage = rules[i](inputelement.value)
                 }
                
                 if(errorMesage) break
             }
             if(errorMesage){
                 errorElement.innerText = errorMesage
                 getParent(inputelement,options.formGroupSelector).classList.add('invalid')
              }
             else{
                 errorElement.innerText= ''
                 getParent(inputelement,options.formGroupSelector).classList.remove('invalid')
             }
             return !errorMesage
        }
     
     
     
     
         if(formElement){
            options.rules.forEach(function(rule){
                // Luu lai cac rule
                if(Array.isArray(selectorRules[rule.selector])){
                    selectorRules[rule.selector].push(rule.test)
                }else{
                    selectorRules[rule.selector]=[rule.test]
                }
                var inputelements= formElement.querySelectorAll(rule.selector)
                Array.from(inputelements).forEach(inputelement=>{
                    if(inputelement){
                        inputelement.onblur=function(){
                            validate(inputelement,rule)
    
                        }
                        // khi go vao
                        inputelement.oninput = function(){
                            var errorElement = getParent(inputelement,options.formGroupSelector).querySelector(options.errorSelector)
                            errorElement.innerHTML= ''
    
                            getParent(inputelement,options.formGroupSelector).classList.remove('invalid')
                        }
                    }
                })
                
            })
            document.querySelector(options.submitBtn).onclick= function(e){
                e.preventDefault()
    
                var isFromValid= true;
                options.rules.forEach(function(rule){
                    var inputelement= formElement.querySelector(rule.selector)
                    var isValid = validate(inputelement,rule)
                    if(!isValid){
                        isFromValid=false
                    }
                })
                if(isFromValid){
                    if(typeof options.onSubmit === 'function'){
                        
                        options.onSubmit()
                    }
                    // truong hop submit vs hanh vi mac dinh
                    else{
                        formElement.submit()
                    }
                }
            }
         }
     }

 /**
  * In ra cảnh báo khi input để trống 
  * @param {*} selector 
  * @returns 
  * creatBy : PVM.Quân(04/08/2021)
  */
isRequired = function(selector){
     return{
     selector : selector,
     test: function(values){
         return values ? undefined: 'Vui lòng nhập trường này '
     }
     }
 }


/**
  * In ra cảnh báo khi bị trùng mã nhân viên 
  * @param {*} selector 
  * @returns 
  * creatBy : PVM.Quân(04/08/2021)
  */
EmployeeCode = function(selector,Code){
     return {
        selector: selector,
        test: function(value){
            return value !== Code() ?  undefined : 'Mã nhân viên đã tồn tại rồi'
        }
    }
 }

/**
  * In ra cảnh báo khi bị trùng cmt
  * @param {*} selector 
  * @returns 
  * creatBy : PVM.Quân(04/08/2021)
  */
IdentityNumber = function(selector,IdentityNumber){
    return {
       selector: selector,
       test: function(value){
           return value !== IdentityNumber() ?  undefined : 'Chứng minh thư đã tồn tại rồi'
       }
   }
}

/**
  * Bắt buộc phải là email 
  * @param {*} selector 
  * @returns 
  * creatBy : PVM.Quân(04/08/2021)
  */

isEmail = function(selector){
    return{
    selector : selector,
    test: function(values){
        var regex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
        return regex.test(values) ? undefined: 'Trường này phải là email'
    }
    }
}

}
export default new Vadilator()