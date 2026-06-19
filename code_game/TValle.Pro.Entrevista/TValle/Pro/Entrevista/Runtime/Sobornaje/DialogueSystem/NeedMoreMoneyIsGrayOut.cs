using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Sobornaje.DialogueSystem
{
	// Token: 0x02000079 RID: 121
	public class NeedMoreMoneyIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x0001CE6C File Offset: 0x0001B06C
		public bool isGreyOut
		{
			get
			{
				return !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "DownPaymentPaid", false) || MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "BribableAsked", false) || MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "BribableAny", false);
			}
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0001CEBC File Offset: 0x0001B0BC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x0400031A RID: 794
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
