using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Auras
{
	// Token: 0x02000540 RID: 1344
	[Obsolete("reeemplazado por EmocionAuraReceiver y EmocionAuraProducer", true)]
	public class AuraDeConcentDeCharacter : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x06002111 RID: 8465 RVA: 0x0007B5C7 File Offset: 0x000797C7
		public Character character
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x06002112 RID: 8466 RVA: 0x0007B5CF File Offset: 0x000797CF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = this.GetComponentEnRoot(false);
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
		}

		// Token: 0x06002113 RID: 8467 RVA: 0x0007B602 File Offset: 0x00079802
		public float ObtenerCurrentAura()
		{
			return this.addicionesDeConcent.AdicinarValorIncluyendo(this.defaultAura);
		}

		// Token: 0x04001577 RID: 5495
		public float defaultAura;

		// Token: 0x04001578 RID: 5496
		public ModificableDeFloat addicionesDeConcent = new ModificableDeFloat(0f);

		// Token: 0x04001579 RID: 5497
		private Character m_Character;
	}
}
