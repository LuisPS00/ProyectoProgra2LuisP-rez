<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoProgramaciónLuisPérez.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="fonts/icomoon/style.css">

    <link rel="stylesheet" href="css/owl.carousel.min.css">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.min.css">

    <!-- Style -->
    <link rel="stylesheet" href="css/style.css">
</head>
<body>
    <body>
    <div class="d-lg-flex half">
        <div class="bg order-1 order-md-2" style="background-image: url('images/XXVSE2YGJJAAVH5FOH73VPATNA.jpg');"></div>
        <div class="contents order-2 order-md-1">

            <div class="container">
                <div class="row align-items-center justify-content-center">
                    <div class="col-md-7">
                        <h3>Iniciar Sesion <strong>Gimnasio UH</strong></h3>
                       <p class="mb-4">BIENVENIDO AL GIMNASIO UH, DONDE SE PONDRÁ MÁS DURO QUE CRISTIANO RONALDO.</p>
                        <form action="#" method="post" runat="server">
                            <div class="form-group first">
                                <label for="username">Email</label>
                                
                                <asp:TextBox ID="Tusuario" class="form-control" placeholder="Ingrese su email." runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group last mb-3">
                                <label for="password">Clave</label>
                                
                                <asp:TextBox ID="Tcontraseña" class="form-control" placeholder="Ingrese la clave." runat="server"></asp:TextBox>
                            </div>

                            

                            
                            <asp:Button ID="BIngresar" class="btn btn-block btn-primary" runat="server" Text="Ingresar" OnClick="BIngresar_Click" />
                            </div>
                    <asp:Label ID="lmensaje" runat="server" ForeColor="Red"></asp:Label>
                </div>
                        </form>
                    </div>
                    
                </div>
            </div>
        </div>


    </div>



    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
        
</body>
</html>
