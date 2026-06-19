using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime
{
	// Token: 0x02000054 RID: 84
	public abstract class ModificadorDeVolumenPorShapes : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000179 RID: 377
		public abstract IReadOnlyList<ModificadorDeVolumenPorShapes.ModificacionInfo> infos { get; }

		// Token: 0x0600017A RID: 378 RVA: 0x00003014 File Offset: 0x00001214
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			foreach (ModificadorDeVolumenPorShapes.ModificacionInfo modificacionInfo in this.infos)
			{
				modificacionInfo.Destroy();
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00003068 File Offset: 0x00001268
		public void Actualizar()
		{
			for (int i = 0; i < this.infos.Count; i++)
			{
				ModificadorDeVolumenPorShapes.ModificacionInfo modificacionInfo = this.infos[i];
				if (modificacionInfo.isValid)
				{
					modificacionInfo.Actualizar();
				}
			}
		}

		// Token: 0x02000141 RID: 321
		public abstract class ModificacionInfo
		{
			// Token: 0x170004C6 RID: 1222
			// (get) Token: 0x06000DA6 RID: 3494
			public abstract string normbreDeShape { get; }

			// Token: 0x170004C7 RID: 1223
			// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x0002F29B File Offset: 0x0002D49B
			public virtual bool isValid
			{
				get
				{
					return this.m_renderer != null && !string.IsNullOrEmpty(this.normbreDeShape);
				}
			}

			// Token: 0x06000DA8 RID: 3496 RVA: 0x0002F2BC File Offset: 0x0002D4BC
			public void Init(Animator anim, ModificadorDeVolumenPorShapes holder)
			{
				if (holder == null)
				{
					throw new ArgumentNullException("holder", "holder null reference.");
				}
				this.m_holder = holder;
				if (anim == null)
				{
					throw new ArgumentNullException("anim", "anim null reference.");
				}
				Transform transform = anim.transform.FindDeepChild(MapaSingleton<MapaSingletonDeMainSkins>.instance.ObtenerValorDeField(this.m_skin), true);
				if (transform == null)
				{
					throw new NotSupportedException();
				}
				this.m_renderer = transform.GetComponent<SkinnedMeshRenderer>();
				if (this.m_renderer == null)
				{
					throw new NotSupportedException();
				}
				this.m_shape = new ShapeKey(this.normbreDeShape);
			}

			// Token: 0x06000DA9 RID: 3497 RVA: 0x0002F35F File Offset: 0x0002D55F
			public void Destroy()
			{
				this.Destroyed();
			}

			// Token: 0x06000DAA RID: 3498 RVA: 0x0002F368 File Offset: 0x0002D568
			public void Actualizar()
			{
				float valor = this.m_shape.GetValor(this.m_renderer);
				float num = MathfExtension.InverseLerpUnclamped(0f, 100f, valor);
				num = Mathf.LerpUnclamped(1f, this.volumenChangeOnShapeMax, num);
				if (num == 0f)
				{
					num = 1E-05f;
				}
				this.Updated(num);
			}

			// Token: 0x06000DAB RID: 3499
			protected abstract void Destroyed();

			// Token: 0x06000DAC RID: 3500
			protected abstract void Updated(float mod);

			// Token: 0x040007AC RID: 1964
			[SerializeField]
			[StringSelector(typeof(MapaSingletonDeMainSkins), "fieldsEditor")]
			private string m_skin;

			// Token: 0x040007AD RID: 1965
			public float volumenChangeOnShapeMax;

			// Token: 0x040007AE RID: 1966
			public bool modificarAltura;

			// Token: 0x040007AF RID: 1967
			[NonSerialized]
			private ShapeKey m_shape;

			// Token: 0x040007B0 RID: 1968
			private SkinnedMeshRenderer m_renderer;

			// Token: 0x040007B1 RID: 1969
			protected ModificadorDeVolumenPorShapes m_holder;
		}
	}
}
