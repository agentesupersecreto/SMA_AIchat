using System;
using Assets.Base.BeachGirl.Mapas.Runtime;
using Assets.Base.Bones.Runtime.V2.ConstraintsV2.Users;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Constraints.Penes
{
	// Token: 0x020000AA RID: 170
	public class PeneMaleConstraintsAdder : StandaloneConstraintsAdder
	{
		// Token: 0x06000525 RID: 1317 RVA: 0x00010670 File Offset: 0x0000E870
		protected override void OnInit()
		{
			PenisBoneMap penisBoneMap = Singleton<MapasDeHuesos>.instance.mapas.penisBoneMap;
			MapaSingletonDeMaleGuiasBody instance = MapaSingleton<MapaSingletonDeMaleGuiasBody>.instance;
			ICharacter componentEnRoot = this.GetComponentEnRoot(false);
			string penisRoot = penisBoneMap.penisRoot;
			Transform transform = componentEnRoot.transform.FindDeepChild(penisRoot, true);
			if (transform == null)
			{
				transform = componentEnRoot.transform.FindDeepChildEndsWith(penisRoot, true);
			}
			Transform transform2 = componentEnRoot.transform.FindDeepChild(instance.penisPoint, true);
			base.Create<ChildOfGuiaUser>(ref this.baseDePene, penisRoot);
			this.baseDePene.SetReferences(transform, transform2);
		}

		// Token: 0x0400030A RID: 778
		public ChildOfGuiaUser baseDePene;
	}
}
