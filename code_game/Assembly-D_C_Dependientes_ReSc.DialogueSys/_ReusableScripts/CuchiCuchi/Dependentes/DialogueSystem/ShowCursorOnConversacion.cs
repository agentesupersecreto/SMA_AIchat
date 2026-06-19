using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000021 RID: 33
	public class ShowCursorOnConversacion : OnConversationBase
	{
		// Token: 0x0600011E RID: 286 RVA: 0x000062B6 File Offset: 0x000044B6
		protected void Start()
		{
			this.m_canHideCursor = Singleton<ConfiguracionGeneralDeMouse>.instance.canHideCursorModificableAnd.ObtenerModificadorNotNull(this);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000062CE File Offset: 0x000044CE
		protected void OnDestroy()
		{
			ModificadorDeBool canHideCursor = this.m_canHideCursor;
			if (canHideCursor != null)
			{
				canHideCursor.TryRemoverDeOwner(true);
			}
			this.m_canHideCursor = null;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000062EA File Offset: 0x000044EA
		protected override Transform ObtenerCurrentActor()
		{
			return null;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000062ED File Offset: 0x000044ED
		protected override void OnConversationComienza(Transform currentActor, Transform currentConversant)
		{
			this.m_canHideCursor.valor.valor = false;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00006300 File Offset: 0x00004500
		protected override void OnConversationTermina(Transform currentActor, Transform currentConversant)
		{
			this.m_canHideCursor.valor.valor = true;
		}

		// Token: 0x04000099 RID: 153
		private ModificadorDeBool m_canHideCursor;
	}
}
