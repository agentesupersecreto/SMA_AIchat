using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins.ArmaduresSkins;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Skins
{
	// Token: 0x02000068 RID: 104
	public class GenericFemaleArmatureSkinsClasificada : ArmatureSkinsClasificada
	{
		// Token: 0x060001D2 RID: 466 RVA: 0x000042BC File Offset: 0x000024BC
		protected override void PoblarPartes(ArmatureSkinsClasificada.SkinPartes skinPartes, List<Skin> Skins, List<SkinnedMeshRenderer> mainRenderers)
		{
			MapaSingletonDeFemaleMainSkinsConfig instance = MapaSingleton<MapaSingletonDeFemaleMainSkinsConfig>.instance;
			this.FindSkinAndAdd(instance.head.ObtenerSkinName(), ref skinPartes.head, Skins);
			this.FindSkinAndAdd(instance.body.ObtenerSkinName(), ref skinPartes.body, Skins);
			this.FindSkinAndAdd(instance.scalp.ObtenerSkinName(), ref skinPartes.scalp, Skins);
			this.FindSkinAndAdd(instance.cejas.ObtenerSkinName(), ref skinPartes.cejas, Skins);
			this.FindSkinAndAdd(instance.ojos.ObtenerSkinName(), ref skinPartes.ojos, Skins);
			this.FindSkinAndAdd(instance.lengua.ObtenerSkinName(), ref skinPartes.lengua, Skins);
			this.FindSkinAndAdd(instance.dientes.ObtenerSkinName(), ref skinPartes.dientes, Skins);
			this.FindSkinAndAdd(instance.pesones.ObtenerSkinName(), ref skinPartes.pesones, Skins);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00004390 File Offset: 0x00002590
		private void FindSkinAndAdd(string name, ref Skin r, List<Skin> Skins)
		{
			Skin skin = Skins.FirstOrDefault((Skin sk) => sk.name == name);
			r = skin;
		}
	}
}
