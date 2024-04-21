using Godot;
using System;

public partial class MainGameSceneSrcipt : Node
{
	[Export] public Control StartMenu;
	[Export] public Control PauseMenu;
	public PackedScene scene = GD.Load<PackedScene>("res://Scenes/GameLVL.tscn");
	
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("Escape"))
		{
			MoveChild(PauseMenu,GetChildCount()-1);
			PauseMenu.Visible = !PauseMenu.Visible;
		}
	}
	
	private void _on_resume_pressed()
	{
		PauseMenu.Visible = !PauseMenu.Visible;
	}
	private void _on_start_2_pressed()
	{
		var instance = scene.Instantiate();
		AddChild(instance);
		RemoveChild(StartMenu);
	}
	private void _on_exit_2_pressed()
	{
		GetTree().Quit();
	}
	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}
