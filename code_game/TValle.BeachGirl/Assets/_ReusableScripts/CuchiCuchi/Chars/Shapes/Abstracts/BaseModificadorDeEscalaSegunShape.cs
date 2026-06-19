using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Shapes.Abstracts
{
	// Token: 0x02000137 RID: 311
	public abstract class BaseModificadorDeEscalaSegunShape : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06000D73 RID: 3443
		public abstract IReadOnlyList<BaseModificadorDeEscalaSegunShape.ModificacionInfo> infos { get; }

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06000D74 RID: 3444
		public abstract ITransformScaleModificable modificable { get; }

		// Token: 0x06000D75 RID: 3445 RVA: 0x0002EA3C File Offset: 0x0002CC3C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			ICharacter componentEnRoot = this.GetComponentEnRoot(false);
			foreach (BaseModificadorDeEscalaSegunShape.ModificacionInfo modificacionInfo in this.infos)
			{
				modificacionInfo.Init(componentEnRoot.bodyAnimator, this.modificable, this);
				if (!modificacionInfo.isValid)
				{
					Debug.LogError("ModificacionInfo no es valida.");
				}
			}
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x0002EAB4 File Offset: 0x0002CCB4
		public void Actualizar()
		{
			for (int i = 0; i < this.infos.Count; i++)
			{
				BaseModificadorDeEscalaSegunShape.ModificacionInfo modificacionInfo = this.infos[i];
				if (modificacionInfo.isValid)
				{
					modificacionInfo.Actualizar();
				}
			}
		}

		// Token: 0x02000208 RID: 520
		public abstract class ModificacionInfo
		{
			// Token: 0x17000540 RID: 1344
			// (get) Token: 0x06000FFE RID: 4094
			public abstract string normbreDeShape { get; }

			// Token: 0x17000541 RID: 1345
			// (get) Token: 0x06000FFF RID: 4095 RVA: 0x0003579E File Offset: 0x0003399E
			public bool isValid
			{
				get
				{
					return this.m_renderer != null && !string.IsNullOrEmpty(this.normbreDeShape) && this.m_modificable != null;
				}
			}

			// Token: 0x06001000 RID: 4096 RVA: 0x000357C8 File Offset: 0x000339C8
			public void Init(Animator anim, ITransformScaleModificable modificable, BaseModificadorDeEscalaSegunShape holder)
			{
				if (holder == null)
				{
					throw new ArgumentNullException("holder", "holder null reference.");
				}
				if (anim == null)
				{
					throw new ArgumentNullException("anim", "anim null reference.");
				}
				Transform transform = anim.transform.FindDeepChild(MapaSingleton<MapaSingletonDeMainSkins>.instance.ObtenerValorDeField(this.m_skin), true);
				if (transform == null)
				{
					throw new NotSupportedException();
				}
				if (modificable == null)
				{
					throw new ArgumentNullException("modificable", "modificable null reference.");
				}
				this.m_modificable = modificable;
				this.m_renderer = transform.GetComponent<SkinnedMeshRenderer>();
				if (this.m_renderer == null)
				{
					throw new NotSupportedException();
				}
				this.m_shape = new ShapeKey(this.normbreDeShape);
				this.XModificador = modificable.x.ObtenerModificadorNotNull(holder.name + this.normbreDeShape);
				this.YModificador = modificable.y.ObtenerModificadorNotNull(holder.name + this.normbreDeShape);
				this.ZModificador = modificable.z.ObtenerModificadorNotNull(holder.name + this.normbreDeShape);
			}

			// Token: 0x06001001 RID: 4097 RVA: 0x000358E4 File Offset: 0x00033AE4
			public void Destroy()
			{
				ModificadorDeFloat xmodificador = this.XModificador;
				if (xmodificador != null)
				{
					xmodificador.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat ymodificador = this.YModificador;
				if (ymodificador != null)
				{
					ymodificador.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat zmodificador = this.ZModificador;
				if (zmodificador == null)
				{
					return;
				}
				zmodificador.TryRemoverDeOwner(true);
			}

			// Token: 0x06001002 RID: 4098 RVA: 0x00035920 File Offset: 0x00033B20
			public void Actualizar()
			{
				float valor = this.m_shape.GetValor(this.m_renderer);
				float num = MathfExtension.InverseLerpUnclamped(0f, 100f, valor);
				float num2 = Mathf.LerpUnclamped(1f, this.xChange, num);
				if (num2 == 0f)
				{
					num2 = 1E-05f;
				}
				float num3 = Mathf.LerpUnclamped(1f, this.yChange, num);
				if (num3 == 0f)
				{
					num3 = 1E-05f;
				}
				float num4 = Mathf.LerpUnclamped(1f, this.zChange, num);
				if (num4 == 0f)
				{
					num4 = 1E-05f;
				}
				this.XModificador.valor.valor = num2;
				this.YModificador.valor.valor = num3;
				this.ZModificador.valor.valor = num4;
			}

			// Token: 0x04000B1A RID: 2842
			[SerializeField]
			[StringSelector(typeof(MapaSingletonDeMainSkins), "fieldsEditor")]
			private string m_skin;

			// Token: 0x04000B1B RID: 2843
			public float xChange = 1f;

			// Token: 0x04000B1C RID: 2844
			public float yChange = 1f;

			// Token: 0x04000B1D RID: 2845
			public float zChange = 1f;

			// Token: 0x04000B1E RID: 2846
			private ShapeKey m_shape;

			// Token: 0x04000B1F RID: 2847
			private SkinnedMeshRenderer m_renderer;

			// Token: 0x04000B20 RID: 2848
			private ModificadorDeFloat XModificador;

			// Token: 0x04000B21 RID: 2849
			private ModificadorDeFloat YModificador;

			// Token: 0x04000B22 RID: 2850
			private ModificadorDeFloat ZModificador;

			// Token: 0x04000B23 RID: 2851
			private ITransformScaleModificable m_modificable;
		}
	}
}
