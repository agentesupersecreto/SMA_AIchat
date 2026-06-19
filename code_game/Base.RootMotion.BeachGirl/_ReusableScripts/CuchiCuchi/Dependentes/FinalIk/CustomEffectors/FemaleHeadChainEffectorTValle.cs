using System;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors
{
	// Token: 0x020000C5 RID: 197
	public sealed class FemaleHeadChainEffectorTValle : HeadChainEffectorTValle
	{
		// Token: 0x06000732 RID: 1842 RVA: 0x00022B80 File Offset: 0x00020D80
		protected override void AwakeUnityEvent()
		{
			Animator bodyAnimator = base.GetComponentInParent<ICharacter>().bodyAnimator;
			this.cuello1.bone = bodyAnimator.transform.FindDeepChild(MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerNombreDeHueso(this.cuello1Name), this.cuello1Name, true);
			this.cuello2.bone = bodyAnimator.transform.FindDeepChild(MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerNombreDeHueso(this.cuello2Name), this.cuello2Name, true);
			this.head.bone = bodyAnimator.transform.FindDeepChild(MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerNombreDeHueso(this.headName), this.headName, true);
			this.cuello2.rootBone = (this.cuello1.rootBone = (this.head.rootBone = bodyAnimator.transform.FindDeepChild(MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerNombreDeHueso(this.rootBone), this.rootBone, true)));
			base.AwakeUnityEvent();
		}

		// Token: 0x040004D9 RID: 1241
		[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
		public string cuello1Name;

		// Token: 0x040004DA RID: 1242
		[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
		public string cuello2Name;

		// Token: 0x040004DB RID: 1243
		[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
		public string headName;

		// Token: 0x040004DC RID: 1244
		[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
		[Tooltip("el spine mas alto")]
		public string rootBone;
	}
}
