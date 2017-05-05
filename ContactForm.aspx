<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactForm.aspx.cs" Inherits="SongCatelogApp.ContactForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div class="messages"></div>
        <input type="hidden" name="hdncaptcha" id="hdncaptcha" value="">
        <input type="hidden" name="hdnusername" id="hdnusername" value="">
        
        <div class="controls">

            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="form_name">Name *</label>
                        <input type="text" name="fromname" id="fromname" class="form-control" placeholder="Please enter your firstname *" required="required" data-error="Firstname is required.">
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                                <div class="col-md-6">
                    <div class="form-group">
                        <label for="form_email">Email *</label>
                        <input  type="email" name="email" id="email" class="form-control" placeholder="Please enter your email *" required="required" data-error="Valid email is required.">
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="form_lastname">Subject *</label>
                        <input  type="text" name="subject" id="subject" class="form-control" placeholder="Please enter Subject *" required="required" data-error="Subject is required.">
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="form_message">Message *</label>
                        <textarea  name="message" class="form-control" id="message" placeholder="Message for me *" rows="4" required="required" data-error="Please,leave us a message."></textarea>
                        <div class="help-block with-errors"></div>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label" id="Label1">Captcha </label>
                        <label class="col-sm-3 control-label" id="captchaOperation"></label>
                        <div class="col-sm-2">
                            <input type="text" class="form-control" name="captcha" id="captcha" data-match="#hdncaptcha" required="required" data-match-error="Captcha Does not Match"/>
                            <div id="error" style="color:red;display:none;">Captcha Error</div>
                        </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <input type="button" class="btn btn-success btn-send" value="Send message" onclick="return sendMail();" />
                </div>
            </div>
           
        </div>
    </form>

  <script>
      function sendMail() {
          document.getElementById("error").style.display = "none";
          if (document.getElementById("hdncaptcha").value != document.getElementById("captcha").value) {
              document.getElementById("error").style.display = "block";
              return false;
          }
          else {
              var userid = getQueryVariableUserId();
              var fromname = document.getElementById("fromname").value;
              var email = document.getElementById("email").value;
              var subject = document.getElementById("subject").value;
              var message = document.getElementById("message").value;

              $.ajax({
                  type: "POST",
                  //url: "loadMoreNews",
                  data: JSON.stringify({ userid: userid, fromname: fromname, email: email, subject: subject, message: message }),
                  url: "/profileMethods.asmx/sendEmail",
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (data) {
                      $('#modal').modal.hide();
                  },
                  error: function (textStatus, errorThrown) {
                      $('#modal').modal.hide();
                  }
              });
          }
      }

          //$('#myModal').on('shown', function () {
          //    var val1 = randomNumber(1, 100);
          //    var val2 = randomNumber(1, 200);
          //    alert(val1);
          //    $('#captchaOperation').html([val1, '+', val2, '='].join(' '));
         
    
          //})
          //function randomNumber(min, max) {
          //    return Math.floor(Math.random() * (max - min + 1) + min);
          //};
      


  </script>

</body>
</html>
