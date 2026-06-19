using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Shapes.Abstracts;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Shapes
{
	// Token: 0x0200011D RID: 285
	public sealed class FemalePuppetModificadorDeVolumenDeMusculos : PuppetModificadorDeVolumenDeMusculos
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x00020D0A File Offset: 0x0001EF0A
		public override IReadOnlyList<ModificadorDeVolumenPorShapes.ModificacionInfo> infos
		{
			get
			{
				return this.m_infosJoind;
			}
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00020D12 File Offset: 0x0001EF12
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_infosJoind = new List<FemalePuppetModificadorDeVolumenDeMusculos.Info>();
			this.m_infosJoind.AddRange(this.m_fatP);
			this.m_infosJoind.AddRange(this.m_fatN);
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x00020D47 File Offset: 0x0001EF47
		public override void OnUpdateEvent1()
		{
			base.Actualizar();
		}

		// Token: 0x04000491 RID: 1169
		[SerializeField]
		private List<FemalePuppetModificadorDeVolumenDeMusculos.Info> m_fatP = new List<FemalePuppetModificadorDeVolumenDeMusculos.Info>();

		// Token: 0x04000492 RID: 1170
		[SerializeField]
		private List<FemalePuppetModificadorDeVolumenDeMusculos.Info> m_fatN = new List<FemalePuppetModificadorDeVolumenDeMusculos.Info>();

		// Token: 0x04000493 RID: 1171
		private List<FemalePuppetModificadorDeVolumenDeMusculos.Info> m_infosJoind;

		// Token: 0x0200011E RID: 286
		[Serializable]
		public class Info : PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo
		{
			// Token: 0x17000128 RID: 296
			// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00020D6D File Offset: 0x0001EF6D
			public override string normbreDeShape
			{
				get
				{
					return MapaSingleton<MapaDeFemaleBlendShapes>.instance.ObtenerValorDeField(this.m_shape);
				}
			}

			// Token: 0x04000494 RID: 1172
			[SerializeField]
			[StringSelector(typeof(MapaDeFemaleBlendShapes), "fieldsEditor")]
			private string m_shape;
		}
	}
}
