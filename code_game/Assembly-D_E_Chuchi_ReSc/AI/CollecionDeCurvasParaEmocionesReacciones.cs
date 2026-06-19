using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000354 RID: 852
	public sealed class CollecionDeCurvasParaEmocionesReacciones : Singleton<CollecionDeCurvasParaEmocionesReacciones>
	{
		// Token: 0x06001266 RID: 4710 RVA: 0x0004FB4C File Offset: 0x0004DD4C
		protected override void InitData(bool esEditorTime)
		{
			foreach (CollecionDeCurvasParaEmocionesReacciones.Grupo grupo in this.curvas)
			{
				if (!this.dictionary.ContainsKey(grupo.reaccion))
				{
					this.dictionary.Add(grupo.reaccion, grupo.curva);
				}
			}
			foreach (CollecionDeCurvasParaEmocionesReacciones.Grupo grupo2 in this.curvasMaxValue)
			{
				if (!this.dictionaryMaxValue.ContainsKey(grupo2.reaccion))
				{
					this.dictionaryMaxValue.Add(grupo2.reaccion, grupo2.curva);
				}
			}
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x0004FBE0 File Offset: 0x0004DDE0
		public AnimationCurve ObtenerCurva(ReaccionHumana reaccion)
		{
			AnimationCurve animationCurve;
			if (this.dictionary.TryGetValue(reaccion, out animationCurve))
			{
				return animationCurve;
			}
			return null;
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x0004FC00 File Offset: 0x0004DE00
		public AnimationCurve ObtenerCurvaMaxValue(ReaccionHumana reaccion)
		{
			AnimationCurve animationCurve;
			if (this.dictionaryMaxValue.TryGetValue(reaccion, out animationCurve))
			{
				return animationCurve;
			}
			return null;
		}

		// Token: 0x04000F79 RID: 3961
		[CoolArrayItem]
		public CollecionDeCurvasParaEmocionesReacciones.Grupo[] curvas;

		// Token: 0x04000F7A RID: 3962
		[CoolArrayItem]
		public CollecionDeCurvasParaEmocionesReacciones.Grupo[] curvasMaxValue = new CollecionDeCurvasParaEmocionesReacciones.Grupo[]
		{
			new CollecionDeCurvasParaEmocionesReacciones.Grupo
			{
				reaccion = ReaccionHumana.placer,
				curva = new AnimationCurve(new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(0.25f, -0.5f, -5f, -5f),
					new Keyframe(0.5f, -1f),
					new Keyframe(0.75f, -0.5f, 5f, 5f),
					new Keyframe(1f, 0f)
				})
			}
		};

		// Token: 0x04000F7B RID: 3963
		public Dictionary<ReaccionHumana, AnimationCurve> dictionary = new Dictionary<ReaccionHumana, AnimationCurve>();

		// Token: 0x04000F7C RID: 3964
		public Dictionary<ReaccionHumana, AnimationCurve> dictionaryMaxValue = new Dictionary<ReaccionHumana, AnimationCurve>();

		// Token: 0x02000355 RID: 853
		[Serializable]
		public class Grupo
		{
			// Token: 0x1700048D RID: 1165
			// (get) Token: 0x0600126A RID: 4714 RVA: 0x0004FCFA File Offset: 0x0004DEFA
			public string name
			{
				get
				{
					return this.reaccion.ToString();
				}
			}

			// Token: 0x04000F7D RID: 3965
			public ReaccionHumana reaccion;

			// Token: 0x04000F7E RID: 3966
			public AnimationCurve curva;
		}
	}
}
