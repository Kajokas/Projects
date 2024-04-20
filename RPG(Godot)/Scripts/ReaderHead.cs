using Godot;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Stats
{
	public string name { get; set; }
	public int HP { get; set; }
	public int Mana { get; set; }
	public int ATK { get; set; }
	public int DEF { get; set; }
	public int Speed { get; set; }
}

public partial class ReaderHead : TextureRect
{
	public int ID = 0;
	public Stats stats;
	public int EID;
	public Stats Estats;

	public override void _Ready()
	{
		var file = FileAccess.Open("res://Characters.json", FileAccess.ModeFlags.Read);

		string json_text = file.GetAsText();
		file.Close();

		var casted = JsonConvert.DeserializeObject<Dictionary<string, Stats>>(json_text);
		
		casted.TryGetValue(ID.ToString(), out stats);
		
		var random = new RandomNumberGenerator();
		random.Randomize();
		EID = random.RandiRange(9,11);
		casted.TryGetValue(EID.ToString(), out Estats);
		
		switch(ID)
		{
			default:
				this.Texture = (Texture2D)GD.Load("res://gfx/Heads/Bob Head.png");
				break;
			case 1:
				this.Texture = (Texture2D)GD.Load("res://gfx/Heads/Viking Head.png");
				break;
			case 2:
				this.Texture = (Texture2D)GD.Load("res://gfx/Heads/Knight Head.png");
				break;
			case 3:
				this.Texture = (Texture2D)GD.Load("res://gfx/Heads/Monk Head.png");
				break;
			case 4:
				this.Texture = (Texture2D)GD.Load("res://gfx/Heads/Barbarian Head.png");
				break;
			case 5:
				this.Texture = (Texture2D)GD.Load("res://gfx/Heads/King Head.png");
				break;
		}
	}
}
