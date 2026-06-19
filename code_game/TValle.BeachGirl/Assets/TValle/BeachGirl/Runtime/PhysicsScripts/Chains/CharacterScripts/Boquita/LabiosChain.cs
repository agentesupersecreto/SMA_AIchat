using System;
using System.Collections.Generic;
using Assets.Base.BeachGirl.Mapas.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.Abstracts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x0200008D RID: 141
	public sealed class LabiosChain : LinearBoneChain<LabioPoint, LabioPoint.Configuracion>
	{
		// Token: 0x170001AD RID: 429
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x0000C436 File Offset: 0x0000A636
		public bool usandoLabioToLabio
		{
			get
			{
				return this.m_usarLabioToLabio;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x0000C43E File Offset: 0x0000A63E
		[Obsolete("", true)]
		public IReadOnlyDictionary<string, LabioToLabioJoint> labioToLabiosPorNombre
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x0000C445 File Offset: 0x0000A645
		public IReadOnlyList<LabioToLabioJoint> labioToLabios
		{
			get
			{
				return this.m_labioToLabios;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x0000C44D File Offset: 0x0000A64D
		public ModificadorDeDriversDeJoint suavizadorDeLabioToLabio
		{
			get
			{
				return this.m_suavizadorDeLabioToLabio;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0000C455 File Offset: 0x0000A655
		public override int cantidadDePuntos
		{
			get
			{
				return 8;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x0000C458 File Offset: 0x0000A658
		public override Transform boneRoot
		{
			get
			{
				return this.m_boneRoot;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000C460 File Offset: 0x0000A660
		public IReadOnlyList<Collider> allColliders
		{
			get
			{
				return this.m_colliders;
			}
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0000C468 File Offset: 0x0000A668
		protected override void AwakeUnityEvent()
		{
			this.m_worldScale = base.transform.lossyScale.Escala();
			this.colliderConfig.material = Singleton<ColecionDePhysicsMaterials>.instance.labios;
			base.AwakeUnityEvent();
			string labiosRoot = MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabiosRoot;
			this.m_boneRoot = base.transform.FindDeepChild(labiosRoot, true);
			this.m_BocaHole = base.GetComponentInChildren<BocaHole>();
			if (this.m_BocaHole == null)
			{
				throw new ArgumentNullException("m_BocaHole", "m_BocaHole null reference.");
			}
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0000C4F0 File Offset: 0x0000A6F0
		protected override void StartUnityEvent()
		{
			this.m_suavizadorDeLabioToLabio = new ModificadorDeDriversDeJoint("LabioToLabioMod_General");
			base.StartUnityEvent();
			base.CorrectChainTransform(true);
			for (int i = 0; i < this.cantidadDePuntos; i++)
			{
				Transform charBoneTargetTransformOfPoint = this.GetCharBoneTargetTransformOfPoint(i);
				charBoneTargetTransformOfPoint.localScale = Vector3.one;
				charBoneTargetTransformOfPoint.Copy(this.GetInnerNameProxys(i));
			}
			base.LoadPuntos();
			base.StartPoints();
			base.LoadRootScaleChager();
			base.FixPoints();
			this.m_colliders = this.currentChildColliders;
			this.m_EstadoDePuntos.posicionesLocalesIniciales.Actializar();
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0000C580 File Offset: 0x0000A780
		private string GetOutterName(int index)
		{
			switch (index)
			{
			case 0:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutUp;
			case 1:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutUp_L;
			case 2:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutSide_L;
			case 3:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutDown_L;
			case 4:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutDown;
			case 5:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutDown_R;
			case 6:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutSide_R;
			case 7:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutUp_R;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0000C61C File Offset: 0x0000A81C
		private string GetInnerName(int index)
		{
			switch (index)
			{
			case 0:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInUp;
			case 1:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInUp_L;
			case 2:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInSide_L;
			case 3:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInDown_L;
			case 4:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInDown;
			case 5:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInDown_R;
			case 6:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInSide_R;
			case 7:
				return MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInUp_R;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000C6B8 File Offset: 0x0000A8B8
		private string GetInnerNameProxys(int index)
		{
			switch (index)
			{
			case 0:
				return "PHYSCIS_" + MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInUp;
			case 1:
				return "PHYSCIS_" + MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInUp_L;
			case 2:
				return "PHYSCIS_" + MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInSide_L;
			case 3:
				return "PHYSCIS_" + MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInDown_L;
			case 4:
				return "PHYSCIS_" + MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInDown;
			case 5:
				return "PHYSCIS_" + MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInDown_R;
			case 6:
				return "PHYSCIS_" + MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInSide_R;
			case 7:
				return "PHYSCIS_" + MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInUp_R;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000C7A4 File Offset: 0x0000A9A4
		protected override void OnRootScaleChanged(object target)
		{
			base.OnRootScaleChanged(target);
			base.FixPoints();
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000C7B3 File Offset: 0x0000A9B3
		public sealed override void OnUpdateEvent2()
		{
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000C7B8 File Offset: 0x0000A9B8
		public sealed override void OnUpdateEvent6()
		{
			this.m_worldScale = base.transform.lossyScale.Escala();
			float num = ((!this.m_BocaHole.isPenetrated) ? 0f : Mathf.InverseLerp(0.001f, 0.006f, this.GetMaxAnchuraLimpiaLocal()));
			this.colliderConfig.UpdateRadiusMod(num, true);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000C812 File Offset: 0x0000AA12
		public float GetMaxAnchuraLimpiaLocal()
		{
			return this.m_BocaHole.estadoDePuntos.actualLocal.maxLimpiaLocalHole * this.m_BocaHole.worldHoleScale / this.m_worldScale;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000C83C File Offset: 0x0000AA3C
		protected override Transform GetCharBoneTargetTransformOfPoint(int index)
		{
			return this.m_boneRoot.FindDeepChild(this.GetInnerName(index), true);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000C851 File Offset: 0x0000AA51
		protected override Transform GetJointTransformOfPoint(int index)
		{
			return this.m_boneRoot.FindDeepChild(this.GetOutterName(index), true);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000C866 File Offset: 0x0000AA66
		protected override Transform GetTargetBodyTransformOfPoint(int index)
		{
			return this.m_boneRoot.FindDeepChild(this.GetInnerNameProxys(index), true);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0000C87C File Offset: 0x0000AA7C
		protected override void CustomizarPunto(LabioPoint punto, int index)
		{
			base.CustomizarPunto(punto, index);
			punto.colliderConfig = this.colliderConfig;
			float num;
			switch (index)
			{
			case 0:
				num = 0.33f;
				break;
			case 1:
				num = 0.16f;
				break;
			case 2:
				num = 0.1f;
				break;
			case 3:
				num = 0.1f;
				break;
			case 4:
				num = 0.33f;
				break;
			case 5:
				num = 0.1f;
				break;
			case 6:
				num = 0.1f;
				break;
			case 7:
				num = 0.16f;
				break;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
			punto.configuracion = (LabioPoint.Configuracion)punto.configuracion.Clone();
			punto.configuracion.limitacionDeMotionConfig = punto.configuracion.limitacionDeMotionConfig.Copia();
			for (int i = 0; i < punto.configuracion.limitacionDeMotionConfig.limitaciones.Count; i++)
			{
				LimitarPolaridadDeAxis.Configuracion configuracion = punto.configuracion.limitacionDeMotionConfig.limitaciones[i];
				if (configuracion.axisPolarizado == AxisPolarizado.yNegative || configuracion.axisPolarizado == AxisPolarizado.yPositive)
				{
					configuracion.toleranceMod = num;
				}
			}
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0000C994 File Offset: 0x0000AB94
		protected override void AfterStartPoint(LabioPoint point)
		{
			base.AfterStartPoint(point);
			int num = base.indexDePuntoNombre[point.jointTransform.name];
			string text;
			string text2;
			switch (num)
			{
			case 0:
				text = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioUp;
				text2 = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioUp_Edge;
				break;
			case 1:
				text = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioUp_L;
				text2 = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioUp_L_Edge;
				break;
			case 2:
				text = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labionSide_L;
				text2 = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labionSide_L_Edge;
				break;
			case 3:
				text = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioDown_L;
				text2 = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioDown_L_Edge;
				break;
			case 4:
				text = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioDown;
				text2 = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioDown_Edge;
				break;
			case 5:
				text = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioDown_R;
				text2 = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioDown_R_Edge;
				break;
			case 6:
				text = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labionSide_R;
				text2 = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labionSide_R_Edge;
				break;
			case 7:
				text = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioUp_R;
				text2 = MapaSingleton<MapaSingletonDeFemaleGuiasBody>.instance.labioUp_R_Edge;
				break;
			default:
				throw new ArgumentOutOfRangeException(num.ToString());
			}
			point.InitCollider(this.GetInnerName(num), text, text2);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000CAD0 File Offset: 0x0000ACD0
		protected override void OnPuntosLoaded()
		{
			base.OnPuntosLoaded();
			if (!this.m_usarLabioToLabio)
			{
				return;
			}
			this.AddLabioToLabio(base.puntos[2], base.puntos[1]);
			this.AddLabioToLabio(base.puntos[2], base.puntos[3]);
			this.AddLabioToLabio(base.puntos[6], base.puntos[7]);
			this.AddLabioToLabio(base.puntos[6], base.puntos[5]);
			this.AddLabioToLabio(base.puntos[1], base.puntos[0]);
			this.AddLabioToLabio(base.puntos[3], base.puntos[4]);
			this.AddLabioToLabio(base.puntos[7], base.puntos[0]);
			this.AddLabioToLabio(base.puntos[5], base.puntos[4]);
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0000CBDC File Offset: 0x0000ADDC
		private void AddLabioToLabio(LabioPoint punto, LabioPoint targetPunto)
		{
			LabioToLabioJoint labioToLabioJoint = punto.targetBodyTransform.gameObject.AddComponent<LabioToLabioJoint>();
			labioToLabioJoint.configuraciones = this.labioToLabioJointConfig;
			labioToLabioJoint.SetConnectedBody(targetPunto, punto, base.indexDePuntoNombre[punto.jointTransform.name], this.m_suavizadorDeLabioToLabio);
			this.m_labioToLabios.Add(labioToLabioJoint);
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0000CC38 File Offset: 0x0000AE38
		protected override void OnPuntosStarted()
		{
			base.OnPuntosStarted();
			if (!this.m_usarLabioToLabio)
			{
				return;
			}
			for (int i = 0; i < this.m_labioToLabios.Count; i++)
			{
				this.m_labioToLabios[i].ManualStart();
			}
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0000CC7C File Offset: 0x0000AE7C
		protected override void OnJointsFixed()
		{
			base.OnJointsFixed();
			if (!this.m_usarLabioToLabio)
			{
				return;
			}
			for (int i = 0; i < this.m_labioToLabios.Count; i++)
			{
				this.m_labioToLabios[i].FixAdmins();
			}
		}

		// Token: 0x0400024F RID: 591
		[SerializeField]
		private bool m_usarLabioToLabio = true;

		// Token: 0x04000250 RID: 592
		[SerializeField]
		private ModificadorDeDriversDeJoint m_suavizadorDeLabioToLabio;

		// Token: 0x04000251 RID: 593
		private List<LabioToLabioJoint> m_labioToLabios = new List<LabioToLabioJoint>();

		// Token: 0x04000252 RID: 594
		public LabioToLabioJoint.Configuraciones labioToLabioJointConfig = new LabioToLabioJoint.Configuraciones();

		// Token: 0x04000253 RID: 595
		public LabioPointCollider.Configuracion colliderConfig;

		// Token: 0x04000254 RID: 596
		private Transform m_boneRoot;

		// Token: 0x04000255 RID: 597
		private List<Collider> m_colliders;

		// Token: 0x04000256 RID: 598
		private BocaHole m_BocaHole;

		// Token: 0x04000257 RID: 599
		private float m_worldScale = 1f;
	}
}
