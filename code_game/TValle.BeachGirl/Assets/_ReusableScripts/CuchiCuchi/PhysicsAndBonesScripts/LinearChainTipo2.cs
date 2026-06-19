using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using Assets._ReusableScripts.PhysicsScripts.JointAdmins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000DF RID: 223
	public abstract class LinearChainTipo2<Tpoint, Tconfig> : AplicableBehaviour, ILinearChain, IJointSuavisableV2, IFixableSuavisableJointAdmin, IFixableJointAdmin where Tpoint : RecalculableJoint<Tconfig> where Tconfig : RecalculableJointBase.JointConfiguracion
	{
		// Token: 0x1700038F RID: 911
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x0001C228 File Offset: 0x0001A428
		public sealed override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates3);
			}
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0001C234 File Offset: 0x0001A434
		void IFixableJointAdmin.Fix()
		{
			if (base.isDestroyed)
			{
				return;
			}
			IJointSuavisableV2 suavizaciones = this.m_rootPunto.suavizaciones;
			if (suavizaciones != null)
			{
				suavizaciones.Fix();
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				IJointSuavisableV2 suavizaciones2 = this.m_puntosExcluyendoRootList[i].suavizaciones;
				if (suavizaciones2 != null)
				{
					suavizaciones2.Fix();
				}
			}
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0001C29C File Offset: 0x0001A49C
		void IFixableSuavisableJointAdmin.FixSuavizacion()
		{
			if (base.isDestroyed)
			{
				return;
			}
			IJointSuavisableV2 suavizaciones = this.m_rootPunto.suavizaciones;
			if (suavizaciones != null)
			{
				suavizaciones.FixSuavizacion();
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				IJointSuavisableV2 suavizaciones2 = this.m_puntosExcluyendoRootList[i].suavizaciones;
				if (suavizaciones2 != null)
				{
					suavizaciones2.FixSuavizacion();
				}
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x0001C304 File Offset: 0x0001A504
		DriversDeJointModificable IJointSuavisableV2.suavisable
		{
			get
			{
				return this.m_allPointsDriversDeJointModificable;
			}
		}

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x060008F0 RID: 2288 RVA: 0x0001C30C File Offset: 0x0001A50C
		// (remove) Token: 0x060008F1 RID: 2289 RVA: 0x0001C344 File Offset: 0x0001A544
		public event LinearChainTipo2<Tpoint, Tconfig>.SettingConfigToPointHandler onSettingConfigToPoint;

		// Token: 0x060008F2 RID: 2290 RVA: 0x0001C37C File Offset: 0x0001A57C
		private void OnStartJointEstirable()
		{
			this.m_allPointsDriversDeJointModificable = new DriversDeJointModificable(this);
			this.m_allPointsDriversDeJointMod = new ModificadorDeDriversDeJoint("AllLinearChainTipo2PointsDriversDeJointMod");
			IJointSuavisableV2 suavizaciones = this.m_rootPunto.suavizaciones;
			if (suavizaciones != null)
			{
				suavizaciones.suavisable.TryAddModificador(this.m_allPointsDriversDeJointMod);
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				IJointSuavisableV2 suavizaciones2 = this.m_puntosExcluyendoRootList[i].suavizaciones;
				if (suavizaciones2 != null)
				{
					suavizaciones2.suavisable.TryAddModificador(this.m_allPointsDriversDeJointMod);
				}
			}
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0001C410 File Offset: 0x0001A610
		private void UpdateJointEstirable()
		{
			ModificadorDeDriversDeJoint.Data data = ModificadorDeDriversDeJoint.Data.TodoAValor(1f);
			if (this.m_allPointsDriversDeJointModificable.Count > 0)
			{
				this.m_allPointsDriversDeJointModificable.ModificarValor(ref data);
			}
			if (!data.IgualA(this.m_allPointsDriversDeJointMod))
			{
				this.m_allPointsDriversDeJointMod.Override(ref data, false);
				((IFixableSuavisableJointAdmin)this).FixSuavizacion();
			}
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x0001C468 File Offset: 0x0001A668
		private void OnDestroyJointEstirable()
		{
			Tpoint tpoint = this.m_rootPunto;
			if (tpoint != null)
			{
				IJointSuavisableV2 suavizaciones = tpoint.suavizaciones;
				if (suavizaciones != null)
				{
					DriversDeJointModificable suavisable = suavizaciones.suavisable;
					if (suavisable != null)
					{
						suavisable.RemoverModificador(this.m_allPointsDriversDeJointMod.id);
					}
				}
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				Tpoint tpoint2 = this.m_puntosExcluyendoRootList[i];
				IJointSuavisableV2 jointSuavisableV = ((tpoint2 != null) ? tpoint2.suavizaciones : null);
				if (jointSuavisableV != null)
				{
					DriversDeJointModificable suavisable2 = jointSuavisableV.suavisable;
					if (suavisable2 != null)
					{
						suavisable2.RemoverModificador(this.m_allPointsDriversDeJointMod.id);
					}
				}
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x0001C502 File Offset: 0x0001A702
		// (set) Token: 0x060008F6 RID: 2294 RVA: 0x0001C50A File Offset: 0x0001A70A
		public EstadoDeCadena estado
		{
			get
			{
				return this.m_estado;
			}
			set
			{
				this.m_estado = value;
			}
		}

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x060008F7 RID: 2295 RVA: 0x0001C514 File Offset: 0x0001A714
		// (remove) Token: 0x060008F8 RID: 2296 RVA: 0x0001C54C File Offset: 0x0001A74C
		public event Action<LinearChainTipo2<Tpoint, Tconfig>> pointsStared;

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x060008F9 RID: 2297
		public abstract int cantidadDePuntos { get; }

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x060008FA RID: 2298
		public abstract Transform puntoBaseTransform { get; }

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x0001C581 File Offset: 0x0001A781
		public Tpoint last
		{
			get
			{
				return this[this.cantidadDePuntos - 1];
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x0001C594 File Offset: 0x0001A794
		public virtual List<Collider> currentChildColliders
		{
			get
			{
				List<Collider> list = new List<Collider>();
				base.GetComponentsInChildren<Collider>(list);
				return list;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x0001C5B0 File Offset: 0x0001A7B0
		public virtual List<Collider> currentParentColliders
		{
			get
			{
				List<Collider> list = new List<Collider>();
				base.GetComponentsInParent<Collider>(false, list);
				return list;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x0001C5CC File Offset: 0x0001A7CC
		public Tpoint rootPunto
		{
			get
			{
				return this.m_rootPunto;
			}
		}

		// Token: 0x17000398 RID: 920
		public Tpoint this[int index]
		{
			get
			{
				if (index == -1)
				{
					return this.m_rootPunto;
				}
				if (this.m_puntosExcluyendoRoot.ContainsKey(index))
				{
					return this.m_puntosExcluyendoRoot[index];
				}
				return default(Tpoint);
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x0001C610 File Offset: 0x0001A810
		public Vector3 localForward
		{
			get
			{
				return this.m_localForward;
			}
		}

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x06000901 RID: 2305 RVA: 0x0001C618 File Offset: 0x0001A818
		// (remove) Token: 0x06000902 RID: 2306 RVA: 0x0001C650 File Offset: 0x0001A850
		public event Action<LinearChainTipo2<Tpoint, Tconfig>> jointsFixing;

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x06000903 RID: 2307 RVA: 0x0001C688 File Offset: 0x0001A888
		// (remove) Token: 0x06000904 RID: 2308 RVA: 0x0001C6C0 File Offset: 0x0001A8C0
		public event Action<LinearChainTipo2<Tpoint, Tconfig>> jointsFixed;

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x06000905 RID: 2309 RVA: 0x0001C6F8 File Offset: 0x0001A8F8
		// (remove) Token: 0x06000906 RID: 2310 RVA: 0x0001C730 File Offset: 0x0001A930
		public event Action<LinearChainTipo2<Tpoint, Tconfig>> scaleChanged;

		// Token: 0x06000907 RID: 2311 RVA: 0x0001C765 File Offset: 0x0001A965
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0001C76D File Offset: 0x0001A96D
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_wasDisabled = true;
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x0001C77D File Offset: 0x0001A97D
		protected sealed override void AfterStartUnityEvent()
		{
			base.AfterStartUnityEvent();
			this.OnStartJointEstirable();
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x0001C78B File Offset: 0x0001A98B
		public sealed override void OnUpdateEvent1()
		{
			if (this.m_wasDisabled)
			{
				this.FixPointsEnOrdenAsc();
				this.m_wasDisabled = false;
			}
			this.UpdateJointEstirable();
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0001C7A8 File Offset: 0x0001A9A8
		public Tpoint ObtenerPuntoDeConnectedBody(Rigidbody rb)
		{
			Tpoint tpoint = this.m_rootPunto;
			if (((tpoint != null) ? tpoint.joint.connectedBody : null) == rb)
			{
				return this.m_rootPunto;
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				Tpoint tpoint2 = this.m_puntosExcluyendoRootList[i];
				if (tpoint2.joint.connectedBody == rb)
				{
					return tpoint2;
				}
			}
			return default(Tpoint);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0001C828 File Offset: 0x0001AA28
		public void EjecutarEnOrdenAsc(Action<Tpoint> accion)
		{
			if (this.m_rootPunto != null)
			{
				accion(this.m_rootPunto);
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				Tpoint tpoint = this.m_puntosExcluyendoRootList[i];
				accion(tpoint);
			}
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0001C880 File Offset: 0x0001AA80
		public virtual Tpoint FindByNamePoint(string name)
		{
			if (this.m_rootPunto != null && this.m_rootPunto.targetBodyTransform.name == name)
			{
				return this.m_rootPunto;
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				Tpoint tpoint = this.m_puntosExcluyendoRootList[i];
				if (tpoint.targetBodyTransform.name == name)
				{
					return tpoint;
				}
			}
			return default(Tpoint);
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x0001C90C File Offset: 0x0001AB0C
		public void FixPointsEnOrdenAsc()
		{
			this.FixingPointsEnOrdenAsc();
			Action<LinearChainTipo2<Tpoint, Tconfig>> action = this.jointsFixing;
			if (action != null)
			{
				action(this);
			}
			this.m_localForward = Vector3.Cross(this.puntosConfig.jointAxisAdmin.localRightAxis.normalized, this.puntosConfig.jointAxisAdmin.localUpAxis.normalized).normalized;
			Tpoint tpoint = this.m_rootPunto;
			if (tpoint != null)
			{
				tpoint.FixAdmins();
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				this.m_puntosExcluyendoRootList[i].FixAdmins();
			}
			Action<LinearChainTipo2<Tpoint, Tconfig>> action2 = this.jointsFixed;
			if (action2 == null)
			{
				return;
			}
			action2(this);
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x0001C9CB File Offset: 0x0001ABCB
		protected virtual void FixingPointsEnOrdenAsc()
		{
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0001C9D0 File Offset: 0x0001ABD0
		public Dictionary<int, Tpoint> ObtenerPuntos()
		{
			Dictionary<int, Tpoint> dictionary = new Dictionary<int, Tpoint>(this.m_puntosExcluyendoRoot.Count + 1);
			if (this.m_rootPunto != null)
			{
				dictionary.Add(-1, this.m_rootPunto);
			}
			foreach (KeyValuePair<int, Tpoint> keyValuePair in this.m_puntosExcluyendoRoot)
			{
				dictionary.Add(keyValuePair.Key, keyValuePair.Value);
			}
			return dictionary;
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0001CA64 File Offset: 0x0001AC64
		public void CorrectChainTransform(bool correctScale)
		{
			if (base.transform == this.puntoBaseTransform)
			{
				return;
			}
			if (base.transform.parent.lossyScale != Vector3.one)
			{
				throw new InvalidOperationException("la escala de la linear chain debe ser vector one.");
			}
			base.transform.position = this.puntoBaseTransform.position;
			base.transform.rotation = this.puntoBaseTransform.rotation;
			if (correctScale)
			{
				base.transform.localScale = this.puntoBaseTransform.lossyScale;
			}
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x0001CAF1 File Offset: 0x0001ACF1
		public void CorrectChainTransformScale()
		{
			base.transform.localScale = this.puntoBaseTransform.lossyScale;
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0001CB0C File Offset: 0x0001AD0C
		protected void LoadRootScaleChager()
		{
			this.m_ScaleChangedBroadcaster = this.GetComponentNotNull<ScaleChangedBroadcaster>();
			this.m_ScaleChangedBroadcaster.AddTarget(this.puntoBaseTransform, false);
			this.m_ScaleChangedBroadcaster.updateEvent = GlobalUpdater.UpdateType.fixedUpdate3;
			this.m_ScaleChangedBroadcaster.ScaleChanged += new ScaleChangedBroadcaster.ScaleChangedHandler(this.onRootScaleChanged);
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0001CB5C File Offset: 0x0001AD5C
		protected void StartRootScaleChager()
		{
			if (this.m_ScaleChangedBroadcaster && !this.m_ScaleChangedBroadcaster.isStared)
			{
				this.m_ScaleChangedBroadcaster.ManualStart();
			}
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0001CB83 File Offset: 0x0001AD83
		protected void onRootScaleChanged(object target)
		{
			this.OnRootScaleChanged(target);
			Action<LinearChainTipo2<Tpoint, Tconfig>> action = this.scaleChanged;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0001CB9D File Offset: 0x0001AD9D
		protected virtual void OnRootScaleChanged(object target)
		{
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0001CBA0 File Offset: 0x0001ADA0
		protected virtual void LoadPuntos()
		{
			Transform targetBodyTransformOfRootPoint = this.GetTargetBodyTransformOfRootPoint();
			if (targetBodyTransformOfRootPoint != null)
			{
				this.m_rootPunto = this.GetPoint(-1, this.puntoBaseTransform, targetBodyTransformOfRootPoint);
				this.m_rootPunto.SetManualStart();
				this.m_rootPunto.scalerBone = this.puntoBaseTransform;
				this.CustomizarPuntoRoot(this.m_rootPunto);
			}
			for (int i = 0; i < this.cantidadDePuntos; i++)
			{
				Tpoint tpoint = this.LoadPunto(i);
				this.CustomizarPunto(tpoint, i);
				this.m_puntosExcluyendoRoot.Add(i, tpoint);
				this.m_puntosExcluyendoRootList.Add(tpoint);
				tpoint.SetManualStart();
			}
			this.onSettingConfigToPoint = null;
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0001CC4F File Offset: 0x0001AE4F
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.OnDestroyJointEstirable();
			if (!quitting && this.m_ScaleChangedBroadcaster != null)
			{
				this.m_ScaleChangedBroadcaster.ScaleChanged -= new ScaleChangedBroadcaster.ScaleChangedHandler(this.onRootScaleChanged);
			}
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0001CC88 File Offset: 0x0001AE88
		protected void StartPoints()
		{
			Tpoint tpoint = this.m_rootPunto;
			if (tpoint != null)
			{
				tpoint.ManualStart();
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				this.m_puntosExcluyendoRootList[i].ManualStart();
			}
			if (this.m_rootPunto != null)
			{
				this.AfterStartPoint(this.m_rootPunto);
			}
			for (int j = 0; j < this.m_puntosExcluyendoRootList.Count; j++)
			{
				Tpoint tpoint2 = this.m_puntosExcluyendoRootList[j];
				this.AfterStartPoint(tpoint2);
			}
			Action<LinearChainTipo2<Tpoint, Tconfig>> action = this.pointsStared;
			if (action != null)
			{
				action(this);
			}
			this.pointsStared = null;
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x0001CD3C File Offset: 0x0001AF3C
		public void ObtenerModificadores(string id, List<ModificadorDeDriversDeJoint> resultado, bool incluirRoot)
		{
			if (incluirRoot && this.m_rootPunto != null)
			{
				resultado.Add(this.m_rootPunto.suavizaciones.suavisable.AddModificador(id));
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				Tpoint tpoint = this.m_puntosExcluyendoRootList[i];
				resultado.Add(tpoint.suavizaciones.suavisable.AddModificador(id));
			}
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x0001CDBF File Offset: 0x0001AFBF
		protected virtual void AfterStartPoint(Tpoint point)
		{
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x0001CDC4 File Offset: 0x0001AFC4
		protected virtual Tpoint LoadPunto(int index)
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
			Tpoint point = this.GetPoint(index, jointTransformOfPoint, targetBodyTransformOfPoint);
			point.scalerBone = charBoneTargetTransformOfPoint;
			return point;
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0001CE30 File Offset: 0x0001B030
		protected virtual Tpoint GetPoint(int index, Transform jointTransform, Transform targetTransform)
		{
			Tpoint tpoint = jointTransform.gameObject.AddComponent<Tpoint>();
			Tconfig tconfig = this.puntosConfig;
			LinearChainTipo2<Tpoint, Tconfig>.SettingConfigToPointHandler settingConfigToPointHandler = this.onSettingConfigToPoint;
			if (settingConfigToPointHandler != null)
			{
				settingConfigToPointHandler(tpoint, index, ref tconfig, this);
			}
			tpoint.configuracion = tconfig;
			tpoint.jointTransform = jointTransform;
			tpoint.targetBodyTransform = targetTransform;
			return tpoint;
		}

		// Token: 0x0600091E RID: 2334
		protected abstract Transform GetTargetBodyTransformOfRootPoint();

		// Token: 0x0600091F RID: 2335
		protected abstract Transform GetJointTransformOfPoint(int index);

		// Token: 0x06000920 RID: 2336
		protected abstract Transform GetTargetBodyTransformOfPoint(int index);

		// Token: 0x06000921 RID: 2337
		protected abstract Transform GetCharBoneTargetTransformOfPoint(int index);

		// Token: 0x06000922 RID: 2338 RVA: 0x0001CE8B File Offset: 0x0001B08B
		protected virtual void CustomizarPunto(Tpoint punto, int index)
		{
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0001CE8D File Offset: 0x0001B08D
		protected virtual void CustomizarPuntoRoot(Tpoint punto)
		{
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0001CE8F File Offset: 0x0001B08F
		void ILinearChain.FixEnOrdenAsc()
		{
			this.FixPointsEnOrdenAsc();
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0001CE98 File Offset: 0x0001B098
		public void KillForces()
		{
			Tpoint tpoint = this.m_rootPunto;
			if (tpoint != null)
			{
				tpoint.KillForces();
			}
			for (int i = 0; i < this.m_puntosExcluyendoRootList.Count; i++)
			{
				this.m_puntosExcluyendoRootList[i].KillForces();
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000926 RID: 2342 RVA: 0x0001CEE7 File Offset: 0x0001B0E7
		public IReadOnlyList<Tpoint> puntosExcluyendoRootList
		{
			get
			{
				return this.m_puntosExcluyendoRootList;
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000927 RID: 2343 RVA: 0x0001CEEF File Offset: 0x0001B0EF
		IReadOnlyList<RecalculableJointBase> ILinearChain.puntosExcluyendoRootList
		{
			get
			{
				return this.m_puntosExcluyendoRootList;
			}
		}

		// Token: 0x040004B7 RID: 1207
		[Header("IJointEstirable")]
		[SerializeField]
		private DriversDeJointModificable m_allPointsDriversDeJointModificable;

		// Token: 0x040004B8 RID: 1208
		[SerializeField]
		private ModificadorDeDriversDeJoint m_allPointsDriversDeJointMod;

		// Token: 0x040004BA RID: 1210
		[Header("LinearChainTipo2")]
		[ReadOnlyUI]
		[SerializeField]
		private EstadoDeCadena m_estado;

		// Token: 0x040004BC RID: 1212
		public Tconfig puntosConfig;

		// Token: 0x040004BD RID: 1213
		private ScaleChangedBroadcaster m_ScaleChangedBroadcaster;

		// Token: 0x040004BE RID: 1214
		private Tpoint m_rootPunto;

		// Token: 0x040004BF RID: 1215
		private Dictionary<int, Tpoint> m_puntosExcluyendoRoot = new Dictionary<int, Tpoint>();

		// Token: 0x040004C0 RID: 1216
		[NonSerialized]
		private List<Tpoint> m_puntosExcluyendoRootList = new List<Tpoint>();

		// Token: 0x040004C1 RID: 1217
		private Vector3 m_localForward;

		// Token: 0x040004C2 RID: 1218
		private bool m_wasDisabled;

		// Token: 0x020001B9 RID: 441
		// (Invoke) Token: 0x06000F42 RID: 3906
		public delegate void SettingConfigToPointHandler(Tpoint point, int index, ref Tconfig config, LinearChainTipo2<Tpoint, Tconfig> sender);
	}
}
