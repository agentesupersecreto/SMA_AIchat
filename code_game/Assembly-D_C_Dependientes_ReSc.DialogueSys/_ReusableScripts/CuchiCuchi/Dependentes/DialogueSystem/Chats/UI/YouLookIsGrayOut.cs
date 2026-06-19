using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Chats.UI
{
	// Token: 0x0200006D RID: 109
	public class YouLookIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600032A RID: 810 RVA: 0x00010772 File Offset: 0x0000E972
		public bool isGreyOut
		{
			get
			{
				return MemoriaDeCharacterBase.LeerBoolean(this.m_mem, "DescritaVisualmente", "General", false);
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0001078A File Offset: 0x0000E98A
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x04000149 RID: 329
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
