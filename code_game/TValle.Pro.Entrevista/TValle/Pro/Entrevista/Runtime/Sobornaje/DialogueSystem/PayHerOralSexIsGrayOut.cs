using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Sobornaje.DialogueSystem
{
	// Token: 0x0200007C RID: 124
	public class PayHerOralSexIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x0001D079 File Offset: 0x0001B279
		public bool isGreyOut
		{
			get
			{
				return MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "OralBribed", false) || !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "BribableAny", false);
			}
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0001D0A6 File Offset: 0x0001B2A6
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x0400031E RID: 798
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
