using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Sobornaje.DialogueSystem
{
	// Token: 0x0200007D RID: 125
	public class PayHerSexIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x0001D0E1 File Offset: 0x0001B2E1
		public bool isGreyOut
		{
			get
			{
				return MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "VaginalBribed", false) || !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "BribableAny", false);
			}
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0001D10E File Offset: 0x0001B30E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x0400031F RID: 799
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
