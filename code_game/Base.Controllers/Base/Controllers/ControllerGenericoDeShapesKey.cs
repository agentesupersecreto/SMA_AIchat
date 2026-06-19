using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts;
using UnityEngine;

namespace Assets.Base.Controllers
{
	// Token: 0x02000003 RID: 3
	public abstract class ControllerGenericoDeShapesKey : AplicableBehaviour
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020BF File Offset: 0x000002BF
		public ModificableDeFloat modificableGeneral
		{
			get
			{
				return this.m_modificableGeneral;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000004 RID: 4 RVA: 0x000020C8 File Offset: 0x000002C8
		// (remove) Token: 0x06000005 RID: 5 RVA: 0x00002100 File Offset: 0x00000300
		public event Action updated;

		// Token: 0x06000006 RID: 6 RVA: 0x00002138 File Offset: 0x00000338
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.m_ShapeKeys.Clear();
			this.InstantiateShapeKeys(this.m_ShapeKeys);
			for (int i = 0; i < this.m_ShapeKeys.Count; i++)
			{
				IShapeKey shapeKey = this.m_ShapeKeys[i];
				this.m_nombreToIndex.Add(shapeKey.nombre, i);
				ControllerGenericoDeShapesKey.ShapeKeyValores shapeKeyValores = new ControllerGenericoDeShapesKey.ShapeKeyValores();
				this.OnShapeKeyValoresCreado(shapeKeyValores, shapeKey);
				this.m_ShapeKeysMods.Add(shapeKeyValores);
				this.m_modificadoresDeTodos.Add(shapeKeyValores.ObtenerModificadorNotNull(this));
			}
			this.ProducirGrupos();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021EE File Offset: 0x000003EE
		protected virtual void OnShapeKeyValoresCreado(ControllerGenericoDeShapesKey.ShapeKeyValores valores, IShapeKey shapeKey)
		{
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021F0 File Offset: 0x000003F0
		public ControllerGenericoDeShapesKey.ShapeKeyValores GetModificablesDeShape(int index)
		{
			if (this.m_ShapeKeysMods.ContieneIndex(index))
			{
				return this.m_ShapeKeysMods[index];
			}
			return null;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002210 File Offset: 0x00000410
		public ControllerGenericoDeShapesKey.ShapeKeyValores GetModificablesDeShape(string shapeName)
		{
			int num;
			if (this.m_nombreToIndex.TryGetValue(shapeName, out num))
			{
				return this.m_ShapeKeysMods[num];
			}
			return null;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000223C File Offset: 0x0000043C
		public ControllerGenericoDeShapesKey.ShapeKeyValores GetModificablesDeShape(string positiveName, string negativeName)
		{
			string text;
			if (!this.m_nombreDeNombrePlarizado.TryGetValue(new ValueTuple<string, string>(positiveName, negativeName), out text))
			{
				text = negativeName + "/" + positiveName;
				this.m_nombreDeNombrePlarizado.Add(new ValueTuple<string, string>(positiveName, negativeName), text);
			}
			int num;
			if (this.m_nombreToIndex.TryGetValue(text, out num))
			{
				return this.m_ShapeKeysMods[num];
			}
			return null;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000229D File Offset: 0x0000049D
		[Obsolete("", true)]
		protected virtual void GetTargetShapeKeys(List<string> resultado)
		{
		}

		// Token: 0x0600000C RID: 12
		protected abstract void InstantiateShapeKeys(List<IShapeKey> resultado);

		// Token: 0x0600000D RID: 13 RVA: 0x0000229F File Offset: 0x0000049F
		protected virtual void ProducirGrupos()
		{
		}

		// Token: 0x0600000E RID: 14
		protected abstract SkinnedMeshRenderer GetRenderer();

		// Token: 0x0600000F RID: 15 RVA: 0x000022A1 File Offset: 0x000004A1
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.onAllIKsUpdated += this.M_updater_iKsUpdated;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000022C0 File Offset: 0x000004C0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_updater != null)
			{
				this.m_updater.onAllIKsUpdated -= this.M_updater_iKsUpdated;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000022E8 File Offset: 0x000004E8
		private void M_updater_iKsUpdated(IIKUpdater obj)
		{
			this.doUpdate();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022F0 File Offset: 0x000004F0
		public void DoUpdate()
		{
			this.doUpdate();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022F8 File Offset: 0x000004F8
		protected virtual bool CanUpdate()
		{
			return true;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000022FC File Offset: 0x000004FC
		protected void doUpdate()
		{
			if (!this.CanUpdate())
			{
				return;
			}
			try
			{
				SkinnedMeshRenderer renderer = this.GetRenderer();
				if (!(renderer == null))
				{
					for (int i = 0; i < this.m_grupos.Count; i++)
					{
						this.m_grupos[i].Update(this);
					}
					float num = this.m_modificableGeneral.ModificarValor(this.modificadorGeneral);
					for (int j = 0; j < this.m_modificadoresDeTodos.Count; j++)
					{
						this.m_modificadoresDeTodos[j].valor.valor = num;
					}
					for (int k = 0; k < this.m_ShapeKeys.Count; k++)
					{
						IShapeKey shapeKey = this.m_ShapeKeys[k];
						ControllerGenericoDeShapesKey.ShapeKeyValores shapeKeyValores = this.m_ShapeKeysMods[k];
						float num2 = shapeKeyValores.valorCalculadoFast;
						ControllerGenericoDeShapesKey.GrupoBase grupoBase;
						if (this.m_grupoDeShape.TryGetValue(shapeKeyValores, out grupoBase))
						{
							num2 = grupoBase.ApplyTo(this.m_nombreToIndex[shapeKey.nombre], num2);
						}
						shapeKey.SetValor(renderer, num2);
					}
				}
			}
			finally
			{
				Action action = this.updated;
				if (action != null)
				{
					action();
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000242C File Offset: 0x0000062C
		public float GetValorActual(int index)
		{
			if (this.m_ShapeKeysMods.ContieneIndex(index))
			{
				return this.m_ShapeKeys[index].GetValor(this.GetRenderer());
			}
			return 0f;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000245C File Offset: 0x0000065C
		public float GetValorActual(string shapeName)
		{
			int num;
			if (this.m_nombreToIndex.TryGetValue(shapeName, out num))
			{
				return this.m_ShapeKeys[num].GetValor(this.GetRenderer());
			}
			return 0f;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002498 File Offset: 0x00000698
		public float GetValorActual(string positiveName, string negativeName)
		{
			string text;
			if (!this.m_nombreDeNombrePlarizado.TryGetValue(new ValueTuple<string, string>(positiveName, negativeName), out text))
			{
				text = negativeName + "/" + positiveName;
				this.m_nombreDeNombrePlarizado.Add(new ValueTuple<string, string>(positiveName, negativeName), text);
			}
			int num;
			if (this.m_nombreToIndex.TryGetValue(text, out num))
			{
				return this.m_ShapeKeys[num].GetValor(this.GetRenderer());
			}
			return 0f;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002508 File Offset: 0x00000708
		protected ControllerGenericoDeShapesKey.GrupoNormalizado AgruparNormalizando(params string[] names)
		{
			ControllerGenericoDeShapesKey.GrupoNormalizado g = new ControllerGenericoDeShapesKey.GrupoNormalizado();
			g.Init(this, names);
			this.m_grupos.Add(g);
			names.ForEach(delegate(string n)
			{
				this.m_grupoDeShape.Add(this.GetModificablesDeShape(n), g);
			});
			return g;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002564 File Offset: 0x00000764
		protected ControllerGenericoDeShapesKey.GrupoNormalizadoExagerado AgruparNormalizandoExagerado(float exageracionPower = 4f, params string[] names)
		{
			ControllerGenericoDeShapesKey.GrupoNormalizadoExagerado g = new ControllerGenericoDeShapesKey.GrupoNormalizadoExagerado();
			g.Init(this, names);
			g.exageracionPower = exageracionPower;
			this.m_grupos.Add(g);
			names.ForEach(delegate(string n)
			{
				this.m_grupoDeShape.Add(this.GetModificablesDeShape(n), g);
			});
			return g;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000025CC File Offset: 0x000007CC
		protected ControllerGenericoDeShapesKey.GrupoNormalizadoLimitadoPorMaximoDeOtros AgruparNormalizando(string[] limites, params string[] names)
		{
			ControllerGenericoDeShapesKey.GrupoNormalizadoLimitadoPorMaximoDeOtros g = new ControllerGenericoDeShapesKey.GrupoNormalizadoLimitadoPorMaximoDeOtros();
			g.Init(this, names, limites);
			this.m_grupos.Add(g);
			names.ForEach(delegate(string n)
			{
				this.m_grupoDeShape.Add(this.GetModificablesDeShape(n), g);
			});
			return g;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002628 File Offset: 0x00000828
		protected ControllerGenericoDeShapesKey.GrupoNormalizadoExageradoLimitadoPorMaximoDeOtros AgruparNormalizandoExagerado(string[] limites, float exageracionPower = 4f, params string[] names)
		{
			ControllerGenericoDeShapesKey.GrupoNormalizadoExageradoLimitadoPorMaximoDeOtros g = new ControllerGenericoDeShapesKey.GrupoNormalizadoExageradoLimitadoPorMaximoDeOtros();
			g.Init(this, names, limites);
			g.exageracionPower = exageracionPower;
			this.m_grupos.Add(g);
			names.ForEach(delegate(string n)
			{
				this.m_grupoDeShape.Add(this.GetModificablesDeShape(n), g);
			});
			return g;
		}

		// Token: 0x04000001 RID: 1
		public float modificadorGeneral = 1f;

		// Token: 0x04000002 RID: 2
		[SerializeField]
		private ModificableDeFloat m_modificableGeneral = new ModificableDeFloat(1f);

		// Token: 0x04000003 RID: 3
		private Dictionary<string, int> m_nombreToIndex = new Dictionary<string, int>();

		// Token: 0x04000004 RID: 4
		private List<IShapeKey> m_ShapeKeys = new List<IShapeKey>();

		// Token: 0x04000005 RID: 5
		[SerializeField]
		private List<ControllerGenericoDeShapesKey.ShapeKeyValores> m_ShapeKeysMods = new List<ControllerGenericoDeShapesKey.ShapeKeyValores>();

		// Token: 0x04000006 RID: 6
		private IIKUpdater m_updater;

		// Token: 0x04000007 RID: 7
		private List<ModificadorDeFloat> m_modificadoresDeTodos = new List<ModificadorDeFloat>();

		// Token: 0x04000008 RID: 8
		[TupleElementNames(new string[] { "positiveName", "negativeName" })]
		private Dictionary<ValueTuple<string, string>, string> m_nombreDeNombrePlarizado = new Dictionary<ValueTuple<string, string>, string>();

		// Token: 0x04000009 RID: 9
		[SerializeReference]
		private List<ControllerGenericoDeShapesKey.GrupoBase> m_grupos = new List<ControllerGenericoDeShapesKey.GrupoBase>();

		// Token: 0x0400000A RID: 10
		private Dictionary<ControllerGenericoDeShapesKey.ShapeKeyValores, ControllerGenericoDeShapesKey.GrupoBase> m_grupoDeShape = new Dictionary<ControllerGenericoDeShapesKey.ShapeKeyValores, ControllerGenericoDeShapesKey.GrupoBase>();

		// Token: 0x02000015 RID: 21
		[Serializable]
		public abstract class GrupoBase
		{
			// Token: 0x060000BE RID: 190
			public abstract void Update(ControllerGenericoDeShapesKey controller);

			// Token: 0x060000BF RID: 191
			public abstract float ApplyTo(int shapeIndex, float value);

			// Token: 0x060000C0 RID: 192 RVA: 0x00003AA4 File Offset: 0x00001CA4
			internal void Init(ControllerGenericoDeShapesKey controller, string[] names)
			{
				this.grupo = names.Select(delegate(string g)
				{
					int num;
					controller.m_nombreToIndex.TryGetValue(g, out num);
					return num;
				}).ToArray<int>();
				this.shapeIndexToLocalIndex = this.grupo.Select((int value, int index) => new ValueTuple<int, int>(value, index)).ToDictionary(([TupleElementNames(new string[] { "value", "index" })] ValueTuple<int, int> par) => par.Item1, ([TupleElementNames(new string[] { "value", "index" })] ValueTuple<int, int> par) => par.Item2);
			}

			// Token: 0x0400006A RID: 106
			public int[] grupo;

			// Token: 0x0400006B RID: 107
			public Dictionary<int, int> shapeIndexToLocalIndex;
		}

		// Token: 0x02000016 RID: 22
		[Serializable]
		public class GrupoNormalizadoExagerado : ControllerGenericoDeShapesKey.GrupoBase
		{
			// Token: 0x17000021 RID: 33
			// (get) Token: 0x060000C2 RID: 194 RVA: 0x00003B56 File Offset: 0x00001D56
			public float max
			{
				get
				{
					return this.m_max;
				}
			}

			// Token: 0x060000C3 RID: 195 RVA: 0x00003B60 File Offset: 0x00001D60
			public override void Update(ControllerGenericoDeShapesKey controller)
			{
				if (this.m_actualesW == null || this.m_actualesW.Length != this.grupo.Length)
				{
					this.m_actualesW = new float[this.grupo.Length];
				}
				for (int i = 0; i < this.grupo.Length; i++)
				{
					float num = controller.GetModificablesDeShape(this.grupo[i]).valorCalculadoFast;
					int num2 = Mathf.RoundToInt(num);
					if (!this.repetidos.Add(num2))
					{
						num *= 0.66666f;
					}
					float num3 = num / 100f;
					this.m_actualesW[i] = num3;
				}
				this.repetidos.Clear();
				this.m_max = this.m_actualesW.ExagerarWeigths(ref this.m_mods, this.exageracionPower);
			}

			// Token: 0x060000C4 RID: 196 RVA: 0x00003C18 File Offset: 0x00001E18
			public override float ApplyTo(int shapeIndex, float value)
			{
				float num = this.m_mods[this.shapeIndexToLocalIndex[shapeIndex]];
				return value * num;
			}

			// Token: 0x0400006C RID: 108
			public float exageracionPower = 4f;

			// Token: 0x0400006D RID: 109
			[SerializeField]
			private float m_max;

			// Token: 0x0400006E RID: 110
			private float[] m_actualesW;

			// Token: 0x0400006F RID: 111
			private float[] m_mods;

			// Token: 0x04000070 RID: 112
			private HashSet<int> repetidos = new HashSet<int>();
		}

		// Token: 0x02000017 RID: 23
		[Serializable]
		public class GrupoNormalizado : ControllerGenericoDeShapesKey.GrupoBase
		{
			// Token: 0x17000022 RID: 34
			// (get) Token: 0x060000C6 RID: 198 RVA: 0x00003C5A File Offset: 0x00001E5A
			public float total
			{
				get
				{
					return this.m_total;
				}
			}

			// Token: 0x060000C7 RID: 199 RVA: 0x00003C64 File Offset: 0x00001E64
			public override void Update(ControllerGenericoDeShapesKey controller)
			{
				this.m_total = 0f;
				for (int i = 0; i < this.grupo.Length; i++)
				{
					this.m_total += controller.GetModificablesDeShape(this.grupo[i]).valorCalculadoFast;
				}
			}

			// Token: 0x060000C8 RID: 200 RVA: 0x00003CAF File Offset: 0x00001EAF
			public override float ApplyTo(int shapeIndex, float value)
			{
				if (this.m_total > 0f)
				{
					value *= value / this.m_total;
				}
				return value;
			}

			// Token: 0x04000071 RID: 113
			[SerializeField]
			private float m_total;
		}

		// Token: 0x02000018 RID: 24
		[Serializable]
		public class GrupoNormalizadoLimitadoPorMaximoDeOtros : ControllerGenericoDeShapesKey.GrupoNormalizado
		{
			// Token: 0x17000023 RID: 35
			// (get) Token: 0x060000CA RID: 202 RVA: 0x00003CD3 File Offset: 0x00001ED3
			public float disminucionPorMax
			{
				get
				{
					return this.m_disminucionPorMax;
				}
			}

			// Token: 0x060000CB RID: 203 RVA: 0x00003CDC File Offset: 0x00001EDC
			internal void Init(ControllerGenericoDeShapesKey controller, string[] names, string[] limitesNames)
			{
				base.Init(controller, names);
				this.limites = limitesNames.Select(delegate(string g)
				{
					int num;
					controller.m_nombreToIndex.TryGetValue(g, out num);
					return num;
				}).ToArray<int>();
				this.limiteIndexToLocalIndex = this.limites.Select((int value, int index) => new ValueTuple<int, int>(value, index)).ToDictionary(([TupleElementNames(new string[] { "value", "index" })] ValueTuple<int, int> par) => par.Item1, ([TupleElementNames(new string[] { "value", "index" })] ValueTuple<int, int> par) => par.Item2);
			}

			// Token: 0x060000CC RID: 204 RVA: 0x00003D94 File Offset: 0x00001F94
			public override void Update(ControllerGenericoDeShapesKey controller)
			{
				base.Update(controller);
				this.m_disminucionPorMax = 0f;
				for (int i = 0; i < this.limites.Length; i++)
				{
					this.m_disminucionPorMax = Mathf.Max(this.m_disminucionPorMax, controller.GetModificablesDeShape(this.limites[i]).valorCalculadoFast);
				}
			}

			// Token: 0x060000CD RID: 205 RVA: 0x00003DEC File Offset: 0x00001FEC
			public override float ApplyTo(int shapeIndex, float value)
			{
				float num = base.ApplyTo(shapeIndex, value);
				num -= this.m_disminucionPorMax;
				if (num < 0f)
				{
					return 0f;
				}
				return num;
			}

			// Token: 0x04000072 RID: 114
			public int[] limites;

			// Token: 0x04000073 RID: 115
			public Dictionary<int, int> limiteIndexToLocalIndex;

			// Token: 0x04000074 RID: 116
			[SerializeField]
			private float m_disminucionPorMax;
		}

		// Token: 0x02000019 RID: 25
		[Serializable]
		public class GrupoNormalizadoExageradoLimitadoPorMaximoDeOtros : ControllerGenericoDeShapesKey.GrupoNormalizadoExagerado
		{
			// Token: 0x17000024 RID: 36
			// (get) Token: 0x060000CF RID: 207 RVA: 0x00003E22 File Offset: 0x00002022
			public float disminucionPorMax
			{
				get
				{
					return this.m_disminucionPorMax;
				}
			}

			// Token: 0x060000D0 RID: 208 RVA: 0x00003E2C File Offset: 0x0000202C
			internal void Init(ControllerGenericoDeShapesKey controller, string[] names, string[] limitesNames)
			{
				base.Init(controller, names);
				this.limites = limitesNames.Select(delegate(string g)
				{
					int num;
					controller.m_nombreToIndex.TryGetValue(g, out num);
					return num;
				}).ToArray<int>();
				this.limiteIndexToLocalIndex = this.limites.Select((int value, int index) => new ValueTuple<int, int>(value, index)).ToDictionary(([TupleElementNames(new string[] { "value", "index" })] ValueTuple<int, int> par) => par.Item1, ([TupleElementNames(new string[] { "value", "index" })] ValueTuple<int, int> par) => par.Item2);
			}

			// Token: 0x060000D1 RID: 209 RVA: 0x00003EE4 File Offset: 0x000020E4
			public override void Update(ControllerGenericoDeShapesKey controller)
			{
				base.Update(controller);
				this.m_disminucionPorMax = 0f;
				for (int i = 0; i < this.limites.Length; i++)
				{
					this.m_disminucionPorMax = Mathf.Max(this.m_disminucionPorMax, controller.GetModificablesDeShape(this.limites[i]).valorCalculadoFast);
				}
			}

			// Token: 0x060000D2 RID: 210 RVA: 0x00003F3C File Offset: 0x0000213C
			public override float ApplyTo(int shapeIndex, float value)
			{
				float num = base.ApplyTo(shapeIndex, value);
				num -= this.m_disminucionPorMax;
				if (num < 0f)
				{
					return 0f;
				}
				return num;
			}

			// Token: 0x04000075 RID: 117
			public int[] limites;

			// Token: 0x04000076 RID: 118
			public Dictionary<int, int> limiteIndexToLocalIndex;

			// Token: 0x04000077 RID: 119
			[SerializeField]
			private float m_disminucionPorMax;
		}

		// Token: 0x0200001A RID: 26
		[Serializable]
		public class ShapeKeyValores : ValorFlotanteBaseLibre
		{
		}
	}
}
