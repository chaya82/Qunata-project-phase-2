<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="Quanta.Account.Verification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head>

  <meta charset="UTF-8">
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no" name="viewport">
  <title>Quanta</title>
  <!-- General CSS Files -->
  <link rel="stylesheet" href="/assets/css/app.min.css">
  <link rel="stylesheet" href="/assets/bundles/bootstrap-social/bootstrap-social.css">
  <!-- Template CSS -->
  <link rel="stylesheet" href="/assets/css/style.css">
  <link rel="stylesheet" href="/assets/css/components.css">
  <!-- Custom style CSS -->
  
  <link rel='shortcut icon' type='image/x-icon' href='/assets/img/favicon.ico' />
<style>
.dark{background: linear-gradient(to bottom, rgba(0,0,0,0.7) 0%, rgba(0,0,0,0.7) 100%),url(/assets/img/auth-background-image.jpg);}.dark .card{border:0;background-color:#11151e;color:#96a2b4}
.card {
    background-color: #fff !important;
    }
.form-control, .input-group-text, .custom-select, .custom-file-label {
    background-color: #fdfdff !important;}
.dark .card .card-header {
    border-bottom-color: #fff!important;
}
.dark .form-group>label {
    color: #34395e;
}
.text-muted {
    color: #6c757d !important;
}
.theme-coral a {
    color: #ff470f;
}

</style>
</head>

<body>
    <form id="form1" runat="server">
     <div class="loader"></div>
  <div id="app">
    <section class="section">
      <div class="container mt-3">
        <div class="row">
          <div class="col-12 col-sm-8 offset-sm-2 col-md-6 offset-md-3 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4">
          <div class="login-brand login-brand-color">
            	QUANTA
            </div>
            <div class="card">
              <div class="card-header card-header-auth">
                <h4>User Verification</h4>
              </div>
              <!-- <center>
              <div class="logo-auth">
              	<img alt="image" src="assets/img/logo.png" />
          	  </div>
          	  <div>
          	  	<span class="logo-name-auth">Grexa</span>
          	  </div>
          	  </center> -->
              <div class="card-body">
                <p class="text-muted">We have sent a verification link to your registered email id. Click on the link to confirm your email address and activate your account.</p>
               
                
                  <div class="form-group">
                   
                    <p class="text-muted">If you have not received the mail, click 'resend' after <span id="spnTm">120</span> Seconds.</p>
                  <asp:Button ID="btnresend" runat="server" Text="Resend" CssClass="btn btn-lg btn-block btn-auth-color"
                Style="display: none" OnClick="btnresend_Click" OnClientClick='javascript:$("#btnresend").attr("style", "display:none");' />
                 
                  </div>
               
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    
  </div>
  <!-- General JS Scripts -->
  <script src="/assets/js/app.min.js"></script>
  <!-- JS Libraies -->
  <!-- Page Specific JS File -->
  <!-- Template JS File -->
  <script src="/assets/js/scripts.js"></script>
  <script>
      var myvar;
      var z = document.getElementById('spnTm').innerHTML;
      function resendActiveTime() {
          if (z >= 0) {
              document.getElementById('spnTm').innerHTML = parseInt(z);
              z = parseInt(z) - 1
          }
          else {
              $('#btnresend').attr("style", "display:block");
              clearInterval(myVar)
          }

      }

      $(document).ready(function () {
          myvar = setInterval(resendActiveTime, 1000)
      })
    </script>
    </form>
</body>
</html>
