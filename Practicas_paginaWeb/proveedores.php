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
    <title>Proveedores y Marcas</title>
</head>
<body bgcolor="#006316" style="font-family: 'Georgia MT';">

<nav class="navbar" style="background-color: #008080;">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Inventario de Medicamento - Proveedores y Marcas</a>
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

<h1 class="display-1" style="padding-right:45px; padding-left:45px;"> <Center><b><u>Proveedores y Marcas</b></u></h1>

<div class="col" style="padding:2px; background-color: #ffffff" > </div>
<div class="col" style="padding:5px; background-color: #F0E68C" >  </div>
<div class="col" style="padding:10px; background-color: #ffffff" > </div>
<div class="col" style="padding-right:45px; padding-left:45px;">

<center><h2><b><u>Datos de la tabla:</u></b></h2></center>
<div class="col" style="padding:15px; background-color: #ffffff;"></div>

<div class="row">
  <div class="col-sm-6"style=" padding-right:45px; padding-left:45px;">
    <div class="card">               
    <div class="card text-center">    
     <h5 class="card-header"style="background-color: #F0FFF0;"><b><u>Encabezados</b></u></h5>
     </div>
      <div class="card-body">        
      <p class="card-text">
      <ol class="list-group list-group-flush">
  <li class="list-group-item">1. ID:</li>
  <li class="list-group-item">2. Nombre del Proveedor:</li>
  <li class="list-group-item">3. Teléfono:</li>
  <li class="list-group-item">4. Marca:</li>
  <li class="list-group-item">5. Dirección:</li>
  <li class="list-group-item">6. Calificación:</li>
</ol></p>
      </div>
    </div>
  </div>


  <div class="col-sm-6"style=" padding-right:45px; padding-left:45px;">
    <div class="card">   
    <div class="card text-center">    
     <h5 class="card-header"style="background-color: #F0FFF0;"><b><u>Definición</b></u></h5>
     </div>
      <div class="card-body">
        <p class="card-text">
        <ol class="list-group list-group-flush">
  <li class="list-group-item"> → Numeración.</li>
  <li class="list-group-item"> → Palabra que designa a la persona.</li>
  <li class="list-group-item"> → Teléfono del proveedor.</li>
  <li class="list-group-item"> → Palabra que designa la marca.</li>
  <li class="list-group-item"> → Dirección de la empresa de la marca.</li>
  <li class="list-group-item"> → Del 1-5 que tan buena es la Marca.</li>
</ol>
       </p>
      </div>
    </div>
  </div>
</div>   

</div>   







<div class="col" style="padding:15px; background-color: #ffffff" > </div>
<div class="col" style="padding:5px; background-color: #F0E68C" >  </div>

<div class="col" style="padding:15px; background-color: #ffffff;"></div>
<center><h2><b><u>Tabla de Proveedores</u></b></h2></center>


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

        $consulta = "SELECT p.id_proveedores, p.nom_proveedores, p.telefono, a.nom_marca, a.direccion, a.calificacion FROM proveedores p inner JOIN marca a on a.id_marca=p.id_proveedores;
        
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
        echo '<th scope="col"><h4>Nombre del Proveedor</th></h4>';
        echo '<th scope="col"><h4>Teléfono</th></h4>';
        echo '<th scope="col"><h4>Marca </th></h4>';
        echo '<th scope="col"><h4>Dirección</th></h4>';
        echo '<th scope="col"><h4>Calificación</th></h4>';        
        echo '</thead>';
        echo "</tr>";
        while ($colum = mysqli_fetch_array($result))
        {
            echo "<tr>";
            echo "<td>" . $colum['id_proveedores'] . "</td>";
            echo "<td>" . $colum['nom_proveedores'] . "</td>";
            echo "<td>" . $colum['telefono'] . "</td>";
            echo "<td>" . $colum['nom_marca'] . "</td>";
            echo "<td>" . $colum['direccion'] . "</td>";
            echo "<td>" . $colum['calificacion'] . "</td>";
            echo "</tr>";
        }
        echo "</table>"; ?>

        
</div>

<div class="col" style="padding:15px; background-color: #ffffff" > </div>
<div class="col" style="padding:5px; background-color: #F0E68C" >  </div>

<div class="col" style="padding:15px; background-color: #ffffff;"></div>
<center><h2><b><u>Tabla de Medicamentos con sus Proveedores</u></b></h2></center>


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

        $consulta = "SELECT a.nom_marca, m.nom_med, m.id_med, p.nom_proveedores FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento;
        
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
        echo '<th scope="col"><h4> Medicamentos </th></h4>';
        echo '<th scope="col"><h4> Nombre de la Marca </th></h4>';
        echo '<th scope="col"><h4> Nombre del Proveedor </th></h4>';        
        echo '</thead>';
        echo "</tr>";
        while ($colum = mysqli_fetch_array($result))
        {
            echo "<tr>";
            echo "<td>" . $colum['id_med'] . "</td>";
            echo "<td>" . $colum['nom_med'] . "</td>";
            echo "<td>" . $colum['nom_marca'] . "</td>";
            echo "<td>" . $colum['nom_proveedores'] . "</td>";
            echo "</tr>";
        }
        echo "</table>"; ?>

        
</div>
</div>
<div class="col" style="padding:15px; background-color: #ffffff; padding-right:0px; padding-left:0px;"></div>
<div class="col" style="padding:30px; background-color: #008080; padding-right:0px; padding-left:0px;"></div>

    </body>
</html>