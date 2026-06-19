using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Chats.UI
{
	// Token: 0x02000024 RID: 36
	public class SayHelloIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00008644 File Offset: 0x00006844
		public bool isGreyOut
		{
			get
			{
				return Singleton<SMAGameplayController>.instance.IsHired(this.m_mem.owner.ID_UnicoString) || this.m_mem.ConoceACurrentMainCharacter();
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000866F File Offset: 0x0000686F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x040000DB RID: 219
		private MemoriaDeCharacterGeneralPermanente m_mem;
	}
}
