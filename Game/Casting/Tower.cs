namespace Unit04.Game.Casting{
    using System;
public class Tower : Artifact{

private int ammo = 0;

public bool shoot(){
if (ammo>10000){
  
ammo = 0;
return true;
}
else{ ammo +=1;
return false;}
}


    
}






}