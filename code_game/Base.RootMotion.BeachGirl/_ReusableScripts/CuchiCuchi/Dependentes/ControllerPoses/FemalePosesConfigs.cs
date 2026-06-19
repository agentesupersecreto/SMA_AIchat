using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.ControllerPoses
{
	// Token: 0x020000C8 RID: 200
	public sealed class FemalePosesConfigs : Singleton<FemalePosesConfigs>
	{
		// Token: 0x06000748 RID: 1864 RVA: 0x00023160 File Offset: 0x00021360
		protected override void InitData(bool esEditorTime)
		{
			foreach (ConfiguracionDePoscionSexual configuracionDePoscionSexual in this.m_configuracionesDePose)
			{
				if (!this.m_ConfigDePose.ContainsKey((int)configuracionDePoscionSexual.pose))
				{
					this.m_ConfigDePose.Add((int)configuracionDePoscionSexual.pose, configuracionDePoscionSexual);
				}
				else
				{
					Debug.LogError("id de pose repetida: " + configuracionDePoscionSexual.pose.ToString(), this);
				}
			}
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x000231F4 File Offset: 0x000213F4
		public bool ContieneConfig(TipoDePose pose)
		{
			return this.m_ConfigDePose.ContainsKey((int)pose);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00023204 File Offset: 0x00021404
		public ConfiguracionDePoscionSexual GetConfig(TipoDePose pose)
		{
			ConfiguracionDePoscionSexual configuracionDePoscionSexual;
			if (this.m_ConfigDePose.TryGetValue((int)pose, out configuracionDePoscionSexual))
			{
				return configuracionDePoscionSexual;
			}
			throw new InvalidOperationException("no existe posicion sexual con id: " + pose.ToString());
		}

		// Token: 0x040004EC RID: 1260
		private Dictionary<int, ConfiguracionDePoscionSexual> m_ConfigDePose = new Dictionary<int, ConfiguracionDePoscionSexual>();

		// Token: 0x040004ED RID: 1261
		[SerializeField]
		[CoolArrayItem]
		private List<ConfiguracionDePoscionSexual> m_configuracionesDePose;
	}
}
