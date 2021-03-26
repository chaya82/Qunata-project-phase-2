<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verificationnew.aspx.cs" Inherits="Quanta.Account.Verificationnew" %>

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

<body  >
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
                <p class="text-muted">To verfiy your phone number kindly click on send OTP.</p>
                <div class="form-group">
                   
                    <p class="text-muted"><span id="spnTm" style="display:none" >If you have not received the OTP, click 'Resend OTP' </span> </p>
              
                 
                  </div>
               <div id="recaptcha-container"></div>
               <asp:Button ID="btnsendOTP" runat="server" Text="Send OTP"  Visible="false"
                      onclick="btnsendOTP_Click" /> 
    <button id="send" type="button" onclick="sendotp(<%= Session["Mobile"] %>);">Send OTP</button>
    
                <div id="verify"  style="display:none">
                    <input type="text" id="verificationCode" placeholder="Enter verification code" />
    <button type="button" onclick="codeverify();">Verify code</button>
    <button id="resend"  type="button" onclick="phoneAuth(<%= Session["Mobile"] %>);">Resend OTP</button>
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
  

    

<!-- The core Firebase JS SDK is always required and must be listed first -->
<script src="https://www.gstatic.com/firebasejs/6.0.2/firebase.js"></script>

<!-- TODO: Add SDKs for Firebase products that you want to use
     https://firebase.google.com/docs/web/setup#config-web-app -->

<script>
    // Your web app's Firebase configuration
    var firebaseConfig = {
        apiKey: "AIzaSyBIx4Co8RlAm1fdZF193ZSGH6x5bpd6IzM",
        authDomain: "sms-auth-45d3b.firebaseapp.com",
        databaseURL: "https://sms-auth-45d3b.firebaseio.com",
        projectId: "sms-auth-45d3b",
        storageBucket: "sms-auth-45d3b.appspot.com",
        messagingSenderId: "486512649363",
        appId: "1:486512649363:web:2f48f895de560821be5966",
        measurementId: "G-F22PRX7ZFW"
    };
    // Initialize Firebase
    firebase.initializeApp(firebaseConfig);
</script>
<script type="text/javascript">
    function sendotp(number) {

        phoneAuth(number)
        document.getElementById("send").style.display = "none";
        document.getElementById("spnTm").style.display = "block";
      
        document.getElementById("verify").style.display = "block";
    }
</script>
<script src="../js/NumberAuthentication.js"  type="text/javascript"></script>

    </form>
</body>
</html>
