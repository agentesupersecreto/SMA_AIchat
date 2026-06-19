using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.AutoRatingProfilesDeGrupos
{
	// Token: 0x0200014D RID: 333
	public class GrupoProfileIndependiente : GrupoProfile
	{
		// Token: 0x14000049 RID: 73
		// (add) Token: 0x060009C0 RID: 2496 RVA: 0x00020688 File Offset: 0x0001E888
		// (remove) Token: 0x060009C1 RID: 2497 RVA: 0x000206C0 File Offset: 0x0001E8C0
		public event Action<GrupoProfile> onNew;

		// Token: 0x060009C2 RID: 2498 RVA: 0x000206F8 File Offset: 0x0001E8F8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_new == null)
			{
				throw new ArgumentNullException("m_new", "m_new null reference.");
			}
			this.m_new.onClick.AddListener(new UnityAction(this.OnNew));
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00020748 File Offset: 0x0001E948
		protected override void UpdateControls()
		{
			base.UpdateControls();
			this.m_remover.gameObject.SetActive(false);
			switch (this.portraitDeGrupo.modo)
			{
			case PortraitDeGrupo.Modo.applyed:
			case PortraitDeGrupo.Modo.notFound:
			case PortraitDeGrupo.Modo.manual:
				this.m_new.gameObject.SetActive(true);
				return;
			case PortraitDeGrupo.Modo.displayOnly:
				this.m_new.gameObject.SetActive(false);
				return;
			}
			throw new ArgumentOutOfRangeException(this.portraitDeGrupo.modo.ToString());
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x000207DA File Offset: 0x0001E9DA
		private void OnNew()
		{
			Action<GrupoProfile> action = this.onNew;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x040003E0 RID: 992
		[SerializeField]
		private Button m_new;
	}
}
