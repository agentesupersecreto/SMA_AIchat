using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Chats.UI
{
	// Token: 0x0200010A RID: 266
	public class SayHelloWhenHiredIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x00034BE3 File Offset: 0x00032DE3
		public bool isGreyOut
		{
			get
			{
				return !Singleton<SMAGameplayController>.instance.IsHired(this.m_mem.owner.ID_UnicoString) || this.m_mem.SaludoACurrentMainCharacter(Singleton<TiempoDeJuego>.instance.now);
			}
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00034C18 File Offset: 0x00032E18
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x040004C9 RID: 1225
		private MemoriaDeCharacterGeneralPermanente m_mem;
	}
}
