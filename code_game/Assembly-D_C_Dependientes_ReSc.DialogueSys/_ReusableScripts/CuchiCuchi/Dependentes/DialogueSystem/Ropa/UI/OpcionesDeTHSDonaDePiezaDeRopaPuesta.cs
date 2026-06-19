using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.CuchiCuchi.Ropa;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.UI
{
	// Token: 0x02000034 RID: 52
	public abstract class OpcionesDeTHSDonaDePiezaDeRopaPuesta : GenericOpcionesDeTHSDonaDeKeys<string>
	{
		// Token: 0x0600017E RID: 382 RVA: 0x00007AFC File Offset: 0x00005CFC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_manager = this.GetComponentEnRoot(false);
			if (this.m_manager == null)
			{
				throw new ArgumentNullException("m_manager", "m_manager null reference.");
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00007B29 File Offset: 0x00005D29
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			base.OnDonaShowed(currentUserData, sender);
			this.puedeDesvestirse = true;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00007B3A File Offset: 0x00005D3A
		protected override void LoadKeys(HashSetList<string> resultado)
		{
			this.m_manager.ObtenerPiezasIDs(resultado, false);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00007B4C File Offset: 0x00005D4C
		protected override string TextDeKey(string key)
		{
			string nombreCorto;
			try
			{
				nombreCorto = AsyncSingleton<RopaParaAvatarUnificado>.instance.ObtenerData(key).nombreCorto;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return nombreCorto;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00007B80 File Offset: 0x00005D80
		protected override string KeyDeItemKey(string key, int index)
		{
			return this.m_dibujando[index];
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00007B8E File Offset: 0x00005D8E
		protected override string KeyDeIndex(int index)
		{
			return this.m_dibujando[index].ToString();
		}

		// Token: 0x040000C6 RID: 198
		private IRopaManager m_manager;

		// Token: 0x040000C7 RID: 199
		public bool puedeDesvestirse = true;
	}
}
