using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Sobornaje.DialogueSystem
{
	// Token: 0x0200007A RID: 122
	public class PayHerAnalSexIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x0001CEF7 File Offset: 0x0001B0F7
		public bool isGreyOut
		{
			get
			{
				return MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "AnalBribed", false) || !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "BribableAny", false);
			}
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0001CF24 File Offset: 0x0001B124
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x0400031B RID: 795
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
