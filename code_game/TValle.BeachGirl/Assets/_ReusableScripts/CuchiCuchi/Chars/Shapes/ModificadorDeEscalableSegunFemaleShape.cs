using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Shapes.Abstracts;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Shapes
{
	// Token: 0x02000136 RID: 310
	public sealed class ModificadorDeEscalableSegunFemaleShape : BaseModificadorDeEscalaSegunShape
	{
		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06000D6C RID: 3436 RVA: 0x0002E9D8 File Offset: 0x0002CBD8
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06000D6D RID: 3437 RVA: 0x0002E9DB File Offset: 0x0002CBDB
		public override IReadOnlyList<BaseModificadorDeEscalaSegunShape.ModificacionInfo> infos
		{
			get
			{
				return this.modificacionInfo;
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06000D6E RID: 3438 RVA: 0x0002E9E3 File Offset: 0x0002CBE3
		public override ITransformScaleModificable modificable
		{
			get
			{
				return this.m_modificable;
			}
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x0002E9EB File Offset: 0x0002CBEB
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x0002E9F3 File Offset: 0x0002CBF3
		protected override void StartUnityEvent()
		{
			this.m_modificable = base.GetComponent<ITransformScaleModificable>();
			if (this.m_modificable == null)
			{
				throw new ArgumentNullException("m_modificable", "m_modificable null reference.");
			}
			base.StartUnityEvent();
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x0002EA1F File Offset: 0x0002CC1F
		public override void OnUpdateEvent1()
		{
			base.Actualizar();
		}

		// Token: 0x04000782 RID: 1922
		[SerializeField]
		public List<ModificadorDeEscalableSegunFemaleShape.Info> modificacionInfo = new List<ModificadorDeEscalableSegunFemaleShape.Info>();

		// Token: 0x04000783 RID: 1923
		private ITransformScaleModificable m_modificable;

		// Token: 0x02000207 RID: 519
		[Serializable]
		public class Info : BaseModificadorDeEscalaSegunShape.ModificacionInfo
		{
			// Token: 0x1700053F RID: 1343
			// (get) Token: 0x06000FFC RID: 4092 RVA: 0x00035784 File Offset: 0x00033984
			public override string normbreDeShape
			{
				get
				{
					return MapaSingleton<MapaDeFemaleBlendShapes>.instance.ObtenerValorDeField(this.m_shape);
				}
			}

			// Token: 0x04000B19 RID: 2841
			[SerializeField]
			[StringSelector(typeof(MapaDeFemaleBlendShapes), "fieldsEditor")]
			private string m_shape;
		}
	}
}
