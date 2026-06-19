using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Interacciones.Donas;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Interacciones.Donas
{
	// Token: 0x020000E9 RID: 233
	[Obsolete("usar el nuevo loader")]
	public abstract class LoaderOpcionesDeDonaBase : CustomMonobehaviour
	{
		// Token: 0x17000227 RID: 551
		// (get) Token: 0x060006F1 RID: 1777
		public abstract bool isDrawing { get; }

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060006F2 RID: 1778
		public abstract DonaDeInteraccionBase dona { get; }

		// Token: 0x060006F3 RID: 1779
		public abstract void Show();

		// Token: 0x060006F4 RID: 1780
		public abstract void Hide();

		// Token: 0x060006F5 RID: 1781 RVA: 0x000194A0 File Offset: 0x000176A0
		protected static void LoadFrom(Transform target, List<IOpcionesDeDonaProductor> result)
		{
			try
			{
				target.GetComponents<IOpcionesDeDonaProductor>(LoaderOpcionesDeDonaBase.m_temp3);
				for (int i = 0; i < LoaderOpcionesDeDonaBase.m_temp3.Count; i++)
				{
					IOpcionesDeDonaProductor opcionesDeDonaProductor = LoaderOpcionesDeDonaBase.m_temp3[i];
					Behaviour behaviour = opcionesDeDonaProductor as Behaviour;
					if (!(behaviour != null) || behaviour.isActiveAndEnabled)
					{
						result.Add(opcionesDeDonaProductor);
					}
				}
			}
			finally
			{
				LoaderOpcionesDeDonaBase.m_temp3.Clear();
			}
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00019518 File Offset: 0x00017718
		protected static void LoadFrom(Transform target, ref IOpcionesDeDonaAcceptProductor result)
		{
			try
			{
				if (result == null)
				{
					target.GetComponents<IOpcionesDeDonaAcceptProductor>(LoaderOpcionesDeDonaBase.m_temp4);
					for (int i = 0; i < LoaderOpcionesDeDonaBase.m_temp4.Count; i++)
					{
						IOpcionesDeDonaAcceptProductor opcionesDeDonaAcceptProductor = LoaderOpcionesDeDonaBase.m_temp4[i];
						Behaviour behaviour = opcionesDeDonaAcceptProductor as Behaviour;
						if (!(behaviour != null) || behaviour.isActiveAndEnabled)
						{
							result = opcionesDeDonaAcceptProductor;
							break;
						}
					}
				}
			}
			finally
			{
				LoaderOpcionesDeDonaBase.m_temp4.Clear();
			}
		}

		// Token: 0x040002AA RID: 682
		private static List<IOpcionesDeDonaProductor> m_temp3 = new List<IOpcionesDeDonaProductor>();

		// Token: 0x040002AB RID: 683
		private static List<IOpcionesDeDonaAcceptProductor> m_temp4 = new List<IOpcionesDeDonaAcceptProductor>();
	}
}
