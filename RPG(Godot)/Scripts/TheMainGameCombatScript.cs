using Godot;
using System;
using System.Collections.Generic;

public struct StackTest
{
	public int SSp1;
	public int SSp2;
	public int SSp3;
	public int SSp1MP;
	public int SSp2MP;
	public int SSp3MP;
	
	public int SSe1;
	public int SSe2;
	public int SSe3;
}

public partial class TheMainGameCombatScript : Control
{
	[Export] public Sprite2D P1;
	[Export] public Sprite2D P2;
	[Export] public Sprite2D P3;
	[Export] public Sprite2D E1;
	[Export] public Sprite2D E2;
	[Export] public Sprite2D E3;
	
	[Export] public HBoxContainer TurnQueueUI;
	[Export] public VBoxContainer PlayerContUI;
	[Export] public VBoxContainer EnemyContUI;
	[Export] public TextureRect PlayerActions;
	[Export] public TextureRect Selector;
	[Export] public Label BattleText;
	
	public Stack<StackTest> StekasT = new Stack<StackTest>();
	public Queue<int> Eile = new Queue<int>();
	public LinkedList<int> PlayerSarasas = new LinkedList<int>();
	public LinkedListNode<int> CurPlayer;
	public LinkedList<int> EnemySarasas = new LinkedList<int>();
	public LinkedListNode<int> CurEnemy;
	
	public bool isSelecting = false;
	public bool isSelectingForMagic = false;
	public int RemainingEnemies = 3;
	public int RemainingPlayers = 3;
	public int LeftGoBacks = 5;
	
	private StackTest tempy = new StackTest();
	
	public void LoadGameStuff()
	{
		var Temp1 = (StatHeadScript)PlayerContUI.GetChild(0);
		CurPlayer = new LinkedListNode<int>(Temp1.CharRep);
		PlayerSarasas.AddFirst(CurPlayer);
		var Temp2 = (StatHeadScript)EnemyContUI.GetChild(0);
		CurEnemy = new LinkedListNode<int>(Temp2.CharRep);
		EnemySarasas.AddFirst(CurEnemy);
		for(int i = 1; i < 3; i++)
		{
			Temp1 = (StatHeadScript)PlayerContUI.GetChild(i);
			PlayerSarasas.AddLast(Temp1.CharRep);
			Temp2 = (StatHeadScript)EnemyContUI.GetChild(i);
			EnemySarasas.AddLast(Temp2.CharRep);
		}
		for(int i = 0; i < 6; i++)
		{
			var Temp = (TurnQueueHeadStats)TurnQueueUI.GetChild(i);
			Eile.Enqueue(Temp.CharRep);
		}
		ZmogeliukuSpriteChange(P1, ((StatHeadScript)PlayerContUI.GetChild(0)).stat.name);
		ZmogeliukuSpriteChange(P2, ((StatHeadScript)PlayerContUI.GetChild(1)).stat.name);
		ZmogeliukuSpriteChange(P3, ((StatHeadScript)PlayerContUI.GetChild(2)).stat.name);
		ZmogeliukuSpriteChange(E1, ((StatHeadScript)EnemyContUI.GetChild(0)).stat.name);
		ZmogeliukuSpriteChange(E2, ((StatHeadScript)EnemyContUI.GetChild(1)).stat.name);
		ZmogeliukuSpriteChange(E3, ((StatHeadScript)EnemyContUI.GetChild(2)).stat.name);
		BeginBattle();
	}
	
	//Del spirtes keitimo, zaidimui nesvarbus
	public void ZmogeliukuSpriteChange(Sprite2D Zmog, String Vardas)
	{
		switch(Vardas)
		{
			default:
				Zmog.Texture = (Texture2D)GD.Load("res://gfx/PlayerChars/bob.png");
				break;
			case ("Viking"):
				Zmog.Texture = (Texture2D)GD.Load("res://gfx/PlayerChars/Viking.png");
				break;
			case ("Knight"):
				Zmog.Texture = (Texture2D)GD.Load("res://gfx/PlayerChars/Knight.png");
				break;
			case ("Monk"):
				Zmog.Texture = (Texture2D)GD.Load("res://gfx/PlayerChars/Monk.png");
				break;
			case ("Barbarian"):
				Zmog.Texture = (Texture2D)GD.Load("res://gfx/PlayerChars/Barbarian.png");
				break;
			case ("King"):
				Zmog.Texture = (Texture2D)GD.Load("res://gfx/PlayerChars/King.png");
				break;
			case ("Zombie"):
				Zmog.Texture = (Texture2D)GD.Load("res://gfx/EnemyChars/Zombie.png");
				break;
			case ("Orc"):
				Zmog.Texture = (Texture2D)GD.Load("res://gfx/EnemyChars/Orc.png");
				break;
			case ("Vampire"):
				Zmog.Texture = (Texture2D)GD.Load("res://gfx/EnemyChars/Vampire.png");
				break;
		}
	}
	
	private async void StartWait()
	{
		//Godot reikalauja async metodo, kad palaukti sekundes. Yield Neveikia;
		await ToSignal(GetTree().CreateTimer(5), "timeout");
		NextChar();
	}
	
	public void BeginBattle()
	{	
		StackPildimas();
		if(Eile.Peek()<=3)
		{
			if(((StatHeadScript)PlayerContUI.GetChild(Eile.Peek()-1)).stat.HP > 0)
				PlayersTurn();
			else PlayerDeath();
		}
		else 
		{
			if(((StatHeadScript)EnemyContUI.GetChild(Eile.Peek()-4)).stat.HP > 0)
				EnemiesTurn();
			else EnemyDeath();
		}
	}
	
	public void StackPildimas()
	{
		tempy.SSp1 = ((StatHeadScript)PlayerContUI.GetChild(0)).stat.HP;
		tempy.SSp2 = ((StatHeadScript)PlayerContUI.GetChild(1)).stat.HP;
		tempy.SSp3 = ((StatHeadScript)PlayerContUI.GetChild(2)).stat.HP;
		tempy.SSe1 = ((StatHeadScript)EnemyContUI.GetChild(0)).stat.HP;
		tempy.SSe2 = ((StatHeadScript)EnemyContUI.GetChild(1)).stat.HP;
		tempy.SSe3 = ((StatHeadScript)EnemyContUI.GetChild(2)).stat.HP;
		
		tempy.SSp1MP = ((StatHeadScript)PlayerContUI.GetChild(0)).stat.Mana;
		tempy.SSp2MP = ((StatHeadScript)PlayerContUI.GetChild(1)).stat.Mana;
		tempy.SSp3MP = ((StatHeadScript)PlayerContUI.GetChild(2)).stat.Mana;
		
		StekasT.Push(tempy);
	}
	
	public void YouWin()
	{
		PlayerActions.Visible = false;
		BattleText.Text = "You win";
	}
	
	public void YouLose()
	{
		BattleText.Text = "You lose";
	}
	
	public void PlayerDeath()
	{
		if(Eile.Peek()==1)
			P1.Visible = false;
		if(Eile.Peek()==2)
			P2.Visible = false;
		if(Eile.Peek()==3)
			P3.Visible = false;
		
		RemainingPlayers--;
		TurnQueueUI.RemoveChild(TurnQueueUI.GetChild(0));
		Eile.Dequeue();
		if(RemainingPlayers==0)
			YouLose();
		else BeginBattle();
	}
	
	public void EnemyDeath()
	{
		if(Eile.Peek()==4)
			E1.Visible = false;
		if(Eile.Peek()==5)
			E2.Visible = false;
		if(Eile.Peek()==6)
			E3.Visible = false;
		RemainingEnemies--;
		TurnQueueUI.RemoveChild(TurnQueueUI.GetChild(0));
		Eile.Dequeue();
		if(RemainingEnemies==0)
			YouWin();
		else BeginBattle();
	}
	
	public void PlayersTurn()
	{
		PlayerActions.Visible = true;
		BattleText.Text = "Your turn";
	}
	
	public void EnemiesTurn()
	{
		PlayerActions.Visible = false;
		
		EnemySarasas.Find(Eile.Peek());
		var random = new RandomNumberGenerator();
		random.Randomize();
		int action = random.RandiRange(1,2);
		if(action == 1)
		{
			var Enemy = (StatHeadScript)EnemyContUI.GetChild(Eile.Peek() - 4);
			action = random.RandiRange(0,2);
			var Player = (StatHeadScript)PlayerContUI.GetChild(action);
			Enemy.isDeffending = false;
			if (Player.isDeffending == true && Player.stat.DEF <= Enemy.stat.ATK)
				Player.stat.HP -= (Enemy.stat.ATK-Player.stat.DEF);
			else if (Player.isDeffending == false)
				Player.stat.HP -= Enemy.stat.ATK;
			
			BattleText.Text = Enemy.stat.name + " attacked " + Player.stat.name;
		}
		else
		{
			var Enemy = (StatHeadScript)EnemyContUI.GetChild(Eile.Peek() - 4);
			Enemy.isDeffending = true;
			BattleText.Text = Enemy.stat.name + " is defending";
		}
		StartWait();
	}
	
	public void NextChar()
	{
		TurnQueueUI.MoveChild(TurnQueueUI.GetChild(0),TurnQueueUI.GetChildCount()-1);
		Eile.Enqueue(Eile.Peek());
		Eile.Dequeue();
		BeginBattle();
	}
	
	private void _on_attack_pressed()
	{
		PlayerActions.Visible = false;
		Selector.Visible = true;
		Selector.GetParent().RemoveChild(Selector);
		EnemyContUI.GetChild(CurEnemy.Value-4).AddChild(Selector);
		isSelecting = true;
	}
	
	private void _on_deffend_pressed()
	{
		var Player = (StatHeadScript)PlayerContUI.GetChild(Eile.Peek()-1);
		Player.isDeffending = true;
		NextChar();
	}
	
	private void _on_special_pressed()
	{
		if(((StatHeadScript)PlayerContUI.GetChild(Eile.Peek()-1)).stat.Mana>=5)
		{
			PlayerActions.Visible = false;
			Selector.Visible = true;
			Selector.GetParent().RemoveChild(Selector);
			PlayerContUI.GetChild(CurPlayer.Value-1).AddChild(Selector);
			isSelectingForMagic = true;
		}
		else BattleText.Text = "You don't have enough mana";
	}
	
	private void _on_go_back_pressed()
	{
		if(LeftGoBacks>0 && StekasT.Count>1)
		{
			StekasT.Pop();//Pirma Pop, nes ejimas prasideda su Push, tai Peek cia paroditu dabartinius stats.
		
		((StatHeadScript)PlayerContUI.GetChild(0)).stat.HP = StekasT.Peek().SSp1;
		((StatHeadScript)PlayerContUI.GetChild(1)).stat.HP = StekasT.Peek().SSp2;
		((StatHeadScript)PlayerContUI.GetChild(2)).stat.HP = StekasT.Peek().SSp3;
		((StatHeadScript)EnemyContUI.GetChild(0)).stat.HP = StekasT.Peek().SSe1;
		((StatHeadScript)EnemyContUI.GetChild(1)).stat.HP = StekasT.Peek().SSe2;
		((StatHeadScript)EnemyContUI.GetChild(2)).stat.HP = StekasT.Peek().SSe3;
		
		((StatHeadScript)PlayerContUI.GetChild(0)).stat.Mana = StekasT.Peek().SSp1MP;
		((StatHeadScript)PlayerContUI.GetChild(1)).stat.Mana = StekasT.Peek().SSp2MP;
		((StatHeadScript)PlayerContUI.GetChild(2)).stat.Mana = StekasT.Peek().SSp3MP;
		
		LeftGoBacks--;
		}
	}
	
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("UP"))
		{
			if(isSelecting == true)
			{
				if(CurEnemy.Previous != null)
				{
				CurEnemy = CurEnemy.Previous;
				var SelectedEnemy = EnemyContUI.GetChild(CurEnemy.Value-4);
				Selector.GetParent().RemoveChild(Selector);
				SelectedEnemy.AddChild(Selector);
				}
			}
			if(isSelectingForMagic == true)
			{
				if(CurPlayer.Previous != null)
				{
				CurPlayer = CurPlayer.Previous;
				var SelectedEnemy = PlayerContUI.GetChild(CurPlayer.Value-1);
				Selector.GetParent().RemoveChild(Selector);
				SelectedEnemy.AddChild(Selector);
				}
			}
			
		}
		if (@event.IsActionPressed("Down"))
		{
			if(isSelecting == true)
			{
				if(CurEnemy.Next != null)
				{
				CurEnemy = CurEnemy.Next;
				var SelectedEnemy = EnemyContUI.GetChild(CurEnemy.Value-4);
				Selector.GetParent().RemoveChild(Selector);
				SelectedEnemy.AddChild(Selector);
				}
			}
			if(isSelectingForMagic == true)
			{
				if(CurPlayer.Next != null)
				{
				CurPlayer = CurPlayer.Next;
				var SelectedEnemy = PlayerContUI.GetChild(CurPlayer.Value-1);
				Selector.GetParent().RemoveChild(Selector);
				SelectedEnemy.AddChild(Selector);
				}
			}
		}
		if (@event.IsActionPressed("Confirm"))
		{
			if(isSelecting == true)
			{
			Selector.Visible = false;
			var Enemy = (StatHeadScript)EnemyContUI.GetChild(CurEnemy.Value - 4);
			var Player = (StatHeadScript)PlayerContUI.GetChild(Eile.Peek() - 1);
			Player.isDeffending = false;
			
				if (Enemy.isDeffending == true && Enemy.stat.DEF <= Player.stat.ATK)
					Enemy.stat.HP -= (Player.stat.ATK-Enemy.stat.DEF);
				else if (Enemy.isDeffending == false)
					Enemy.stat.HP -= Player.stat.ATK;
					
			isSelecting = false;
			
			NextChar();
			}
			
			if(isSelectingForMagic == true)
			{
			Selector.Visible = false;
			var Player2 = (StatHeadScript)PlayerContUI.GetChild(CurPlayer.Value - 1);
			var Player1 = (StatHeadScript)PlayerContUI.GetChild(Eile.Peek() - 1);
			Player1.isDeffending = false;
			
			Player1.stat.Mana -= 5;
			Player2.stat.HP += 5;
			
			isSelectingForMagic = false;
			
			NextChar();
			}
		}
	}
}
