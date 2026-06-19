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
	// Token: 0x02000287 RID: 647
	[LabelLocalizado("<i>Mesh:</i> Head 2", "US")]
	public sealed class AlteracionesDependientesDeMeshDeCabezaGeneral : HolderDeAlteradores<AlteradorDeScalaDeBoneDeParte>
	{
		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06001102 RID: 4354 RVA: 0x00050212 File Offset: 0x0004E412
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.onAI3;
			}
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x00050218 File Offset: 0x0004E418
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

		// Token: 0x06001104 RID: 4356 RVA: 0x00050268 File Offset: 0x0004E468
		protected override void InstanciarAlteradores(List<AlteradorDeScalaDeBoneDeParte> resultado)
		{
			Animator componentInChildren = this.m_character.GetComponentInChildren<Animator>();
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.none, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Cabeza, new Func<Side, string>(Singleton<MapasDeHuesos>.instance.mapas.femaleBonesMap.neck01.Get_FullName), this.escalas.headMinScala, this.escalas.headMaxScala, HumanBodyBones.Head, this.escalas.headMuscleMod, true));
		}

		// Token: 0x04000C67 RID: 3175
		public AlteracionesDependientesDeMeshDeCabezaGeneral.Escalas escalas = new AlteracionesDependientesDeMeshDeCabezaGeneral.Escalas();

		// Token: 0x04000C68 RID: 3176
		private PuppetMaster m_puppet;

		// Token: 0x04000C69 RID: 3177
		protected Character m_character;

		// Token: 0x02000288 RID: 648
		[Serializable]
		public class Escalas
		{
			// Token: 0x04000C6A RID: 3178
			public Vector3 headMinScala = new Vector3(0.9f, 0.9f, 0.9f);

			// Token: 0x04000C6B RID: 3179
			public Vector3 headMaxScala = new Vector3(1.07f, 1.07f, 1.07f);

			// Token: 0x04000C6C RID: 3180
			public float headMuscleMod = 0.5f;
		}
	}
}
