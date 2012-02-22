//Re-written by Foul or "Archangel", a basic Mount Stone for temporary mounts made for Server wars.
//See installation instructions.
using System;
using Server.Items;
using Server.Mobiles;
namespace Server.Items
{
	public class MountStone : Item
	{
		public override string DefaultName
		{
			get { return "a Mount Stone"; }
		}

		[Constructable]
		public MountStone() : base( 0xED4 )
		{
			Movable = false;
			Hue = 0x20C; //Change this if you don't like the color of the purple stone
			//To change the Mount's color edit Mount.cs
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.Mounted == true )
			{
				from.SendMessage(78, "You're already mounted!"); //Already mounted warning.
				return;
			}
				Mount mount = new Mount(); //Adds new mount (MUST HAVE Mount.cs)
				mount.MoveToWorld( from.Location, from.Map ); //Moves new mount to player.
				mount.SetControlMaster( from ); //Automatically sets the player who owns the mount.
				mount.Rider = from; //Mounts the person who clicked the stone on new mount.
				from.SendMessage(78, "Go, Go, Go!"); //Confirms to player that he has a new mount.
		}

		public MountStone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}