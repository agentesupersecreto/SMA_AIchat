using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.CustomMonoBehaviours.Runtime;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.Spa.Globales
{
	// Token: 0x02000072 RID: 114
	public class ColleccionDeCamillas : InstantiatedSingleton<ColleccionDeCamillas>
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060004E3 RID: 1251 RVA: 0x0001C7FE File Offset: 0x0001A9FE
		public IReadOnlyList<Camilla> camillas
		{
			get
			{
				return this.m_camillas;
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0001C806 File Offset: 0x0001AA06
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_camillaDeId = this.m_camillas.ToDictionary((Camilla c) => c.id);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0001C840 File Offset: 0x0001AA40
		public Camilla GetCamilla(string id, bool updatedGotos)
		{
			Camilla camilla;
			if (this.m_camillaDeId.TryGetValue(id, out camilla))
			{
				if (updatedGotos)
				{
					CamillaGotosPositionsToClientBodyParts componentInChildren = camilla.GetComponentInChildren<CamillaGotosPositionsToClientBodyParts>();
					CamillaBigGotosPositionsToClientBody componentInChildren2 = camilla.GetComponentInChildren<CamillaBigGotosPositionsToClientBody>();
					if (componentInChildren != null)
					{
						componentInChildren.UpdateGOTOs();
					}
					if (componentInChildren2 != null)
					{
						componentInChildren2.UpdateGOTOs();
					}
				}
				return camilla;
			}
			return null;
		}

		// Token: 0x040002EF RID: 751
		[SerializeField]
		private Camilla[] m_camillas;

		// Token: 0x040002F0 RID: 752
		private Dictionary<string, Camilla> m_camillaDeId;
	}
}
