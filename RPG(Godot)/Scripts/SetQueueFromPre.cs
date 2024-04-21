using Godot;
using System;

public partial class SetQueueFromPre : Container
{
	[Export] public HBoxContainer TurnQueue;
	[Export] public Control Game;
	public override void _Process(double delta)
	{
		if (this.GetChildCount()==6)
			AddTheTurnHeadsToQueue();
	}
	
	public void AddTheTurnHeadsToQueue()
	{
		while(this.GetChildCount()!=0)
		{
			int place = 0;
			int MaxSpeed=-1;
			for(int i = 0; i<this.GetChildCount(); i++)
			{
				var ChildHead = (TurnQueueHeadStats)this.GetChild(i);
				if(ChildHead.Speed>MaxSpeed)
				{
					MaxSpeed = ChildHead.Speed;
					place = i;
				}
			}
			var MovingHead = (TurnQueueHeadStats)this.GetChild(place);
			this.RemoveChild(MovingHead);
			TurnQueue.AddChild(MovingHead);
		}
		var TheGame = (TheMainGameCombatScript)Game;
		TheGame.LoadGameStuff();
	}
}
