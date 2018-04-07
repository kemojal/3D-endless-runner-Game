using Godot;
using System;

public class Enemy : RigidBody
{
    private Vector3 pos;
   // private Random random;
    private float speed  = 200f;
    
    public override void _Ready()
    {
      

    }

   public override void _Process(float delta)
   {
     pos  = GetTranslation();
     pos.z += delta * speed;
     SetTranslation(pos);
   }
}
