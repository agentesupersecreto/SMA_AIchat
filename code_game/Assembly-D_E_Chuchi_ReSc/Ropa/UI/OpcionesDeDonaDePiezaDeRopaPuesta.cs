using System;
using Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa.UI
{
	// Token: 0x0200013E RID: 318
	[Obsolete("usar la version para THS")]
	public class OpcionesDeDonaDePiezaDeRopaPuesta : GenericOpcionesDeDonaDeKeys<string, OpcionesDeDonaDePiezaDeRopaPuesta.CurrentClicked>
	{
		// Token: 0x0600074E RID: 1870 RVA: 0x000225E5 File Offset: 0x000207E5
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_manager = this.GetComponentEnRoot(false);
			if (this.m_manager == null)
			{
				throw new ArgumentNullException("m_manager", "m_manager null reference.");
			}
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00022612 File Offset: 0x00020812
		protected override void LoadKeys(HashSetList<string> resultado)
		{
			this.m_manager.ObtenerPiezasIDs(resultado, false);
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00022624 File Offset: 0x00020824
		public override string TextDeKey(string key)
		{
			string nombreCorto;
			try
			{
				nombreCorto = this.m_manager.ObtenerMapa().ObtenerData(key).nombreCorto;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return nombreCorto;
		}

		// Token: 0x040005CA RID: 1482
		private IRopaManager m_manager;

		// Token: 0x0200013F RID: 319
		[Serializable]
		public class CurrentClicked : OpcionesDeDonaCurrentClickedKey<string>
		{
			// Token: 0x040005CB RID: 1483
			public bool puedeDesvestirse = true;
		}
	}
}
