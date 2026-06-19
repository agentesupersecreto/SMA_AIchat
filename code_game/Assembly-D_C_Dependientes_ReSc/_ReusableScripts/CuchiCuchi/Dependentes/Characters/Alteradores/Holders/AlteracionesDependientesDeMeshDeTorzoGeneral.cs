using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Alteradores;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders
{
	// Token: 0x0200028D RID: 653
	[LabelLocalizado("<i>Mesh:</i> Torzo", "US")]
	public sealed class AlteracionesDependientesDeMeshDeTorzoGeneral : HolderDeAlteradores<AlteradorDeScalaDeBoneDeParte>
	{
		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06001111 RID: 4369 RVA: 0x00014284 File Offset: 0x00012484
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate3;
			}
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x00050720 File Offset: 0x0004E920
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_puppet = this.m_character.GetComponentInChildren<PuppetMaster>();
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x00050770 File Offset: 0x0004E970
		protected override void InstanciarAlteradores(List<AlteradorDeScalaDeBoneDeParte> resultado)
		{
			Animator componentInChildren = this.m_character.GetComponentInChildren<Animator>();
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.none, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Spine02, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBonesMap.spine02_DEF.Get_FullName), this.medidas.spine02MinScala, this.medidas.spine02MaxScala, HumanBodyBones.Chest, 0.33f, false));
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.none, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Spine01, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBonesMap.spine01_DEF.Get_FullName), this.medidas.spine01MinScala, this.medidas.spine01MaxScala, HumanBodyBones.Spine, 0.25f, false));
		}

		// Token: 0x04000C79 RID: 3193
		public AlteracionesDependientesDeMeshDeTorzoGeneral.Medidas medidas = new AlteracionesDependientesDeMeshDeTorzoGeneral.Medidas();

		// Token: 0x04000C7A RID: 3194
		private PuppetMaster m_puppet;

		// Token: 0x04000C7B RID: 3195
		protected Character m_character;

		// Token: 0x0200028E RID: 654
		[Serializable]
		public class Medidas
		{
			// Token: 0x04000C7C RID: 3196
			public Vector3 spine02MinScala = new Vector3(0.9f, 0.99f, 0.95f);

			// Token: 0x04000C7D RID: 3197
			public Vector3 spine02MaxScala = new Vector3(1.03f, 1.01f, 1.05f);

			// Token: 0x04000C7E RID: 3198
			public Vector3 spine01MinScala = new Vector3(0.7f, 0.99f, 0.95f);

			// Token: 0x04000C7F RID: 3199
			public Vector3 spine01MaxScala = new Vector3(1.2f, 1.01f, 1.05f);
		}
	}
}
