using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders
{
	// Token: 0x0200028F RID: 655
	[LabelLocalizado("<i>Mesh:</i> Body 2", "US")]
	public sealed class AlteracionesDependientesDeMeshGeneral : HolderDeAlteradores<AlteradorDeScalaDeBoneDual>
	{
		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06001116 RID: 4374 RVA: 0x00014284 File Offset: 0x00012484
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate3;
			}
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x000508C4 File Offset: 0x0004EAC4
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

		// Token: 0x06001118 RID: 4376 RVA: 0x00050914 File Offset: 0x0004EB14
		protected override void InstanciarAlteradores(List<AlteradorDeScalaDeBoneDual> resultado)
		{
			Transform rootBoneTransform = this.m_character.rootBoneTransform;
			string scala_Puppet = DiccionarioDeNombresDeAlteradoresFemeninos.Scala_Puppet;
			Transform transform = rootBoneTransform;
			PuppetMaster puppet = this.m_puppet;
			AlteradorDeScalaDeBoneDual alteradorDeScalaDeBoneDual = new AlteradorDeScalaDeBoneDual(scala_Puppet, this, transform, (puppet != null) ? puppet.transform : null, this.escalas.minScalaPuppet, this.escalas.maxScalaPuppet, Vector3.one);
			resultado.Add(alteradorDeScalaDeBoneDual);
		}

		// Token: 0x04000C80 RID: 3200
		public AlteracionesDependientesDeMeshGeneral.Escalas escalas = new AlteracionesDependientesDeMeshGeneral.Escalas();

		// Token: 0x04000C81 RID: 3201
		private PuppetMaster m_puppet;

		// Token: 0x04000C82 RID: 3202
		private Character m_character;

		// Token: 0x02000290 RID: 656
		[Serializable]
		public class Escalas
		{
			// Token: 0x04000C83 RID: 3203
			public Vector3 minScalaPuppet = Vector3.one * 0.7777778f;

			// Token: 0x04000C84 RID: 3204
			public Vector3 maxScalaPuppet = Vector3.one * 1.2f;
		}
	}
}
