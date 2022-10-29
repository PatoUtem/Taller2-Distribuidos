<?php
session_start();
$data = json_decode( file_get_contents("http://apis.local:8081/Taller2/api/Pokemon?desde=0"), true );
$_SESSION['b']='0';
?>
<?php $n= $data['next']; ?>

<!DOCTYPE html>
<html lang="en">
  
<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Taller 2 paralela</title>
  <link rel="stylesheet" href="./cs/bootstrap.css"/>

  <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
  <a class="navbar-brand" href="#">
  <img src="./img/logo.png" width="30" height="30" class="d-inline-block align-top" alt="">
    Lista de pokemon
  </a>
  <button class="btn btn-primary" style="float: right;" onclick="location.href='/Taller2-distribuidos/siguientes.php'">Mostrar 10 siguientes</button>
  </nav>
  
  
</head>

<body>
 
</body>


</html>