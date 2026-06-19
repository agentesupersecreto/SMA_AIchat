using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x0200046C RID: 1132
	public class ConsentCorrupted : AplicableCustomMonobehaviour
	{
		// Token: 0x060018B1 RID: 6321 RVA: 0x000649E3 File Offset: 0x00062BE3
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_DesHielo = this.GetComponentEnRoot(false);
			this.m_usaDeshielo = this.m_DesHielo != null;
		}

		// Token: 0x060018B2 RID: 6322 RVA: 0x00064A0C File Offset: 0x00062C0C
		public IReadOnlyCollection<ConsensualTree.Data> CorruptEstimulo(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag)
		{
			IReadOnlyCollection<ConsensualTree.Data> readOnlyCollection = ConsensualTree.OverridesInvertedSet(tipoDeEstimulo, direccion, parteEstimulada, parteEstimulante, tag);
			foreach (ConsensualTree.Data data in readOnlyCollection)
			{
				this.m_corrupted.Add(data);
				if (this.m_usaDeshielo)
				{
					this.m_DesHielo.SetTo(100f, data.tipoDeEstimulo, data.parteEstimulada, data.direccion, data.parteEstimulante);
				}
			}
			return readOnlyCollection;
		}

		// Token: 0x060018B3 RID: 6323 RVA: 0x00064A98 File Offset: 0x00062C98
		public bool EsCorrupted(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag)
		{
			ConsensualTree.Data data = new ConsensualTree.Data
			{
				tipoDeEstimulo = tipoDeEstimulo,
				direccion = direccion,
				parteEstimulada = parteEstimulada,
				parteEstimulante = parteEstimulante,
				tag = tag
			};
			return this.m_corrupted.Contains(data);
		}

		// Token: 0x060018B4 RID: 6324 RVA: 0x00064AE8 File Offset: 0x00062CE8
		public bool EsCorrupted(InteracionEstimulanteBasica estimulo, ParteQuePuedeEstimular estimulante, string tag)
		{
			for (int i = 0; i < estimulo.partesDelCuerpoHumanoEstimuladas.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = estimulo.partesDelCuerpoHumanoEstimuladas[i];
				if (this.EsCorrupted(estimulo.tipoDeEstimulo, estimulo.tipo, parteDelCuerpoHumano, estimulante, tag))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060018B5 RID: 6325 RVA: 0x00064B34 File Offset: 0x00062D34
		public bool EsCorrupted(ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			if (calculoDeInteracionEstimulante == null)
			{
				return false;
			}
			ICalculoDeEstimuloDeParteEstimulante calculoDeEstimuloDeParteEstimulante = calculo as ICalculoDeEstimuloDeParteEstimulante;
			return calculoDeEstimuloDeParteEstimulante != null && this.EsCorrupted(calculoDeInteracionEstimulante.estimuloBasico, calculoDeEstimuloDeParteEstimulante.estimulanteParte, calculo.tag);
		}

		// Token: 0x060018B6 RID: 6326 RVA: 0x00064B71 File Offset: 0x00062D71
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Test Corrupted"
			};
		}

		// Token: 0x060018B7 RID: 6327 RVA: 0x00064B8A File Offset: 0x00062D8A
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.CorruptEstimulo(this.m_debugCorruptedData.tipoDeEstimulo, this.m_debugCorruptedData.direccion, this.m_debugCorruptedData.parteEstimulada, this.m_debugCorruptedData.parteEstimulante, null);
		}

		// Token: 0x040012D2 RID: 4818
		public bool debugLog;

		// Token: 0x040012D3 RID: 4819
		public ConsensualTree.Data debugTarget;

		// Token: 0x040012D4 RID: 4820
		private DesHielo m_DesHielo;

		// Token: 0x040012D5 RID: 4821
		private bool m_usaDeshielo;

		// Token: 0x040012D6 RID: 4822
		[SerializeField]
		private SerializableHashSetListValues<ConsensualTree.Data> m_corrupted = new SerializableHashSetListValues<ConsensualTree.Data>();

		// Token: 0x040012D7 RID: 4823
		[Header("DEBUG")]
		[SerializeField]
		private ConsentCorrupted.DebugCorrupted m_debugCorruptedData = new ConsentCorrupted.DebugCorrupted();

		// Token: 0x0200046D RID: 1133
		[Serializable]
		public class DebugCorrupted
		{
			// Token: 0x040012D8 RID: 4824
			public TipoDeEstimulo tipoDeEstimulo;

			// Token: 0x040012D9 RID: 4825
			public DireccionDeEstimulo direccion;

			// Token: 0x040012DA RID: 4826
			public ParteDelCuerpoHumano parteEstimulada;

			// Token: 0x040012DB RID: 4827
			public ParteQuePuedeEstimular parteEstimulante;
		}
	}
}
