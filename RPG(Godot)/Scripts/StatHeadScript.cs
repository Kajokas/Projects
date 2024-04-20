using Godot;
using System;

public partial class StatHeadScript : TextureRect
{
	[Export] public Label Name;
	[Export] public ProgressBar HP;
	[Export] public ProgressBar MP;
	public Stats stat;
	public int CharRep;
	public bool isDeffending = false;
	public override void _Ready()
	{
		Name.Text = stat.name;
		HP.MaxValue = stat.HP;
		MP.MaxValue = stat.Mana;
	}
	public override void _Process(double delta)
	{
		HP.Value = stat.HP;
		MP.Value = stat.Mana;
		if(isDeffending == true)
			this.FlipH = true;
		else this.FlipH = false;
		
		if (stat.Mana == 0)
			MP.Visible = false;
		else MP.Visible = true;
		
		if (HP.Value == 0)
			this.Modulate = new Color("#292929d3");
		else this.Modulate = new Color("#ffffff");
	}
}
