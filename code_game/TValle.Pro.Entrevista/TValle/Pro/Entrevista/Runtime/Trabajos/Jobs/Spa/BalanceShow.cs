using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets._ReusableScripts.CuchiCuchi;
using TMPro;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.Spa
{
	// Token: 0x0200006C RID: 108
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class BalanceShow : CustomMonobehaviour
	{
		// Token: 0x060004C9 RID: 1225 RVA: 0x0001C344 File Offset: 0x0001A544
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_TextMeshProUGUI = base.GetComponent<TextMeshProUGUI>();
			this.m_CoroutineCapsule = new CoroutineCapsule(this.UpdateBalnceUIRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0001C37D File Offset: 0x0001A57D
		private IEnumerator UpdateBalnceUIRutine()
		{
			WaitForSeconds w = new WaitForSeconds(0.5f);
			for (;;)
			{
				yield return w;
				JobsManager jobsManager = (AsyncSingleton<JobsManager>.IsInScene ? AsyncSingleton<JobsManager>.instance : null);
				if (Singleton<CharacteresActivos>.IsInScene && ((jobsManager != null) ? jobsManager.current : null) != null && !jobsManager.isloadingJob && jobsManager.current.mainPlayerCharacter != null)
				{
					Guid id = jobsManager.current.mainPlayerCharacter.ID;
					if (Singleton<CharacteresActivos>.instance.Obtener(id) != null)
					{
						CharacterWallet characterWallet = Singleton<CharacteresActivos>.instance.FindSingleCachedComponent<CharacterWallet>(id, false);
						if (characterWallet != null)
						{
							float num = characterWallet.Current("fiat");
							this.m_TextMeshProUGUI.text = "Balance: " + num.ToString("C0");
							continue;
						}
					}
				}
				this.m_TextMeshProUGUI.text = "Balance: " + 0f.ToString("C");
			}
			yield break;
		}

		// Token: 0x040002BB RID: 699
		private TextMeshProUGUI m_TextMeshProUGUI;

		// Token: 0x040002BC RID: 700
		private CoroutineCapsule m_CoroutineCapsule;
	}
}
