using Godot;
using System;

public partial class TurnOffCharSelectionScreen : VBoxContainer
{
	[Export] public TextureRect CharSelection;
	[Export] public Container PreQueue;
	[Export] public VBoxContainer PlayerContainer;
	[Export] public VBoxContainer EnemyContainer;
	[Export] public Control Game;
	public PackedScene TurnQueueHead = GD.Load<PackedScene>("res://Assets/Head.tscn");
	public PackedScene StatsHead = GD.Load<PackedScene>("res://Assets/StatHead.tscn");
	public override void _Process(double delta)
	{
		if(this.GetChildCount()==3)
			BeginBattle();
	}
	
	public void BeginBattle()
	{
		for(int i = 0; i<3; i++)
		{
			var RHead = (ReaderHead)this.GetChild(i);
			var instance = (TurnQueueHeadStats)TurnQueueHead.Instantiate();
			var PlayerStatsHead = (StatHeadScript)StatsHead.Instantiate();
			instance.ID = RHead.ID;
			instance.SetHead();
			instance.Speed = RHead.stats.Speed;
			instance.CharRep = i+1;
			PreQueue.AddChild(instance);
			PlayerStatsHead.stat = RHead.stats;
			PlayerStatsHead.Texture = instance.Texture;
			PlayerStatsHead.CharRep = i+1;
			PlayerContainer.AddChild(PlayerStatsHead);
			
			instance = (TurnQueueHeadStats)TurnQueueHead.Instantiate();
			var EnemyStatsHead = (StatHeadScript)StatsHead.Instantiate();
			instance.ID = RHead.EID;
			instance.SetHead();
			instance.Speed = RHead.Estats.Speed;
			instance.CharRep = i+4;
			PreQueue.AddChild(instance);
			EnemyStatsHead.stat = RHead.Estats;
			EnemyStatsHead.Texture = instance.Texture;
			EnemyStatsHead.CharRep = i+4;
			EnemyContainer.AddChild(EnemyStatsHead);
		}
		this.QueueFree();
		CharSelection.Visible = false;
	}
}
