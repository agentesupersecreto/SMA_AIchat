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
	// Token: 0x0200028B RID: 651
	[LabelLocalizado("<i>Mesh:</i> Legs 1", "US")]
	public sealed class AlteracionesDependientesDeMeshDePiernasGeneral : HolderDeAlteradores<AlteradorDeScalaDeBoneDeParte>
	{
		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x0600110C RID: 4364 RVA: 0x00014284 File Offset: 0x00012484
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate3;
			}
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x00050468 File Offset: 0x0004E668
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

		// Token: 0x0600110E RID: 4366 RVA: 0x000504B8 File Offset: 0x0004E6B8
		protected override void InstanciarAlteradores(List<AlteradorDeScalaDeBoneDeParte> resultado)
		{
			Animator componentInChildren = this.m_character.GetComponentInChildren<Animator>();
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaSuperior_L, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBodyConstaintsBonesNamesMap.thighTwist01.Get_FullName), this.medidas.piernasMinScala, this.medidas.piernasMaxScala, HumanBodyBones.LeftUpperLeg, 1f, false));
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.R, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaSuperior_R, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBodyConstaintsBonesNamesMap.thighTwist01.Get_FullName), this.medidas.piernasMinScala, this.medidas.piernasMaxScala, HumanBodyBones.RightUpperLeg, 1f, false));
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CanillaSuperior_L, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBodyConstaintsBonesNamesMap.calfTwist01.Get_FullName), this.medidas.piernasMinScala, this.medidas.piernasMaxScala, HumanBodyBones.LeftLowerLeg, 1f, false));
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.R, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CanillaSuperior_R, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBodyConstaintsBonesNamesMap.calfTwist01.Get_FullName), this.medidas.piernasMinScala, this.medidas.piernasMaxScala, HumanBodyBones.RightLowerLeg, 1f, false));
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Pie_L, this.medidas.piesManosMinScala, this.medidas.piesManosMaxScala, HumanBodyBones.LeftFoot, 1f));
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.R, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Pie_R, this.medidas.piesManosMinScala, this.medidas.piesManosMaxScala, HumanBodyBones.RightFoot, 1f));
		}

		// Token: 0x04000C72 RID: 3186
		public AlteracionesDependientesDeMeshDePiernasGeneral.Medidas medidas = new AlteracionesDependientesDeMeshDePiernasGeneral.Medidas();

		// Token: 0x04000C73 RID: 3187
		private PuppetMaster m_puppet;

		// Token: 0x04000C74 RID: 3188
		protected Character m_character;

		// Token: 0x0200028C RID: 652
		[Serializable]
		public class Medidas
		{
			// Token: 0x04000C75 RID: 3189
			public Vector3 piernasMinScala = new Vector3(0.75f, 0.75f, 1f);

			// Token: 0x04000C76 RID: 3190
			public Vector3 piernasMaxScala = new Vector3(1.2f, 1.2f, 1f);

			// Token: 0x04000C77 RID: 3191
			public Vector3 piesManosMinScala = new Vector3(0.88f, 0.88f, 0.88f);

			// Token: 0x04000C78 RID: 3192
			public Vector3 piesManosMaxScala = new Vector3(1.1f, 1.1f, 1.1f);
		}
	}
}
