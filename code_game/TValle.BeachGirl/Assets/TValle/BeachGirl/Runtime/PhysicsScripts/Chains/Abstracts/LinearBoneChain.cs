using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.Abstracts
{
	// Token: 0x02000093 RID: 147
	public abstract class LinearBoneChain<Tpoint, Tconfig> : LinearBoneChainBase where Tpoint : RecalculableJoint<Tconfig> where Tconfig : RecalculableJointBase.JointConfiguracion
	{
		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000E0BE File Offset: 0x0000C2BE
		public sealed override IReadOnlyList<RecalculableJointBase> puntosBase
		{
			get
			{
				return this.puntos;
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000442 RID: 1090 RVA: 0x0000E0C8 File Offset: 0x0000C2C8
		// (remove) Token: 0x06000443 RID: 1091 RVA: 0x0000E100 File Offset: 0x0000C300
		public event Action<LinearBoneChain<Tpoint, Tconfig>> pointsStared;

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x0000E138 File Offset: 0x0000C338
		public virtual List<Collider> currentChildColliders
		{
			get
			{
				List<Collider> list = new List<Collider>();
				base.GetComponentsInChildren<Collider>(list);
				return list;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000E154 File Offset: 0x0000C354
		public virtual List<Collider> currentParentColliders
		{
			get
			{
				List<Collider> list = new List<Collider>();
				base.GetComponentsInParent<Collider>(false, list);
				return list;
			}
		}

		// Token: 0x170001C2 RID: 450
		public Tpoint this[int index]
		{
			get
			{
				if (this.puntos.ContieneIndexReadOnly(index))
				{
					return this.puntos[index];
				}
				return default(Tpoint);
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x0000E1A1 File Offset: 0x0000C3A1
		public IReadOnlyList<Tpoint> puntos
		{
			get
			{
				return this.m_puntos;
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x0000E1A9 File Offset: 0x0000C3A9
		public IReadOnlyDictionary<string, int> indexDePuntoNombre
		{
			get
			{
				return this.m_indexDePuntoNombre;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000449 RID: 1097
		public abstract int cantidadDePuntos { get; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x0600044A RID: 1098
		public abstract Transform boneRoot { get; }

		// Token: 0x0600044B RID: 1099
		protected abstract Transform GetJointTransformOfPoint(int index);

		// Token: 0x0600044C RID: 1100
		protected abstract Transform GetTargetBodyTransformOfPoint(int index);

		// Token: 0x0600044D RID: 1101
		protected abstract Transform GetCharBoneTargetTransformOfPoint(int index);

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x0600044E RID: 1102 RVA: 0x0000E1B4 File Offset: 0x0000C3B4
		// (remove) Token: 0x0600044F RID: 1103 RVA: 0x0000E1EC File Offset: 0x0000C3EC
		public event Action<LinearBoneChain<Tpoint, Tconfig>> jointsFixing;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000450 RID: 1104 RVA: 0x0000E224 File Offset: 0x0000C424
		// (remove) Token: 0x06000451 RID: 1105 RVA: 0x0000E25C File Offset: 0x0000C45C
		public event Action<LinearBoneChain<Tpoint, Tconfig>> jointsFixed;

		// Token: 0x06000452 RID: 1106 RVA: 0x0000E291 File Offset: 0x0000C491
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (!quitting && this.m_ScaleChangedBroadcaster != null)
			{
				this.m_ScaleChangedBroadcaster.ScaleChanged -= new ScaleChangedBroadcaster.ScaleChangedHandler(this.OnRootScaleChanged);
			}
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0000E2C4 File Offset: 0x0000C4C4
		public Tpoint ObtenerPuntoDeConnectedBody(Rigidbody rb)
		{
			for (int i = 0; i < this.puntos.Count; i++)
			{
				Tpoint tpoint = this.puntos[i];
				if (tpoint.joint.connectedBody == rb)
				{
					return tpoint;
				}
			}
			return default(Tpoint);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0000E318 File Offset: 0x0000C518
		public virtual Tpoint FindByNamePoint(string name)
		{
			for (int i = 0; i < this.puntos.Count; i++)
			{
				Tpoint tpoint = this.puntos[i];
				if (tpoint.targetBodyTransform.name == name)
				{
					return tpoint;
				}
			}
			return default(Tpoint);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0000E36C File Offset: 0x0000C56C
		public void FixPoints()
		{
			Action<LinearBoneChain<Tpoint, Tconfig>> action = this.jointsFixing;
			if (action != null)
			{
				action(this);
			}
			for (int i = 0; i < this.puntos.Count; i++)
			{
				this.puntos[i].FixAdmins();
			}
			this.OnJointsFixed();
			Action<LinearBoneChain<Tpoint, Tconfig>> action2 = this.jointsFixed;
			if (action2 == null)
			{
				return;
			}
			action2(this);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x0000E3D0 File Offset: 0x0000C5D0
		public void CorrectChainTransform(bool correctScale)
		{
			if (base.transform == this.boneRoot)
			{
				return;
			}
			if (base.transform.parent.lossyScale != Vector3.one)
			{
				throw new InvalidOperationException("la escala de la linear chain debe ser vector one.");
			}
			base.transform.position = this.boneRoot.position;
			base.transform.rotation = this.boneRoot.rotation;
			if (correctScale)
			{
				base.transform.localScale = this.boneRoot.lossyScale;
			}
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0000E45D File Offset: 0x0000C65D
		protected virtual void OnRootScaleChanged(object target)
		{
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0000E460 File Offset: 0x0000C660
		public void ObtenerModificadores(string id, List<ModificadorDeDriversDeJoint> resultado)
		{
			for (int i = 0; i < this.puntos.Count; i++)
			{
				Tpoint tpoint = this.puntos[i];
				resultado.Add(tpoint.suavizaciones.suavisable.AddModificador(id));
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0000E4AC File Offset: 0x0000C6AC
		protected virtual void AfterStartPoint(Tpoint point)
		{
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x0000E4AE File Offset: 0x0000C6AE
		protected virtual void CustomizarPunto(Tpoint punto, int index)
		{
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0000E4B0 File Offset: 0x0000C6B0
		public void KillForces()
		{
			for (int i = 0; i < this.puntos.Count; i++)
			{
				this.puntos[i].KillForces();
			}
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0000E4EC File Offset: 0x0000C6EC
		protected void LoadRootScaleChager()
		{
			this.m_ScaleChangedBroadcaster = this.GetComponentNotNull<ScaleChangedBroadcaster>();
			this.m_ScaleChangedBroadcaster.AddTarget(this.boneRoot, false);
			this.m_ScaleChangedBroadcaster.updateEvent = GlobalUpdater.UpdateType.fixedUpdate3;
			this.m_ScaleChangedBroadcaster.ScaleChanged += new ScaleChangedBroadcaster.ScaleChangedHandler(this.OnRootScaleChanged);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0000E53D File Offset: 0x0000C73D
		protected virtual Tpoint InstanciarPoint(Transform jointTransform, Transform targetTransform)
		{
			Tpoint tpoint = jointTransform.gameObject.AddComponent<Tpoint>();
			tpoint.configuracion = this.puntosConfig;
			tpoint.jointTransform = jointTransform;
			tpoint.targetBodyTransform = targetTransform;
			return tpoint;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0000E574 File Offset: 0x0000C774
		protected void LoadPuntos()
		{
			for (int i = 0; i < this.cantidadDePuntos; i++)
			{
				Tpoint tpoint = this.LoadPunto(i);
				this.CustomizarPunto(tpoint, i);
				this.m_puntos.Add(tpoint);
				this.m_indexDePuntoNombre.Add(tpoint.jointTransform.name, i);
				tpoint.SetManualStart();
			}
			this.OnPuntosLoaded();
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0000E5DC File Offset: 0x0000C7DC
		protected Tpoint LoadPunto(int index)
		{
			Transform jointTransformOfPoint = this.GetJointTransformOfPoint(index);
			Transform targetBodyTransformOfPoint = this.GetTargetBodyTransformOfPoint(index);
			if (jointTransformOfPoint == null)
			{
				throw new ArgumentNullException("JointTransform", "JointTransform null reference.");
			}
			if (targetBodyTransformOfPoint == null)
			{
				throw new ArgumentNullException("TargetTransform", "TargetTransform null reference.");
			}
			Transform charBoneTargetTransformOfPoint = this.GetCharBoneTargetTransformOfPoint(index);
			Tpoint tpoint = this.InstanciarPoint(jointTransformOfPoint, targetBodyTransformOfPoint);
			tpoint.scalerBone = charBoneTargetTransformOfPoint;
			return tpoint;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0000E648 File Offset: 0x0000C848
		protected void StartPoints()
		{
			for (int i = 0; i < this.puntos.Count; i++)
			{
				this.puntos[i].ManualStart();
			}
			for (int j = 0; j < this.puntos.Count; j++)
			{
				Tpoint tpoint = this.puntos[j];
				this.AfterStartPoint(tpoint);
			}
			this.OnPuntosStarted();
			Action<LinearBoneChain<Tpoint, Tconfig>> action = this.pointsStared;
			if (action != null)
			{
				action(this);
			}
			this.pointsStared = null;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0000E6CA File Offset: 0x0000C8CA
		protected virtual void OnPuntosLoaded()
		{
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0000E6CC File Offset: 0x0000C8CC
		protected virtual void OnPuntosStarted()
		{
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000E6CE File Offset: 0x0000C8CE
		protected virtual void OnJointsFixed()
		{
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000E6D0 File Offset: 0x0000C8D0
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar Chain",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000E6E9 File Offset: 0x0000C8E9
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.CorrectChainTransform(true);
			this.FixPoints();
			base.ReSubscribeToGlobalUpdater();
		}

		// Token: 0x0400029C RID: 668
		public Tconfig puntosConfig;

		// Token: 0x0400029D RID: 669
		private ScaleChangedBroadcaster m_ScaleChangedBroadcaster;

		// Token: 0x0400029E RID: 670
		private List<Tpoint> m_puntos = new List<Tpoint>();

		// Token: 0x040002A2 RID: 674
		private Dictionary<string, int> m_indexDePuntoNombre = new Dictionary<string, int>();
	}
}
