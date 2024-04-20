using Godot;
using System;

public partial class TurnQueueHeadStats : TextureRect
{
	public int ID;
	public int Speed;
	public int CharRep;
	
	public void SetHead()
	{
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
			case 9:
				this.Texture = (Texture2D)GD.Load("res://gfx/Heads/Zombie Head.png");
				break;
			case 10:
				this.Texture = (Texture2D)GD.Load("res://gfx/Heads/Orc Head.png");
				break;
			case 11:
				this.Texture = (Texture2D)GD.Load("res://gfx/Heads/Vampire Head.png");
				break;
		}
	}
}
