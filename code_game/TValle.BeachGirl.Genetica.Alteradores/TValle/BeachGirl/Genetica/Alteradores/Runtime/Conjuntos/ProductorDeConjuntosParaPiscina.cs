using System;
using System.Collections.Generic;
using Assets.Base.Genetica.Runtime.NPCs.Abstracts.Interfaces;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos
{
	// Token: 0x02000063 RID: 99
	public class ProductorDeConjuntosParaPiscina : AplicableCustomMonobehaviour, IProductorDeConjuntos
	{
		// Token: 0x17000231 RID: 561
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x000110AC File Offset: 0x0000F2AC
		public IReadOnlyDictionary<string, IReadOnlyCollection<object>> conjuntosParaApariencia
		{
			get
			{
				if (!ConjuntosDeAparienciaFisica.integridadChecked)
				{
					ConjuntosDeAparienciaFisica.CheckIntegridad();
				}
				return ConjuntosDeAparienciaFisica.conjuntos;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x000110BF File Offset: 0x0000F2BF
		public IReadOnlyDictionary<string, IReadOnlyCollection<object>> conjuntosParaPersonalidad
		{
			get
			{
				if (!ConjuntosDePersonalidad.integridadChecked)
				{
					ConjuntosDePersonalidad.CheckIntegridad();
				}
				return ConjuntosDePersonalidad.conjuntos;
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000110D2 File Offset: 0x0000F2D2
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Check Integridad"
			};
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x000110E4 File Offset: 0x0000F2E4
		protected override void OnAplicar()
		{
			base.OnAplicar();
			ConjuntosDeAparienciaFisica.CheckIntegridad();
			ConjuntosDePersonalidad.CheckIntegridad();
		}
	}
}
