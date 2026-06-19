using System;
using Assets.Base.Behaviours.Runtime.Anims;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers.GoTo;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.GoTo
{
	// Token: 0x020000A9 RID: 169
	public class SillaGoToTarget : GoToTarget
	{
		// Token: 0x06000520 RID: 1312 RVA: 0x0001056A File Offset: 0x0000E76A
		protected override void AwakeUnityEvent()
		{
			this.m_SillaGenerica = base.GetComponentInParent<SillaGenerica>();
			if (this.m_SillaGenerica == null)
			{
				throw new ArgumentNullException("m_SillaGenerica", "m_SillaGenerica null reference.");
			}
			base.AwakeUnityEvent();
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0001059C File Offset: 0x0000E79C
		public override void Registrar()
		{
			this.UpdateSillaGoto();
			base.Registrar();
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x000105AC File Offset: 0x0000E7AC
		public virtual void UpdateSillaGoto()
		{
			this.m_SillaGenerica.Init();
			if (this.m_sillaGoto == null)
			{
				this.m_sillaGoto = base.data.transform;
			}
			if (this.m_sillaGoto == null)
			{
				this.m_sillaGoto = new GameObject("gOTO").transform;
				this.m_sillaGoto.parent = base.transform;
				base.data.SetTrasform(this.m_sillaGoto);
			}
			this.m_sillaGoto.SetPositionAndRotation(this.m_SillaGenerica.gotoWorldPositon, this.m_SillaGenerica.worldRotation);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00010649 File Offset: 0x0000E849
		protected override void OnUsing(ICharacterNavegable navegable, ICharacterTeleportable teleportable, ICharacter character)
		{
			base.OnUsing(navegable, teleportable, character);
			this.m_SillaGenerica.UpdateGoto(character);
			this.UpdateSillaGoto();
		}

		// Token: 0x04000308 RID: 776
		private Transform m_sillaGoto;

		// Token: 0x04000309 RID: 777
		protected SillaGenerica m_SillaGenerica;
	}
}
