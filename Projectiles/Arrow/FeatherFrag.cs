using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
	public class FeatherFrag : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Feather Frag");
		}

		public override void SetDefaults()
		{
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.width = 6;
			projectile.height = 6;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 40;
		}
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
		}

	}
}
