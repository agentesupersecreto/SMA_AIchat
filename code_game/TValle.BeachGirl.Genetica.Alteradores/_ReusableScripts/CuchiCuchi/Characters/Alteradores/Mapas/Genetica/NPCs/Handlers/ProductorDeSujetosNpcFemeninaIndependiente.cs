using System;
using Assets.Base.Genetica.Runtime.NPCs;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica.NPCs.Handlers
{
	// Token: 0x02000069 RID: 105
	public class ProductorDeSujetosNpcFemeninaIndependiente : CustomMonobehaviour, ISujetoNpcProductor<ISujetoIdentificableNpc>
	{
		// Token: 0x060004CC RID: 1228 RVA: 0x00011510 File Offset: 0x0000F710
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_randomGen = new Random(Guid.NewGuid().GetHashCode());
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00011544 File Offset: 0x0000F744
		public void Init()
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			this.m_piscina = base.GetComponent<IPiscinaManagerDeSujetosBase<ISujetoIdentificableNpc>>();
			if (this.m_piscina == null)
			{
				throw new ArgumentNullException("m_piscina", "m_piscina null reference.");
			}
			if (this.defaultNPC == null)
			{
				throw new ArgumentNullException("@defaultNPC", "@defaultNPC null reference.");
			}
			this.m_DefaultOverrider = base.GetComponent<ISujetoNpcProductorDefaultOverrider>();
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x000115AD File Offset: 0x0000F7AD
		public ISujetoIdentificableNpc ProducirSujetoNpc(bool dummy)
		{
			return ProductorDeSujetosNpcFemenina.ProducirSujetoNpcConOverride(this.defaultNPC, this.m_DefaultOverrider, this.m_randomGen, this.m_piscina.ID, dummy, this);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x000115D3 File Offset: 0x0000F7D3
		public ISujetoIdentificableNpc ProducirSujetoNpc(TipoDeRandomizadoParaSujeto tipoDeRandomizadoApariencia, TipoDeRandomizadoParaSujeto tipoDeRandomizadoPersonalidad, bool dummy)
		{
			return ProductorDeSujetosNpcFemenina.ProducirSujetoNpcConOverride(tipoDeRandomizadoApariencia, tipoDeRandomizadoPersonalidad, this.defaultNPC, this.m_DefaultOverrider, this.m_randomGen, this.m_piscina.ID, dummy, this);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x000115FB File Offset: 0x0000F7FB
		[Obsolete("", true)]
		public ISujetoIdentificable ProducirSujetoApariencia(bool dummy)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00011602 File Offset: 0x0000F802
		[Obsolete("", true)]
		public ISujetoIdentificable ProducirSujetoPersonalidad(bool dummy)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00011609 File Offset: 0x0000F809
		ISujetoIdentificableNpc ISujetoNpcProductor<ISujetoIdentificableNpc>.DeepInstantiate(ISujetoIdentificableNpc original)
		{
			return ProductorDeSujetosNpcFemenina.DeepInstantiate(original);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00011614 File Offset: 0x0000F814
		public void DestriurSujetoNpc(Object posibleSujeto)
		{
			if (posibleSujeto == null)
			{
				return;
			}
			if (TValleEditorTools.IsPersistent(posibleSujeto))
			{
				return;
			}
			ISujetoIdentificableNpc sujetoIdentificableNpc = posibleSujeto as ISujetoIdentificableNpc;
			if (sujetoIdentificableNpc == null)
			{
				return;
			}
			sujetoIdentificableNpc.Destruir();
		}

		// Token: 0x04000229 RID: 553
		public SujetoIdentificableNpcAlteradoresFemeninos defaultNPC;

		// Token: 0x0400022A RID: 554
		private ISujetoNpcProductorDefaultOverrider m_DefaultOverrider;

		// Token: 0x0400022B RID: 555
		private Random m_randomGen;

		// Token: 0x0400022C RID: 556
		private IPiscinaManagerDeSujetosBase<ISujetoIdentificableNpc> m_piscina;
	}
}
