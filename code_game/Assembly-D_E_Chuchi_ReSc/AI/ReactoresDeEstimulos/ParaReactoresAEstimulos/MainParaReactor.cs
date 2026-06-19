using System;
using System.Collections.Generic;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.ParaReactoresAEstimulos
{
	// Token: 0x020003C8 RID: 968
	public sealed class MainParaReactor : AplicableCustomMonobehaviour, IParaReactor
	{
		// Token: 0x060014E4 RID: 5348 RVA: 0x00059348 File Offset: 0x00057548
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			foreach (ParaReactorPadre paraReactorPadre in base.GetComponentsInChildren<ParaReactorPadre>())
			{
				this.m_paraReactorDeTag.Add(paraReactorPadre.paraReactor, paraReactorPadre);
				this.m_paraReactoresContags.Add(new ValueTuple<string, ParaReactorPadre>(paraReactorPadre.paraReactor, paraReactorPadre));
			}
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x000593A0 File Offset: 0x000575A0
		public void FlagReaccionado(IReadOnlyList<string> Tags, float duracion)
		{
			for (int i = 0; i < Tags.Count; i++)
			{
				this.FlagReaccionado(Tags[i], duracion);
			}
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x000593CC File Offset: 0x000575CC
		public void FlagReaccionado(string Tag, float duracion)
		{
			if (Tag == "None")
			{
				return;
			}
			CoolDown coolDown;
			if (!this.m_flagged.TryGetValue(Tag, out coolDown))
			{
				coolDown = new CoolDown();
				this.m_flagged.Add(Tag, coolDown);
			}
			if (coolDown.left < duracion)
			{
				coolDown.ApplyNext(duracion);
			}
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x00003B39 File Offset: 0x00001D39
		void IParaReactor.BeforeReacciones()
		{
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x0005941C File Offset: 0x0005761C
		public void Reaccionar(IReadOnlyList<ICalculoDeEstimulo> resultadosEnFrame)
		{
			for (int i = 0; i < this.m_paraReactoresContags.Count; i++)
			{
				ValueTuple<string, ParaReactorPadre> valueTuple = this.m_paraReactoresContags[i];
				string item = valueTuple.Item1;
				CoolDown coolDown;
				if (!(item != "None") || !this.m_flagged.TryGetValue(item, out coolDown) || !coolDown.isOn)
				{
					valueTuple.Item2.Reaccionar(resultadosEnFrame);
				}
			}
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x00059485 File Offset: 0x00057685
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Mostrar Flagged"
			};
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x000594A0 File Offset: 0x000576A0
		protected override void OnAplicar2()
		{
			this.m_flaggedDebug.Clear();
			foreach (KeyValuePair<string, CoolDown> keyValuePair in this.m_flagged)
			{
				this.m_flaggedDebug.Add(new MainParaReactor.DeubgFlagged
				{
					tag = keyValuePair.Key,
					cooldown = keyValuePair.Value
				});
			}
		}

		// Token: 0x040010F7 RID: 4343
		private Dictionary<string, ParaReactorPadre> m_paraReactorDeTag = new Dictionary<string, ParaReactorPadre>();

		// Token: 0x040010F8 RID: 4344
		private List<ValueTuple<string, ParaReactorPadre>> m_paraReactoresContags = new List<ValueTuple<string, ParaReactorPadre>>();

		// Token: 0x040010F9 RID: 4345
		private Dictionary<string, CoolDown> m_flagged = new Dictionary<string, CoolDown>();

		// Token: 0x040010FA RID: 4346
		[SerializeField]
		[NonReorderable]
		private List<MainParaReactor.DeubgFlagged> m_flaggedDebug = new List<MainParaReactor.DeubgFlagged>();

		// Token: 0x020003C9 RID: 969
		[Serializable]
		private struct DeubgFlagged
		{
			// Token: 0x040010FB RID: 4347
			public string tag;

			// Token: 0x040010FC RID: 4348
			public CoolDown cooldown;
		}
	}
}
