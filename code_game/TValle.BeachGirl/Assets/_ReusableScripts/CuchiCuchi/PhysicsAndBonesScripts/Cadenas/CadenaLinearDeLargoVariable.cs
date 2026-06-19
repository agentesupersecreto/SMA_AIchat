using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Puntos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Cadenas
{
	// Token: 0x02000113 RID: 275
	public sealed class CadenaLinearDeLargoVariable : LinearChainTipo2<PuntoGenerico, PuntoGenerico.Configuracion>
	{
		// Token: 0x06000C1F RID: 3103 RVA: 0x00029160 File Offset: 0x00027360
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_boneRoot == null)
			{
				throw new ArgumentNullException("m_boneRoot", "m_boneRoot null reference.");
			}
			if (this.m_ChainTrarsforms.Count <= 0 || this.m_ChainTrarsforms.Contains(this.m_boneRoot))
			{
				throw new InvalidOperationException();
			}
			this.LoadPuntos();
			base.StartPoints();
			base.LoadRootScaleChager();
			base.StartRootScaleChager();
			base.FixPointsEnOrdenAsc();
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x000291D6 File Offset: 0x000273D6
		protected override void OnRootScaleChanged(object target)
		{
			base.OnRootScaleChanged(target);
			base.CorrectChainTransform(false);
			base.FixPointsEnOrdenAsc();
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06000C21 RID: 3105 RVA: 0x000291EC File Offset: 0x000273EC
		public override Transform puntoBaseTransform
		{
			get
			{
				return this.m_boneRoot;
			}
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06000C22 RID: 3106 RVA: 0x000291F4 File Offset: 0x000273F4
		public override int cantidadDePuntos
		{
			get
			{
				return this.m_ChainTrarsforms.Count;
			}
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x00029201 File Offset: 0x00027401
		protected override Transform GetCharBoneTargetTransformOfPoint(int index)
		{
			return this.m_ChainTrarsforms[index];
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x0002920F File Offset: 0x0002740F
		protected override Transform GetJointTransformOfPoint(int index)
		{
			return this.m_ChainTrarsforms[index];
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x0002921D File Offset: 0x0002741D
		protected override Transform GetTargetBodyTransformOfPoint(int index)
		{
			if (index == 0)
			{
				return this.m_boneRoot;
			}
			return this.m_ChainTrarsforms[index - 1];
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x00029237 File Offset: 0x00027437
		protected override Transform GetTargetBodyTransformOfRootPoint()
		{
			return null;
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x0002923A File Offset: 0x0002743A
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Reset Configuraciones",
				playTimeVisible = false
			};
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x00029253 File Offset: 0x00027453
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.puntosConfig = new PuntoGenerico.Configuracion();
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x00029266 File Offset: 0x00027466
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "ReAplicar Configuracion",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x0002927F File Offset: 0x0002747F
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			if (this.correctChainTransformOnScaleChange)
			{
				base.CorrectChainTransform(false);
			}
			base.FixPointsEnOrdenAsc();
		}

		// Token: 0x04000694 RID: 1684
		[Tooltip("puede generar glitches")]
		public bool correctChainTransformOnScaleChange = true;

		// Token: 0x04000695 RID: 1685
		[SerializeField]
		private Transform m_boneRoot;

		// Token: 0x04000696 RID: 1686
		[SerializeField]
		[CoolArrayItem]
		private List<Transform> m_ChainTrarsforms = new List<Transform>();
	}
}
