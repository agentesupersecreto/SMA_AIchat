using System;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita;
using Assets.TValle.BeachGirl.Sexual;

namespace Assets.TValle.BeachGirl.Runtime
{
	// Token: 0x02000055 RID: 85
	public class PuedoConversarHablarSegunTipoDeBocaSex : CustomMonobehaviour, ICharacterPuedeHablar
	{
		// Token: 0x0600017D RID: 381 RVA: 0x000030AE File Offset: 0x000012AE
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_BocaHole = this.GetComponentEnRoot(false);
			if (this.m_BocaHole == null)
			{
				throw new ArgumentNullException("m_BocaHole", "m_BocaHole null reference.");
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000030E1 File Offset: 0x000012E1
		public bool PuedeIntentarHablar(out bool duracionEsIndefinida)
		{
			duracionEsIndefinida = true;
			return this.m_BocaHole.currentOralSexTipo == TipoDeOralSex.None || this.m_BocaHole.currentOralSexTipo == TipoDeOralSex.conBoca;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00003103 File Offset: 0x00001303
		public bool PuedeHablarConClaridad(out bool duracionEsIndefinida)
		{
			duracionEsIndefinida = true;
			return this.m_BocaHole.currentOralSexTipo == TipoDeOralSex.None;
		}

		// Token: 0x040000F4 RID: 244
		private BocaHole m_BocaHole;
	}
}
