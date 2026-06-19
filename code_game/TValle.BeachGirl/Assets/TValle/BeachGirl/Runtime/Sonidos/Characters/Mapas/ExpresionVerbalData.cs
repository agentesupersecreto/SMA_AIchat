using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Mapas
{
	// Token: 0x02000063 RID: 99
	[CreateAssetMenu(fileName = "ExpresionVerbalData", menuName = "Mapas/Sonidos/ExpresionVerbalData")]
	public class ExpresionVerbalData : AplicableScriptable
	{
		// Token: 0x060001C1 RID: 449 RVA: 0x00003F67 File Offset: 0x00002167
		public float Length(float PitchMod)
		{
			return this.clip.length / (PitchMod * this.pitchMod);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00003F7D File Offset: 0x0000217D
		private void Reset()
		{
			this.expresionesDeLaBoca.Add(new ExpresionVerbalData.ExprecionDeBocaEnTiempo
			{
				tipoDeRespiracion = ExpresionVerbalData.TipoDeRespiracion.exhalacion,
				modoDeRespiracion = ExpresionVerbalData.ModoDeRespiracion.bucal,
				gestoPrimario = TiposDeGestosDeBoca.exclamar_A
			});
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00003FA5 File Offset: 0x000021A5
		public void Init()
		{
			if (this.m_init)
			{
				return;
			}
			this.OrdenarExpresionesSegunTiempo();
			this.m_init = true;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00003FC0 File Offset: 0x000021C0
		private void OrdenarExpresionesSegunTiempo()
		{
			if (this.expresionesDeLaBoca.Count == 0)
			{
				throw new InvalidOperationException();
			}
			if (this.clip == null)
			{
				throw new ArgumentNullException("clip", "clip null reference.");
			}
			for (int i = 0; i < this.expresionesDeLaBoca.Count; i++)
			{
				ExpresionVerbalData.ExprecionDeBocaEnTiempo exprecionDeBocaEnTiempo = this.expresionesDeLaBoca[i];
				if (i == 0 && exprecionDeBocaEnTiempo.startTime != 0f)
				{
					Debug.LogError("Expresion primera, debe tener startTime en zero siempre", this);
				}
				if (exprecionDeBocaEnTiempo.startTime >= this.clip.length)
				{
					Debug.LogError("Expresion en index: " + i.ToString() + " tiene el start time mal definido", this);
				}
			}
			this.expresionesDeLaBoca.Sort((ExpresionVerbalData.ExprecionDeBocaEnTiempo a, ExpresionVerbalData.ExprecionDeBocaEnTiempo b) => a.startTime.CompareTo(b.startTime));
			for (int j = 0; j < this.expresionesDeLaBoca.Count; j++)
			{
				ExpresionVerbalData.ExprecionDeBocaEnTiempo exprecionDeBocaEnTiempo2 = this.expresionesDeLaBoca[j];
				int num = j + 1;
				if (this.expresionesDeLaBoca.ContieneIndex(num))
				{
					ExpresionVerbalData.ExprecionDeBocaEnTiempo exprecionDeBocaEnTiempo3 = this.expresionesDeLaBoca[num];
					exprecionDeBocaEnTiempo2.duration = exprecionDeBocaEnTiempo3.startTime - exprecionDeBocaEnTiempo2.startTime;
				}
				else
				{
					exprecionDeBocaEnTiempo2.duration = this.clip.length - exprecionDeBocaEnTiempo2.startTime;
				}
				if (exprecionDeBocaEnTiempo2.duration <= 0f)
				{
					Debug.LogError("Duracion de gesto es menor o igual a zero", this);
				}
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00004124 File Offset: 0x00002324
		public ExpresionVerbalData.ExprecionDeBocaEnTiempo ObtenerExpresionEnTiempo(float time)
		{
			this.Init();
			if (this.expresionesDeLaBoca.Count == 0)
			{
				throw new InvalidOperationException();
			}
			if (this.expresionesDeLaBoca.Count == 1)
			{
				return this.expresionesDeLaBoca[0];
			}
			if (time <= 0f)
			{
				return this.expresionesDeLaBoca.First<ExpresionVerbalData.ExprecionDeBocaEnTiempo>();
			}
			for (int i = this.expresionesDeLaBoca.Count - 1; i >= 0; i--)
			{
				ExpresionVerbalData.ExprecionDeBocaEnTiempo exprecionDeBocaEnTiempo = this.expresionesDeLaBoca[i];
				if (time >= exprecionDeBocaEnTiempo.startTime)
				{
					return exprecionDeBocaEnTiempo;
				}
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000041AE File Offset: 0x000023AE
		protected override void OnAplicar1()
		{
			this.OrdenarExpresionesSegunTiempo();
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000041B6 File Offset: 0x000023B6
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Ordenar expresiones segun tiempo",
				playTimeVisible = true,
				editorTimeVisible = true
			};
		}

		// Token: 0x04000120 RID: 288
		public AudioClip clip;

		// Token: 0x04000121 RID: 289
		[Tooltip("Opcional")]
		public string expresionEnTexto;

		// Token: 0x04000122 RID: 290
		[Space]
		public float volMod = 1f;

		// Token: 0x04000123 RID: 291
		public float pitchMod = 1f;

		// Token: 0x04000124 RID: 292
		[Space]
		public List<ExpresionVerbalData.ExprecionDeBocaEnTiempo> expresionesDeLaBoca = new List<ExpresionVerbalData.ExprecionDeBocaEnTiempo>();

		// Token: 0x04000125 RID: 293
		[NonSerialized]
		private bool m_init;

		// Token: 0x02000146 RID: 326
		[Serializable]
		public class ExprecionDeBocaEnTiempo
		{
			// Token: 0x170004CC RID: 1228
			// (get) Token: 0x06000DBA RID: 3514 RVA: 0x0002F597 File Offset: 0x0002D797
			public float startTime
			{
				get
				{
					return this.m_startTime;
				}
			}

			// Token: 0x040007C4 RID: 1988
			[SerializeField]
			private float m_startTime;

			// Token: 0x040007C5 RID: 1989
			[ReadOnlyUI]
			public float duration;

			// Token: 0x040007C6 RID: 1990
			public ExpresionVerbalData.TipoDeRespiracion tipoDeRespiracion;

			// Token: 0x040007C7 RID: 1991
			public ExpresionVerbalData.ModoDeRespiracion modoDeRespiracion;

			// Token: 0x040007C8 RID: 1992
			public TiposDeGestosDeBoca gestoPrimario;

			// Token: 0x040007C9 RID: 1993
			public TiposDeGestosDeBoca gestoSegundario;
		}

		// Token: 0x02000147 RID: 327
		public enum TipoDeRespiracion
		{
			// Token: 0x040007CB RID: 1995
			exhalacion,
			// Token: 0x040007CC RID: 1996
			inhalacion
		}

		// Token: 0x02000148 RID: 328
		public enum ModoDeRespiracion
		{
			// Token: 0x040007CE RID: 1998
			bucal,
			// Token: 0x040007CF RID: 1999
			nasal
		}
	}
}
