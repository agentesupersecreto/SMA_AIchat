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
	// Token: 0x02000284 RID: 644
	[LabelLocalizado("<i>Mesh:</i> Arms 1", "US")]
	public sealed class AlteracionesDependientesDeMeshDeBrazosGeneral : HolderDualDeAlteradores<AlteradorDeScalaDeBoneDualDeParte, AlteradorDeScalaDeBoneDeParte>
	{
		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x060010E8 RID: 4328 RVA: 0x00014284 File Offset: 0x00012484
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate3;
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x060010E9 RID: 4329 RVA: 0x0004FC3C File Offset: 0x0004DE3C
		protected override GlobalUpdater.UpdateType? updateTypeB
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x0004FC54 File Offset: 0x0004DE54
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

		// Token: 0x060010EB RID: 4331 RVA: 0x0004FCA4 File Offset: 0x0004DEA4
		protected override void InstanciarAlteradores(List<AlteradorDeScalaDeBoneDualDeParte> resultado)
		{
			Animator componentInChildren = this.m_character.GetComponentInChildren<Animator>();
			resultado.Add(this.ProducirDualParte(this.m_puppet, componentInChildren, Side.L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BrazoSuperior_L, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBodyConstaintsBonesNamesMap.upperarmTwist01.Get_FullName), new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBonesMap.clavicleDEF.Get_FullName), this.escalas.brazosMinScala, this.escalas.brazosMaxScala, Vector3.right, HumanBodyBones.LeftUpperArm, 1f));
			resultado.Add(this.ProducirDualParte(this.m_puppet, componentInChildren, Side.R, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BrazoSuperior_R, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBodyConstaintsBonesNamesMap.upperarmTwist01.Get_FullName), new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBonesMap.clavicleDEF.Get_FullName), this.escalas.brazosMinScala, this.escalas.brazosMaxScala, Vector3.right, HumanBodyBones.RightUpperArm, 1f));
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x0004FDB0 File Offset: 0x0004DFB0
		protected override void InstanciarAlteradoresB(List<AlteradorDeScalaDeBoneDeParte> resultado)
		{
			Animator componentInChildren = this.m_character.GetComponentInChildren<Animator>();
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AnteBrazoSuperior_L, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBodyConstaintsBonesNamesMap.forearmTwist01.Get_FullName), this.escalas.brazosMinScala, this.escalas.brazosMaxScala, HumanBodyBones.LeftLowerArm, 1f, false));
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.R, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AnteBrazoSuperior_R, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBodyConstaintsBonesNamesMap.forearmTwist01.Get_FullName), this.escalas.brazosMinScala, this.escalas.brazosMaxScala, HumanBodyBones.RightLowerArm, 1f, false));
		}

		// Token: 0x04000C61 RID: 3169
		public AlteracionesDependientesDeMeshDeBrazosGeneral.Escalas escalas = new AlteracionesDependientesDeMeshDeBrazosGeneral.Escalas();

		// Token: 0x04000C62 RID: 3170
		private PuppetMaster m_puppet;

		// Token: 0x04000C63 RID: 3171
		protected Character m_character;

		// Token: 0x02000285 RID: 645
		[Serializable]
		public class Escalas
		{
			// Token: 0x04000C64 RID: 3172
			public Vector3 brazosMinScala = new Vector3(0.7f, 0.7f, 1f);

			// Token: 0x04000C65 RID: 3173
			public Vector3 brazosMaxScala = new Vector3(1.175f, 1.175f, 1f);
		}
	}
}
