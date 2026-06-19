using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Alteradores;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders
{
	// Token: 0x02000289 RID: 649
	[LabelLocalizado("<i>Mesh:</i> Hands", "US")]
	public sealed class AlteracionesDependientesDeMeshDeManosGeneral : HolderDeAlteradores<AlteradorDeScalaDeBoneDeParte>
	{
		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06001107 RID: 4359 RVA: 0x00014284 File Offset: 0x00012484
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate3;
			}
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x00050344 File Offset: 0x0004E544
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

		// Token: 0x06001109 RID: 4361 RVA: 0x00050394 File Offset: 0x0004E594
		protected override void InstanciarAlteradores(List<AlteradorDeScalaDeBoneDeParte> resultado)
		{
			Animator componentInChildren = this.m_character.GetComponentInChildren<Animator>();
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Mano_L, this.escalas.piesManosMinScala, this.escalas.piesManosMaxScala, HumanBodyBones.LeftHand, 1f));
			resultado.Add(this.ProducirParte(this.m_puppet, componentInChildren, Side.R, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Mano_R, this.escalas.piesManosMinScala, this.escalas.piesManosMaxScala, HumanBodyBones.RightHand, 1f));
		}

		// Token: 0x04000C6D RID: 3181
		public AlteracionesDependientesDeMeshDeManosGeneral.Escalas escalas = new AlteracionesDependientesDeMeshDeManosGeneral.Escalas();

		// Token: 0x04000C6E RID: 3182
		private PuppetMaster m_puppet;

		// Token: 0x04000C6F RID: 3183
		protected Character m_character;

		// Token: 0x0200028A RID: 650
		[Serializable]
		public class Escalas
		{
			// Token: 0x04000C70 RID: 3184
			public Vector3 piesManosMinScala = new Vector3(0.88f, 0.88f, 0.88f);

			// Token: 0x04000C71 RID: 3185
			public Vector3 piesManosMaxScala = new Vector3(1.1f, 1.1f, 1.1f);
		}
	}
}
