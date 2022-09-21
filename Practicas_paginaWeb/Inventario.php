<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">	
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
    <title>Inventario</title>
</head>
<body bgcolor="#006316" style="font-family: 'Georgia MT';">

<nav class="navbar" style="background-color: #008080;">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Inventario de Medicamento - Inventario</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasDarkNavbar" aria-controls="offcanvasDarkNavbar">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="offcanvas offcanvas-end " style="background-color: #008080;" tabindex="-1" id="offcanvasDarkNavbar" aria-labelledby="offcanvasDarkNavbarLabel">
      <div class="offcanvas-header">
        <h3 class="offcanvas-title" id="offcanvasDarkNavbarLabel"> Menú</h3>
        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="offcanvas" aria-label="Close"></button>
      </div>
      <div class="offcanvas-body">
        <ul class="navbar-nav justify-content-end flex-grow-1 pe-3">

               <li class="nav-item">
                  <a class="nav-link active" aria-current="page" href="index.php">Inicio</a>
                </li>

               <li class="nav-item">
                  <a class="nav-link active" aria-current="page" href="Inventario.php "> Inventario</a>
                </li>

                <li class="nav-item">
                  <a class="nav-link active" aria-current="page" href="medicamentos.php "> Medicamentos</a>
                </li>

                <li class="nav-item">
                <a class="nav-link active" aria-current="page" href="proveedores.php ">Proveedores y Marcas</a>
                </li>

                <li class="nav-item">
                <a class="nav-link active" aria-current="page" href="clientes.php ">Clientes</a>
                </li>
        </ul>        
      </div>
    </div>
  </div>
</nav>

<div class="col" style="padding:10px; background-color: #ffffff" > </div>
<div class="col" style="padding:5px; background-color: #F0E68C" >  </div>

<h1 class="display-1" style="padding-right:45px; padding-left:45px;"> <Center><b><u>Inventario</b></u></h1>


<div class="col" style="padding:2px; background-color: #ffffff" > </div>
<div class="col" style="padding:5px; background-color: #F0E68C" >  </div>
<div class="col" style="padding:10px; background-color: #ffffff" > </div>

<img src="https://img.freepik.com/foto-gratis/vista-superior-variedad-medicamentos-tabletas_23-2148529769.jpg?w=2000" class="d-block w-100">


<div class="col" style="padding:12px; background-color: #ffffff" > </div>
<div class="col" style="padding:5px; background-color: #F0E68C" >  </div>
<div class="col" style="padding:15px; background-color: #ffffff;"></div>
<center><h2><b><u>Tabla de Compras</u></b></h2></center>


    <div class="col" style="padding:15px; background-color: #ffffff;"></div>

    <div class="container-fluid">
        <?php
        $user = "root";
        $pass = "";
        $host = "localhost";
        $conneccion = mysqli_connect($host, $user, $pass);
        if(!$conneccion) 
                {
                    echo "No se ha podido conectar con el servidor" . mysql_error();
                }

        $DB = "inventario_medicamentos";
        $dbselect = mysqli_select_db($conneccion,$DB);
        if (!$dbselect)
        {
        echo "No se ha podido encontrar la Base de Datos";
        }

        $consulta = "SELECT c.id_compra, c.fec_compra, m.nom_med, a.nom_marca, m.fec_caducidad, m.uni_medida, m.Cantidad_existente, m.precio_costo, c.total_PC, m.precio_final, c.total FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento;
        
        ";
        $result = mysqli_query($conneccion,$consulta);
        
        if(!$result) 
        {
            echo "No se ha podido realizar la consulta";
        }              
        echo '<table class="table table table-striped-columns">';
        echo'<thead class="table-dark">';
        echo "<tr>";
        echo '<th scope="col"><h4>ID</th></h4>';
        echo '<th scope="col"><h4>Fecha de la Compra</th></h4>';
        echo '<th scope="col"><h4>Nombre del Medicamento</th></h4>';
        echo '<th scope="col"><h4>Nombre del Proveedor</th></h4>';
        echo '<th scope="col"><h4>Fecha de Caducidad</th></h4>';
        echo '<th scope="col"><h4>Unidad de Medida</th></h4>';  
        echo '<th scope="col"><h4>Stock</th></h4>';
        echo '<th scope="col"><h4>Precio Costo (Q)</th></h4>';
        echo '<th scope="col"><h4>Total (Q)</th></h4>';
        echo '<th scope="col"><h4>Precio Final (Q)</th></h4>';
        echo '<th scope="col"><h4>Total (Q)</th></h4>';        
        echo '</thead>';
        echo "</tr>";
        while ($colum = mysqli_fetch_array($result))
        {
            echo "<tr>";
            echo "<td>" . $colum['id_compra'] . "</td>";
            echo "<td>" . $colum['fec_compra'] . "</td>";
            echo "<td>" . $colum['nom_med'] . "</td>";
            echo "<td>" . $colum['nom_marca'] . "</td>";
            echo "<td>" . $colum['fec_caducidad'] . "</td>";
            echo "<td>" . $colum['uni_medida'] . "</td>";
            echo "<td>" . $colum['Cantidad_existente'] . "</td>";
            echo "<td>" . $colum['precio_costo'] . "</td>";
            echo "<td>" . $colum['total_PC'] . "</td>";
            echo "<td>" . $colum['precio_final'] . "</td>";
            echo "<td>" . $colum['total'] . "</td>";
            echo "</tr>";
        }
        echo "</table>"; ?>

        
</div>

<div class="col" style="padding:15px; background-color: #ffffff" > </div>
<div class="col" style="padding:5px; background-color: #F0E68C" >  </div>

<div class="col" style="padding:15px; background-color: #ffffff;"></div>
<center><h2><b><u>Tabla de Ventas</u></b></h2></center>


    <div class="col" style="padding:15px; background-color: #ffffff;"></div>




<div class="container-fluid">
        <?php
        $user = "root";
        $pass = "";
        $host = "localhost";
        $conneccion = mysqli_connect($host, $user, $pass);
        if(!$conneccion) 
                {
                    echo "No se ha podido conectar con el servidor" . mysql_error();
                }

        $DB = "inventario_medicamentos";
        $dbselect = mysqli_select_db($conneccion,$DB);
        if (!$dbselect)
        {
        echo "No se ha podido encontrar la Base de Datos";
        }

        $consulta = "SELECT v.id_venta, c.nom_cliente,  c.ape_cliente, v.fec_venta, m.nom_med, m.fec_caducidad, m.uni_medida, m.Cantidad_existente, v.unidades_vendidas, m.precio_final, v.subtotal_venta, v.total FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento;
        
        ";
        $result = mysqli_query($conneccion,$consulta);
        
        if(!$result) 
        {
            echo "No se ha podido realizar la consulta";
        }  
        echo '<table class="table table table-striped-columns">';
        echo'<thead class="table-dark">';
        echo "<tr>";
        echo '<th scope="col"><h4>ID</th></h4>';
        echo '<th scope="col"><h4>Nombres del Cliente</th></h4>';
        echo '<th scope="col"><h4>Apellidos del Cliente</th></h4>';
        echo '<th scope="col"><h4>Fecha de la Venta</th></h4>';
        echo '<th scope="col"><h4>Nombre del Medicamento</th></h4>';        
        echo '<th scope="col"><h4>Fecha de Caducidad</th></h4>';
        echo '<th scope="col"><h4>Unidad de Medida</th></h4>';   
        echo '<th scope="col"><h4>Stock</th></h4>';
        echo '<th scope="col"><h4>Unidades a Vender</th></h4>';   
        echo '<th scope="col"><h4>Precio (Q)</th></h4>';
        echo '<th scope="col"><h4>Subtotal (Q)</th></h4>';   
        echo '<th scope="col"><h4>Total (Q)</th></h4>';
        echo '</thead>';
        echo "</tr>";
        while ($colum = mysqli_fetch_array($result))
        {
            echo "<tr>";
            echo "<td>" . $colum['id_venta'] . "</td>";
            echo "<td>" . $colum['nom_cliente'] . "</td>";
            echo "<td>" . $colum['ape_cliente'] . "</td>";
            echo "<td>" . $colum['fec_venta'] . "</td>";
            echo "<td>" . $colum['nom_med'] . "</td>";
            echo "<td>" . $colum['fec_caducidad'] . "</td>";
            echo "<td>" . $colum['uni_medida'] . "</td>";
            echo "<td>" . $colum['Cantidad_existente'] . "</td>";
            echo "<td>" . $colum['unidades_vendidas'] . "</td>";
            echo "<td>" . $colum['precio_final'] . "</td>";
            echo "<td>" . $colum['subtotal_venta'] . "</td>";
            echo "<td>" . $colum['total'] . "</td>";
            echo "</tr>";
        }
        echo "</table>"; ?>

        
</div>
</div>
<div class="col" style="padding:15px; background-color: #ffffff; padding-right:0px; padding-left:0px;"></div>
<div class="col" style="padding:30px; background-color: #008080; padding-right:0px; padding-left:0px;"></div>

    </body>
</html>