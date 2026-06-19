using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Shapes.Abstracts;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Shapes
{
	// Token: 0x02000238 RID: 568
	[Obsolete("reemplazado por guias", true)]
	public class DesplazadorDePenePorShapes : BaseDesplazadorSegunShape
	{
		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000F11 RID: 3857 RVA: 0x0001FA6E File Offset: 0x0001DC6E
		public override Transform target
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000F12 RID: 3858 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000F13 RID: 3859 RVA: 0x000434AA File Offset: 0x000416AA
		public override IReadOnlyList<BaseDesplazadorSegunShape.DesplazamientoInfo> desplazamientoInfo
		{
			get
			{
				return this.m_infos;
			}
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x000434B2 File Offset: 0x000416B2
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			PuppetPenisAdder componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("adder", "adder null reference.");
			}
			componentEnRoot.added += this.Adder_onAdded;
			base.SetManualStart();
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x000434F1 File Offset: 0x000416F1
		private void Adder_onAdded(BehaviourAdder obj)
		{
			base.ManualStart();
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x000434F9 File Offset: 0x000416F9
		public override void OnUpdateEvent1()
		{
			base.OnUpdateEvent1();
			base.Actualizar();
		}

		// Token: 0x04000A4E RID: 2638
		[SerializeField]
		private List<DesplazadorDePenePorShapes.Info> m_infos = new List<DesplazadorDePenePorShapes.Info>();

		// Token: 0x02000239 RID: 569
		[Serializable]
		public class Info : BaseDesplazadorSegunShape.DesplazamientoInfo
		{
			// Token: 0x170003C8 RID: 968
			// (get) Token: 0x06000F18 RID: 3864 RVA: 0x0004351A File Offset: 0x0004171A
			public override string normbreDeShape
			{
				get
				{
					return MapaSingleton<MapaDeMaleBlendShapes>.instance.ObtenerValorDeField(this.m_shape);
				}
			}

			// Token: 0x04000A4F RID: 2639
			[SerializeField]
			[StringSelector(typeof(MapaDeMaleBlendShapes), "fieldsEditor")]
			private string m_shape;
		}
	}
}
