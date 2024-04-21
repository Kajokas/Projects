using Godot;
using System;

public partial class CharSelectionButt : Button
{
	[Export] public int CharID;
	[Export] public Panel ConfirmScreen;
	[Export] public Label ConText;
	[Export] public Container PreSelect;
	public PackedScene Reader = GD.Load<PackedScene>("res://Assets/ReaderHead.tscn");
	
	public void _on_pressed()
	{
		ConfirmScreen.Visible = true;
		if(PreSelect.GetChildCount() == 1)
		{
			var Character = PreSelect.GetChild(0);
			PreSelect.RemoveChild(Character);
		}
		var instance = (ReaderHead)Reader.Instantiate();
		instance.ID = CharID;
		PreSelect.AddChild(instance);
		
		ConText.Text = instance.stats.name + "\n HP: " + instance.stats.HP + "; Mana: " + instance.stats.Mana +"; \n Attack: "+instance.stats.ATK+"; Defence: "+instance.stats.DEF+"; Speed: "+instance.stats.Speed+"\n Special: Heal(5MP) \n Do you want to ad him to your team?";
	}
}
