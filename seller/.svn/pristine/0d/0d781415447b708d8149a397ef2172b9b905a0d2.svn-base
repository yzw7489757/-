$(function () { 
    inputctr.public.checkLogin();
    $.ajax({
        url: baseUrl + '/GetUserTax',
        method: 'post',
        dataType: "json",
        data: {
          userid: amazon_userid,
        },
        success: function (res) {
          console.log(res)
          if (res.result == 1) {
            var data = res.data;
            $('.company_name').text(decodeURIComponent(res.company_name));
            if(!data.country){
              $('.country').text('--')
            }else{
              $('.country').text(decodeURIComponent(data.country));
            };

            if(!data.address){
              $('.address').text('--')
            }else{
              $('.address').text(decodeURIComponent(data.address));
            };

            if(!data.address2){
              $('.address2').text('--')
            }else{
              $('.address2').text(decodeURIComponent(data.address2));
            };

            if(!data.city){
              $('.city').text('--')
            }else{
              $('.city').text(decodeURIComponent(data.city));
            };

            if(!data.province){
              $('.province').text('--')
            }else{
              $('.province').text(decodeURIComponent(data.province));
            };

            if(!data.zipcode){
              $('.zipcode').text('--')
            }else{
              $('.zipcode').text(decodeURIComponent(data.zipcode));
            };

            if(!data.fullname){
              $('.fullname').text('--')
            }else{
              $('.fullname').text(decodeURIComponent(data.full_name));
            };

            if(!data.phone){
              $('.phone').text('--')
            }else{
              $('.phone').text(decodeURIComponent(data.phone));
            };
            
            if(!data.email){
              $('.email').text('--')
            }else{
              $('.email').text(decodeURIComponent(data.email));
            }
            sessionStorage.setItem('tax_id',res.tax_id)
          }
        },
        error:function (res) { 
            console.log(decodeURIComponent(res.error))
         }
      })
    $('.goBack').click(function(){
      $(location).attr('href','/seller/account_information.html')
    })
 })