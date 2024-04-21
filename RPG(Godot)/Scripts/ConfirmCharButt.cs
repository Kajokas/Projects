using Godot;
using System;

public partial class ConfirmCharButt : Button
{
	[Export] public Panel ConfirmScreen;
	[Export] public VBoxContainer PTeam;
	[Export] public Container PreSelect;
	
	private void _on_pressed()
	{
		ConfirmScreen.Visible = false;
		var Character = PreSelect.GetChild(0);
		PreSelect.RemoveChild(Character);
		PTeam.AddChild(Character);
	}
	public override void _Ready()
	{
	}
}
