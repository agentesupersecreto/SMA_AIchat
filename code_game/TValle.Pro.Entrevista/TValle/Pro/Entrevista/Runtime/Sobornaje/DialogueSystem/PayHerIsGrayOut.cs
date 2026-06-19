using System;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Sobornaje.DialogueSystem
{
	// Token: 0x0200007B RID: 123
	public class PayHerIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0001CF60 File Offset: 0x0001B160
		public bool isGreyOut
		{
			get
			{
				if (!this.m_memPerma.ConoceACurrentMainCharacter())
				{
					return true;
				}
				if (MemoriaDeCharacterBase.LeerDeepBoolean(this.m_memTemp, null, "DownPaymentPaid", false))
				{
					return true;
				}
				if (MemoriaDeCharacterBase.LeerDeepBoolean(this.m_memTemp, null, "DownPaymentTalked", false))
				{
					return true;
				}
				MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
				float? num;
				if (current == null)
				{
					num = null;
				}
				else
				{
					Character character = current.character;
					if (character == null)
					{
						num = null;
					}
					else
					{
						CharacterWallet componentEnRoot = character.GetComponentEnRoot<CharacterWallet>();
						num = ((componentEnRoot != null) ? new float?(componentEnRoot.Current("fiat")) : null);
					}
				}
				float? num2 = num;
				return num2.GetValueOrDefault(0f) < 50f;
			}
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0001D008 File Offset: 0x0001B208
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_memPerma = this.GetComponentEnRoot(false);
			if (this.m_memPerma == null)
			{
				throw new ArgumentNullException("m_memPerma", "m_memPerma null reference.");
			}
			this.m_memTemp = this.GetComponentEnRoot(false);
			if (this.m_memTemp == null)
			{
				throw new ArgumentNullException("m_memTemp", "m_memTemp null reference.");
			}
		}

		// Token: 0x0400031C RID: 796
		private MemoriaDeCharacterGeneralPermanente m_memPerma;

		// Token: 0x0400031D RID: 797
		private MemoriaDeCharacterGeneralTemporal m_memTemp;
	}
}
