<?php include("./template/CabeceraSiguientes.php"); ?>
<?php include("./variable/VariableSiguiente.php"); ?>

<?php $data = json_decode( file_get_contents("http://apis.local:8081/Taller2/api/Pokemon?desde=$next"), true );  ?>
<?php foreach($data['respuesta'] as $r) { ?>
    <?php $_SESSION['a']= $_SESSION['a']+'1';?>
    <?php echo ("<br/><br/>");?>
<div class="d-sm-flex align-self-sm-stretch ">

     <div class="card">
     <div class="card-body">
      <h4 class="card-title"><?php echo ("<br/><br/><br/>"); $a = $r["imagen"]; echo "<img src='$a'>"; ?></h4>
     </div>
    </div>

     <div class="card">
     <div class="card-body">
     <h4 class="card-title">Datos del pokemon: </h4>
     <p class="card-text">ID: <?php  echo $r['id'];?></p>
      <p class="card-text">Nombre: <?php  echo $r['nombre'];?></p>
      <p class="card-text">Peso: <?php  echo $r['peso'];?> </p>    
      <p class="card-text">Altura <?php  echo $r['altura'];?> </p>    
      <p class="card-text">Tipo/Tipos: <?php  foreach($r['tipos'] as $t) { echo ("  │ ");echo $t;  echo ("  │ "); }?></p>
      <p class="card-text">Formas: <?php  foreach($r['formas'] as $t) { echo ("  │ ");echo $t;  echo ("  │ "); }?></p>
     </div>
    </div>

    <div class="card">
     <div class="card-body">
      <h4 class="card-title">Habilidades iniciales:   </h4>
      <p class="card-text"><?php  foreach($r['habilidades'] as $t) { echo ("  │  ");echo $t;  echo ("  │  "); }?></p>
     </div>
    </div>

    <div class="col-lg-6">
    <div class="card">
     <div class="card-body">
      <h4 class="card-title">Ubicacion del pokemon:   </h4>
      <p class="card-text"><?php  foreach($r['ubicacion'] as $t) { echo ("│");echo $t;  echo ("│"); }?></p>
     </div>
    </div>
    </div>
    </div>
<?php } ?>
