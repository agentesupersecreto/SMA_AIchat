using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers.GoTo;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.Spa
{
	// Token: 0x0200006D RID: 109
	public class Camilla : CustomMonobehaviour
	{
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x0001C394 File Offset: 0x0001A594
		public string id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0001C39C File Offset: 0x0001A59C
		public IReadOnlyList<GoToTarget> gotos
		{
			get
			{
				return this.m_gotos;
			}
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0001C3A4 File Offset: 0x0001A5A4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_gotos = base.GetComponentsInChildren<GoToTarget>();
			this.m_gotoDeID = this.m_gotos.ToDictionary((GoToTarget g) => g.data.Id);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0001C3F4 File Offset: 0x0001A5F4
		public GoToTarget GetGoTo(string id)
		{
			GoToTarget goToTarget;
			if (this.m_gotoDeID.TryGetValue(id, out goToTarget))
			{
				return goToTarget;
			}
			return null;
		}

		// Token: 0x040002BD RID: 701
		[SerializeField]
		private string m_id;

		// Token: 0x040002BE RID: 702
		[ReadOnlyUI]
		[SerializeField]
		private GoToTarget[] m_gotos;

		// Token: 0x040002BF RID: 703
		private Dictionary<string, GoToTarget> m_gotoDeID;
	}
}
