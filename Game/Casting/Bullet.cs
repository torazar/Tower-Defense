namespace Unit04.Game.Casting{
    using System;
public class Bullet : Actor{






public override void Fall(){
    Point Fall = GetPosition();
                Point Speed = new Point(0, -5);
                Fall = Fall.Add(Speed);
                SetPosition(Fall);

}







}}