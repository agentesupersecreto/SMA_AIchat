using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Estimulos.Sonidos.Inicializadores
{
	// Token: 0x020000AE RID: 174
	[RequireComponent(typeof(IReproductorDeSonidoDeToques))]
	public class InicializadorDeHitSkinReproductor : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060003BB RID: 955 RVA: 0x0000E05C File Offset: 0x0000C25C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			base.GetComponent<IReproductorDeSonidoDeToques>().TrySetEstimulables(this.paraHitSkins, this.paraEmulatedHitSkins, this.paraPadre);
		}

		// Token: 0x040002C4 RID: 708
		public bool paraPadre;

		// Token: 0x040002C5 RID: 709
		public List<HitPartEnum> paraHitSkins = new List<HitPartEnum>();

		// Token: 0x040002C6 RID: 710
		public List<BodyPartEnum> paraEmulatedHitSkins = new List<BodyPartEnum>();

		// Token: 0x040002C7 RID: 711
		[Header("DEbuging")]
		public RerpoductorHitSkinsTouchParaManyHelpler.TipoDeHitSkinsDebug usarDebug;
	}
}
