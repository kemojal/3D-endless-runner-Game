using Godot;
using System;

public class Main : Spatial
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    // declare player variable 
    // var nameVariable         # GDScript equivalent
    RigidBody player;
    Random r  = new Random();
    float linearSpeedX   = 1500f;
   private PackedScene EnemyScene  = ResourceLoader.Load("res://scenes/Enemy.tscn") as PackedScene;
    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        // player  = get_node("player")  #GDScript equivalent
        
        player  = (RigidBody) GetNode("player"); // player  = GetNode("player") as RigidBody;
        
    }
    public override void _Input(InputEvent ev)
    {
        // check keyboard input event
       if( ev is InputEventKey){
           var key  = (InputEventKey) ev;
           if(key.IsPressed() && key.IsAction("ui_left"))
           {
               //GD.Print("left");
               player.SetLinearVelocity( new Vector3( -linearSpeedX * GetProcessDeltaTime(), 0, 0));
           }else 
           if ( key.IsPressed() && key.IsAction("ui_right")){
               //GD.Print("right");
               player.SetLinearVelocity( new Vector3( linearSpeedX * GetProcessDeltaTime(), 0 , 0 ));
           }
           else{
               player.SetLinearVelocity( new Vector3(0, 0, 0));
           }

       }
    }
	private void _on_SpawnEnemytimer_timeout()
{
    // Replace with function body
	
    //GD.Print("Enemy is spawned");
    Godot.RigidBody e; 
    e  = EnemyScene.Instance() as Godot.RigidBody;
    Godot.Vector3 pos  = e.GetTranslation();
    pos.z  = -500;
    pos.y  = 2;
    int xRand  = r.Next( -5, 5) * 5;
    pos.x   = pos.x  - xRand;
    e.SetTranslation(pos);

    // randomize the scale
    Godot.Vector3 scale  = e.GetScale();
    int s  = r.Next(2, 4);
    scale  = scale * 3;
    e.SetScale(scale);
    AddChild(e);
}
	
//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}






